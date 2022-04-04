using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Threading;
using System.Web;

namespace IDCrm.Models
{
    public class IDGenel
    {
        private static readonly object balanceLock = new object();
        public static DatabaseEntities db = new DatabaseEntities();

      
    




        public static string KarakterTemizle(string deger = "")
        {
            deger = deger.ToUpper();
            deger = deger.Replace("İ", "I");
            deger = deger.Replace("Ğ", "G");
            deger = deger.Replace("Ü", "U");
            deger = deger.Replace("Ö", "O");
            deger = deger.Replace("Ç", "C");
            return deger;
        }
    }

    public class IDMailKalipleri
    {
        DatabaseEntities db = new DatabaseEntities();
        public IDMailKalipleri()
        {

        }

        private IDMailSablonu _IDMailSablonu1;
        /// <summary>
        /// Sira No, Firma, Teklif Tipi, Aciklama
        /// </summary>
        public IDMailSablonu IDMailSablon1
        {
            get
            {
                _IDMailSablonu1 = new IDMailSablonu()
                {
                    Baslik = db.MailKaliplaris.Where((e) => e.Sira == 1).First().Baslik,
                    Icerik = db.MailKaliplaris.Where((e) => e.Sira == 1).First().Detay
                };
                return _IDMailSablonu1;
            }
            set { _IDMailSablonu1 = value; }
        }


        private IDMailSablonu _IDMailSablonu2;
        /// <summary>
        /// Teklif No, Hazırlayanlar, Firma, Gönderilecek Kişi, Teklif Tipi, Açıklama
        /// </summary>
        public IDMailSablonu IDMailSablon2
        {
            get
            {
                _IDMailSablonu2 = new IDMailSablonu()
                {
                    Baslik = db.MailKaliplaris.Where((e) => e.Sira == 2).First().Baslik,
                    Icerik = db.MailKaliplaris.Where((e) => e.Sira == 2).First().Detay
                };
                return _IDMailSablonu2;
            }
            set { _IDMailSablonu2 = value; }
        }

        private IDMailSablonu _IDMailSablonu3;

        public IDMailSablonu IDMailSablon3
        {
            get
            {
                MailKaliplari mk = db.MailKaliplaris.Where((e) => e.Sira == 3).First();
                _IDMailSablonu3 = new IDMailSablonu()
                {
                    Baslik = mk.Baslik,
                    Icerik = mk.Detay
                };
                return _IDMailSablonu3;
            }
            set { _IDMailSablonu3 = value; }
        }


        private IDMailSablonu _IDMailSablonu4;

        public IDMailSablonu IDMailSablon4
        {
            get
            {
                _IDMailSablonu4 = new IDMailSablonu()
                {
                    Baslik = db.MailKaliplaris.Where((e) => e.Sira == 4).First().Baslik,
                    Icerik = db.MailKaliplaris.Where((e) => e.Sira == 4).First().Detay
                };
                return _IDMailSablonu4;
            }
            set { _IDMailSablonu4 = value; }
        }


        private IDMailSablonu _IDMailSablonu5;


        public IDMailSablonu IDMailSablon5
        {
            get
            {
                _IDMailSablonu5 = new IDMailSablonu()
                {
                    Baslik = db.MailKaliplaris.Where((e) => e.Sira == 5).First().Baslik,
                    Icerik = db.MailKaliplaris.Where((e) => e.Sira == 5).First().Detay
                };
                return _IDMailSablonu5;
            }
            set { _IDMailSablonu5 = value; }
        }


        private IDMailSablonu _IDMailSablonu6;

        public IDMailSablonu IDMailSablon6
        {
            get
            {
                _IDMailSablonu6 = new IDMailSablonu()
                {
                    Baslik = db.MailKaliplaris.Where((e) => e.Sira == 6).First().Baslik,
                    Icerik = db.MailKaliplaris.Where((e) => e.Sira == 6).First().Detay
                };
                return _IDMailSablonu6;
            }
            set { _IDMailSablonu6 = value; }
        }

        private IDMailSablonu _IDMailSablonu7;


        public IDMailSablonu IDMailSablon7
        {
            get
            {
                _IDMailSablonu7 = new IDMailSablonu()
                {
                    Baslik = db.MailKaliplaris.Where((e) => e.Sira == 7).First().Baslik,
                    Icerik = db.MailKaliplaris.Where((e) => e.Sira == 7).First().Detay
                };
                return _IDMailSablonu7;
            }
            set { _IDMailSablonu7 = value; }
        }


        private IDMailSablonu _IDMailSablonu8;

        public IDMailSablonu IDMailSablon8
        {
            get
            {
                _IDMailSablonu8 = new IDMailSablonu()
                {
                    Baslik = db.MailKaliplaris.Where((e) => e.Sira == 8).First().Baslik,
                    Icerik = db.MailKaliplaris.Where((e) => e.Sira == 8).First().Detay
                };
                return _IDMailSablonu8;
            }
            set { _IDMailSablonu8 = value; }
        }

