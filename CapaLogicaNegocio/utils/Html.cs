using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace CapaLogicaNegocio.utils
{
    public class Html
    {
        public static string htmlTemplateEmail(string nameConatact, string affair)
        {
            return  "<html>" +
                        "<body>" +
                            "<div style=\"box-shadow: 0 4px 8px 0 rgba(0,0,0,0.2);transition: 0.3s; background-color: aliceblue;padding: 15px; \">" +
                                "<div>" +
                                    "<h4 style=\"text-align: center;color:blue\"><span>¡Hola "+nameConatact+"!, no te pierdas de nuestra promoción de: ¡"+ affair + "!.</span></h3>" +
                                "</div>" +
                                "<div>" +
                                    "<h2 style=\"text-align: center;\"><span>Nuestras promociones</span></h2>" +
                                "</div>" +
                                "<div style=\"text-align: center;\">" +
                                    "<img style=\"text-align: center;\" width=\"250\" height=\"250\" src=\"cid:imagenEnHTML\" >" +
                                "</div>" +
                                "<div style=\"margin-top: 20px;\">" +
                                    "<div style=\"text-align: center;\">" +
                                        "<h3><b>Conoce nuestras sucursales</b></h3>" +
                                    "</div>" +
                                    "<div style=\"text-align: center;margin-top: 10px;\">" +
                                        "<h3><b>Conoce nuestros productos</b></h3>" +
                                    "</div>" +
                                "</div>  "+
                                "<div style=\"text-align: center;margin-top:50px; \" >" +
                                    "<a " +
                                        "style= " +
                                        "\"border: 1px solid transparent;" +
                                        "padding: 0.375rem 0.75rem;" +
                                        "font-size: 1rem;" +
                                        "border-radius: 50px; " +
                                        "transition: color .15s ease-in-out,background-color .15s ease-in-out,border-color .15s ease-in-out,box-shadow .15s ease-in-out; " +
                                        "user-select: none;text-align: center;" +
                                        "text-decoration: none;" +
                                        "vertical-align: middle;" +
                                        "display: inline-block;" +
                                        "font-weight: 600;" +
                                        "line-height: 1.5;" +
                                        "font-family:Arial,sans-serif;" +
                                        "width:80%;" +
                                        "margin: 0.25rem 0.125rem;" +
                                        "color: #fff;background-color: #0C3877;" +
                                        "border-color: 0C3877;" +
                                        "\" href=\"https://www.google.com/\">Visitanos" +
                                    "</a>" +
                                "</div>" +
                            "</div>" +
                        "</body>" +
                    "</html>";
        }
    }
}
