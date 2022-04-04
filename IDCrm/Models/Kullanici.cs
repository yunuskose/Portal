using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IDCrm.Models
{
    public class Kullanici
    {
        public int SirketID { get; set; }
        public string Sirket { get; set; }

        public int KullaniciID { get; set; }
        public string KullaniciAdi { get; set; }
        public string Parola { get; set; }
        public string Admin { get; set; }
    }
}