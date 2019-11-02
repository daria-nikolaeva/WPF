﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace WpfApp1
{
    class CostCheck:ICheck
    {
       
       
        public bool CanCheck(Object obj)
        {
            return obj is Phone;
        }
       

       
        public bool Check(Object phone)
        {
            return (phone as Phone).Cost >= 5000;
           
        }
    }
}
