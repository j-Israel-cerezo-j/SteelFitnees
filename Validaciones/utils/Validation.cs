using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Globalization;
using System.Reflection;

namespace Validaciones.utils
{
    public class Validation
    {
        public static Object getValue(SqlDataReader renglon, string columna)
        {
            Object value;
            try
            {
                value = renglon[columna];

                if (DBNull.Value == value)
                {
                    value = null;
                }
            }
            catch (IndexOutOfRangeException e)
            {
                value = null;
            }
            return value;
        }
        public static Dictionary<string, bool> isNullOrEmptys(Dictionary<string, string> requestForm)
        {
            char[] charsToTrim = { ' ' };
            var result = new Dictionary<string, bool>();
            foreach (var item in requestForm)
            {
                string valueWithoutSpaces = item.Value.Trim(charsToTrim);
                if (String.IsNullOrEmpty(valueWithoutSpaces))
                {
                    result.Add(item.Key, true);
                    break;
                }
            }
            return result;
        }
        public static bool isNullOrEmpty(Dictionary<string, string> request, string field)
        {
            char[] charsToTrim = { ' ' };
            var result = false;
            foreach (var item in request)
            {
                string valueWithoutSpaces = item.Value.Trim(charsToTrim);
                if (valueWithoutSpaces == field)
                {
                    if (String.IsNullOrEmpty(valueWithoutSpaces))
                    {
                        result = true;
                        break;
                    }
                }
            }
            return result;
        }
        public static string empty(object entity,string nameId="")
        {
            Type tipe= entity.GetType();
            PropertyInfo[] properties = tipe.GetProperties();

            foreach (var propeti in properties)
            {
                var value= propeti.GetValue(entity);
                if (propeti.Name == nameId)
                {
                    if ((int)value == 0)
                    {
                        return propeti.Name;
                    }
                }
                else if (value==null || (value is string && string.IsNullOrWhiteSpace((string)value)))
                {                    
                    return propeti.Name;
                }
            }
            return null;
        }
        public static bool IsEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
        public static bool numericalFormat(string strNumerico)
        {
            return strNumerico.All(char.IsDigit);
        }
        public static bool LongMin(string str, int longi)
        {
            bool logitudCorrecta = (str.Length >= longi);
            return logitudCorrecta;
        }
        public static bool LongMax(string str, int longi)
        {
            bool logitudCorrecta = (str.Length <= longi);
            return logitudCorrecta;
        }
        public static bool Long(string longitud, int longMin, int longMax)
        {
            bool logitudCorrecta = (longitud.Length >= longMin && longitud.Length <= longMax);
            return logitudCorrecta;
        }
        public static bool FormantDate(string strDate)
        {
            DateTime dateFecha;
            return DateTime.TryParseExact(strDate, "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None, out dateFecha);
        }
        public static bool FormantDateFullFormant(string strDate)
        {
            DateTime dateFecha;
            return DateTime.TryParseExact(strDate, "d/M/yyyy", null, System.Globalization.DateTimeStyles.None, out dateFecha) 
                ||
                DateTime.TryParseExact(strDate, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out dateFecha)
                ||
                DateTime.TryParseExact(strDate, "d/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out dateFecha)
                ||
                DateTime.TryParseExact(strDate, "dd/M/yyyy", null, System.Globalization.DateTimeStyles.None, out dateFecha);
        }
        public static bool FormantDateTime(string strDate)
        {
            DateTime dateFecha;
            return DateTime.TryParseExact(strDate, "yyyy-MM-ddTHH:mm", null, System.Globalization.DateTimeStyles.None, out dateFecha);
        }
        public static bool FormantTime(string strTime)
        {
            DateTime time;
            return DateTime.TryParseExact(strTime, "HH:mm", null, System.Globalization.DateTimeStyles.None, out time);
        }
        public static bool Select(string select)
        {
            bool formatoCorrectoSelect = !(select == "-1" || select == null || select == "" || select == "-2");
            return formatoCorrectoSelect;
        }
        public static bool SelectFormant(string select)
        {
            bool formatoCorrectoSelect = !(select == null || select == "");
            return formatoCorrectoSelect;
        }
        public static bool FormantCheck(string strCheck)
        {
            return !(strCheck == "" || strCheck == null);
        }
        public static bool FormantLengthTelephone(string strTelephone)
        {
            return !(strTelephone.Length < 10 || strTelephone.Length > 10);
        }
    }
}
