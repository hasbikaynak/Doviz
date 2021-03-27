using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class DatabaseLogicLayer : BaseClass //baseclassimizdan kalittik
    {
        SqlConnection con; //oncelikle gerekli sql connection formatlarimizi tanimliyoruz.
        SqlCommand cmd;
        SqlDataReader reader;
        public DatabaseLogicLayer()
        {
            con = new SqlConnection(@"Data Source = OLAF\SQLEXPRESS; Initial Catalog = PhoneBook; Integrated Security = True"); // ctor icerisinde sql baglatimizi kuruyoruz
        }

        public void BaglantiIslemleri() //baglanti islemleri isimli bir metod olusturup acik olan baglantimizi kapatabiliyoruz veya kapali olan baglantimizi acabiliyoruz.
        {
            if (con.State==System.Data.ConnectionState.Open)
            {
                con.Close();
            }
            else
            {
                con.Open();
            }
        }
        public SqlDataReader ParaBirimiListesi()
        {
            TryCatchKullan(() => 
            {
                cmd = new SqlCommand("Select * from ParaBirimi", con);
                BaglantiIslemleri();
                reader =cmd.ExecuteReader();
            });
            return reader;
        }
        public SqlDataReader KurListe()
        {
            TryCatchKullan(() =>
            {
                cmd = new SqlCommand("Select * from Kur", con);
                BaglantiIslemleri();
                reader = cmd.ExecuteReader();
            });
            return reader;
        }
        public SqlDataReader KurListe(Guid ParaBirimiID)
        {
            TryCatchKullan(() =>
            {
                cmd = new SqlCommand("Select * from Kur where ParaBirimiID=@ParaBirimiID", con);
                cmd.Parameters.Add("ParaBirimiID", System.Data.SqlDbType.UniqueIdentifier).Value=ParaBirimiID; 
                BaglantiIslemleri();
                reader = cmd.ExecuteReader();
            });
            return reader;
        }
        public SqlDataReader KurGecmisListe()
        {
            TryCatchKullan(() =>
            {
                cmd = new SqlCommand("Select * from KurGecmis", con);
                BaglantiIslemleri();
                reader = cmd.ExecuteReader();
            });
            return reader;
        }

        public SqlDataReader KurGecmisListe(Guid ParaBirimiID) // these are overload methods
        {
            TryCatchKullan(() =>
            {
                cmd = new SqlCommand("Select * from KurGecmis where ParaBirimiID=@ParaBirimiID", con);
                cmd.Parameters.Add("ParaBirimiID", System.Data.SqlDbType.UniqueIdentifier).Value = ParaBirimiID;
                BaglantiIslemleri();
                reader = cmd.ExecuteReader();
            });
            return reader;
        }

        public SqlDataReader KurKayitEKLE(Kur kur)
        {
            TryCatchKullan(() =>
            {
                cmd = new SqlCommand("KurKayitEKLE", con); // eski yaptigimiz islemlerden hatirlarsak, normalde burada insert into veya update gibi methodlar yazardik ancak burada direk 
                //SQLimde kayitli olan procedure tipli methodumu cagiriyorum.
                cmd.CommandType = System.Data.CommandType.StoredProcedure; //cagirdigim methodun procedure tipli bir method oldugunu sistemime bildirdim.
                cmd.Parameters.Add("@ID", SqlDbType.UniqueIdentifier).Value = kur.ID;       // system.data kismini using olarak baslagica ekledim
                cmd.Parameters.Add("@KurID",SqlDbType.UniqueIdentifier)value = kur.ID
            });
            return reader;
        }
    }
}
