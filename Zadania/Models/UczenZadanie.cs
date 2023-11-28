namespace Zadania.Models
{
    public class UczenZadanie
    {
        public int Id { get; set; }

        public int? UczenId { get; set; }
        public Uczen? Uczen { get; set; }

        public int? ZadanieId { get; set; }
        public Zadanie? Zadanie { get; set; }

        public string Tytul { get; set; }
        public string Tresc { get; set; }
    }
}
