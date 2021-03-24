using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class BaseClass
    {
        public void TryCatchKullan(Action _action)
        {
            try
            {
                _action();
            }
            catch (Exception ex)
            {

                //Loglama islemleri burada olacak
            }
        }
    }
}
