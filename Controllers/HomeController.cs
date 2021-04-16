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

        public IActionResult Test()
        {
            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Add("X-Api-Key", API_KEY);
            httpClient.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            string CRIME_API_PATH = BASE_URL + "api/nibrs/aggravated-assault/offender/national/race?API_KEY=iiHnOKfno2Mgkt5AynpvPpUQTEyxE77jo1RU8PIv";

            string CrimeData = "";

            Root results = null;

            httpClient.BaseAddress = new Uri(CRIME_API_PATH);

            try
            {
                HttpResponseMessage response = httpClient.GetAsync(CRIME_API_PATH).GetAwaiter().GetResult();

                if (response.IsSuccessStatusCode)
                {
                    CrimeData = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                }

                if (!CrimeData.Equals(""))
                {

                    results = JsonConvert.DeserializeObject<Root>(CrimeData);
                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }

            return View(results);
        }
    

        public IActionResult States()
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