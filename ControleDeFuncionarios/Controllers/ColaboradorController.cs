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

        [HttpPost]
        public IActionResult Editar(ColaboradorModel colaborador)
		{
            if (colaborador.DataDemissao.HasValue && colaborador.DataDemissao.Value < colaborador.DataAdmissao)
            {
                ModelState.AddModelError("DataDemissao", "A Data de Demissão deve ser maior que a Data de Admissão.");
                
                return View("Editar", colaborador);
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
