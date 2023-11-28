namespace Zadania.Models
{
    public class Zadanie
    {
        public int ZadanieId { get; set; }
        public string Tytul { get; set; }
        public string Opis { get; set; }
        public DateTime DataWaznosci { get; set; }
        public bool CzyWyslanePoTerminie { get; set; }
        public int? Punktacja { get; set; }

        public int? UczenId { get; set; }
        public Uczen? Uczen { get; set; }

        public int? KlasaId { get; set; }
        public Klasa? Klasa { get; set; }

        public int NauczycielId { get; set; }
        public Nauczyciel? Nauczyciel { get; set; }
    }
}
