using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS412Final_Pesa.Repositories.Interfaces {
    interface IError {
        bool Log(Exception ex);
    }
}
