using Microsoft.AspNetCore.Identity;

namespace Zadania.Models
{
    public class Nauczyciel
    {
        public int NauczycielId { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public ICollection<Zadanie> Zadanie { get; } = new List<Zadanie>();

        public string NauczycielUserId { get; set; }
        public IdentityUser? NauczycielUser { get; set; }
    }
}