        private IDMailSablonu _IDMailSablonu9;


        public IDMailSablonu IDMailSablon9
        {
            get
            {
                _IDMailSablonu9 = new IDMailSablonu()
                {
                    Baslik = db.MailKaliplaris.Where((e) => e.Sira == 9).First().Baslik,
                    Icerik = db.MailKaliplaris.Where((e) => e.Sira == 9).First().Detay
                };
                return _IDMailSablonu9;
            }
            set { _IDMailSablonu9 = value; }
        }


        private IDMailSablonu _IDMailSablonu10;


        public IDMailSablonu IDMailSablon10
        {
            get
            {
                _IDMailSablonu10 = new IDMailSablonu()
                {
                    Baslik = db.MailKaliplaris.Where((e) => e.Sira == 10).First().Baslik,
                    Icerik = db.MailKaliplaris.Where((e) => e.Sira == 10).First().Detay
                };
                return _IDMailSablonu10;
            }
            set { _IDMailSablonu10 = value; }
        }


        private IDMailSablonu _IDMailSablonu11;


        public IDMailSablonu IDMailSablon11
        {
            get
            {
                _IDMailSablonu11 = new IDMailSablonu()
                {
                    Baslik = db.MailKaliplaris.Where((e) => e.Sira == 11).First().Baslik,
                    Icerik = db.MailKaliplaris.Where((e) => e.Sira == 11).First().Detay
                };
                return _IDMailSablonu11;
            }
            set { _IDMailSablonu11 = value; }
        }

        private IDMailSablonu _IDMailSablonu12;


        public IDMailSablonu IDMailSablon12
        {
            get
            {
                _IDMailSablonu12 = new IDMailSablonu()
                {
                    Baslik = db.MailKaliplaris.Where((e) => e.Sira == 12).First().Baslik,
                    Icerik = db.MailKaliplaris.Where((e) => e.Sira == 12).First().Detay
                };
                return _IDMailSablonu12;
            }
            set { _IDMailSablonu12 = value; }
        }


        private IDMailSablonu _IDMailSablonu13;

        public IDMailSablonu IDMailSablon13
        {
            get
            {
                _IDMailSablonu13 = new IDMailSablonu()
                {
                    Baslik = db.MailKaliplaris.Where((e) => e.Sira == 13).First().Baslik,
                    Icerik = db.MailKaliplaris.Where((e) => e.Sira == 13).First().Detay
                };
                return _IDMailSablonu13;
            }
            set { _IDMailSablonu13 = value; }
        }


        private IDMailSablonu _IDMailSablonu14;


        public IDMailSablonu IDMailSablon14
        {
            get
            {
                _IDMailSablonu14 = new IDMailSablonu()
                {
                    Baslik = db.MailKaliplaris.Where((e) => e.Sira == 14).First().Baslik,
                    Icerik = db.MailKaliplaris.Where((e) => e.Sira == 14).First().Detay
                };
                return _IDMailSablonu14;
            }
            set { _IDMailSablonu14 = value; }
        }

        private IDMailSablonu _IDMailSablonu15;

        public IDMailSablonu IDMailSablon15
        {
            get
            {
                _IDMailSablonu15 = new IDMailSablonu()
                {
                    Baslik = db.MailKaliplaris.Where((e) => e.Sira == 15).First().Baslik,
                    Icerik = db.MailKaliplaris.Where((e) => e.Sira == 15).First().Detay
                };
                return _IDMailSablonu15;
            }
            set { _IDMailSablonu15 = value; }
        }

        private IDMailSablonu _IDMailSablonu16;

        public IDMailSablonu IDMailSablon16
        {
            get
            {
                _IDMailSablonu16 = new IDMailSablonu()
                {
                    Baslik = db.MailKaliplaris.Where((e) => e.Sira == 16).First().Baslik,
                    Icerik = db.MailKaliplaris.Where((e) => e.Sira == 16).First().Detay
                };
                return _IDMailSablonu16;
            }
            set { _IDMailSablonu16 = value; }
        }


        private IDMailSablonu _IDMailSablonu17;

        public IDMailSablonu IDMailSablon17
        {
            get
            {
                _IDMailSablonu17 = new IDMailSablonu()
                {
                    Baslik = db.MailKaliplaris.Where((e) => e.Sira == 17).First().Baslik,
                    Icerik = db.MailKaliplaris.Where((e) => e.Sira == 17).First().Detay
                };
                return _IDMailSablonu17;
            }
            set { _IDMailSablonu17 = value; }
        }


        private IDMailSablonu _IDMailSablonu18;


