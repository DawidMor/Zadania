using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Zadania.Models;

namespace Zadania.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Zadania.Models.Klasa>? Klasa { get; set; }
        public DbSet<Zadania.Models.Nauczyciel>? Nauczyciel { get; set; }
        public DbSet<Zadania.Models.Uczen>? Uczen { get; set; }
        public DbSet<Zadania.Models.Zadanie>? Zadanie { get; set; }
        public DbSet<Zadania.Models.UczenZadanie>? UczenZadanie { get; set; }
    }
}