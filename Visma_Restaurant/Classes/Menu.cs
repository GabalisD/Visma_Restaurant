using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visma_Restaurant.Classes
{
    class Menu
    {
        public List<Item> menuItems { get; set; }

        public Menu()
        {
            menuItems = new List<Item>();
        }

        public bool AddItemToMenu(Item item)
        {
            for (int i = 0; i < menuItems.Count(); i++)
            {
                if (menuItems[i].id == item.id) return false;
            }
            menuItems.Add(item);
            return true;
        }

        public void UpdateMenuItem(int id, string name, List<Product> products)
        {
            for (int i = 0; i < menuItems.Count(); i++)
            {
                if (id == menuItems[i].id)
                {
                    menuItems[i].name = name;
                    menuItems[i].ingredients = products;

                }

            }
        }

        public void DeleteItem(int id)
        {
            for (int i = 0; i < menuItems.Count(); i++)
            {
                if (id == menuItems[i].id)
                {
                    menuItems.RemoveAt(i);
                }
            }
        }
    }

}
