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
                ID=reader.IsDBNull(0)?Guid.Empty:reader.GetGuid(0),
                 Code=reader.IsDBNull(1)?string.Empty:reader.GetString(1),
                  Tanim=reader.IsDBNull(2)?string.Empty:reader.GetString(2),
                   UyariLimit=reader.IsDBNull(3)?0:reader.GetDecimal(3)
                
                
                });
            }
            reader.Close(); //readerimizi bitirdik
            DLL.BaglantiIslemleri();//sql connectinimizi kapatiyoruz.
            return ParaBirimleri; //olusturdugumuz parabirimleri listemizi return donuyoruz.
        }
    }
}
