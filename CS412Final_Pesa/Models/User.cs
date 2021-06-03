using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CS412Final_Pesa.Models {
    [Serializable]
    public class User {
        public long Id { get; set; }
        public string First { get; set; }
        public string Last { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public Address Address { get; set; }
    }
}