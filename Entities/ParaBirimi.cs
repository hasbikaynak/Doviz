using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
   public class ParaBirimi
    {
        public Guid ID { get; set; }
        public Guid ParaBirimiID{ get; set; }
        public string Code{ get; set; }
        public string Tanim { get; set; }
        public decimal UyariLimit { get; set; }
        
    }
}
