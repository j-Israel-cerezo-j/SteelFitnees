using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace CapaEntidades
{
    public class Promotion
    {
        public int id { get; set; }
        public int fkBranche { get; set; }
        public bool check { get; set; }
        public HttpPostedFile img { get; set; }
        public string path { get; set; }
        public string fileName { get; set; }

    }
}
