using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Cadastro
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string loginName = string.Empty;

            if (Session["UserLogin"] != null)
            {
                loginName = Session["UserLogin"].ToString();
            }
            if(loginName == string.Empty)
            {
                Response.Redirect("Login.aspx");
            }

            else
            {
                string mode = Request.QueryString["mode"];

                if (!IsPostBack)
                {
                    ButtonUpdate.Visible = mode == "UPD";
                    ButtonDelete.Visible = mode == "DEL";
                    ButtonInsert.Visible = mode == "INS";

                    if (mode == "VIEW" || mode == "DEL")
                    {
                        int id = int.Parse(Request.QueryString["id"]);
                        TextBoxId.Text = id.ToString();

                        User user = Functions.GetUserByID(id);

                        TextBoxName.Text = user.Name;
                        TextBoxEmail.Text = user.Email;
                        TextBoxLogin.Text = user.Login;

                        TextBoxName.Enabled = false;
                        TextBoxEmail.Enabled = false;
                        TextBoxLogin.Enabled = false;
                        TextBoxPassword.Visible = false;
                        TextBoxPassword.Enabled = false;

                        LabelPassword.Visible = false;
                    }

                    if (mode == "UPD")
                    {
                        TextBoxPassword.Visible = false;
                        LabelPassword.Visible = false;
                    }

                    if (mode != "INS")
                    {
                        int id = int.Parse(Request.QueryString["id"]);
                        TextBoxId.Text = id.ToString();

                        User user = Functions.GetUserByID(id);

                        TextBoxName.Text = user.Name;
                        TextBoxEmail.Text = user.Email;
                        TextBoxLogin.Text = user.Login;
                        TextBoxPassword.Text = user.Password;

                    }
                }

               


            }
        }

        protected void ButtonInsert_Click(object sender, EventArgs e)
        {
            User user = new User(TextBoxName.Text, TextBoxEmail.Text,
                TextBoxLogin.Text, TextBoxPassword.Text);
            Functions.UserInsert(user);
            Response.Redirect("RegisterList.aspx");
        }

        protected void ButtonUpdate_Click(object sender, EventArgs e)
        {
            int id = int.Parse(Request.QueryString["id"]);

            User user = Functions.UserUpdate(id, TextBoxName.Text, TextBoxEmail.Text,
                TextBoxLogin.Text, TextBoxPassword.Text);

            TextBoxId.Text = id.ToString();
            user.Name = TextBoxName.Text;
            user.Email = TextBoxEmail.Text;
            user.Login = TextBoxLogin.Text;
            user.Password = TextBoxPassword.Text;

            Response.Redirect("RegisterList.aspx");
        }

        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            int id = int.Parse(Request.QueryString["id"]);
            Functions.UserDelete(id);
        }

        protected void ButtonClose_Click(object sender, EventArgs e)
        {
            Response.Redirect("RegisterList.aspx");
        }
    }
}