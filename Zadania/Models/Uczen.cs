using Microsoft.AspNetCore.Identity;

namespace Zadania.Models
{
    public class Uczen
    {
        public int UczenId { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public int? KlasaId { get; set; }
        public Klasa? Klasa { get; set; }
        ///public ICollection<Zadanie> Zadanie { get; } = new List<Zadanie>();
        ///
        public ICollection<UczenZadanie> UczenZadanie { get; } = new List<UczenZadanie>();

        public string UczenUserId { get; set; }
        public IdentityUser? UczenUser { get; set; }
    }
}
