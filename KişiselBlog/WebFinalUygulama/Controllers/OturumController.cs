using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Web.Security;

namespace WebFinalUygulama.Controllers
{
    public class OturumController : Controller
    {
        // GET: Oturum
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult KullaniciGiris()
        {

            return View("KullaniciGiris");

        }

        [HttpPost]
        public ActionResult OturumAc(Kullanici kullanici) {
                blogEntities1 model = new blogEntities1();
                var oturum = model.Kullanici.Where(p => p.KullaniciAdi == kullanici.KullaniciAdi && p.Sifre == kullanici.Sifre).FirstOrDefault();


                if (oturum != null)
                {
                    JavaScriptSerializer serialize = new JavaScriptSerializer();
                    string jsonKullanici = serialize.Serialize(oturum);

                    FormsAuthenticationTicket bilet = new FormsAuthenticationTicket(
                                                            1, FormsAuthentication.FormsCookieName,
                                                            DateTime.Now, DateTime.Now.AddMinutes(2),
                                                            true, jsonKullanici
                                                            );

                    string sifreliBilet = FormsAuthentication.Encrypt(bilet);

                    HttpCookie cerez = new HttpCookie(FormsAuthentication.FormsCookieName, sifreliBilet);
                    cerez.Expires = DateTime.Now.AddMinutes(2);
                    Response.Cookies.Add(cerez);
                }

                return RedirectToAction("../Home/Anasayfa");
        }

        [HttpPost]
        public ActionResult Kaydol(Kullanici kullanici) {
            blogEntities1 model = new blogEntities1();
            var kaydol = model.Kullanici.Where(s => s.KullaniciAdi == kullanici.KullaniciAdi && s.Sifre == kullanici.Sifre).ToList();
            if (kaydol.Count() == 0) {
                model.Kullanici.Add(kullanici);
                model.SaveChanges();
                List<Siir> liste = model.Siir.ToList();
                return View("../Oturum/KullaniciGiris", liste);
            }

            return RedirectToAction("../Oturum/KullaniciGiris");
        }

        public ActionResult CikisYap() {
            if (Request.Cookies[FormsAuthentication.FormsCookieName] != null) {

                HttpCookie cookieNesne = new HttpCookie(FormsAuthentication.FormsCookieName);
                cookieNesne.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(cookieNesne);
            }

            return RedirectToAction("../Home/Anasayfa");
        }
    }
}