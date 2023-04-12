using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogicaNegocio.MessageErrors
{
    public class MessageErrors
    {
        public static string selectABranchPlease = "Seleccione una sucursal por favor por favor";
        public static string incorrectFomrmantEmail = "El correo electronico no tiene el formato correcto, verifica por favor";
        public static string failedSendEmail = "Ocurrió un error al enviar el correo electrónico";
        public static string authenticationFailedSendEmail = "Tu correo y/o contraseña son incorrectos, verifica porr favor";
        public static string errorDeleteBrancheReference = "No puedes eliminar la sucursal por que tiene productos asignados";
        public static string errorDeleteDayReference = "No puedes eliminar el dia ya que esta asginado a un horario";
        public static string errorDeletePorductReference = "No puedes eliminar el producto ya que esta asginado a una sucursal";
        public static string failedToUpdate = "Error al actualizar";
        public static string errorDeletingBranch = "Error deleting branch";
        public static string errorDeletingImage = "Error al eliminar la imagen";
        public static string empetyContacts = "Sin contactos registrados aún.";
        public static string invalidSmpEmail = "Correo no valio, el correo tiene que ser Gmail u Outlook";
        public static string errorDeletingProduct = "Error al eliminar el producto";
        public static string idRecordEmpty = "Id de registro vacio";
        public static string errorAddingToBranch = "Error al agregar la sucursal";
        public static string errorAddingImage = "Error al agregar la imagen";
        public static string catalogNoExists = "El catalogo no se ha encontrado";
        public static string errorSavingUserImage { get; set; } = "Error al guardar la imagen,intentarlo mas tarde por favor";
        public static string formantIncorrectTime = "El formato tipo hora, es incorrecto";
        public static string formantIncorrectNumber = "El formato númerico es incorrecto";
        public static string noneTable = "Tabla no encontrada";
        public static string noneFilter = "Filtro no encontrado";
        public static string nonexistentField(string field = "")
        {
            return "El campo " + field + " no exite";
        }
        public static string wrongLength(string campo, string minLength, string maxLength)
        {
            return "La longitud de " + campo + " tiene que ser no menor a " + minLength + " y no mayor a " + maxLength + " caracteres";
        }
        public static string invalidSelectorIn(string campo = "")
        {
            if (campo != "")
            {
                return "Selecciona una opción correcta sobre el selector " + campo;
            }
            else
            {
                return "Selecciona una opción correcta sobre selector";
            }
        }
        public static string wrongFileExtension(string extensions)
        {
            return "Solamente se permiten archivos " + extensions;
        }
    }
}
