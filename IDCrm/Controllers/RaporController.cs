using IDCrm.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IDCrm.Controllers
{
    public class RaporController : Controller
    {
        private DatabaseEntities db = new DatabaseEntities();

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult Rapor1(string Donem="", string ProjeKodu="", string Aciklama="")
        {
            if (Session["Kullanici"] == null)
                return Redirect("~/Site/Giris");
            DataTable dt = new DataTable();
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select * from [TD_MH_PR_0] Where 1=1 ";
                if (Donem != "")
                {
                    cmd.CommandText += " and DONEM = @Donem ";
                    cmd.Parameters.AddWithValue("@Donem", Donem);
                }
                if (ProjeKodu != "")
                {
                    cmd.CommandText += " and PROJE_KODU = @ProjeKodu ";
                    cmd.Parameters.AddWithValue("@ProjeKodu", ProjeKodu);
                }
                if (Aciklama != "")
                {
                    cmd.CommandText += " and PROJE_ACIKLAMA like '%'+@Aciklama+'%' ";
                    cmd.Parameters.AddWithValue("@Aciklama", Aciklama);
                }
                
                dt = (DataTable)IDVeritabani.Sorgula(cmd, SorgulaTuru.Tablo);
                ViewBag.Donem = Donem;
                ViewBag.ProjeKodu = ProjeKodu;
                ViewBag.Aciklama = Aciklama;
            }
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select * from [TD_MH_PR_2]  Where LEN(PROJE_KODU) = 4 Order by PROJE_KODU";
                ViewBag.ProjeKodlari = (DataTable)IDVeritabani.Sorgula(cmd, SorgulaTuru.Tablo);
            }
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select * from TD_DONEMLER WITH(NOLOCK) ";
                ViewBag.Donemler = (DataTable)IDVeritabani.Sorgula(cmd, SorgulaTuru.Tablo);
            }
            return View(dt);
        }

        public ActionResult Sayim()
        {
            if (Session["Kullanici"] == null)
                return Redirect("~/Site/Giris");

            DataTable dt = new DataTable();
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select * from TD_SAYIMLAR WITH(NOLOCK) ";
                dt = (DataTable)IDVeritabani.Sorgula(cmd, SorgulaTuru.Tablo);
            }

            return View(dt);
        }

        [HttpGet]
        public ActionResult SayimGirisi(int id = 0)
        {
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select * from [TD_MH_PR_2]  Where LEN(PROJE_KODU) = 4 Order by PROJE_KODU";
                ViewBag.ProjeKodlari = (DataTable)IDVeritabani.Sorgula(cmd, SorgulaTuru.Tablo);
            }

            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select * from TD_DONEMLER WITH(NOLOCK) ";
                ViewBag.Donemler = (DataTable)IDVeritabani.Sorgula(cmd, SorgulaTuru.Tablo);
            }
            ViewBag.Id = id;
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select * from TD_SAYIMLAR WITH(NOLOCK) Where ID = @ID or @ID2 = 0";
                cmd.Parameters.AddWithValue("@ID", id);
                cmd.Parameters.AddWithValue("@ID2", id);
                ViewBag.Sayim = (DataTable)IDVeritabani.Sorgula(cmd, SorgulaTuru.Tablo);
            }

            return View();
        }

        [HttpPost]
        public ActionResult SayimGirisi(int id, string Donem, string ProjeKodu, decimal Tutar, string Aciklama)
        {
            {
                SqlCommand cmd = new SqlCommand();
                if (id == 0)
                {
                    cmd.CommandText = "Insert Into TD_SAYIMLAR (Donem,ProjeKodu,Tutar,Aciklama) values (@Donem,@ProjeKodu,@Tutar,@Aciklama)";

                    cmd.Parameters.AddWithValue("@Donem", Donem);
                    cmd.Parameters.AddWithValue("@ProjeKodu", ProjeKodu);
                    cmd.Parameters.AddWithValue("@Tutar", Tutar);
                    cmd.Parameters.AddWithValue("@Aciklama", Aciklama);
                }
                else
                {

                    cmd.CommandText = "Update TD_SAYIMLAR set Donem=@Donem,ProjeKodu=@ProjeKodu,Tutar=@Tutar,Aciklama=@Aciklama Where ID = @ID";

                    cmd.Parameters.AddWithValue("@Donem", Donem);
                    cmd.Parameters.AddWithValue("@ProjeKodu", ProjeKodu);
                    cmd.Parameters.AddWithValue("@Tutar", Tutar);
                    cmd.Parameters.AddWithValue("@Aciklama", Aciklama);
                    cmd.Parameters.AddWithValue("@ID", id);
                }
                ViewBag.ProjeKodlari = (DataTable)IDVeritabani.Sorgula(cmd, SorgulaTuru.Tablo);
            }

            return Redirect("~/Rapor/Sayim");
        }

        public ActionResult SayimSil(int id)
        {
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "Delete from TD_SAYIMLAR Where ID = @ID";
                cmd.Parameters.AddWithValue("@ID", id);
                ViewBag.ProjeKodlari = (DataTable)IDVeritabani.Sorgula(cmd, SorgulaTuru.Tablo);
            }

            return Redirect("~/Rapor/Sayim");
        }


        //Taşeron Hakedişi
        public ActionResult TH()
        {
            if (Session["Kullanici"] == null)
                return Redirect("~/Site/Giris");

            DataTable dt = new DataTable();
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select * from TD_TH WITH(NOLOCK) ";
                dt = (DataTable)IDVeritabani.Sorgula(cmd, SorgulaTuru.Tablo);
            }

            return View(dt);
        }

        [HttpGet]
        public ActionResult THGirisi(int id = 0)
        {
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select * from [TD_MH_PR_2]  Where LEN(PROJE_KODU) = 4 Order by PROJE_KODU";
                ViewBag.ProjeKodlari = (DataTable)IDVeritabani.Sorgula(cmd, SorgulaTuru.Tablo);
            }

            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select * from TD_DONEMLER WITH(NOLOCK) ";
                ViewBag.Donemler = (DataTable)IDVeritabani.Sorgula(cmd, SorgulaTuru.Tablo);
            }
            ViewBag.Id = id;
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select * from TD_TH WITH(NOLOCK) Where ID = @ID or @ID2 = 0";
                cmd.Parameters.AddWithValue("@ID", id);
                cmd.Parameters.AddWithValue("@ID2", id);
                ViewBag.Sayim = (DataTable)IDVeritabani.Sorgula(cmd, SorgulaTuru.Tablo);
            }

            return View();
        }

        [HttpPost]
        public ActionResult THGirisi(int id, string Donem, string ProjeKodu, decimal Tutar, string Aciklama)
        {
            {
                SqlCommand cmd = new SqlCommand();
                if (id == 0)
                {
                    cmd.CommandText = "Insert Into TD_TH (Donem,ProjeKodu,Tutar,Aciklama) values (@Donem,@ProjeKodu,@Tutar,@Aciklama)";

                    cmd.Parameters.AddWithValue("@Donem", Donem);
                    cmd.Parameters.AddWithValue("@ProjeKodu", ProjeKodu);
                    cmd.Parameters.AddWithValue("@Tutar", Tutar);
                    cmd.Parameters.AddWithValue("@Aciklama", Aciklama);
                }
                else
                {

                    cmd.CommandText = "Update TD_TH set Donem=@Donem,ProjeKodu=@ProjeKodu,Tutar=@Tutar,Aciklama=@Aciklama Where ID = @ID";

                    cmd.Parameters.AddWithValue("@Donem", Donem);
                    cmd.Parameters.AddWithValue("@ProjeKodu", ProjeKodu);
                    cmd.Parameters.AddWithValue("@Tutar", Tutar);
                    cmd.Parameters.AddWithValue("@Aciklama", Aciklama);
                    cmd.Parameters.AddWithValue("@ID", id);
                }
                ViewBag.ProjeKodlari = (DataTable)IDVeritabani.Sorgula(cmd, SorgulaTuru.Tablo);
            }

            return Redirect("~/Rapor/TH");
        }

        public ActionResult THSil(int id)
        {
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "Delete from TD_TH Where ID = @ID";
                cmd.Parameters.AddWithValue("@ID", id);
                ViewBag.ProjeKodlari = (DataTable)IDVeritabani.Sorgula(cmd, SorgulaTuru.Tablo);
            }

            return Redirect("~/Rapor/TH");
        }
    }
}