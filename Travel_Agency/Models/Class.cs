using System.ComponentModel.DataAnnotations;

namespace Travel_Agency.Models
{
    public class PacchettoViaggi
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "l'url dell'immagine è obbligatorio")]
        [Url(ErrorMessage = "L'url inserito non è valido")]
        public string Immagine { get; set; }

        [Required(ErrorMessage = "La destinazione è obbligatoria")]
        [StringLength(50, ErrorMessage = "La destinazione non può avere più di 50 caratteri")]
        public string Destinazione { get; set; }

        [Required(ErrorMessage = "La Pensione è obbligatoria")]
        [StringLength(20, ErrorMessage = "La destinazione non può avere più di 20 caratteri")]
        public string TipoPensione { get; set; }

        [Required(ErrorMessage = "il numero di stelle è obbligatorio")]
        [Range(1, 5, ErrorMessage = "Le stelle vanno da 1 a 5 massimo")]
        public int StelleHotel { get; set; }

        [Required(ErrorMessage = "Il numero di Ospiti è obbligatorio")]
        [Range(1, 5, ErrorMessage = "Le stelle vanno da 1 a 5 massimo")]
        public int NumerOspiti { get; set; }

        [Required(ErrorMessage = "Il prezzo è obbligatorio")]
        public double Prezzo { get; set; }

        public PacchettoViaggi()
        {

        }

        public PacchettoViaggi(string Immagine, string Destinazione, string TipoPensione, int StelleHotel, int NumerOspiti, double Prezzo)
        {
            this.Immagine = Immagine;
            this.Destinazione = Destinazione;
            this.TipoPensione = TipoPensione;
            this.StelleHotel = StelleHotel;
            this.NumerOspiti = NumerOspiti;
            this.Prezzo = Prezzo;
        }
    }
}