using DIS_Assignment4.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;
using DIS_Assignment4.DataAccess;


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

        //Need to put a method in here to get the data to show each different Race key
        public IActionResult Detail()
        {
            return View();
        }

        public IActionResult AboutUs()
        {
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

        
        
        
        //David's build of chart structure


        public ViewResult Chart()
        {
            string[] ChartLabels = new string[] { "year1", "year2", "year3", "year4", "year5" }; // (X-axis= time) this shouldnt be hard coded, but be a collection of objects
            string[] ChartColors = new string[] { "#3e95cd", "#8e5ea2", "#3cba9f", "#e8c3b9", "#c45850" }; 
            int[] ChartData = new int[] { 2478, 5267, 734, 784, 433 }; // (Y-axis= # of crimes) this shouldnt be hard coded, but be a collection of objects



            ChartModel Model = new ChartModel  //this is how we put all data from above (Public ViewResult Chart) together as one object to be rendered
            {
                ChartType = "bar",
                Labels = String.Join(",", ChartLabels.Select(d => "'" + d + "'")),
                Colors = String.Join(",", ChartColors.Select(d => "\"" + d + "\"")),
                Data = String.Join(",", ChartData.Select(d => d)),
                Title = "Crime arrests per year"  //couldve come from database, or argument of method
            };

            return View(Model);

        }





        public ViewResult DemoAjax()
        {
            return View();
        }

        public JsonResult AjaxResult()
        {
            Task.WaitAll(Task.Delay(1000));

            return Json("Test");
        }
        
        
        
        

    }
}



