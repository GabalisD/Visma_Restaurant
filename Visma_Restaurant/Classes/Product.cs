using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visma_Restaurant.Classes
{
    class Product
    {
        public int id { get; set; }
        public string name { get; set; }
        public int portionCount { get; set; }
        public string unit { get; set; }
        public double portionSize { get; set; }


        public Product(int id,string name, int portionCount,string unit, double portionSize)
        {
            this.id = id;
            this.name = name;
            this.portionCount = portionCount;
            this.unit = unit;
            this.portionSize = portionSize;
            
        }

        public string toString()
        {
            return id+ " "+name+' '+portionCount+" "+unit+" "+portionSize;
        }



    }


}
