using ControleDeFuncionarios.Data;
using ControleDeFuncionarios.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ControleDeFuncionarios.Controllers
{
    public class ColaboradorController : Controller
    {
        private readonly BancoContext _bancoContext;
        public ColaboradorController(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }
        public IActionResult Index()
        {
            if (_bancoContext.Colaborador == null)
            {
                ModelState.AddModelError("ZeroDados:", "Não possui cadastros em nosso banco");

            }

            return View(_bancoContext.Colaborador);
        }

        [HttpGet]
        public IActionResult Editar(int colaboradorId)
        {
            ColaboradorModel colaborador = _bancoContext.Colaborador
            .Include(c => c.Empresa)
            .Include(c => c.Cargo)
            .FirstOrDefault(c => c.Id == colaboradorId);
            //ColaboradorModel colaborador = await _bancoContext.Colaborador.FindAsync(colaboradorId);

            return View(colaborador);
        }

        [HttpPost]
        public IActionResult Editar(ColaboradorModel colaborador)
        {
            if (colaborador.DataDemissao.HasValue && colaborador.DataDemissao.Value < colaborador.DataAdmissao)
            {
                ModelState.AddModelError("DataDemissao", "A Data de Demissão deve ser maior que a Data de Admissão.");

                return View("Editar", colaborador);
            }
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


            _bancoContext.Colaborador.Update(colaborador);
            _bancoContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Visualizar()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Detalhes(int colaboradorId)
        {

            var colaborador = _bancoContext.Colaborador
             .Include(c => c.Empresa)
             .Include(c => c.Cargo)
             .FirstOrDefault(c => c.Id == colaboradorId);

            if (colaborador == null)
            {
                return NotFound();
            }

            var listaItens = new List<ColaboradorModel> { colaborador };

            return View(listaItens);
        }
    }

}
