namespace Zadania.Models
{
    public class Uczen
    {
        public int UczenId { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public ICollection<Zadanie> Zadanie { get; } = new List<Zadanie>();
    }
}
