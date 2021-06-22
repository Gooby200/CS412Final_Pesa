using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CS412Final_Pesa.Models {
    [Serializable]
    public class Order {
        public long Id { get; set; }
        public string CustomerName { get; set; }
        public DateTime ServiceDate { get; set; }
        public List<Service> Services { get; set; }
        public decimal PaidAmount { get; set; }
        public User OrderedBy { get; set; }
        public decimal Total => Services == null ? 0M : Services.Sum(x => x.Price);
        public Order() {
            Services = new List<Service>();
        }
    }
}