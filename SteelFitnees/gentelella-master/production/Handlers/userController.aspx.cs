using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaEntidades;
using CapaLogicaNegocio;
using CapaLogicaNegocio.Services;

namespace SteelFitnees.gentelella_master.production.Handlers
{
    public partial class userController : System.Web.UI.Page
    {
        private UserService userService = new UserService();
        public static string getJsonResponse { get; private set; } = "{\"k\":1}";
        protected void Page_Load(object sender, EventArgs e)
        {
            add();
        }
        private void add()
        {            
            userService.addUser();
        }
    }
}