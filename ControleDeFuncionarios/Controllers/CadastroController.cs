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

            var colaboradorExistente = _bancoContext.Colaborador.FirstOrDefault(e =>
                e.Cpf == colaborador.Cpf &&
                e.Matricula == colaborador.Matricula);

            if (colaboradorExistente != null)
            {
                ModelState.AddModelError("Matricula", "A matrícula já existe. Escolha uma matrícula diferente.");
                return View(colaborador);
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

            var cargoExistente = _bancoContext.Cargo.FirstOrDefault(e =>
                e.Cbo == colaborador.Cargo.Cbo &&
                e.Funcao == colaborador.Cargo.Funcao);

            if (cargoExistente != null)
            {
                colaborador.Cargo = cargoExistente;
            }
            else
            {
                _bancoContext.Cargo.Add(colaborador.Cargo);
            }

            _bancoContext.Colaborador.Add(colaborador);
            _bancoContext.SaveChanges();

            return RedirectToAction("Criar");
        }
    }
}

