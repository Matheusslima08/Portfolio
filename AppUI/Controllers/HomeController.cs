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

        // Método para obter o tema atual (você deve implementar GetCurrentTheme)
        private string GetCurrentTheme()
        {
            // Aqui você deve implementar a lógica para determinar o tema atual.
            // Exemplo: recuperar de um cookie, banco de dados ou configuração padrão.
            if (Request.Cookies.TryGetValue("UserTheme", out var theme))
            {
                return theme;
            }

            // Retorna um tema padrão, caso não haja um tema selecionado.
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
