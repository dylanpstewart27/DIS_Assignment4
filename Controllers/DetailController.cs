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
    public class DetailController : Controller
    {

        public ApplicationDbContext dbContext;

        public DetailController(ApplicationDbContext context)
        {
            dbContext = context;
        }

        public IActionResult Detail()
        {
            List<Key> Data = new List<Key>();

            {
                foreach (var y in dbContext.Keys.OrderBy(k => k.key))
                {


                    Data.Add(y);

                }

                return View(Data);
            }
        }

        public IActionResult Details(string key)
        {
            
            List<Datum> list = new List<Datum>();
           

            //List<SectorSourceAnnual> list = new List<SectorSourceAnnual>();
            //var sectorSourceData = _context.AnnualEnergyConsumption.Where(t => t.sector.SectorName == sector & t.energysource.SourceName == source).OrderByDescending(y => y.Year);
            //foreach (AnnualEnergyConsumption dbRow in sectorSourceData)
            //{
            //    SectorSourceAnnual listRow = new SectorSourceAnnual();
            //    listRow.Year = dbRow.Year;
            //    listRow.Value = dbRow.Value;
            //    list.Add(listRow);
            //}
            //details.data = list;
            //return View(details);

            //var query = dbContext.Datums.Where(d => d.key == key);
            foreach(Datum x in dbContext.Datums.Where(d => d.key == key))
            {
                list.Add(x);
            }
            

            return View(list);
        }
    }
}
