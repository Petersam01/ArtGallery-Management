using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ArtGallary
{
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ID"] != null | Session["AdminID"] != null | Session["UserID"] != null)
            {
                Session["ID"] = null;
                Session["UserID"] = null;
                Session["AdminID"] = null;
                Session["UserType"] = null;
                Session["AdminType"] = null;
                Session["Email"] = null;

                Response.Redirect("Login.aspx");
            }
        }
    }
}