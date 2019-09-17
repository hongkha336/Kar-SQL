using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kar_SQL
{
    public class readFile
    {
        public List<String> loadDataBase()
        {
            List<String> myDatabases = new List<String>();
            try
            {
                myDatabases = new List<string>();
                foreach (string path in Directory.GetDirectories("database"))
                {
                    myDatabases.Add(path.Substring(9, path.Length - 9));

                }
            }
            catch
            {
            }
            return myDatabases;
        }



        public List<String> loadTableInDatabase(String myDatabase_name)
        {
            List<String> myDatabases = new List<String>();
            try
            {
                myDatabases = new List<string>();
                foreach (string path in Directory.GetFiles("database/" + myDatabase_name))
                {

                    String temp = path.Substring(10 + myDatabase_name.Length, path.Length - 10 - myDatabase_name.Length);
                    temp = temp.Substring(0, temp.Length - 4);
                    if (!temp.EndsWith("inf_"))
                        myDatabases.Add(temp);
                }
            }
            catch
            {
            }
            return myDatabases;
        }


        // Đọc lên nội dung của một file và trả về 1 mảng nội dung
        public List<String> read_Contents(String filePath)
        {
            List<String> lines = File.ReadAllLines(filePath).ToList();
            List<String> newLines = new List<String>();
            foreach (String str in lines)
            {
                if(!str.Trim().Equals(""))
                {
                    newLines.Add(str);
                }
            }
            
            return newLines;

        }



        public List<Field> read_File_Infor(String tableName, String databaseName)
        {
            List<Field> myList = new List<Field>();
            List<String> myContents = read_Contents("database/" + databaseName + "/" + tableName + "inf_.txt");
            foreach (String str in myContents)
            {
                myList.Add(getField(str));
            }
            return myList;

        }

        public List<String[]> read_File_Infor_FK(String tableName, String databaseName)
        {
            List<String[]> myList = new List<String[]>();
            List<String> myContents = read_Contents("database/" + databaseName + "/" + tableName + "_FK_inf_.txt");
            foreach (String str in myContents)
            {
                String[] arr = new String[3];

                String temp = str;
                temp = temp.Substring(1, temp.Length - 1);

                arr[0] = "";
                while (temp.Length > 0 && temp[0] != '/')
                {
                    arr[0] += temp[0];
                    temp = temp.Substring(1, temp.Length - 1);
                }

                temp = temp.Substring(1, temp.Length - 1);
                arr[1] = "";
                while (temp.Length > 0 && temp[0] != '/')
                {
                    arr[1] += temp[0];
                    temp = temp.Substring(1, temp.Length - 1);
                }

                temp = temp.Substring(1, temp.Length - 1);
                arr[2] = "";
                while (temp.Length > 0 && temp[0] != '/')
                {
                    arr[2] += temp[0];
                    temp = temp.Substring(1, temp.Length - 1);
                }


                myList.Add(arr);
            }
            return myList;

        }

        private Field getField(String str)
        {

            Field f = new Field();
            str = str.Substring(1, str.Length - 1);
            while (str[0] != '/' && str.Length > 0)
            {
                f.ColName += str[0];
                str = str.Substring(1, str.Length - 1);
            }
            str = str.Substring(1, str.Length - 1);
            while (str[0] != '/' && str.Length > 0)
            {
                f.ColPro += str[0];
                str = str.Substring(1, str.Length - 1);
            }
            str = str.Substring(1, str.Length - 1);

            f.isPK = Convert.ToBoolean(str);

            return f;
        }


        public void delete_file(String filePath)
        {

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }

        public void delete_dr(String filePath)
        {

            try
            {
                Directory.Delete( filePath, true);
            }
            catch
            { }
        }



        // đọc ra danh sách columname
        public List<String> getColName_From_Object(List<Field> myList)
        {
            List<String> myStringList = new List<string>();
            foreach (Field fi in myList)
            {
                myStringList.Add(fi.ColName);
            }
            return myStringList;
        }

        // đọc ra kiểu dữ liệu của từng coltrong table
        public List<String> getCol_datatypes_From_Object(List<Field> myList)
        {
            List<String> myStringList = new List<string>();
            foreach (Field fi in myList)
            {
                myStringList.Add(fi.ColPro);
            }
            return myStringList;
        }


        private bool isInDelete(int i, List<int> myList)
        {
            for (int j = 0; j < myList.Count; j++)
            {
                if (myList[j] == i)
                    return true;
            }
            return false;
        }

        public List<String[]> read_Table_Contents(String tableName, String DbName, List<Field> myField, List<int> delete_index)
        {
            List<String[]> myReturnList = new List<String[]>();
            // đọc nội dung của file ra 1 danh sách
            List<String> myFileContents = read_Contents("database/" + DbName + "/" + tableName + ".txt");

            foreach (String lines in myFileContents)
            {
                int n = myField.Count;
                int nStr = 0;
                String[] newString = new String[n];
                newString[nStr] = "";
                String temp = lines.Substring(1, lines.Length - 1);

                while (temp.Length > 0)
                {

                    if (!isInDelete(nStr, delete_index))
                    {
                        temp = temp.Substring(1, temp.Length - 1);
                        while( temp.Length > 0 &&temp[0] != '\'')
                        {
                            temp = temp.Substring(1, temp.Length - 1);
                        }
                    }
                    else
                    {
                        if (temp[0] != '\'')
                        {
                            newString[nStr] += temp[0];
                            temp = temp.Substring(1, temp.Length - 1);
                        }
                        else
                        {
                            temp = temp.Substring(1, temp.Length - 1);
                            nStr++;
                            newString[nStr] = "";
                        }
                    }
                }

                myReturnList.Add(newString);
            }
            return myReturnList;
        }


        public List<String[]> read_Table_Contents(String tableName, String DbName, List<Field> myField)
        {

            HashMD5 hash = new HashMD5(DbName);

            List<String[]> myReturnList = new List<String[]>();
            // đọc nội dung của file ra 1 danh sách
            List<String> myFileContents = read_Contents("database/" + DbName + "/" + tableName + ".txt");

            foreach (String lines in myFileContents)
            {
                int n = myField.Count;
                int nStr = 0;
                String[] newString = new String[n];
                newString[nStr] = "";
                String temp = lines.Substring(1, lines.Length - 1);

                while (temp.Length > 0)
                {
                        if (temp[0] != '\'')
                        {
                            newString[nStr] += temp[0];
                            temp = temp.Substring(1, temp.Length - 1);
                        }
                        else
                        {
                        newString[nStr] =newString[nStr];
                      //  newString[nStr] = hash.Decrypt(newString[nStr]);
                            temp = temp.Substring(1, temp.Length - 1);
                            nStr++;
                            newString[nStr] = "";
                        }
                    
                }
               // newString[newString.Length-1] = hash.Decrypt(newString[newString.Length - 1]);
                myReturnList.Add(newString);
            }
            return myReturnList;
        }
    }
}
