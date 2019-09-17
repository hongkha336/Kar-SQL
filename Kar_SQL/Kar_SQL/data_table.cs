using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kar_SQL
{
    public class data_table
    {


        public List<String> getColName_From_Object(List<Field> myList)
        {
            List<String> myStringList = new List<string>();
            foreach(Field fi in myList)
            {
                myStringList.Add(fi.ColName + " - " +fi.ColPro);
            }
            return myStringList;
        }



        public DataTable ConvertListToDataTable(List<String> ListColName, List<String[]> ListColContents)
        {
            // New table.
            DataTable table = new DataTable();
            

            // Add columns.
            for (int i = 0; i < ListColName.Count; i++)
            {
                table.Columns.Add(ListColName[i]);
            }

            // Add rows.
            foreach (var array in ListColContents)
            {
                table.Rows.Add(array);
            }

            return table;
        }


        public DataTable ConvertListToDataTable(List<Field> myList, List<String[]> ListColContents)
        {
            // New table.
            DataTable table = new DataTable();
            List<String> ListColName = getColName_From_Object(myList);
            

            // Add columns.
            for (int i = 0; i < ListColName.Count; i++)
            {
                table.Columns.Add(ListColName[i]);
            }

            // Add rows.
            foreach (var array in ListColContents)
            {
                table.Rows.Add(array);
            }

            return table;
        }


        public  DataTable ConvertListToDataTable(List<string[]> list)
        {
            // New table.
            list = new List<string[]>();
            string[] arr = new string[3];
            arr[0] = "Ahihi";
            arr[1] = "Ahoho";
            arr[2] = "Ahehe";
            list.Add(arr);
            DataTable table = new DataTable();

            table.Columns.Add();
            table.Columns.Add();
            table.Columns.Add();
            // Add rows.
            foreach (var array in list)
            {
                table.Rows.Add(array);
            }
            return table;
        }
    }
}
