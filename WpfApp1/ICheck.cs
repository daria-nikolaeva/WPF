using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    interface ICheck
    {
        bool CanCheck(Object obj);
        bool Check(Object phone);
    }
}
