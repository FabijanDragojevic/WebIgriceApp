﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebIgriceApp.Models;
using WebIgriceApp.Models;

namespace WebIgriceApp.Controllers
{
    public class KategorijaController : Controller
    {
        private readonly IRepozitorijUpita _repozitorijUpita;
        public KategorijaController(IRepozitorijUpita repozitorijUpita)
        {
            _repozitorijUpita = repozitorijUpita;
        }

        public IActionResult Index()
        {
            return View(_repozitorijUpita.PopisKategorija());
        }

        public IActionResult Create()
        {

            int sljedeciId = _repozitorijUpita.KategorijaSljedeciId(); 
            Kategorija kategorija = new Kategorija() { Id = sljedeciId };
            return View(kategorija);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Naziv")] Kategorija kategorija)
        {
            ModelState.Remove("Igrices");

            if (ModelState.IsValid)
            {
                _repozitorijUpita.Create(kategorija);
                return RedirectToAction("Index"); 
            }
            
            return View(kategorija);

        }

        [HttpGet]
        public IActionResult Update(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var kategorija = _repozitorijUpita.DohvatiKategorijuSIdom(Convert.ToInt32(id));
            if (kategorija == null)
            {
                return NotFound();
            }
            return View(kategorija);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int id, [Bind("Id,Naziv")] Kategorija kategorija)
        {
            if (id != kategorija.Id)
            {
                return NotFound();
            }

            ModelState.Remove("Igrices");

            if (ModelState.IsValid)
            {
                _repozitorijUpita.Update(kategorija);
                return RedirectToAction("Index");
            }
            return View(kategorija);
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var kategorija = _repozitorijUpita.DohvatiKategorijuSIdom(Convert.ToInt32(id));
            if (kategorija == null)
            {
                return NotFound();
            }
            return View(kategorija);
        }


        [HttpPost]
        public IActionResult Delete(int id)
        {
            var kategorija = _repozitorijUpita.DohvatiKategorijuSIdom(Convert.ToInt32(id));
            _repozitorijUpita.Delete(kategorija);
            return RedirectToAction("Index");
        }
    }
}
