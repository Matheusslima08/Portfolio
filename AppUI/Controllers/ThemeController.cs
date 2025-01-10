using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace AppUI.Controllers
{
    public class ThemeController : Controller
    {
        private readonly IConfiguration _configuration;

        public ThemeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost]
        public IActionResult ChangeTheme(string selectedTheme)
        {
            var availableThemes = _configuration.GetSection("Settings:AvailableSkins").Get<string[]>();

            if (availableThemes.Contains(selectedTheme))
            {
                // Salvar tema em um cookie
                Response.Cookies.Append("UserTheme", selectedTheme, new CookieOptions
                {
                    Expires = DateTimeOffset.Now.AddDays(30)
                });
            }

            return RedirectToAction("Index", "Home");
        }

        private string GetCurrentTheme()
        {
            // Tenta obter o tema a partir do cookie
            if (Request.Cookies.TryGetValue("UserTheme", out var theme) && !string.IsNullOrEmpty(theme))
            {
                return theme;
            }

            // Retorna um tema padrão caso o cookie não exista ou esteja vazio
            return "default";
        }
    }
}
