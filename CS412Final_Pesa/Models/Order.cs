using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CS412Final_Pesa.Models {
    [Serializable]
    public class Order {
        public long Id { get; set; }
        public User Customer { get; set; }
        public DateTime ServiceDate { get; set; }
        public List<Service> Services { get; set; }
        public decimal Total => Services.Sum(x => x.Price);
    }
}