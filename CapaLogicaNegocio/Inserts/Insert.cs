using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
namespace CapaLogicaNegocio.Inserts
{
    public class Insert
    {
        public static bool Many(string strFieldsUnios, string table)
        {
            InsesrtsManysDatos insertDatos = new InsesrtsManysDatos("steelFitness");
            return insertDatos.insertMany(strFieldsUnios, table);
        }        
        public static bool Many(Dictionary<object, object> campos, string table)
        {
            InsesrtsManysDatos insertDatos = new InsesrtsManysDatos("steelFitness");
            return insertDatos.insertMany(campos, table);
        }
        public static bool Many(Dictionary<object, List<object>> campos, string table, List<object> extraFields = null)
        {
            InsesrtsManysDatos insertDatos = new InsesrtsManysDatos("steelFitness");
            return insertDatos.insertMany(campos, table, extraFields);
        }
        public static bool Many(Dictionary<List<object>, object> campos, string table, List<object> extraFields = null)
        {
            InsesrtsManysDatos insertDatos = new InsesrtsManysDatos("steelFitness");
            return insertDatos.insertMany(campos, table, extraFields);
        }
    }
}
