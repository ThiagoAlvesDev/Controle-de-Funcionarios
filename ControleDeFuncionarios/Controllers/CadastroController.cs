using ControleDeFuncionarios.APIservice;
using ControleDeFuncionarios.Data;
using ControleDeFuncionarios.Models;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeFuncionarios.Controllers
{
    public class CadastroController : Controller
    {
        private readonly BancoContext _bancoContext;

        public CadastroController(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;

        }
        public IActionResult Index()
        {
            return View(_bancoContext.Colaborador.ToList());
        }

        [HttpGet]
        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CriarAsync(ColaboradorModel colaborador)
        {
            var colaboradorExistente = _bancoContext.Colaborador.Any(e =>
                e.Matricula == colaborador.Matricula);

            if (colaboradorExistente)
            {
                ModelState.AddModelError("Matricula", "A matrícula já existe. Escolha uma matrícula diferente.");
                return View(colaborador);
            }


            // Verificar a situação do CNPJ
            var cnpjService = new ValidacaoCNPJ();
            try
            {

                string situacaoCnpj = await cnpjService.ObterSituacaoCnpj(colaborador.Empresa.Cnpj);

                if (situacaoCnpj != "ATIVA")
                {
                    ModelState.AddModelError("Empresa.Cnpj", "A empresa não está ativa. Insira um CNPJ válido.");
                    return View(colaborador);
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError("Empresa.Cnpj", "Erro ao verificar a situação do CNPJ. Tente novamente mais tarde.");
                return View(colaborador);
            }

            // Verifica se os dados da empresa já existe se sim reaproveita se não adiciona
            var empresaExistente = _bancoContext.Empresa.FirstOrDefault(e =>
                e.Cnpj == colaborador.Empresa.Cnpj &&
                e.RazaoSocial == colaborador.Empresa.RazaoSocial);

            if (empresaExistente != null)
            {
                colaborador.Empresa = empresaExistente;
            }
            else
            {
                _bancoContext.Empresa.Add(colaborador.Empresa);
            }

            // Verifica se existe um Cargo.Cbo se sim reaproveita se não adiciona
            var cargoExistente = _bancoContext.Cargo.FirstOrDefault(e =>
                e.Cbo == colaborador.Cargo.Cbo);

            if (cargoExistente != null)
            {
                colaborador.Cargo = cargoExistente;
            }
            else
            {
                // Verifica se há outros registros no banco de dados que possuem o mesmo prefixo Cbo
                var cargosComMesmoPrefixo = _bancoContext.Cargo.Where(e =>
                    e.Cbo.StartsWith(colaborador.Cargo.Cbo.Substring(0, 2))).ToList();

                // Percorre os cargos existentes e verificar se há uma correspondência exata
                foreach (var cargo in cargosComMesmoPrefixo)
                {
                    if (cargo.Cbo == colaborador.Cargo.Cbo)
                    {
                        colaborador.Cargo = cargo;
                        break;
                    }
                }

                if (colaborador.Cargo.Id == 0)
                {
                    _bancoContext.Cargo.Add(colaborador.Cargo);
                }
            }
            // Permite Data de Demissão nula;
            if (colaborador.DataDemissao == default(DateTime?))
            {
                colaborador.DataDemissao = null;
            }           

            _bancoContext.Colaborador.Add(colaborador);
            _bancoContext.SaveChanges();

            return RedirectToAction("Criar");
        }
    }
}

