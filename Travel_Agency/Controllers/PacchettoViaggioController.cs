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

        [HttpGet]
        public IActionResult DettaglioPacchetto(int id)
        {
            PacchettoViaggio pacchettoTrovato = null;

            using (TravelAgencyContext db = new TravelAgencyContext())
            {
                try
                {

                    pacchettoTrovato = db.PacchettiViaggio
                          .Where(Pizza => Pizza.Id == id)
                          .First();

                    return View("DettaglioPacchetto", pacchettoTrovato);

                }
                catch (InvalidOperationException ex)
                {
                    return NotFound("il post con id " + id + " non è stato trovato");
                }
                catch (Exception ex)
                {
                    return BadRequest();
                }
            }
        }
        
        [HttpGet]
        public IActionResult Create()
        {
            return View("CreatePacchetto");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(PacchettoViaggio nuovoPacchetto)
        {
            if (!ModelState.IsValid)
            {
                return View("CreatePizza", nuovoPacchetto);
            }

            using (TravelAgencyContext db = new TravelAgencyContext())
            {
                PacchettoViaggio pacchettoDaCreare = new PacchettoViaggio(nuovoPacchetto.Immagine, nuovoPacchetto.Destinazione, nuovoPacchetto.TipoPensione, nuovoPacchetto.StelleHotel, nuovoPacchetto.NumerOspiti, nuovoPacchetto.Prezzo);

                db.Add(pacchettoDaCreare);
                db.SaveChanges();
            }

            return RedirectToAction("index");
        }
        /*
        [HttpGet]
        public IActionResult Aggiorna(int id)
        {
            Pizza pizzaDaModificare = null;

            using (PizzaContext db = new PizzaContext())
            {

                //stesso modo di fare le query rispetto a prima ma usando le query classiche di SQL e non entity Framework
                pizzaDaModificare = (from pizza in db.Pizze
                                     where pizza.Id == id
                                     select pizza).First();
            }

            if (pizzaDaModificare == null)
            {
                return NotFound();
            }
            else
            {
                return View("PizzaDaModificare", pizzaDaModificare);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Aggiorna(int id, Pizza modello)
        {
            if (!ModelState.IsValid)
            {
                return View("Aggiorna", modello);
            }

            Pizza pizzaDaModificare = null;

            using (PizzaContext db = new PizzaContext())
            {
                pizzaDaModificare = db.Pizze
                      .Where(Pizza => Pizza.Id == id)
                      .First();

                if (pizzaDaModificare != null)
                {
                    //aggiorniamo i campi con i nuovi valori
                    pizzaDaModificare.Nome = modello.Nome;
                    pizzaDaModificare.Ingredienti = modello.Ingredienti;
                    pizzaDaModificare.Immagine = modello.Immagine;
                    pizzaDaModificare.Prezzo = modello.Prezzo;

                    db.SaveChanges();

                    return RedirectToAction("ListinoPizze");
                }
                else
                {
                    return NotFound();
                }
            }
        }

        [HttpPost]
        public IActionResult Cancella(int id)
        {
            Pizza? pizzaDaCancellare = null;

            using (PizzaContext db = new PizzaContext())
            {
                pizzaDaCancellare = db.Pizze
                      .Where(Pizza => Pizza.Id == id)
                      .FirstOrDefault();
                if (pizzaDaCancellare != null)
                {
                    db.Pizze.Remove(pizzaDaCancellare);
                    db.SaveChanges();

                    return RedirectToAction("ListinoPizze");
                }
                else
                {
                    return NotFound();
                }
            }
        }*/
    }
}
