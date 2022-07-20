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
            if (loginName == string.Empty)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                if (!IsPostBack)
                {
                    GridViewUserList.DataSource = Functions.GetUsersList();
                }
            }
        }
    }
}