using DIS_Assignment4.DataAcess;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DIS_Assignment4.Controllers
{
    [Route("[controller]")]
    public class RacesController : Controller
    {
        private Manager crimesManager;

        public RacesController(Manager crimesManager)
        {
            if (crimesManager == null)
            {
                throw new ArgumentNullException("Null paramater crimesManager");
            }
            this.crimesManager = crimesManager;

        }

        [HttpGet]
        public async Task<IActionResult> Races()
        {
            ViewData["Title"] = "Races";
            return View(await crimesManager.GetRaces());
        }

        [HttpGet("{raceId}")]
        public async Task<IActionResult> Race([FromRoute] int raceId)
        {
            ViewData["Title"] = "Crime details";
            var race = await crimesManager.GetRaceById(raceId);
            ViewData["RaceName"] = race.race;
            return View(await crimesManager.GetCrimeByRaceId(raceId));
        }
    }
}
