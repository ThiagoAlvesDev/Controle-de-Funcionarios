using ControleDeFuncionarios.Data;
using Microsoft.AspNetCore.Mvc;

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

        public IActionResult Editar()
        {
            return View();
        }

        public IActionResult Visualizar()
        {
            return View();
        }
    }
}
