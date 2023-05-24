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
            return View(_bancoContext.Colaborador);
        }

        [HttpGet]
        public IActionResult Editar(int colaboradorId)
        {
            ColaboradorModel colaborador =  _bancoContext.Colaborador
            .Include(c => c.Empresa)
            .Include(c => c.Cargo)
            .FirstOrDefault(c => c.Id == colaboradorId);
            //ColaboradorModel colaborador = await _bancoContext.Colaborador.FindAsync(colaboradorId);

            return View(colaborador);
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
