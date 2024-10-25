using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ArtGallary
{
    public partial class ArtGallery : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["AdminID"] != null)
            {
                logout.Visible = true;
                home.Visible = true;
            }
            else if (Session["AdminID"] != null)
            {
                if ((string)Session["AdminType"] == "Admin")
                {
                    logout.Visible = true;
                    home.Visible = true;

                }
              
            }
            if (Session["AdminID"] == null)
            {
                home.Visible=false;
                logout.Visible = false;
            }
        }
    }
}