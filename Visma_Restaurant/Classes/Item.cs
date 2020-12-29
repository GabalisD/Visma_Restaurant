using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Visma_Restaurant.Classes;

namespace Visma_Restaurant.Classes
{
    class Item
    {
        public int id { get; set; }
        public string name { get; set; }
        public List<Product> ingredients { get; set; }

        public Item(int id, string name, List<Product> ingredients)
        {
            this.id = id;
            this.name = name;
            this.ingredients = ingredients;
            
        }
        public Item(int id, string name)
        {
            this.id = id;
            this.name = name;
            ingredients = new List<Product>();

        }

        public bool AddIngredient(Product product)
        {   
            for(int i=0;i<ingredients.Count();i++)
            {
                if (ingredients[i].id == product.id) return false;
            }
            ingredients.Add(product);
            return true;
        }

        public string toString()
        {
            string ingriedientS = null;
            foreach (Product product in ingredients)
            {
                ingriedientS += " " +product.id;
            }

            return id + " " + name + ingriedientS;
        }
        public string toStringFile()
        {
            string ingriedientS = null;
            foreach (Product product in ingredients)
            {
                ingriedientS += product.id+" ";
            }

            return id + "," + name +","+ ingriedientS.Remove(ingriedientS.Length - 1); 
        }
    }
}
