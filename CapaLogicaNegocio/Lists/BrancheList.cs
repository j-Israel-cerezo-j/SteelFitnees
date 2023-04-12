using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidades;
namespace CapaLogicaNegocio.Lists
{
    public class BrancheList
    {
        private BrancheData brancheData = new BrancheData();

        public List<Branche> listBraches()
        {
            return brancheData.listBranches();
        }
        public List<CommentBranch> listCommentsByIdBrache(int id)
        {
            return brancheData.listCommentsByIdBranches(id);
        }
        public List<CommentBranch> listCommentsByIdBracheAndWeek(int id,DateTime weekIni,DateTime weekEnd)
        {
            return brancheData.listCommentsByIdBranchesAndWeek(id, weekIni, weekEnd);
        }
        public List<CommentBranch> listCommentsByIdBranchesAndCharacteres(int id,string characteres )
        {
            return brancheData.listCommentsByIdBranchesAndCharacteres(id, characteres);
        }
        public List<Branche> listBranchesBranchesByCharactersConicidences(string characters)
        {
            return brancheData.tableBranchesBranchesByCharactersConicidences(characters);
        }
    }
}
