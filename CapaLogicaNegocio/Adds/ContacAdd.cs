using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidades;
using CapaDatos;
namespace CapaLogicaNegocio.Adds
{
    public class ContacAdd
    {
        private ContacData contacData=new ContacData();
        public bool add(Contact contact)
        {
            return contacData.add(contact);
        }
    }
}
