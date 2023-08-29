using CapaEntidades;
using CapaLogicaNegocio.Adds;
using CapaLogicaNegocio.Exceptions;
using CapaLogicaNegocio.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Validaciones.utils;

namespace CapaLogicaNegocio.Services
{
    public class ContactService
    {
        private ContacAdd contacAdd=new ContacAdd();
        public bool add(Dictionary<string, string> request)
        {
            Contact contac = new Contact();
            contac.nombre = RetrieveAtributes.values(request, "nombre");
            contac.email = RetrieveAtributes.values(request, "email");
            isEmpty(contac);
            return contacAdd.add(contac);
        }
        private void isEmpty(Contact contact, string id = "")
        {
            var isEmptyWhitId = "";
            if (id != null && id != "")
            {
                isEmptyWhitId = Validation.empty(contact, nameof(contact.idInformacion));
            }
            else
            {
                isEmptyWhitId = Validation.empty(contact);
            }

            if (isEmptyWhitId != null)
            {
                throw new ServiceException(isEmptyWhitId + MessageErrors.MessageErrors.isEmpty);
            }
        }
    }
}
