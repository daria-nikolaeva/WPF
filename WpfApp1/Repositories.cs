using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    class Repositories
    {
        public delegate void CollectionCengedEventHandler(ArrayList phones);
        public event CollectionCengedEventHandler CollectionCanged;

      


       private ArrayList phones = new ArrayList();
    
        


        public void Add(Phone phone)
        {
            phones.Add(phone);
            CollectionCanged?.Invoke(phones);
        }
        public void RemoveAt(int index)
        {
            if (index >= 0)
            {
                phones.RemoveAt(index);
                CollectionCanged?.Invoke(phones);
            }
           
        }
        public bool tryGetAt(int index, out Phone phone)
        {
            if (index >= 0 && index<phones.Count)
            {
                phone = phones[index] as Phone;
                return true;
            }
            phone = null;
            return false;
        }

       
    }
       

       
      
    
}
