using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Visma_Restaurant.Classes;

namespace Visma_Restaurant.Services
{
    class Utility
    {
        public static void printProductList(List<Product> list)
        {
            for (int i = 0; i < list.Count(); i++)
            {
                Console.WriteLine(list[i].toString());
            }

        }

        public static void printItemList(List<Item> menuItems)
        {

            for (int i = 0; i < menuItems.Count(); i++)
            {
                Console.WriteLine(menuItems[i].toString());
            }
        }

        public static List<Product> BuildProductAddList(string chosenId, StockContainer container)
        {
            List<Product> productAddList = new List<Product>();
            string[] splitId = chosenId.Split(' ');
            string[] uniqueId = splitId.Distinct().ToArray();
            foreach (string productId in uniqueId)
            {
                foreach (Product prod in container.ProductList)
                {
                    int integerId = Int32.Parse(productId);
                    if (integerId == prod.id)
                    {
                        productAddList.Add(prod);
                    }
                }
            }
            return productAddList;
        }

        internal static List<Product> BuildAddItemList(string chosenId, StockContainer container)
        {
            List<Product> productAddList = new List<Product>();
            string[] splitId = chosenId.Split(' ');
            string[] uniqueId = splitId.Distinct().ToArray();
            foreach (string productId in uniqueId)
            {
                foreach (Product prod in container.ProductList)
                {
                    int integerId = Int32.Parse(productId);
                    if (integerId == prod.id)
                    {
                        productAddList.Add(prod);
                    }
                }
            }
            return productAddList;
        }


        internal static List<int> BuildOrderItemProductList(string chosenId, Menu menu)
        {
            List<int> productList = new List<int>();
            string[] splitId = chosenId.Split(' ');
            foreach (string itemId in splitId)
            {
                foreach (Item item in menu.menuItems)
                {
                    int integerId = Int32.Parse(itemId);
                    if (integerId == item.id)
                    {
                        foreach (Product itemProd in item.ingredients)
                        {
                            productList.Add(itemProd.id);
                        }

                    }
                }
            }
            return productList;
        }

        internal static IDictionary<int, int> DeductOrderProductsFromProductList(List<int> orderProducts)
        {
            IDictionary<int, int> numberNames = new Dictionary<int, int>();

            int[] uniqueId = orderProducts.Distinct().ToArray();
            foreach (int i in uniqueId)
            {
                numberNames.Add(i, 0);
                foreach (int id in orderProducts)
                {
                    if (id == i) numberNames[i] = (numberNames[i]) + 1;
                }
            }

            return numberNames;
        }

        internal static void printOrdersList(List<Order> orderList)
        {
            for (int i = 0; i < orderList.Count(); i++)
            {
                Console.WriteLine(orderList[i].toString());
            }
        }

        internal static bool CheckIfEnoughProducts(IDictionary<int, int> productCount, List<Product> productList)
        {
            foreach (Product allProd in productList)
            {
                foreach (KeyValuePair<int, int> pair in productCount)
                {
                    if (allProd.id == pair.Key)
                    {
                        if (allProd.portionCount < pair.Value) return false;
                    }
                }


            }
            return true;
        }

        internal static List<Item> BuildOrderItemsList(string chosenId, Menu menu)
        {
            List<Item> orderItemsList = new List<Item>();
            string[] splitId = chosenId.Split(' ');
            foreach (string itemId in splitId)
            {
                foreach (Item item in menu.menuItems)
                {
                    int integerId = Int32.Parse(itemId);
                    if (integerId == item.id)
                    {

                        orderItemsList.Add(item);

                    }
                }
            }
            return orderItemsList;
        }

        internal static bool AddNewOrder(bool enoughProducts, List<Item> orderItems, IDictionary<int, int> productCount, List<Product> productList, OrderList orders, int id)
        {
            if (enoughProducts == false) return false;

            foreach (Product allProd in productList)
            {
                foreach (KeyValuePair<int, int> pair in productCount)
                {
                    if (allProd.id == pair.Key)
                    {
                        allProd.portionCount -= pair.Value;
                    }
                }
            }
            orders.AddOrderToList(new Order(id, orderItems));
            return true;
        }
    }
}
