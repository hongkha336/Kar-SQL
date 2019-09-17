using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kar_SQL
{
   public class Field
    {
       public String ColName;
       public String ColPro;
       public bool isPK;

        public Field(string colName, string colPro, bool isFK)
        {
            ColName = colName;
            ColPro = colPro;
            this.isPK = isFK;
        }


        public Field()
        {
            ColName = "";
            ColPro = "";
        }
    }
}
