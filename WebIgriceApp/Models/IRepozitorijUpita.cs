using WebIgriceApp.Models;

namespace WebIgriceApp.Models
{
    public interface IRepozitorijUpita
    {
         
        IEnumerable<Igrice> PopisIgrica(); 
        void Create(Igrice igrice); 
        void Delete(Igrice igrice); 
        void Update(Igrice igrice); 
        int SljedeciId();
        int KategorijaSljedeciId();
        Igrice DohvatiIgricuSIdom(int id);

        IEnumerable<Kategorija> PopisKategorija();
        void Create(Kategorija kategorija);
        void Delete(Kategorija kategorija);
        void Update(Kategorija kategorija);

        Kategorija DohvatiKategorijuSIdom(int id);


    }
}

