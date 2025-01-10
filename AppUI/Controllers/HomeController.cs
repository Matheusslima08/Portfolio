using AutoMapper;
using Domain;
using Domain.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System.Diagnostics;

namespace AppUI.Controllers
{
    public class HomeController : CustomController<HomeController>
    {
        public HomeController(ILogger<HomeController> logger,
                              IMemoryCache cache,
                              IMapper mapper,
                              ApplicationUtils utils)
            : base(logger, cache, mapper, utils)
        {
        }

        // M�todo para obter o tema atual (voc� deve implementar GetCurrentTheme)
        private string GetCurrentTheme()
        {
            // Aqui voc� deve implementar a l�gica para determinar o tema atual.
            // Exemplo: recuperar de um cookie, banco de dados ou configura��o padr�o.
            if (Request.Cookies.TryGetValue("UserTheme", out var theme))
            {
                return theme;
            }

            // Retorna um tema padr�o, caso n�o haja um tema selecionado.
            return "default";
        }

        public IActionResult Index()
        {
            var theme = GetCurrentTheme(); // Obtem o tema atual
            ViewData["Theme"] = theme;    // Passa o tema para a view

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
