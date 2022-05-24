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
        
        [HttpGet]
        public IActionResult Aggiorna(int id)
        {
            PacchettoViaggio pacchettoDaModificare = null;

            using (TravelAgencyContext db = new TravelAgencyContext())
            {

                //stesso modo di fare le query rispetto a prima ma usando le query classiche di SQL e non entity Framework
                pacchettoDaModificare = (from PacchettoViaggio in db.PacchettiViaggio
                                     where PacchettoViaggio.Id == id
                                     select PacchettoViaggio).First();
            }

            if (pacchettoDaModificare == null)
            {
                return NotFound();
            }
            else
            {
                return View("AggiornaPacchetto", pacchettoDaModificare);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Aggiorna(int id, PacchettoViaggio modello)
        {
            if (!ModelState.IsValid)
            {
                return View("AggiornaPacchetto", modello);
            }

            PacchettoViaggio pacchettoDaModificare = null;

            using (TravelAgencyContext db = new TravelAgencyContext())
            {
                pacchettoDaModificare = db.PacchettiViaggio
                      .Where(Pizza => Pizza.Id == id)
                      .First();

                if (pacchettoDaModificare != null)
                {
                    //aggiorniamo i campi con i nuovi valori
                    pacchettoDaModificare.Destinazione = modello.Destinazione;
                    pacchettoDaModificare.TipoPensione = modello.TipoPensione;
                    pacchettoDaModificare.StelleHotel = modello.StelleHotel;
                    pacchettoDaModificare.NumerOspiti = modello.NumerOspiti;
                    pacchettoDaModificare.Immagine = modello.Immagine;
                    pacchettoDaModificare.Prezzo = modello.Prezzo;

                    db.SaveChanges();

                    return RedirectToAction("index");
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
            PacchettoViaggio? pizzaDaCancellare = null;

            using (TravelAgencyContext db = new TravelAgencyContext())
            {
                pizzaDaCancellare = db.PacchettiViaggio
                      .Where(Pizza => Pizza.Id == id)
                      .FirstOrDefault();
                if (pizzaDaCancellare != null)
                {
                    db.PacchettiViaggio.Remove(pizzaDaCancellare);
                    db.SaveChanges();

                    return RedirectToAction("index");
                }
                else
                {
                    return NotFound();
                }
            }
        }
    }
}
