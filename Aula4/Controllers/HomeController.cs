using System.Diagnostics;
using Aula4.Models;
using Microsoft.AspNetCore.Mvc;

namespace Aula4.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Exemplo()
        {
            return View();
        }

        public IActionResult ExibirPessoa()
        {
            var pessoa = new Pessoa { Nome = "César", Idade = 43 };

            return View(pessoa);
        }

        public IActionResult ExibirPessoa2()
        {
            var pessoa = new Pessoa { Nome = "Neusa", Idade = 25 };

            return View(pessoa);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
