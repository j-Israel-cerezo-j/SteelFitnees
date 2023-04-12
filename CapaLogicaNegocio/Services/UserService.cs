using CapaEntidades;
using CapaLogicaNegocio.Exceptions;
using CapaLogicaNegocio.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;
using CapaLogicaNegocio.Session;
using CapaLogicaNegocio.Selects;

namespace CapaLogicaNegocio.Services
{
    public class UserService
    {
        private Sessions session = new Sessions();
       
        public bool validateIfExistUser(string email)
        {            
            return DuplicateField.duplicate("usuario", email.Trim(), "users");
        }
        public bool loginUsua(string email, string passRequest, ref string urlRederic)
        {
            string passwordEncrypt = EncryptPassword.GetMD5(passRequest);
            User userLoggedIn = session.login(email.Trim());
           
            // Si no se encuentra la contraseña, devuelve false.
            if (null == userLoggedIn.pass)
            {
                // Puede escribir aquí los intentos de inicio de sesión fallidos en el registro de eventos para mayor seguridad.
                return false;
            }
            bool successfulLogin = (0 == string.Compare(userLoggedIn.pass, passwordEncrypt, false));
            if (!successfulLogin)
            {
                throw new LoginException("Contraseña incorrecta");
            }

            urlRederic = "indexUser.aspx";
            // Compare lookupPassword e ingrese passWord, utilizando una comparación que distingue entre mayúsculas y minúsculas.
            return successfulLogin;
        }
    }
}
