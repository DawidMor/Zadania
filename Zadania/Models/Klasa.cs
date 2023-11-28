namespace Zadania.Models
{
    public class Klasa
    {
        public int KlasaId { get; set; }
        public string NazwaKlasy { get; set; }

        public ICollection<Uczen> Uczen { get; } = new List<Uczen>();

        public ICollection<Zadanie> Zadanie { get; } = new List<Zadanie>();

    }
}
