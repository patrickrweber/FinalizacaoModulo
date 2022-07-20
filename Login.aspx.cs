using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Cadastro
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LoginUser_Authenticate(object sender, AuthenticateEventArgs e)
        {
            Session["LoggedIn"] = true;
            Session["UserLogin"] = string.Empty;

            if(LoginUser.UserName == "admin" && LoginUser.Password == "admin")
            {
                Session["LoggedIn"] = true;
                Session["UserLogin"] = LoginUser.UserName;
                Response.Redirect("RegisterList.aspx");
                Response.Write("<script>alert (' Login realizado com sucesso ');</script>");
            }
            else
            {
                User user = Functions.GetUserByLogin(LoginUser.UserName);
                if(user.Password == LoginUser.Password)
                {
                    Session["LoggedIn"] = true;
                    Session["UserLogin"] = LoginUser.UserName;
                    Response.Redirect("RegisterList.aspx");
                }
            }

        }
    }
}