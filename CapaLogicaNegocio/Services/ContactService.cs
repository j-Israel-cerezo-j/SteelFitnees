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
            bool ban = false;
            var camposEmptysOrNull = Validation.isNullOrEmptys(request);
            if (camposEmptysOrNull.Count == 0)
            {
                Contact contac = new Contact();
                contac.nombre = RetrieveAtributes.values(request, "nombre");
                contac.email = RetrieveAtributes.values(request, "email");
                return contacAdd.add(contac);
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
    }
}
