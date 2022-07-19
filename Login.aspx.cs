using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Register
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LoginUser_Authenticate(object sender, AuthenticateEventArgs e)
        {
            Session["EstaLogado"] = true;
            Session["UsuarioLogado"] = string.Empty;

            if(LoginUser.UserName == "admin" && LoginUser.Password == "admin")
            {
                Session["EstaLogado"] = true;
                Session["UsuarioLogado"] = LoginUser.UserName;
                Response.Redirect("UserRegister.aspx");
                Response.Write("<script>alert (' Login realizado com sucesso ');</script>");
            }
            else
            {
                User user = Functions GetUserByID
            }

        }
    }
}