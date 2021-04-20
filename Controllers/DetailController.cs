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
            var x = dbContext.Keys
                .OrderBy(c => c.key);

            return View(x);
        }
    }
}
