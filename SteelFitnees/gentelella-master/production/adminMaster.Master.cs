using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SteelFitnessWEB.gentelella_master.production
{
    public partial class adminMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Redirect("Index.aspx");
            }
        }

        protected void loggingOut_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.RemoveAll();
            Response.Redirect("Login.aspx");
        }
    }
}