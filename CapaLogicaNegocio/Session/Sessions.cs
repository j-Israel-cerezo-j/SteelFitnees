using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;

namespace CapaLogicaNegocio.Session
{
    public class Sessions
    {
        private DatosUser datos = new DatosUser();
        public User login(string email)
        {
            return datos.login(email);
        }
        public void s(User user)
        {
            datos.add(user);
        }
    }
}
