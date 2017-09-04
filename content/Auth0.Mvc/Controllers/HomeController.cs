using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Auth0.Mvc.Models;
#if (SaveTokens)
using Microsoft.AspNetCore.Authentication;
#endif

namespace Auth0.Mvc.Controllers
{
    public class HomeController : Controller
    {
#if (SaveTokens)
        public async Task<IActionResult> Index()
        {
            // If the user is authenticated, your can retrieve saved tokens using GetTokenAsync()
            if (User.Identity.IsAuthenticated)
            {
                string accessToken = await HttpContext.GetTokenAsync("access_token");
                string idToken = await HttpContext.GetTokenAsync("id_token");

                // Now you can use them. For more info on when and how to use the 
                // access_token and id_token, see https://auth0.com/docs/tokens
            }
        }
#else        
        public IActionResult Index()
        {
            return View();
        }
#endif

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
