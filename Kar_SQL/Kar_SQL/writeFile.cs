using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kar_SQL
{
    class writeFile
    {
        String dbName;
        public writeFile(String dbName)
        {
            this.dbName = dbName;
        }

        public writeFile()
        {
        }

        public void write_Table_Infor(List<Field> myFi, String Tablename)
        {
            String filepath = "database/"+dbName+"/"+Tablename+"inf_.txt";
            FileStream fs = new FileStream(filepath, FileMode.Create);
            StreamWriter sWriter = new StreamWriter(fs, Encoding.UTF8);
            for (int i = 0; i < myFi.Count; i++)
                sWriter.WriteLine("/"+ myFi[i].ColName +"/"+myFi[i].ColPro +"/"+myFi[i].isPK);
            sWriter.Flush();
            fs.Close();

            filepath = "database/" + dbName + "/" + Tablename + ".txt";
            if (!File.Exists(filepath))
            {
                fs = new FileStream(filepath, FileMode.Create);
                fs.Close();
            }
        }

        public void write_Table_Infor(List<Field> myFi, String Tablename, String dbName)
        {
            String filepath = "database/" + dbName + "/" + Tablename + "inf_.txt";
            FileStream fs = new FileStream(filepath, FileMode.Create);
            StreamWriter sWriter = new StreamWriter(fs, Encoding.UTF8);
            for (int i = 0; i < myFi.Count; i++)
                sWriter.WriteLine("/" + myFi[i].ColName + "/" + myFi[i].ColPro + "/" + myFi[i].isPK);
            sWriter.Flush();
            fs.Close();

           
            filepath = "database/" + dbName + "/" + Tablename + ".txt";
            if (!File.Exists(filepath))
            {
                fs = new FileStream(filepath, FileMode.Create);
                fs.Close();
            }
        }


        public void write_Table_Infor_FK(List<String> myFK1,String Tablename)
        {
            String filepath = "database/" + dbName + "/" + Tablename + "_FK_inf_.txt";
            FileStream fs = new FileStream(filepath, FileMode.Create);
            StreamWriter sWriter = new StreamWriter(fs, Encoding.UTF8);
            for (int i = 0; i < myFK1.Count; i++)
                sWriter.WriteLine(myFK1[i]);
            sWriter.Flush();
            fs.Close();


            
        }

        public void write_Table_Contents(List<String> myTable_Contents, String Tablename, String dbName)
        {
            String filepath = "database/" + dbName + "/" + Tablename + ".txt";
            FileStream fs = new FileStream(filepath, FileMode.Create);
            StreamWriter sWriter = new StreamWriter(fs, Encoding.UTF8);
            for (int i = 0; i < myTable_Contents.Count; i++)
                sWriter.WriteLine(myTable_Contents[i]);
            sWriter.Flush();
            fs.Close();

            

        }



        public void delete_file(String filePath)
        {

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }

    }
}
