using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Cadastro
{
	public partial class RegisterList : System.Web.UI.Page
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
                GridViewUserList.DataSource = Functions.GetUsersList();
                GridViewUserList.DataBind();
            }
        }

        protected void ButtonInsert_Click(object sender, EventArgs e)
        {
            Response.Redirect($"UsersRegister.aspx?mode=INS");
        }

        protected void GridViewUserList_RowComannd(object sender, GridViewCommandEventArgs e)
        {
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = GridViewUserList.Rows[rowIndex];
            string id = row.Cells[1].Text;

            if(e.CommandName == "View")
            {
                Response.Redirect($"UsersRegister.aspx?mode=VIEW&id={id}");
            }

            if(e.CommandName == "Update")
            {
                Response.Redirect($"UsersRegister.aspx?mode=DEL&id={id}");
            }
            if(e.CommandName == "Delete")
            {
                Response.Redirect($"UsersRegister.aspx?mode=DEL&id={id}");
            }
        }
    }
}