        public IDMailSablonu IDMailSablon18
        {
            get
            {
                _IDMailSablonu18 = new IDMailSablonu()
                {
                    Baslik = db.MailKaliplaris.Where((e) => e.Sira == 18).First().Baslik,
                    Icerik = db.MailKaliplaris.Where((e) => e.Sira == 18).First().Detay
                };
                return _IDMailSablonu18;
            }
            set { _IDMailSablonu18 = value; }
        }

        private IDMailSablonu _IDMailSablonu19;


        public IDMailSablonu IDMailSablon19
        {
            get
            {
                _IDMailSablonu19 = new IDMailSablonu()
                {
                    Baslik = db.MailKaliplaris.Where((e) => e.Sira == 19).First().Baslik,
                    Icerik = db.MailKaliplaris.Where((e) => e.Sira == 19).First().Detay
                };
                return _IDMailSablonu19;
            }
            set { _IDMailSablonu19 = value; }
        }


        private IDMailSablonu _IDMailSablonu20;


        public IDMailSablonu IDMailSablon20
        {
            get
            {
                _IDMailSablonu20 = new IDMailSablonu()
                {
                    Baslik = db.MailKaliplaris.Where((e) => e.Sira == 20).First().Baslik,
                    Icerik = db.MailKaliplaris.Where((e) => e.Sira == 20).First().Detay
                };
                return _IDMailSablonu20;
            }
            set { _IDMailSablonu20 = value; }
        }


        private IDMailSablonu _IDMailSablonu21;


        public IDMailSablonu IDMailSablon21
        {
            get
            {
                _IDMailSablonu21 = new IDMailSablonu()
                {
                    Baslik = db.MailKaliplaris.Where((e) => e.Sira == 21).First().Baslik,
                    Icerik = db.MailKaliplaris.Where((e) => e.Sira == 21).First().Detay
                };
                return _IDMailSablonu21;
            }
            set { _IDMailSablonu21 = value; }
        }


        private IDMailSablonu _IDMailSablonu22;


        public IDMailSablonu IDMailSablon22
        {
            get
            {
                _IDMailSablonu22 = new IDMailSablonu()
                {
                    Baslik = db.MailKaliplaris.Where((e) => e.Sira == 22).First().Baslik,
                    Icerik = db.MailKaliplaris.Where((e) => e.Sira == 22).First().Detay
                };
                return _IDMailSablonu22;
            }
            set { _IDMailSablonu22 = value; }
        }


        private IDMailSablonu _IDMailSablon23;


        public IDMailSablonu IDMailSablon23
        {
            get
            {
                _IDMailSablon23 = new IDMailSablonu()
                {
                    Baslik = db.MailKaliplaris.Where((e) => e.Sira == 23).First().Baslik,
                    Icerik = db.MailKaliplaris.Where((e) => e.Sira == 23).First().Detay
                };
                return _IDMailSablon23;
            }
            set { _IDMailSablon23 = value; }
        }

        private IDMailSablonu _IDMailSablonu24;


        public IDMailSablonu IDMailSablon24
        {
            get
            {
                _IDMailSablonu24 = new IDMailSablonu()
                {
                    Baslik = db.MailKaliplaris.Where((e) => e.Sira == 24).First().Baslik,
                    Icerik = db.MailKaliplaris.Where((e) => e.Sira == 24).First().Detay
                };
                return _IDMailSablonu24;
            }
            set { _IDMailSablonu24 = value; }
        }


        private IDMailSablonu _IDMailSablonu25;

        public IDMailSablonu IDMailSablon25
        {
            get
            {
                _IDMailSablonu25 = new IDMailSablonu()
                {
                    Baslik = db.MailKaliplaris.Where((e) => e.Sira == 25).First().Baslik,
                    Icerik = db.MailKaliplaris.Where((e) => e.Sira == 25).First().Detay
                };
                return _IDMailSablonu25;
            }
            set { _IDMailSablonu25 = value; }
        }



        private IDMailSablonu _IDMailSablonu26;


        public IDMailSablonu IDMailSablon26
        {
            get
            {
                _IDMailSablonu26 = new IDMailSablonu()
                {
                    Baslik = db.MailKaliplaris.Where((e) => e.Sira == 26).First().Baslik,
                    Icerik = db.MailKaliplaris.Where((e) => e.Sira == 26).First().Detay
                };
                return _IDMailSablonu26;
            }
            set { _IDMailSablonu26 = value; }
        }

        private IDMailSablonu _IDMailSablonu27;


        public IDMailSablonu IDMailSablon27
        {
            get
            {
                _IDMailSablonu27 = new IDMailSablonu()
                {
                    Baslik = db.MailKaliplaris.Where((e) => e.Sira == 27).First().Baslik,
                    Icerik = db.MailKaliplaris.Where((e) => e.Sira == 27).First().Detay
                };
                return _IDMailSablonu27;
            }
            set { _IDMailSablonu27 = value; }
        }


