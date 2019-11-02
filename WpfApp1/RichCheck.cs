using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    class RichCheck:ICheck
    {
        public bool CanCheck(Object obj)
        {
            return (obj is Phone && (obj as Phone).Cost>=20000);
             
        }



        public bool Check(Object phone)
        {
            return !((phone as Phone).Count >1);

        }
    }
}
