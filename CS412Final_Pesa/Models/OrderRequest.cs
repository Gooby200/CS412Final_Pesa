using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CS412Final_Pesa.Models {
    public class OrderRequest {
        public Order Order { get; set; }
        public List<long> ServiceIds { get; set; }
    }
}