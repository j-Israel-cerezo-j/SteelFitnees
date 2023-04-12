using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Validaciones.utils;

namespace CapaEntidades
{
    public class CommentBranch
    {
        public int idComment { get; set; }        
        public string comment { get; set; }
        public DateTime commentDate { get; set; }
        public int fkBranche { get; set; }
        public CommentBranch()
        {

        }
        public CommentBranch(SqlDataReader renglon)
        {
            this.idComment = (int)(Validation.getValue(renglon, "idComment") ?? 0);                        
            this.comment = (string)(Validation.getValue(renglon, "comment"));
            this.commentDate = (DateTime)Validation.getValue(renglon, "commentDate");
            this.fkBranche = (int)(Validation.getValue(renglon, "fkBranche") ?? 0);
        }

        override
        public string ToString()
        {
            return
                "id:'" + idComment + "', " +
                "commentDate:'" + commentDate.ToString("dd/MM/yyyy") + "'," +
                "fkBranche:'" + fkBranche + "', " +
                "comment:'" + comment + "'";
        }
    }
}
