using ControleDeFuncionarios.Data;
using ControleDeFuncionarios.Models;
using ControleDeFuncionarios.Repositorio;
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
        public IActionResult Criar(ColaboradorModel colaborador, EmpresaModel empresa, CargoModel cargo)
        {

            var colaboradorExistente = _bancoContext.Colaborador.FirstOrDefault(e => e.Cpf == colaborador.Cpf);

            if (colaboradorExistente != null)
            {
                // Verificar se a matrícula é igual
                if (colaboradorExistente.Matricula != colaborador.Matricula)
                {
                    // Criar um novo registro com a mesma CPF
                    colaborador.Id = 0; // Definir o Id como 0 para criar um novo registro
                    _bancoContext.Colaborador.Add(colaborador);
                    _bancoContext.SaveChanges();
                }
                else
                {
                    // A matrícula é igual, exibir mensagem de erro
                    ModelState.AddModelError("Matricula", "A matrícula já existe. Escolha uma matrícula diferente.");
                    return View(colaborador);
                }
            }
            else
            {
                // CPF não existe, adicionar o colaborador ao contexto do banco de dados
                _bancoContext.Colaborador.Add(colaborador);
                _bancoContext.SaveChanges();
            }

            //Verificar se Cnpj existe
            var empresaExistente = _bancoContext.Empresa.FirstOrDefault(e => e.Cnpj == colaborador.Empresa.Cnpj);

            if (empresaExistente != null)
            {
                
                colaborador.Empresa = empresaExistente;
            }
            else
            {
               
                _bancoContext.Empresa.Add(colaborador.Empresa);
            }

            // Verificar se CBO existe
            var cargoExistente = _bancoContext.Cargo.FirstOrDefault(e => e.Cbo == colaborador.Cargo.Cbo);
            
            if(cargoExistente != null)
            {
                colaborador.Cargo = cargoExistente;
            }
            else
            {

            _bancoContext.Cargo.Add(cargo);
            }
          
            _bancoContext.SaveChanges();

            return RedirectToAction("Criar");
        }
    }
}
