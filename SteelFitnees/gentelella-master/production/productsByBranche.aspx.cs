using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SteelFitnees.gentelella_master.production
{
    public partial class productsByBranche : System.Web.UI.Page
    {
        public int getIdPorduct { get; set; } = -1;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"]!=""&&Request.QueryString!=null)
            {
                getIdPorduct = Convert.ToInt32(Request.QueryString["id"]);
            }

        }
    }
}