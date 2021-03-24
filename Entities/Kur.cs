using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
   public class Kur
    {
        public Guid ID { get; set; }
        public Guid ParaBirimiID { get; set; }
        public decimal Alis { get; set; }
        public decimal Satis { get; set; }
        public DateTime OlusturmaTarihi { get; set; }
    }
}
