﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SteelFitnessWEB
{
    public partial class principal : System.Web.UI.MasterPage
    {
        public string getUrlReferrer { get;private set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            getUrlReferrer = Request.UrlReferrer != null ? Request.UrlReferrer.ToString() : string.Empty;

        }
    }
}