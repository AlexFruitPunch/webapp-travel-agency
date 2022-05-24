using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Travel_Agency.Models;

namespace Travel_Agency.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index(string SearchString)
        {
            return View();
        }
    }
}