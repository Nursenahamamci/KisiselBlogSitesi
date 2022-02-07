using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebFinalUygulama.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Anasayfa() {
            blogEntities1 model = new blogEntities1();
            List<Siir> liste = model.Siir.ToList();
            return View("Anasayfa",liste);

        }

        [Attribute.Oturum]
        public ActionResult SiirEkle() {
            
            return View("SiirEkle");
        }

        [HttpPost]
        public ActionResult SiirYaz(Siir yeniSiir) {
            blogEntities1 model = new blogEntities1();
            model.Siir.Add(yeniSiir);
            model.SaveChanges();
            return RedirectToAction("Anasayfa");
        }

        [HttpPost]
        public ActionResult SiirSil(Siir silinecekSiir) {
            blogEntities1 model = new blogEntities1();
            var siirSil = model.Siir.FirstOrDefault(s => s.SiirNo == silinecekSiir.SiirNo);
            model.Siir.Remove(siirSil);
            model.SaveChanges();

            List<Siir> liste = model.Siir.ToList();
            return RedirectToAction("Anasayfa",liste);
        }
    }
}