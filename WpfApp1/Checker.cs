using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    class Checker
    {
        public delegate void ValidChengedEventHandler(bool isValid);
        public event ValidChengedEventHandler ValidChanged;


        private ICheck[] chekers;
        private Repositories repo;
        private bool isValid;
        public Checker(Repositories repo)
        {
            this.repo = repo;
            chekers = new ICheck[] { new CostCheck(),new RichCheck() };
            repo.CollectionCanged += CheckCollection;
        }
        public void CheckCollection(ArrayList phones)
        {
            isValid = true;
            foreach (Phone phone in phones)
            {
                foreach(ICheck cheker in chekers)
                {
                    if (cheker.CanCheck(phone))
                    {
                        if (!cheker.Check(phone))
                        {
                            isValid = false;

                        }
                    }
               
                }
            }
           
                ValidChanged?.Invoke(isValid);
            

          
        }
    }
}
