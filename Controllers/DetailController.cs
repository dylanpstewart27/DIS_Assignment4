﻿using DIS_Assignment4.Models;
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
            ViewData["key"] = key;
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

            foreach (Datum x in dbContext.Datums.Where(d => d.key == key).OrderByDescending(d => d.data_year))
            {
                list.Add(x);
            }


            return View(list);
        }

        [HttpGet("/Detail/Create/{key}")]
        public IActionResult Create([FromRoute] string key)
        {
            ViewData["key"] = key;
            return View();
        }

        public IActionResult CreateDatum(string key, int data_year, int month_num, int value)
        {
            var datum = new Datum
            {
                data_year = data_year,
                key = key,
                month_num = month_num,
                value = value
            };
            dbContext.Datums.Add(datum);
            dbContext.SaveChanges();
            return RedirectPreserveMethod("Detail/Details");
        }

        public IActionResult Edit(int id)
        {
            return View(dbContext.Datums.Where(d => d.ID == id));
        }

        public IActionResult Update(int ID, int value)
        {
            var datum = dbContext.Datums.SingleOrDefault(d => d.ID == ID);
            datum.value = value;

            dbContext.Datums.Update(datum);
            dbContext.SaveChanges();

            return View("Edit", dbContext.Datums.Where(d => d.ID == ID));
        }

        public IActionResult Delete(string key, int data_year, int value)
        {
            Datum deletion = dbContext.Datums
                .Where(d => d.key == key & d.data_year == data_year & d.value == value)
                .First();
            //_context.AnnualEnergyConsumption.Remove(DelRecord);
            //await _context.SaveChangesAsync();
            //return View(DelRecord);
            dbContext.Datums.Remove(deletion);
            dbContext.SaveChanges();
            return View();
        }
    }
}
