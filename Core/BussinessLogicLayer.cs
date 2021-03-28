using Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    
    public class BussinessLogicLayer:BaseClass
    {
        DatabaseLogicLayer DLL;

        public BussinessLogicLayer()
        {
            DLL = new DatabaseLogicLayer();
        }

        public List<ParaBirimi> ParaBirimiListesi() // DLL icindeki ParaBirimiListesi methodunun fonksiyonlarini burada dolduruyoruz.
        {
            List<ParaBirimi> ParaBirimleri = new List<ParaBirimi>(); // en son return ile gonderecegimiz parabirimi listesi olusturuyoruz.

            SqlDataReader reader = DLL.ParaBirimiListesi(); // dll icindeki parabirimilistesini reader ile okutuyoruz.
            while (reader.Read())
            {
                ParaBirimleri.Add(new ParaBirimi() // while reader read yeni listemizin icini dolduruyoruz.
                {
                ID=reader.IsDBNull(0)?Guid.Empty:reader.GetGuid(0), // if reader 0. indexi empty degilse o zaman o 0. indexteki degeri al.
                 Code=reader.IsDBNull(1)?string.Empty:reader.GetString(1),
                  Tanim=reader.IsDBNull(2)?string.Empty:reader.GetString(2),
                   UyariLimit=reader.IsDBNull(3)?0:reader.GetDecimal(3)
                
                
                });
            }
            reader.Close(); //readerimizi bitirdik
            DLL.BaglantiIslemleri();//sql connectinimizi kapatiyoruz.
            return ParaBirimleri; //olusturdugumuz parabirimleri listemizi return donuyoruz.
        }
        public List<Kur> KurListe()
        { 
        List<Kur> KurDegerleri = new List<Kur>();

        SqlDataReader reader = DLL.KurListe();
            while (reader.Read())
            {
                KurDegerleri.Add(new Kur()
                {
                    ID = reader.IsDBNull(0) ? Guid.Empty : reader.GetGuid(0),
                    ParaBirimiID = reader.IsDBNull(1) ? Guid.Empty : reader.GetGuid(1),
                    Alis = reader.IsDBNull(2) ? 0 : reader.GetDecimal(2),
                     Satis= reader.IsDBNull(3) ? 0 : reader.GetDecimal(3),
                      OlusturmaTarihi=reader.IsDBNull(4) ? DateTime.MinValue : reader.GetDateTime(4)

                });
            }
            reader.Close();
            DLL.BaglantiIslemleri();
            return KurDegerleri;
        }
        public Kur KurListe(Guid ParaBirimiID) // huston we might need to chcek here again !!!!!
        {
            Kur Kur = new Kur();

            SqlDataReader reader = DLL.KurListe();
            while (reader.Read())
            {
                Kur = new Kur()
                {
                    ID = reader.IsDBNull(0) ? Guid.Empty : reader.GetGuid(0),
                    ParaBirimiID = reader.IsDBNull(1) ? Guid.Empty : reader.GetGuid(1),
                    Alis = reader.IsDBNull(2) ? 0 : reader.GetDecimal(2),
                    Satis = reader.IsDBNull(3) ? 0 : reader.GetDecimal(3),
                    OlusturmaTarihi = reader.IsDBNull(4) ? DateTime.MinValue : reader.GetDateTime(4)

                };
            }
            reader.Close();
            DLL.BaglantiIslemleri();
            return Kur;
        }

        public List<KurGecmis> KurGecmisListe() 
        {
            List<KurGecmis> KurGecmisListe = new List<KurGecmis>();
            SqlDataReader reader = DLL.KurGecmisListe();
            while (reader.Read())
            {
                KurGecmisListe.Add(new KurGecmis()
                {
                    ID = reader.IsDBNull(0) ? Guid.Empty : reader.GetGuid(0),
                    KurID = reader.IsDBNull(1) ? Guid.Empty : reader.GetGuid(1),
                    ParaBirimiID = reader.IsDBNull(2) ? Guid.Empty : reader.GetGuid(2),
                    Alis = reader.IsDBNull(3) ? 0 : reader.GetDecimal(3),
                    Satis = reader.IsDBNull(4) ? 0 : reader.GetDecimal(4),
                    OlusturmaTarihi = reader.IsDBNull(5) ? DateTime.MinValue : reader.GetDateTime(5)

                });

            }
            reader.Close();
            DLL.BaglantiIslemleri();
            return KurGecmisListe;

        }

        public List<KurGecmis> KurGecmisListe(Guid ParaBirimiID)
        {
            List<KurGecmis> KurGecmisListe = new List<KurGecmis>();
            SqlDataReader reader = DLL.KurGecmisListe(ParaBirimiID);
            while (reader.Read())
            {
                KurGecmisListe.Add(new KurGecmis()
                {
                    ID = reader.IsDBNull(0) ? Guid.Empty : reader.GetGuid(0),
                    KurID = reader.IsDBNull(1) ? Guid.Empty : reader.GetGuid(1),
                    ParaBirimiID = reader.IsDBNull(2) ? Guid.Empty : reader.GetGuid(2),
                    Alis = reader.IsDBNull(3) ? 0 : reader.GetDecimal(3),
                    Satis = reader.IsDBNull(4) ? 0 : reader.GetDecimal(4),
                    OlusturmaTarihi = reader.IsDBNull(5) ? DateTime.MinValue : reader.GetDateTime(5)

                });

            }
            reader.Close();
            DLL.BaglantiIslemleri();
            return KurGecmisListe;

        }


        public void KurKayitEKLE(Guid ID, Guid ParaBirimiID, decimal Alis, decimal Satis, DateTime OlusturmaTarihi)
        {
            if (ID != Guid.Empty && ParaBirimiID != Guid.Empty && Alis != 0 && Satis != 0 && OlusturmaTarihi > DateTime.MinValue)
            {
                DLL.KurKayitEKLE(new Kur()
                {
                    ID = ID,
                    ParaBirimiID = ParaBirimiID,
                    Alis = Alis,
                    Satis = Satis,
                    OlusturmaTarihi = OlusturmaTarihi
                });
            }
            else
            {
                //ekleme islemi gerceklesmedi
            }

            
        }


    }
}
