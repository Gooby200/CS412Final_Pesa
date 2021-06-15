using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CS412Final_Pesa.Examples {
    public partial class ImageUploadExample : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            if (Page.IsPostBack == false) {
                BindImageRepeater();
            }
        }

        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e) {

        }

        protected void Button1_Click(object sender, EventArgs e) {
            string strFolder = Server.MapPath("./user_images/");
            string strFileName = FileUpload1.PostedFile.FileName;

            //method 1
            FileUpload1.SaveAs(strFolder + strFileName);

            BindImageRepeater();

            //method 2
            //string strFileName = FileUpload1.PostedFile.FileName;
            //strFileName = Path.GetFileName(strFileName);
        }

        private void BindImageRepeater() {
            List<string> imagePaths = new List<string>();
            string strFolder = Server.MapPath("./user_images/");

            string[] filesindirectory = Directory.GetFiles(strFolder);
            foreach (string item in filesindirectory) {
                imagePaths.Add($"user_images/{Path.GetFileName(item)}");
            }

            Repeater1.DataSource = imagePaths;
            Repeater1.DataBind();
        }
    }
}