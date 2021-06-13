using CS412Final_Pesa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS412Final_Pesa.BLL.Interfaces {
    public interface IOrderBLL {
        decimal GetMoneyCollected();

        List<Order> GetOrders();
    }
}
