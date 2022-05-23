using Microsoft.AspNetCore.Mvc;
using Travel_Agency.Database;
using Travel_Agency.Models;

namespace Travel_Agency.Controllers
{
    public class PacchettoViaggioController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            List<PacchettoViaggio> Pacchettiviaggio = new List<PacchettoViaggio>();

            using (TravelAgencyContext db = new TravelAgencyContext())
            {
                Pacchettiviaggio = db.PacchettiViaggio.ToList();
            }
                return View("Index", Pacchettiviaggio);
        }
    }
}
