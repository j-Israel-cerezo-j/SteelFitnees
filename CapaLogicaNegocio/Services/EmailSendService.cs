using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using CapaEntidades;
using CapaLogicaNegocio.Adds;
using CapaLogicaNegocio.Exceptions;
using CapaLogicaNegocio.Inserts;
using CapaLogicaNegocio.utils;
using Validaciones.utils;
using CapaLogicaNegocio.Lists;
using System.Net.Mime;
using System.IO;
using System.Web;

namespace CapaLogicaNegocio.Services
{
    public  class EmailSendService
    {
        private ContactList contactList = new ContactList();
        public bool send(Dictionary<string, string> request, HttpPostedFile file)
        {

            bool ban = false;
            var camposEmptysOrNull = Validation.isNullOrEmptys(request);
            if (camposEmptysOrNull.Count == 0)
            {
                try
                {
                    MailMessage mensaje = new MailMessage();
                    string affair = RetrieveAtributes.values(request, "asunto");
                    string bodyEmail = RetrieveAtributes.values(request, "info");
                    string senderMail = RetrieveAtributes.values(request, "senderMail");
                    string senderPassword = RetrieveAtributes.values(request, "senderPassword");

                    if (!senderMail.Contains("@"))
                    {
                        throw new ServiceException(MessageErrors.MessageErrors.incorrectFomrmantEmail);
                    }
                    Attachment adjunto = new Attachment(file.InputStream, file.FileName);
                    AlternateView htmlView = AlternateView.CreateAlternateViewFromString(Html.htmlTemplateEmail(), null, "text/html");
                    LinkedResource linkedResource = new LinkedResource(adjunto.ContentStream, adjunto.ContentType);
                    linkedResource.ContentId = "imagenEnHTML";
                    htmlView.LinkedResources.Add(linkedResource);                   
                    mensaje.AlternateViews.Add(htmlView);
                    string smpEmailSend = selectSmpEmailSend(senderMail);

                    mensaje = addMessageRecipients(mensaje);
                    
                    mensaje.From = new MailAddress(senderMail);
                    mensaje.Subject = affair;
                    mensaje.Body = bodyEmail;

                    // Crear un objeto SmtpClient para enviar el correo
                    SmtpClient cliente = new SmtpClient(smpEmailSend);
                    cliente.Port = 587; // Puerto del servidor SMTP
                    cliente.Credentials = new NetworkCredential(senderMail, senderPassword);
                    cliente.EnableSsl = true; // Usar SSL para conexión segura

                    // Enviar el mensaje
                    cliente.Send(mensaje);
                    ban = true;
                }
                catch (SmtpException e)
                {
                    
                    if (e.Message.Contains("535") || e.Message.Contains("authentication failed"))
                    {
                        throw new ServiceException(MessageErrors.MessageErrors.authenticationFailedSendEmail);
                    }
                    else
                    {
                        throw new ServiceException(MessageErrors.MessageErrors.failedSendEmail);                        
                    }
                }
                catch (ServiceException se)
                {
                    throw new ServiceException(se.getMessage());
                }
                catch (Exception e)
                {                    
                    throw new ServiceException("Error al enviar el correo");
                }
            }
            else
            {
                foreach (var item in camposEmptysOrNull)
                {
                    if (item.Value)
                    {
                        throw new ServiceException(item.Key + " esta vacío");
                    }
                }
            }
            return ban;
        }
        private MailMessage addMessageRecipients(MailMessage mensaje)
        {            
            var contacts = contactList.contacts();
            if (contacts.Count == 0)
            {
                throw new ServiceException(MessageErrors.MessageErrors.empetyContacts);
            }

            // Agregar los destinatarios al mensaje
            foreach (var contact in contacts)
            {
                mensaje.To.Add(contact.email);
            }
            return mensaje;
        }
        private string selectSmpEmailSend(string senderMail)
        {
            string smpEmailSend = "";            
            if (senderMail.Contains("outlook") || senderMail.Contains("hotmail"))
            {
                smpEmailSend = "smtp-mail.outlook.com";                
            }
            else if (senderMail.Contains("gmail"))
            {
                smpEmailSend = "smtp.gmail.com";
            }
            if (smpEmailSend == "")
            {
                throw new ServiceException(MessageErrors.MessageErrors.invalidSmpEmail);
            }
            return smpEmailSend;
        }
    }
}
