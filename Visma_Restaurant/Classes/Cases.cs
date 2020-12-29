using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using Visma_Restaurant.Classes;

namespace Visma_Restaurant.Classes
{
    class Cases
    {

        internal static void AddNewProduct(StockContainer container)
        {
            Console.WriteLine("Enter product id");
            int id = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Enter product name");
            string name = Console.ReadLine();
            Console.WriteLine("Enter product portion ");
            int portion = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Enter product measurment unit ");
            string unit = Console.ReadLine();
            Console.WriteLine("Enter product portion size ");
            double portionSize = Double.Parse(Console.ReadLine());

            if(container.AddProductToList(new Product(id, name, portion, unit, portionSize))==true) Console.WriteLine("Succesfully added new product");
            else Console.WriteLine("ID is taken");

        }

        internal static void UpdateExistingProduct(StockContainer container)
        {
            Services.Utility.printProductList(container.ProductList);
            Console.WriteLine("Type in product id:");
            int chosenId = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Enter new product name");
            string name = Console.ReadLine();
            Console.WriteLine("Enter new product portion ");
            int portionCount = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Enter new product measurment unit ");
            string unit = Console.ReadLine();
            Console.WriteLine("Enter new product portion size ");
            double portionSize = Double.Parse(Console.ReadLine());
            container.UpdateProduct(chosenId, name, portionCount, unit, portionSize);
            Console.WriteLine("Product with id: " + chosenId + " updated");
        }

        internal static void PrintItemList(Menu menu)
        {
            Console.Write("Existing menu item list: \n");
            Services.Utility.printItemList(menu.menuItems);
        }

        internal static void UpdateMenuItem(Menu menu, StockContainer container)
        {
            Console.Write("Existing menu item list: \n");
            Services.Utility.printItemList(menu.menuItems);
            Console.WriteLine("Updatable menu item id:");
            int id = Int32.Parse(Console.ReadLine());
            Console.WriteLine("New menu item name:");
            string name = Console.ReadLine();
            Console.WriteLine("Type in ingriedient id's(use space to separate them):");
            Services.Utility.printProductList(container.ProductList);
            string chosenId = Console.ReadLine();
            menu.UpdateMenuItem(id, name, Services.Utility.BuildProductAddList(chosenId, container));
        }

        internal static void PrintOrders(OrderList orderList)
        {
            Console.Write("Existing menu item list: \n");
            Services.Utility.printOrdersList(orderList.orderList);
        }

        internal static void NewOrder(Menu menu, StockContainer container, OrderList orderList)
        {
            Console.WriteLine("Enter order id");
            int id = Int32.Parse(Console.ReadLine());
            Console.Write("Existing menu item list: \n");
            Services.Utility.printItemList(menu.menuItems);
            Console.WriteLine("Choose items to order(use space to list items):");
            string chosenId = Console.ReadLine();
            List<Item> orderItems =Services.Utility.BuildOrderItemsList(chosenId, menu);
            List<int> orderProducts =Services.Utility.BuildOrderItemProductList(chosenId, menu);
           
            IDictionary<int,int> productCount =Services.Utility.DeductOrderProductsFromProductList(orderProducts);
            bool enoughProducts =Services.Utility.CheckIfEnoughProducts(productCount, container.ProductList);
            if (Services.Utility.AddNewOrder(enoughProducts,orderItems, productCount, container.ProductList, orderList, id)) Console.WriteLine("Order taken!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            else Console.WriteLine("Order declined !!!!!!!!!!!!!!!!!!!!!!");

        }

        internal static void DeleteMenuItem(Menu menu)
        {
            Console.Write("Existing menu item list: \n");
            Services.Utility.printItemList(menu.menuItems);
            Console.WriteLine("Choose menu items id:");
            int id = Int32.Parse(Console.ReadLine());
            menu.DeleteItem(id);
        }

        internal static void AddMenuItem(Menu menu, StockContainer container)
        {
            Console.WriteLine("Menu item id:");
            int id = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Menu item name:");
            string name = Console.ReadLine();
            Console.WriteLine("Type in ingriedient id's(use space to separate them):");
            Services.Utility.printProductList(container.ProductList);
            string chosenId = Console.ReadLine();
            menu.AddItemToMenu(new Item(id, name, Services.Utility.BuildAddItemList(chosenId, container)));


        }

        internal static void PrintProductList(StockContainer container)
        {
            Console.Write("Existing products list: \n");
            Services.Utility.printProductList(container.ProductList);
        }

        internal static void RestockProduct(StockContainer container)
        {
            Services.Utility.printProductList(container.ProductList);
            Console.WriteLine("Type in product id:");
            int chosenId = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Choose restocking method: \n 1. Restock with portions \n 2. Restock with product weight");
            int caseSwitch = Int32.Parse(Console.ReadLine());


            switch (caseSwitch)
            {
                case 1:
                    Console.WriteLine("Type in restocakble unit count:");
                    int count = Int32.Parse(Console.ReadLine());
                    container.RestockWithPortions(chosenId, count);
                    Console.WriteLine("Product with id: " + chosenId + " restocked by: " + count + " portions");
                    break;

                case 2:
                    Console.WriteLine("Type in restocakble weight:");
                    double weight = double.Parse(Console.ReadLine());
                    int portions = container.RestockWithWeight(chosenId, weight);
                    Console.WriteLine("Product with id: " + chosenId + " restocked by: " + portions + " portions");

                    break;


                default:
                    Console.WriteLine("Default case");
                    break;
            }

        }

        internal static void RemoveExistingProduct(StockContainer container)
        {
            Services.Utility.printProductList(container.ProductList);
            Console.WriteLine("Type in product id");
            int chosenId = Int32.Parse(Console.ReadLine());
            if (container.RemoveProduct(chosenId) == true) Console.WriteLine("Product with id: " + chosenId + " removed");
            else Console.WriteLine("Product wasnt removed");
            
        }
    }
}
