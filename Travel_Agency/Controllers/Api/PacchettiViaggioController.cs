﻿using Microsoft.AspNetCore.Mvc;
using Travel_Agency.Database;
using Travel_Agency.Models;

namespace Travel_Agency.Controllers.Api
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class PacchettiViaggioController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            List<PacchettoViaggio> Pacchettiviaggio = new List<PacchettoViaggio>();

            using (TravelAgencyContext db = new TravelAgencyContext())
            {
                Pacchettiviaggio = db.PacchettiViaggio.ToList();
            }

            return Ok(Pacchettiviaggio);
        }
    }
}
