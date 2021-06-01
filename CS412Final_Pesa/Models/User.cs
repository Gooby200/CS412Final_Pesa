using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CS412Final_Pesa.Models {
    [Serializable]
    public class User {
        public int Id { get; set; }
        public string First { get; set; }
        public string Last { get; set; }
    }
}