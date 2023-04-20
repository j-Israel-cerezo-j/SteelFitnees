using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidades;
namespace CapaLogicaNegocio.Adds
{
    public class BrancheAdd
    {
        private BrancheData brancheData = new BrancheData();
        public int add(Branche branche)
        {
            return brancheData.add(branche);
        }
        public bool addComments(CommentBranch commentBranch)
        {
            return brancheData.addComments(commentBranch);
        }
    }
}
