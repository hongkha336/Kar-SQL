using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kar_SQL
{
   public class Datatypes
    {
        public int INT;
        public String VARCHAR;
        public String NVARCHAR;
        public String CHAR;
        public DateTime DATETIME;
        public bool BIT;

        public List<String> List_datatype;
        public Datatypes()
        {
            List_datatype = new List<String>();
            List_datatype.Add("int");
            List_datatype.Add("varchar");
            List_datatype.Add("nvarchar");
            List_datatype.Add("char");
            List_datatype.Add("datetime");
            List_datatype.Add("bit");
        }



        public bool isExistDataType(String str)
        {
            foreach (String dt in List_datatype)
            {
                if (str.Trim().ToLower().Equals(dt))
                {
                    return true;
                  
                }
            }
            return false;
        }
      

        public bool isNo(String a)
        {
            try
            {
                Convert.ToInt16(a);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool isCorrectDataType(String values, String dataType)
        {
            if(dataType.Trim().ToLower().Equals("int"))
            {
                return isNo(values);
            }

            if (dataType.Trim().ToLower().Equals("char"))
            {
                return true;
            }

            if (dataType.Trim().ToLower().Equals("varchar"))
            {
                return true;
            }

            if (dataType.Trim().ToLower().Equals("nvarchar"))
            {
                return true;
            }


            if (dataType.Trim().ToLower().Equals("bit"))
            {
                if (values.Trim().ToLower().Equals("true") || values.Trim().ToLower().Equals("false"))
                    return true;
                return false;
            }

            return false;
        }
    }
}
