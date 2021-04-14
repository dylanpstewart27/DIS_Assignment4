using DIS_Assignment4.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

using System.Net.Http;

namespace DIS_Assignment4.Controllers
{
    public class HomeController : Controller
    {
        HttpClient httpClient;

        static string BASE_URL = "https://api.usa.gov/crime/fbi/sapi/";
        static string API_KEY = "lseCYNwUaETkleRct4GGR4iKNbwzpJQ5rTUNPmkK"; //Add your API key here inside ""

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AboutUs()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult States()
        {
            ViewData["Message"] = "Your contact page.";

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
