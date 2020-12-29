using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Visma_Restaurant.Classes;

namespace Visma_Restaurant
{
    class Program
    {

        static void Main(string[] args)
        {

            StockContainer container = new StockContainer();
            Menu menu = new Menu();
            OrderList orderList = new OrderList();


            Services.File.updateStockUsingFileData(container, Services.File.readFile("Stock.txt"));
            Services.File.updateMenuUsingFileData(menu, Services.File.readFile("Menu.txt"), container);
            Services.File.updateOrdersUsingFileData(orderList, Services.File.readFile("Orders.txt"), menu);


            while (true)
            {

                Console.WriteLine("________________________________________________");
                Console.WriteLine("Choose an operation:\n 1. Show product list \n 2. Add new product \n 3. Restock products \n 4. Update existing product \n 5. Remove product \n 6. Print Menu \n 7. Add menu items \n 8. Update menu item info \n 9. Delete menu item \n 10. New Order \n 11. Check orders \n 0. End program\n");
                int caseSwitch = Int32.Parse(Console.ReadLine());


                switch (caseSwitch)
                {
                    case 1:
                        Cases.PrintProductList(container);
                        break;
                    case 2:
                        Cases.AddNewProduct(container);
                        break;

                    case 3:
                        Cases.RestockProduct(container);
                        break;

                    case 4:
                        Cases.UpdateExistingProduct(container);
                        break;
                    case 5:
                        Cases.RemoveExistingProduct(container);
                        break;

                    case 6:
                        Cases.PrintItemList(menu);
                        break;

                    case 7:
                        Cases.AddMenuItem(menu, container);
                        break;
                    case 8:
                        Cases.UpdateMenuItem(menu, container);
                        break;
                    case 9:
                        Cases.DeleteMenuItem(menu);
                        break;
                    case 10:
                        Cases.NewOrder(menu, container, orderList);
                        break;
                    case 11:
                        Cases.PrintOrders(orderList);
                        break;

                    case 0:
                        Services.File.writeStocRecord(container.ProductList, "Stock.txt");
                        Services.File.writeMenuRecord(menu.menuItems, "Menu.txt");
                        Services.File.writeOrdersRecord(orderList.orderList, "Orders.txt");
                        return;

                    default:
                        Console.WriteLine("Default case");
                        break;
                }
                Console.WriteLine();
            }

        }


    }
}
