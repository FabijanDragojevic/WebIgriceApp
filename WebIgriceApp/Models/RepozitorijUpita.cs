using Microsoft.EntityFrameworkCore;
namespace WebIgriceApp.Models
{
    public class RepozitorijUpita: IRepozitorijUpita
    {
        private readonly AppDbContext _appDbContext;
        public RepozitorijUpita(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public void Create (Igrice igrice) 
        {
            _appDbContext.Add(igrice);
            _appDbContext.SaveChanges();
        }
        public void Create(Kategorija kategorija)
        {
            _appDbContext.Add(kategorija);
            _appDbContext.SaveChanges();
        }
        public void Delete (Igrice igrice) 
        {
            _appDbContext.Igrice.Remove(igrice);
            _appDbContext.SaveChanges();
        }
        public void Delete(Kategorija kategorija)
        {
            _appDbContext.Kategorija.Remove(kategorija);
            _appDbContext.SaveChanges();
        }
        public Igrice DohvatiIgricuSIdom(int id)
        {
            return _appDbContext.Igrice
                .Include(k => k.Kategorija)
                .FirstOrDefault(f => f.Id == id);
        }
        public Kategorija DohvatiKategorijuSIdom(int id)
        {
            return _appDbContext.Kategorija.Find(id);
        }

        public int KategorijaSljedeciId()
        {
            int zadnjiId = _appDbContext.Kategorija
               .Count();

            int sljedeciId = zadnjiId + 1;
            return sljedeciId;
        }

        public IEnumerable<Igrice> PopisIgrica()
        {

            return _appDbContext.Igrice.Include(k => k.Kategorija);
        }

      

        public IEnumerable<Kategorija> PopisKategorija()
        {
            return _appDbContext.Kategorija;
        }

        public int SljedeciId()
        {
            int zadnjiId = _appDbContext.Igrice
                .Include(k => k.Kategorija)
                .Max(x => x.Id);

            int sljedeciId = zadnjiId + 1;
            return sljedeciId;
        }

        public void Update(Igrice igrice)
        {
            _appDbContext.Igrice.Update(igrice);
            _appDbContext.SaveChanges();
        }

        public void Update(Kategorija kategorija)
        {
            _appDbContext.Kategorija.Update(kategorija);
            _appDbContext.SaveChanges();
        }
    }
}
