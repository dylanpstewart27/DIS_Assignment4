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
    public class TexasController : Controller
    {
        HttpClient httpClient;

        static string BASE_URL = "https://api.usa.gov/crime/fbi/sapi/";
        static string API_KEY = "lseCYNwUaETkleRct4GGR4iKNbwzpJQ5rTUNPmkK"; //Add your API key here inside ""

        public IActionResult TexasStats()
        {
            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Add("X-Api-Key", API_KEY);
            httpClient.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            string CRIME_API_PATH = BASE_URL + "api/data/arrest/states/offense/TX/all/2016/2019?API_KEY=iiHnOKfno2Mgkt5AynpvPpUQTEyxE77jo1RU8PIv";
            string CrimeData = "";

            TexasRootobject results = null;

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

                    results = JsonConvert.DeserializeObject<TexasRootobject>(CrimeData);
                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }

            return View(results);
        }
    }
}

