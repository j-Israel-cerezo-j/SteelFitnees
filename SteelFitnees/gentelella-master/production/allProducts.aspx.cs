using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SteelFitnees.gentelella_master.production
{
    public partial class allProducts : System.Web.UI.Page
    {        
        public string getCharacters { get; set; } = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["characters"] != "" && Request.QueryString["characters"] != null)
            {                
                getCharacters = Request.QueryString["characters"];
            }
        }
    }
}