using Microsoft.AspNetCore.Mvc;

namespace ControleDeFuncionarios.Controllers
{
    public class Colaborador : Controller
    {
        public IActionResult Index()
        {
            return View();
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
