using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace IDCrm.Models
{
    public class IDVeritabani
    {

        
        //public static string baglanti = "Server=94.73.172.230;Database=u3137601_crm;Uid=u3137601_crm;Pwd=WDal58Z0SFyu33D;";
        public static string baglanti = ConfigurationManager.ConnectionStrings["Baglanti"].ConnectionString;
        public static object Sorgula(SqlCommand cmd, SorgulaTuru tip )
        {
            object sonuc = null;

            using (SqlConnection baglanti = new SqlConnection(IDVeritabani.baglanti))
            {
                baglanti.Open();
                cmd.Connection = baglanti;
                cmd.CommandTimeout = 300;

                switch (tip)
                {
                    case SorgulaTuru.Bos:
                        return cmd.ExecuteNonQuery();
                        break;
                    case SorgulaTuru.Tek:
                        return cmd.ExecuteScalar();
                        break;
                    case SorgulaTuru.Tablo:
                        DataTable dt = new DataTable();
                        SqlDataAdapter adapter = new SqlDataAdapter();
                        adapter.SelectCommand = cmd;
                        adapter.SelectCommand.CommandTimeout = 30;
                        adapter.Fill(dt);
                        return dt;
                        break;
                    case SorgulaTuru.DataSet:
                        DataSet ds = new DataSet();
                        SqlDataAdapter adapter2 = new SqlDataAdapter();
                        adapter2.SelectCommand = cmd;
                        adapter2.SelectCommand.CommandTimeout = 60;
                        adapter2.Fill(ds);
                        return ds;
                        break;
                }
            }


            return sonuc;
        }
    }

    public enum SorgulaTuru
    {
        Bos,
        Tek,
        Tablo,
        DataSet
    }
}