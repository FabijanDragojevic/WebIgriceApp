using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace WebIgriceApp.Models

{
    public class AppDbContext: IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Igrice> Igrice { get; set; }
        public DbSet<Kategorija> Kategorija { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Igrice>().Property(f => f.Cijena).HasPrecision(10, 2);

            builder.Entity<Kategorija>().HasData(
                new Kategorija() { Id = 1, Naziv = "Real-time strategy (RTS)" },
                new Kategorija() { Id = 2, Naziv = "Shooters (FPS and TPS)" },
                new Kategorija() { Id = 3, Naziv = "MOBA" },
                new Kategorija() { Id = 4, Naziv = "Role-Playing" },
                new Kategorija() { Id = 5, Naziv = "Sports" }
                );


            builder.Entity<Igrice>().HasData(
               new Igrice() { Id = 1, Naziv = "StarCraft 2", Cijena = 14.99m, DatumIzlaska = DateTime.Parse("2010-07-27"), SlikaUrl = "https://bnetcmsus-a.akamaihd.net/cms/blog_header/ci/CIGT53U8ZP6M1509744317189.jpg", KategorijaId = 1 },
                new Igrice() { Id = 2, Naziv = "CS:GO", Cijena = 10.99m, DatumIzlaska = DateTime.Parse("2012-08-21"), SlikaUrl = "https://cdn.akamai.steamstatic.com/steam/apps/730/capsule_616x353.jpg?t=1683566799", KategorijaId = 2 },
                new Igrice() { Id = 3, Naziv = "League of Legends", Cijena = 0.00m, DatumIzlaska = DateTime.Parse("2009-12-18"), SlikaUrl = "https://cdn1.epicgames.com/offer/24b9b5e323bc40eea252a10cdd3b2f10/LOL_2560x1440-98749e0d718e82d27a084941939bc9d3", KategorijaId = 3 },
                new Igrice() { Id = 4, Naziv = "divinity original sin II", Cijena = 7.99m, DatumIzlaska = DateTime.Parse("1974-07-18"), SlikaUrl = "https://image.api.playstation.com/cdn/EP3383/CUSA11898_00/qCNa6hRH1XzGkRoUdKnNS0Zon3GMomx3.png", KategorijaId = 4 },
                new Igrice() { Id = 5, Naziv = "FIFA 23", Cijena = 50.99m, DatumIzlaska = DateTime.Parse("2023-04-10"), SlikaUrl = "https://cdn1.epicgames.com/offer/f5deacee017b4b109476933f7dd2edbd/EGS_EASPORTSFIFA23StandardEdition_EACanada_S1_2560x1440-aaf9c5273c27a485f2cce8cb7e804f5c", KategorijaId = 5 }


                );




        }
    }
}
