using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Visma_Restaurant.Classes;

namespace Visma_Restaurant.Classes
{
    class Order
    {
        public int id { get; set; }
        public DateTime date { get; set; }
        public List<Item> menuItems { get; set; }



        public Order(int id)
        {
            this.id = id;
            menuItems = new List<Item>();
        }
        public Order(int id,List<Item> menuItems)
        {
            this.id = id;
            date = DateTime.Now;
            this.menuItems = menuItems;
        }
        public Order(int id, DateTime date, List<Item> menuItems)
        {
            this.id = id;
            this.date = date;
            this.menuItems = menuItems;
        }

        internal string toString()
        {
            string itemS = null;
            foreach (Item item in menuItems)
            {
                itemS += " " + item.id;
            }

            return id + " " + date+" " + itemS ;
        }

        internal string toStringFile()
        {
            string itemS = null;
            foreach (Item item in menuItems)
            {
                itemS +=item.id+" ";
            }

            return id + "," + date + "," + itemS.Remove(itemS.Length - 1);
        }
    }
}
