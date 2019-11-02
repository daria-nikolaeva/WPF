using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace WpfApp1
{
    class CostCheck
    {
        public delegate void ValidChengedEventHandler(bool isValid);
        public event ValidChengedEventHandler ValidChanged;


        Repositories repo;
       
       

      public CostCheck(Repositories _repo)
        {
            repo = _repo;
           
            repo.CollectionCanged += Check;
        }

        bool? isCostValid = null;
        private void Check(ArrayList phones)
        {
            bool hasCheep = false;
            bool hasRich = false;
            foreach(Phone phone in phones)
            {
                if (phone.Cost < 10000)
                {
                    hasCheep = true;
                }
                if (phone.Cost > 20000)
                {
                    hasRich = true;
                }
            }
     
           if( isCostValid!= (hasCheep && hasRich))
           {
                isCostValid = hasCheep && hasRich;
                ValidChanged?.Invoke((bool)isCostValid);
           }
           
           
        }
    }
}
