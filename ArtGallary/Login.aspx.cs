using ArtGallary.Controllers;
using ArtGallary.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ArtGallary
{
    public partial class Login : System.Web.UI.Page
    {
        ArtGalleryApi aga = new ArtGalleryApi();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void signin_Click(object sender, EventArgs e)
        {
            ArtAdmin admin = aga.AdminLogin(email.Value, password.Value);

            bool isAuthenticated = aga.Authenticate(email.Value, password.Value);

            if (aga.Authenticate(email.Value, password.Value))
            {
                if (isAuthenticated)
                {
                    FormsAuthentication.SetAuthCookie(email.Value, false);

                    if (admin != null)
                    {
                        int id1 = getAdminID(admin.Email);
                        if (aga.GetAdminTypeById(id1).Equals("Admin"))
                        {
                            Session["Email"] = email.Value;
                            Session["AdminID"] = id1;
                            Session["AdminType"] = "Admin";
                            Response.Redirect("AddContent.aspx");
                        }
                        else
                        {
                            Session["Email"] = email.Value;
                            Session["AdminID"] = id1;
                            Session["AdminType"] = "Manager";
                            Response.Redirect("AddContent.aspx");
                        }


                    }
                    else
                    {

                        ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "alert('Login Failed. Wrong Username or Password !!!');", true);
                    }
                }

                FormsAuthentication.RedirectFromLoginPage(email.Value, isAuthenticated);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "alert('Login Failed. Wrong Username or Password !!!');", true);
            }

        }

        protected void view_Click(object sender, EventArgs e)
        {
            Response.Redirect("CurrentExhibition.aspx");
        }

        private int getAdminID(String email)
        {
            int ID = 0;

            MySqlConnection sqlCon = new MySqlConnection(Settings.CONNECTION_STRING);
            sqlCon.Open();
            MySqlCommand sqlcmd = new MySqlCommand("SELECT AdminID FROM Admins WHERE Email='" + email + "'", sqlCon);

            var num = sqlcmd.ExecuteScalar();

            ID = (int)num;



            return ID;

        }
    }
}