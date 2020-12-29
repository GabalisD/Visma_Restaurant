using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 

namespace Visma_Restaurant.Classes
{
    class StockContainer
    {
        public List<Product> ProductList  {get; set;}


        public StockContainer()
        {
            ProductList = new List<Product>();
        }

        public StockContainer(List<Product> ProductList)
        {
            this.ProductList = ProductList;
        }


        public bool AddProductToList(Product product)
        {
            for (int i = 0; i < ProductList.Count(); i++)
            {
                if (ProductList[i].id == product.id) return false;
            }
            ProductList.Add(product);
            return true;
            
        }

        public void UpdateProduct(int chosenId, string name, int portionCount, string unit, double portionSize)
        {
            for (int i = 0; i <ProductList.Count(); i++)
            {
                if (chosenId ==ProductList[i].id)
                {
                    ProductList[i].name = name;
                    ProductList[i].portionCount = portionCount;
                    ProductList[i].unit = unit;
                    ProductList[i].portionSize = portionSize;
                }
            }

        }

        public void RestockWithPortions(int chosenId, int count)
        {
            for (int i = 0; i <ProductList.Count(); i++)
            {
                if (chosenId == ProductList[i].id)
                {
                    ProductList[i].portionCount += count;
                }
            }

        }



        public string toString()
        { string returnString = "";
            for (int i=0; i < ProductList.Count(); i++)
            {
                returnString +=ProductList[i].toString();
            }

            return returnString;
        }

        public int RestockWithWeight(int chosenId, double weight)
        {
            double portions = 0;
            for (int i = 0; i < ProductList.Count(); i++)
            {
                if (chosenId == ProductList[i].id)
                {
                    portions = weight / (ProductList[i].portionSize);
                    ProductList[i].portionCount += (int)portions;
                  
                }

            }

            return (int)portions;

        }

        public bool RemoveProduct(int chosenId)
        {
            for (int i = 0; i < ProductList.Count(); i++)
            {
                if (chosenId == ProductList[i].id)
                {
                    ProductList.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }
    }
}
