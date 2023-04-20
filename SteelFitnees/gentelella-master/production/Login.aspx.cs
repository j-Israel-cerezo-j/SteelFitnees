using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Security;
using CapaLogicaNegocio.Services;
using CapaLogicaNegocio.utils;
using CapaEntidades;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Specialized;
using CapaLogicaNegocio.Exceptions;
namespace SteelFitnees.gentelella_master.production
{
    public partial class Login : System.Web.UI.Page
    {
        private UserService userService = new UserService();

        public List<User> getUsersCookies { get; set; } = null;
        public User getUserCookie { get; set; }
        public string getJsonUsersCookies { get; set; }
        public string getJsonUserCookiesDataIncorrect { get; set; } = "a";
        public string getBlockedAccountMsj { get; set; } = "a";
        public bool getPassIncorrect { get; set; } = false;
        public bool getEmptyPassword { get; set; } = false;
        public bool getPassRemember { get; set; } = false;
        public bool getBlockedAccount { get; set; } = false;
        public bool getModalShow { get; set; } = false;
        public int getIndexValueListUser { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {//this.cmdLogin.ServerClick += new System.EventHandler(this.cmdLogin_ServerClick);
            
            if (Session["user"] != null)
            {
                Response.Redirect("indexUser.aspx");
            }
            else
            {
                string JQueryVer = "1.7.1"; ScriptManager.ScriptResourceMapping.AddDefinition("jquery", new ScriptResourceDefinition { Path = "~/Scripts/jquery-" + JQueryVer + ".min.js", DebugPath = "~/Scripts/jquery-" + JQueryVer + ".js", CdnPath = "http://ajax.aspnetcdn.com/ajax/jQuery/jquery-" + JQueryVer + ".min.js", CdnDebugPath = "http://ajax.aspnetcdn.com/ajax/jQuery/jquery-" + JQueryVer + ".js", CdnSupportsSecureConnection = true, LoadSuccessExpression = "window.jQuery" });
                
            }

        }
        protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        {
            try
            {
                lblBlockedAccount.Text = "";
                lblEmailNonexistent.Text = "";
                if (userService.validateIfExistUser(Login1.UserName))
                {
                    string urlRederic = "indexUser.aspx";
                    if (ValidateUser(Login1.UserName, Login1.Password, ref urlRederic))
                    {
                        FormsAuthenticationTicket tkt;
                        string cookiestr;
                        HttpCookie ck;
                        tkt = new FormsAuthenticationTicket(1, Login1.UserName, DateTime.Now,
                        DateTime.Now.AddMinutes(30), Login1.RememberMeSet, "your custom data");
                        cookiestr = FormsAuthentication.Encrypt(tkt);
                        ck = new HttpCookie(FormsAuthentication.FormsCookieName, cookiestr);
                        if (Login1.RememberMeSet)
                            ck.Expires = tkt.Expiration;
                        ck.Path = FormsAuthentication.FormsCookiePath;
                        Response.Cookies.Add(ck);

                        string strRedirect;
                        strRedirect = Request["ReturnUrl"];
                        if (strRedirect == null)
                            strRedirect = urlRederic;
                        //verificar
                        if (Request.Form["checkRemember"] != null)
                        {
                            string valueCheckRemember = Request.Form["checkRemember"];
                            if (valueCheckRemember == "on")
                            {
                                //remembermeLater(user, Login1.UserName);
                            }
                        }
                        Session["user"] = true;
                        //verificar                        
                        Response.Redirect(strRedirect, true);
                    }
                    else
                        Response.Redirect("Login.aspx", true);
                }
                else
                {
                    lblEmailNonexistent.Text = "Nombre de usuario no registrado";
                }
            }
            catch (LoginException ex)
            {
                lblBlockedAccount.Text = ex.getMessage();
            }
        }
        private bool ValidateUser(string userName, string passWord, ref string urlRederic)
        {

            // Check for invalid userName.
            // userName must not be null and must be between 1 and 15 characters.
            if ((null == userName) || (0 == userName.Length))
            {
                System.Diagnostics.Trace.WriteLine("[ValidateUser] La validación de entrada de correo falló.");
                //vUserName.Text = "Correo falló";
                return false;
            }

            // Check for invalid passWord.
            // passWord must not be null and must be between 1 and 25 characters.
            if ((null == passWord) || (0 == passWord.Length) || (passWord.Length > 25))
            {
                System.Diagnostics.Trace.WriteLine("[ValidateUser] La validación de entrada de la contraseña falló.");
                //lblMsg.Text = "Contraseña falló";
                return false;
            }
            return userService.loginUsua(userName, passWord, ref urlRederic);
        }

    }
}