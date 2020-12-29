using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visma_Restaurant.Classes
{
    class OrderList
    {
        public List<Order> orderList { get; set; }


        public OrderList()
        {
            orderList = new List<Order>();
        }

        public bool AddOrderToList(Order order)
        {
            for (int i = 0; i < orderList.Count(); i++)
            {
                if (orderList[i].id == order.id) return false;
            }
            orderList.Add(order);
            return true;

        }
    }
}
