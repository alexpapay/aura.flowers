﻿using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using aura.flowers.Models;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Http;
using System;
using aura.flowers.Utils;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;

namespace aura.flowers.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationSettings _applicationSettings;

        public HomeController(IOptions<ApplicationSettings> applicationSettings)
        {
            _applicationSettings = applicationSettings.Value;
        }

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
        /// Set selected language.
        /// </summary>
        /// <param name="culture">Culture name.</param>
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
        /// Send message from customer in contact us modal window.
        /// </summary>
        /// <param name="model">Contact us modal window view model.</param>
        [HttpPost]
        public IActionResult SendMessage(ContactUsViewModel model)
        {
            MimeMessage message = new MimeMessage();

            message.From.Add(new MailboxAddress("Contact Us form", "website@aura.flowers"));
            message.To.Add(new MailboxAddress("Aura.Flowers manager", "info@aura.flowers"));
            message.Subject = "Aura.Flowers order from site on" +
                              (model.SelectedProductId != 0 ? $"for product type {(ProductTypes)model.SelectedProductId}" :
                                  string.Empty);

            BodyBuilder bodyBuilder = new BodyBuilder
            {
                HtmlBody = "<h1>Good day, manager!</h1>",
                TextBody = $"{model.Name} is interested of your web site." +
                           (model.SelectedProductId != 0 ? $" Selected product type {(ProductTypes)model.SelectedProductId}." :
                               string.Empty) +
                           $" User e-mail: {model.Email}. And message was: {model.Message}"
            };
            message.Body = bodyBuilder.ToMessageBody();

            SmtpClient client = new SmtpClient();

            client.Connect(
                _applicationSettings.MailConfiguration.SmtpServer,
                _applicationSettings.MailConfiguration.Port,
                true);

            client.Authenticate(
                _applicationSettings.MailConfiguration.Login,
                _applicationSettings.MailConfiguration.Password);

            client.Send(message);
            client.Disconnect(true);
            client.Dispose();

            return View("Index");
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