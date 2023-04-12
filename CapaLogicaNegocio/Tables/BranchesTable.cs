using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogicaNegocio.Tables
{
    public  class BranchesTable
    {
        private BrancheData brancheData = new BrancheData();
        public DataTable table()
        {
            return brancheData.tableBranches();
        }
        public DataTable branchesBranchesByCharactersConicidences(string characters)
        {
            return brancheData.listBranchesBranchesByCharactersConicidences(characters);
        }
    }
}
