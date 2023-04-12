using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidades;
using CapaDatos;
namespace CapaLogicaNegocio.Lists
{
    public class ContactList
    { 
        private ContacData contacData=new ContacData();
        public List<Contact> contacts()
        {
            return contacData.listContacts();
        }
    }
}
