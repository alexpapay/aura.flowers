using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using aura.flowers.Models;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Http;
using System;

namespace aura.flowers.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// Main index page.
        /// </summary>
        /// <returns>Main index page view.</returns>
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Privacy and cookies page/subpage.
        /// </summary>
        /// <returns>Privacy and cookies page/subpage view.</returns>
        public IActionResult Privacy()
        {
            return View();
        }

        /// <summary>
        /// Set selected language .
        /// </summary>
        /// <param name="culture">Cilture name.</param>
        /// <param name="returnUrl">Return url string.</param>
        /// <returns>Localized view for selectd language.</returns>
        [HttpPost]
        public IActionResult SetLanguage(string culture, string returnUrl)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
            );

            return LocalRedirect(returnUrl);
        }

        /// <summary>
        /// Error page.
        /// </summary>
        /// <returns></returns>
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}