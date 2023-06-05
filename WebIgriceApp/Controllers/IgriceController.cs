using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebIgriceApp.Models;

namespace WebIgriceApp.Controllers
{
   
    public class IgriceController : Controller
    {
        private readonly IRepozitorijUpita _repozitorijUpita;
        public IgriceController(IRepozitorijUpita repozitorijUpita)
        {
            _repozitorijUpita = repozitorijUpita;
        }
        public IActionResult Index()
        {
            return View(_repozitorijUpita.PopisIgrica());
        }
        public IActionResult Create()
        {
            ViewData["KategorijaId"] = new SelectList(_repozitorijUpita.PopisKategorija(), "Id", "Naziv");
            int sljedeciId = _repozitorijUpita.SljedeciId();
            Igrice igrice = new Igrice() { Id = sljedeciId };
            return View(igrice);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Naziv,DatumIzlaska,Cijena,SlikaUrl,KategorijaId")] Igrice igrice)
        {
            ModelState.Remove("Kategorija");

            if (ModelState.IsValid)
            {
                _repozitorijUpita.Create(igrice);
                return RedirectToAction("Index"); 
            }
            
            ViewData["KategorijaId"] = new SelectList(_repozitorijUpita.PopisKategorija(), "Id", "Naziv", igrice.KategorijaId);
            return View(igrice);

        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            if (id < 1)
            {
                return NotFound();
            }

            Igrice igrice = _repozitorijUpita.DohvatiIgricuSIdom(id);

            if (igrice == null) { return NotFound(); }

            ViewData["KategorijaId"] = new SelectList(_repozitorijUpita.PopisKategorija(), "Id", "Naziv", igrice.KategorijaId);
            return View(igrice);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int id, [Bind("Id,Naziv,DatumIzlaska,Cijena,SlikaUrl,KategorijaId")] Igrice igrice)
        {
            if (id != igrice.Id)
            {
                return NotFound();
            }

            ModelState.Remove("Kategorija");

            if (ModelState.IsValid)
            {
                _repozitorijUpita.Update(igrice);
                return RedirectToAction("Index");
            }
           
            ViewData["KategorijaId"] = new SelectList(_repozitorijUpita.PopisKategorija(), "Id", "Naziv", igrice.KategorijaId);
            return View(igrice);

        }
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id < 1)
            {
                return NotFound();
            }

            var igrice = _repozitorijUpita.DohvatiIgricuSIdom(Convert.ToInt16(id));

            if (igrice == null)
            {
                return NotFound();
            }

            return View(igrice);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var igrice = _repozitorijUpita.DohvatiIgricuSIdom(id);
            _repozitorijUpita.Delete(igrice);
            return RedirectToAction("Index");

        }

       
        public ActionResult SearchIndex(string igriceZanr, string searchString)
        {
            var zanr = new List<string>();

            var zanrUpit = _repozitorijUpita.PopisKategorija();

            ViewData["igriceZanr"] = new SelectList(_repozitorijUpita.PopisKategorija(), "Naziv", "Naziv", zanrUpit);

            var igricee = _repozitorijUpita.PopisIgrica();

            if (!String.IsNullOrWhiteSpace(searchString))
            {
                igricee = igricee.Where(s => s.Naziv.Contains(searchString, StringComparison.OrdinalIgnoreCase));  
            }

            if (string.IsNullOrWhiteSpace(igriceZanr))
                return View(igricee);
            else
            {
                return View(igricee.Where(x => x.Kategorija.Naziv == igriceZanr));
            }

        }
    }
}
