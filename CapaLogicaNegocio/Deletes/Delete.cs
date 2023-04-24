using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
namespace CapaLogicaNegocio.Deletes
{
    public class Delete
    {
        private DeleteWhere delete = new DeleteWhere("steelFitness");
        public bool deleteWhere(string table, string field, string fieldValue)
        {
            return delete.where(table, field, fieldValue);
        }
        public bool deletWhereNot(string table, string fieldWhere1, string fieldWhereNot, string valueFieldCamp1, string valueFieldCampNot)
        {
            return delete.whereNot(table, fieldWhere1, fieldWhereNot, valueFieldCamp1, valueFieldCampNot);
        }
        public bool whereIn(string table, string field, List<string> valiesField)
        {
            return delete.whereIn(table, field, valiesField);
        }
        public bool whereIn(string table, string field, string strValiesField)
        {
            return delete.whereIn(table, field, strValiesField);
        }
    }
}
