using Microsoft.AspNetCore.Mvc;

namespace ControleDeFuncionarios.Controllers
{
    public class Cadastro : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Criar()
        {
            return View();
        }
    }
}
