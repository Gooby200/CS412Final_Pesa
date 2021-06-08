using CS412Final_Pesa.Repositories;
using CS412Final_Pesa.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CS412Final_Pesa {
    public partial class Example4 : System.Web.UI.Page {
        private readonly IError _error = new Error();
        protected void Page_Load(object sender, EventArgs e) {
            //forLoopExample();
            //forLoopExample2();
            //greet();

            //helloworld();
        }

        private void helloworld() {
            try {
                throw new IndexOutOfRangeException();
                throw new DivideByZeroException();
            } catch (Exception ex) {

            }
        }

        private string greet() {
            return say() + hello();
        }

        private string say() {
            return "hello";
        }

        private string hello() {
            return "world";
        }

        private void forLoopExample() {
            int y = 0;
            for (int x = 0; x < 5; x++) {
                if (x == 4) {
                    int z = x / 0;
                    y = x;
                }
            }
        }

        private void forLoopExample2() {
            int y = 0;
            for (int x = 0; x < 5; x++) {
                if (x == 4) {
                    try {
                        int z = x / 0; //imagine 0 is a user input and out of your control
                        y = x;
                    } catch (Exception ex) {
                        _error.Log(ex);
                    }
                }
            }
        }

        public int performDivision(int x, int y) {
            try {
                return x / y;
            } catch (DivideByZeroException ex) {
                throw ex;
            } catch (Exception ex) {
                throw ex;
            }
        }
    }
}