        private IDMailSablonu _IDMailSablonu28;


        public IDMailSablonu IDMailSablon28
        {
            get
            {
                IDMailSablon28 = new IDMailSablonu()
                {
                    Baslik = db.MailKaliplaris.Where((e) => e.Sira == 28).First().Baslik,
                    Icerik = db.MailKaliplaris.Where((e) => e.Sira == 28).First().Detay
                };
                return IDMailSablon28;
            }
            set { IDMailSablon28 = value; }
        }

        private IDMailSablonu _IDMailSablonu29;


        public IDMailSablonu IDMailSablon29
        {
            get
            {
                _IDMailSablonu29 = new IDMailSablonu()
                {
                    Baslik = db.MailKaliplaris.Where((e) => e.Sira == 29).First().Baslik,
                    Icerik = db.MailKaliplaris.Where((e) => e.Sira == 29).First().Detay
                };
                return _IDMailSablonu29;
            }
            set { _IDMailSablonu29 = value; }
        }


        private IDMailSablonu _IDMailSablonu30;


        public IDMailSablonu IDMailSablon30
        {
            get
            {
                _IDMailSablonu30 = new IDMailSablonu()
                {
                    Baslik = db.MailKaliplaris.Where((e) => e.Sira == 30).First().Baslik,
                    Icerik = db.MailKaliplaris.Where((e) => e.Sira == 30).First().Detay
                };
                return _IDMailSablonu30;
            }
            set { _IDMailSablonu30 = value; }
        }


        private IDMailSablonu _IDMailSablonu31;


        public IDMailSablonu IDMailSablon31
        {
            get
            {
                _IDMailSablonu31 = new IDMailSablonu()
                {
                    Baslik = db.MailKaliplaris.Where((e) => e.Sira == 31).First().Baslik,
                    Icerik = db.MailKaliplaris.Where((e) => e.Sira == 31).First().Detay
                };
                return _IDMailSablonu31;
            }
            set { _IDMailSablonu31 = value; }
        }


        private IDMailSablonu _IDMailSablonu32;


        public IDMailSablonu IDMailSablon32
        {
            get
            {
                _IDMailSablonu32 = new IDMailSablonu()
                {
                    Baslik = db.MailKaliplaris.Where((e) => e.Sira == 32).First().Baslik,
                    Icerik = db.MailKaliplaris.Where((e) => e.Sira == 32).First().Detay
                };
                return _IDMailSablonu32;
            }
            set { _IDMailSablonu32 = value; }
        }



        private IDMailSablonu _IDMailSablonu33;


        public IDMailSablonu IDMailSablon33
        {
            get
            {
                _IDMailSablonu33 = new IDMailSablonu()
                {
                    Baslik = db.MailKaliplaris.Where((e) => e.Sira == 33).First().Baslik,
                    Icerik = db.MailKaliplaris.Where((e) => e.Sira == 33).First().Detay
                };
                return _IDMailSablonu33;
            }
            set { _IDMailSablonu33 = value; }
        }
        private IDMailSablonu _IDMailSablonu34;


        public IDMailSablonu IDMailSablon34
        {
            get
            {
                _IDMailSablonu34 = new IDMailSablonu()
                {
                    Baslik = db.MailKaliplaris.Where((e) => e.Sira == 34).First().Baslik,
                    Icerik = db.MailKaliplaris.Where((e) => e.Sira == 34).First().Detay
                };
                return _IDMailSablonu34;
            }
            set { _IDMailSablonu34 = value; }
        }


        private IDMailSablonu _IDMailSablonu35;
        public IDMailSablonu IDMailSablon35
        {
            get
            {
                _IDMailSablonu35 = new IDMailSablonu()
                {
                    Baslik = db.MailKaliplaris.Where((e) => e.Sira == 35).First().Baslik,
                    Icerik = db.MailKaliplaris.Where((e) => e.Sira == 35).First().Detay
                };
                return _IDMailSablonu35;
            }
            set { _IDMailSablonu35 = value; }
        }

        private IDMailSablonu _IDMailSablonu36;
        public IDMailSablonu IDMailSablon36
        {
            get
            {
                _IDMailSablonu36 = new IDMailSablonu()
                {
                    Baslik = db.MailKaliplaris.Where((e) => e.Sira == 36).First().Baslik,
                    Icerik = db.MailKaliplaris.Where((e) => e.Sira == 36).First().Detay
                };
                return _IDMailSablonu36;
            }
            set { _IDMailSablonu36 = value; }
        }


    }

    public class IDMailSablonu
    {
        public string Isim { get; set; }
        public string Icerik { get; set; }
        public string Baslik { get; set; }
    }
}