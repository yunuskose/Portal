using IDCrm.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace IDCrm.Controllers
{
    public class SiteController : Controller
    {

        DatabaseEntities db = new DatabaseEntities();

        public ActionResult AnaSayfa()
        {
            if (Session["Kullanici"] == null)
                return Redirect("~/Site/Giris");

            return View();
        }




        #region Kullanıcı  ve Kullanıcı Girişi

        [HttpGet]
        public ActionResult Cikis()
        {
            Session["Kullanici"] = null;
            return Redirect("~/Site/AnaSayfa");
            return View();
        }
        [HttpGet]
        public ActionResult Giris()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Giris(string KullaniciAdi, string Parola)
        {
            Kullanicilar kullanici = db.Kullanicilars.Where((k) => k.Silindi == false && k.Aktif == true && k.Email == KullaniciAdi && k.Parola == Parola).FirstOrDefault();
            if (kullanici != null)
            {
                Session["Kullanici"] = kullanici;
                return Redirect("~/Site/AnaSayfa");

            }
            ViewBag.Uyari = "Kullanıcı adı veya parola yanlış.";
            return View();
        }

        public ActionResult Kullanicilar()
        {
            if (Session["Kullanici"] == null)
                return Redirect("~/Site/Giris");
            return View(db.Kullanicilars.Where((k) => k.Silindi == false).OrderBy((o) => o.ID).ToList());
        }

        [HttpGet]
        public ActionResult KullaniciYetki(int id)
        {
            if (Session["Kullanici"] == null)
                return Redirect("~/Site/Giris");
            ViewBag.KullaniciAdi = db.Kullanicilars.Where((e) => e.ID == id).FirstOrDefault().Email;
            ViewBag.KullaniciID = db.Kullanicilars.Where((e) => e.ID == id).FirstOrDefault().ID;
            List<KullaniciYetkiler> entity = db.KullaniciYetkilers.Where((k) => k.KullaniciID == id).ToList();
            return View(entity);
        }
        [HttpPost]
        public ActionResult KullaniciYetki(int id,
            string Sayim_Gor, string TH_Gor, string ProjeKarZarar_Gor,
            string KullaniciListesi_Gor
            )
        {
            if (Session["Kullanici"] == null)
                return Redirect("~/Site/Giris");

            foreach (var item in db.KullaniciYetkilers.Where((e)=>e.KullaniciID == id))
            {
                db.KullaniciYetkilers.Remove(item);
            }
            


            db.KullaniciYetkilers.Add(new KullaniciYetkiler()
            {
                KullaniciID = id,
                Modul = "Sayim",
                Gor = Sayim_Gor == "1" ? true : false,
                Duzenle = Sayim_Gor == "1" ? true : false,
                Sil = Sayim_Gor == "1" ? true : false
            });
            db.KullaniciYetkilers.Add(new KullaniciYetkiler()
            {
                KullaniciID = id,
                Modul = "TH",
                Gor = TH_Gor == "1" ? true : false,
                Duzenle = TH_Gor == "1" ? true : false,
                Sil = TH_Gor == "1" ? true : false
            });
            db.KullaniciYetkilers.Add(new KullaniciYetkiler()
            {
                KullaniciID = id,
                Modul = "ProjeKarZarar",
                Gor = ProjeKarZarar_Gor == "1" ? true : false,
                Duzenle = ProjeKarZarar_Gor == "1" ? true : false,
                Sil = ProjeKarZarar_Gor == "1" ? true : false
            });

            db.KullaniciYetkilers.Add(new KullaniciYetkiler()
            {
                KullaniciID = id,
                Modul = "KullaniciListesi",
                Gor = KullaniciListesi_Gor == "1" ? true : false,
                Duzenle = KullaniciListesi_Gor == "1" ? true : false,
                Sil = KullaniciListesi_Gor == "1" ? true : false
            });


            db.SaveChanges();

            ViewBag.KullaniciAdi = db.Kullanicilars.Where((e) => e.ID == id).FirstOrDefault().Email;
            ViewBag.KullaniciID = db.Kullanicilars.Where((e) => e.ID == id).FirstOrDefault().ID;
            List<KullaniciYetkiler> entity = db.KullaniciYetkilers.Where((k) => k.KullaniciID == id).ToList();
            return View(entity);
        }

        [HttpGet]
        public ActionResult Kullanici(int id)
        {
            if (Session["Kullanici"] == null)
                return Redirect("~/Site/Giris");
            Kullanicilar entity = db.Kullanicilars.Where((k) => k.ID == id).FirstOrDefault();
            if (entity == null)
                return View(new Kullanicilar() {  });
            else
                return View(entity);
        }
        [HttpPost]
        public ActionResult Kullanici(int id, string Adi, string Soyadi, string Email, string Parola, string KisiselEmail, string Aktif,
            string Adres,string Grubu

            )
        {
            if (Session["Kullanici"] == null)
                return Redirect("~/Site/Giris");
            if (id > 0)
            {
                Kullanicilar kullanici = db.Kullanicilars.Where((k) => k.ID == id).FirstOrDefault();
                kullanici.Adi = Adi;
                kullanici.Soyadi = Soyadi;
                kullanici.Email = Email;
                kullanici.Parola = Parola;
                kullanici.KisiselMail = KisiselEmail;
                kullanici.Aktif = Aktif == "0" ? false : true;
                kullanici.Adres = Adres;
                kullanici.Grubu = Grubu;
                kullanici.DuzenlemeTarihi = DateTime.Now;
                kullanici.DuzenlemeYapanKullanici = ((Kullanicilar)Session["Kullanici"]).Email;
            }
            else
            {
                Kullanicilar kullanici = new Kullanicilar();
                kullanici.Adi = Adi;
                kullanici.Soyadi = Soyadi;
                kullanici.Email = Email;
                kullanici.Parola = Parola;
                kullanici.KisiselMail = KisiselEmail;
                kullanici.Aktif = Aktif == "0" ? false : true;
                kullanici.Adres = Adres;
                kullanici.Grubu = Grubu;
                kullanici.Silindi = false;
                kullanici.KayitTarihi = DateTime.Now;
                kullanici.KayitYapanKullanici = ((Kullanicilar)Session["Kullanici"]).Email;
                db.Kullanicilars.Add(kullanici);
            }
            db.SaveChanges();
            return Redirect("~/Site/Kullanicilar");
        }

        public ActionResult KullaniciSil(int id = 0)
        {
            if (Session["Kullanici"] == null)
                return Redirect("~/Site/Giris");

            Kullanicilar entity = db.Kullanicilars.Where((k) => k.ID == id).FirstOrDefault();
            entity.Silindi = true;
            entity.SilinenTarih = DateTime.Now;
            entity.SilenKullanici = ((Kullanicilar)Session["Kullanici"]).Email;
            db.SaveChanges();
            return Redirect("~/Site/Kullanicilar");
        }


        [HttpGet]
        public ActionResult ParolaDegistir()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ParolaDegistir(string Parola)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "Update kullanicilar set Parola='" + Parola + "' where ID = @id";
            cmd.Parameters.AddWithValue("@id", ((Kullanicilar)Session["Kullanici"]).ID);
            IDVeritabani.Sorgula(cmd, SorgulaTuru.Bos);

            ViewBag.Bilgilendirme = "Parola başarıyla değiştirilmiştir.";
            return View("ParolaDegistir");
        }


        #endregion


        

        

        





    }
}