using CS412Final_Pesa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CS412Final_Pesa {
    public partial class Example3Page : System.Web.UI.Page {
        private readonly List<User> users =  new List<User>() {
            new User() {
                Id = 1,
                First = "Gaston",
                Last = "Pesa"
            },
            new User() {
                Id = 2,
                First = "John",
                Last = "Smith"
            },
            new User() {
                Id = 3,
                First = "Donald",
                Last = "Duck"
            },
        };

        protected void Page_Load(object sender, EventArgs e) {
            if (Page.IsPostBack == false) {
                ViewState["users"] = users;

                BindGridView();
                BindRepeater();
            }
        }

        protected void updatePanelButton_Click(object sender, EventArgs e) {
            updatePanelLabel.Text = "Button Clicked: " + DateTime.Now;
        }

        protected void Button2_Click(object sender, EventArgs e) {
            Button2.Text = name.Text;
        }

        protected void Button3_Click(object sender, EventArgs e) {
            //toggle visibility
            Label1.Visible = !Label1.Visible;

            //we could also toggle enable disable of textboxes or anything else by doing
            //TextBox1.Visible = false;
            //TextBox1.Visible = true;
            //TextBox1.Visible = !TextBox1.Visible;
        }

        private void BindGridView() {
            //set the data source, can be data from a database as well
            GridView1.DataSource = ViewState["users"];

            //bind the data to the gridview
            GridView1.DataBind();
        }

        private void BindRepeater() {
            Repeater1.DataSource = ViewState["users"];
            Repeater1.DataBind();
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e) {
            //check if the rowtype is a datarow. it could be a header row, for example, but
            //we're only interested in datarows
            if (e.Row.RowType == DataControlRowType.DataRow) {
                //grab the object from the row so that we can utilize it
                User user = (User)e.Row.DataItem;

                //set the controls
                Label Id = (Label)e.Row.FindControl("userId");
                Id.Text = user.Id.ToString();

                Label userName = (Label)e.Row.FindControl("userName");
                userName.Text = $"{user.First} {user.Last}";
            }
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e) {

        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e) {
            GridViewRow row = (GridViewRow)GridView1.Rows[e.RowIndex];
            Label userID = (Label)row.FindControl("userId");

            //find the user
            User user = null;
            foreach (User u in (List<User>)ViewState["users"]) {
                if (u.Id.ToString() == userID.Text) {
                    user = u;
                    break;
                }
            }

            //remove the user that we found
            ((List<User>)ViewState["users"]).Remove(user);

            //rebind the gridview now that we changed our source list
            BindGridView();
            BindRepeater();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e) {
            if (e.CommandName == "CLICKED") {
                GridViewRow row = (GridViewRow)GridView1.Rows[Convert.ToInt32(e.CommandArgument)];
                //do stuff here
            }

        }

        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e) {
            //microsoft example below----

            // This event is raised for the header, the footer, separators, and items.

            // Execute the following logic for Items and Alternating Items.
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) {
                User user = (User)e.Item.DataItem;
                ((Label)e.Item.FindControl("repeaterFirstName")).Text = user.First;
                ((Label)e.Item.FindControl("repeaterLastName")).Text = user.Last;
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e) {
            Response.Redirect("http://www.google.com/");
        }

        protected void Button4_Click(object sender, EventArgs e) {
            List<string> selected = new List<string>();
            if (CheckBox1.Checked)
                selected.Add("checkbox1 is checked");

            if (CheckBox2.Checked)
                selected.Add("checkbox2 is checked");

            if (CheckBox3.Checked)
                selected.Add("checkbox3 is checked");

            Label2.Text = string.Join(", ", selected);
        }

        protected void Button5_Click(object sender, EventArgs e) {
            List<string> selected = new List<string>();
            foreach (ListItem item in CheckBoxList1.Items)
                if (item.Selected)
                    selected.Add(item.Value);

            Label3.Text = string.Join(", ", selected);

        }

        protected void Button6_Click(object sender, EventArgs e) {
            Label4.Text = RadioButtonList1.SelectedValue;
        }

        protected void Button7_Click(object sender, EventArgs e) {
            if (RadioButton1.Checked)
                Label5.Text = "radiobutton1 is checked";

            if (RadioButton2.Checked)
                Label5.Text = "radiobutton2 is checked";

            if (RadioButton3.Checked)
                Label5.Text = "radiobutton3 is checked";
        }

        protected void Button8_Click(object sender, EventArgs e) {
            Button8.Enabled = false;
        }

        protected void Button9_Click(object sender, EventArgs e) {
            if (TextBox2.Text == "hello world") {
                //do some code here
            } else if (TextBox2.Text.Contains("hello")) {
                //do some code here
            }
        }
    }
}