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
        public ApplicationDbContext dbContext;

        public HomeController(ApplicationDbContext context)
        {
            dbContext = context;
        }

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

        public IActionResult Populate()
        {
            Key Key1 = new Key();
            Key1.key = "Asian";
            Key Key2 = new Key();
            Key2.key = "Native Hawaiian";
            Key Key3 = new Key();
            Key3.key = "American Indian or Alaska Native";
            Key Key4 = new Key();
            Key4.key = "White";
            Key Key5 = new Key();
            Key5.key = "Unknown";
            Key Key6 = new Key();
            Key6.key = "Black or African American";

            Year year1 = new Year();
            year1.data_year = 1991;
            Year year2 = new Year();
            year2.data_year = 1992;
            Year year3 = new Year();
            year3.data_year = 1993;
            Year year4 = new Year();
            year4.data_year = 1994;
            Year year5 = new Year();
            year5.data_year = 1995;
            Year year6 = new Year();
            year6.data_year = 1996;
            Year year7 = new Year();
            year7.data_year = 1997;
            Year year8 = new Year();
            year8.data_year = 1998;
            Year year9 = new Year();
            year9.data_year = 1999;
            Year year10 = new Year();
            year10.data_year = 2000;
            Year year11 = new Year();
            year11.data_year = 2001;
            Year year12 = new Year();
            year12.data_year = 2002;
            Year year13 = new Year();
            year13.data_year = 2003;
            Year year14 = new Year();
            year14.data_year = 2004;
            Year year15 = new Year();
            year15.data_year = 2005;
            Year year16 = new Year();
            year16.data_year = 2006;
            Year year17 = new Year();
            year17.data_year = 2007;
            Year year18 = new Year();
            year18.data_year = 2008;
            Year year19 = new Year();
            year19.data_year = 2009;
            Year year20 = new Year();
            year20.data_year = 2010;
            Year year21 = new Year();
            year21.data_year = 2011;
            Year year22 = new Year();
            year22.data_year = 2012;
            Year year23 = new Year();
            year23.data_year = 2013;
            Year year24 = new Year();
            year24.data_year = 2014;
            Year year25 = new Year();
            year25.data_year = 2015;
            Year year26 = new Year();
            year26.data_year = 2016;
            Year year27 = new Year();
            year27.data_year = 2017;
            Year year28 = new Year();
            year28.data_year = 2018;
            Year year29 = new Year();
            year29.data_year = 2019;

            dbContext.Years.Add(year1);
            dbContext.Years.Add(year2);
            dbContext.Years.Add(year3);
            dbContext.Years.Add(year4);
            dbContext.Years.Add(year5);
            dbContext.Years.Add(year6);
            dbContext.Years.Add(year7);
            dbContext.Years.Add(year8);
            dbContext.Years.Add(year9);
            dbContext.Years.Add(year10);
            dbContext.Years.Add(year11);
            dbContext.Years.Add(year12);
            dbContext.Years.Add(year13);
            dbContext.Years.Add(year14);
            dbContext.Years.Add(year15);
            dbContext.Years.Add(year16);
            dbContext.Years.Add(year17);
            dbContext.Years.Add(year18);
            dbContext.Years.Add(year19);
            dbContext.Years.Add(year20);
            dbContext.Years.Add(year21);
            dbContext.Years.Add(year22);
            dbContext.Years.Add(year23);
            dbContext.Years.Add(year24);
            dbContext.Years.Add(year25);
            dbContext.Years.Add(year26);
            dbContext.Years.Add(year27);
            dbContext.Years.Add(year28);
            dbContext.Years.Add(year29);
            dbContext.SaveChanges();
            dbContext.Keys.Add(Key1);
            dbContext.Keys.Add(Key2);
            dbContext.Keys.Add(Key3);
            dbContext.Keys.Add(Key4);
            dbContext.Keys.Add(Key5);
            dbContext.Keys.Add(Key6);
            dbContext.SaveChanges();

            return View();
        }

        public IActionResult PopulateDatum()
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
                    //Database 

                }
                foreach (Datum x in results.data)
                {

                    if (dbContext.Datums.Where(d => d.data_year.Equals(x.data_year)).Count() == 0 & dbContext.Datums.Where(d => d.key.Equals(x.key)).Count() == 0)
                    {
                    dbContext.Datums.Add(x);
                    }

                }


                dbContext.SaveChanges();
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }



            return View(results);
        }

            
        


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        
        
        
        //David's build of chart structure


       

    }
}



