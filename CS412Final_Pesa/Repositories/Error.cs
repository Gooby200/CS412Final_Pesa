using CS412Final_Pesa.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CS412Final_Pesa.Repositories {
    public class Error : IError {
        public bool Log(Exception ex) {
            // log error to the database
            return false;
        }
    }
}