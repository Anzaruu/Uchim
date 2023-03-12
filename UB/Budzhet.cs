using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UB
{
    internal class Budzhet
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public int Money 
        {
            get { return Money; }
            set
            {
                Money = value;
                if(value>0) IsPlus= true;
                else IsPlus= false;
            }
        }
        public bool IsPlus { get; set; }
        public DateTime Date { private get; set; }

        public DateTime GetDate()
        {
            return Date;
        }
    }
}
