using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Threading.Tasks;
using Visma_Restaurant.Classes;

namespace Visma_Restaurant.Services
{
    class File
    {
        public static void writeStocRecord(List<Product> list, string filepath)
        {
            try
            {
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@filepath, false))
                {
                    foreach (Product prod in list)
                    {
                        file.WriteLine(prod.id + "," + prod.name + "," + prod.portionCount + "," + prod.unit + "," + prod.portionSize);
                    }
                }

            }
            catch (Exception ex)
            {
                throw new ApplicationException("error", ex);
            }
        }

        internal static void updateOrdersUsingFileData(OrderList orderslist, string[] dataLines, Menu menu)
        {
            foreach (string line in dataLines)
            {
                string[] data = line.Split(',');
                List<Item> orderItems = Utility.BuildOrderItemsList(data[2], menu);
                DateTime date = DateTime.Parse(data[1]);
                Order order = new Order(Int32.Parse(data[0]), date, orderItems);

                orderslist.AddOrderToList(order);
            }
        }

        internal static void updateMenuUsingFileData(Menu menu, string[] dataLines, StockContainer container)
        {
            if (dataLines == null) return;
            foreach (string line in dataLines)
            {
                string[] data = line.Split(',');


                List<Product> prod = Utility.BuildAddItemList(data[2], container);
                Item item = new Item(Int32.Parse(data[0]), data[1], prod);

                menu.AddItemToMenu(item);
            }
        }



        internal static string[] readFile(string filepath)
        {
            try
            {

                string[] dataLines = System.IO.File.ReadAllLines(@filepath);
                return dataLines;

            }

            catch (Exception ex)
            {
                throw new ApplicationException("error", ex);
            }
        }

        internal static void updateStockUsingFileData(StockContainer container, string[] dataLines)
        {
            foreach (string line in dataLines)
            {
                string[] data = line.Split(',');
                Product prod = new Product(Int32.Parse(data[0]), data[1], Int32.Parse(data[2]), data[3], Double.Parse(data[4]));
                container.AddProductToList(prod);
            }
        }

        internal static void writeMenuRecord(List<Item> menuItems, string filepath)
        {
            try
            {
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@filepath, false))
                {
                    foreach (Item item in menuItems)
                    {

                        file.WriteLine(item.toStringFile());
                    }
                }

            }
            catch (Exception ex)
            {
                throw new ApplicationException("error", ex);
            }
        }

        internal static void writeOrdersRecord(List<Order> orderList, string filepath)
        {
            try
            {
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@filepath, false))
                {
                    foreach (Order order in orderList)
                    {

                        file.WriteLine(order.toStringFile());
                    }
                }

            }
            catch (Exception ex)
            {
                throw new ApplicationException("error", ex);
            }
        }
    }

}
