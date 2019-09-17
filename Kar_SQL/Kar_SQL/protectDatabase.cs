using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kar_SQL
{
    public class protectDatabase
    {
        private String[] firstLine;
        private String[] secondLine;
        private String intput_Password;
        private String system_Password;

        
        public protectDatabase(String input_pass, String system_pass)
        {
            firstLine = new String[13];
            firstLine[0] = "@ECHO OFF";
            firstLine[1] = "title Folder Locker";
            firstLine[2] = "if EXIST \"Control Panel.{ 21EC2020 - 3AEA - 1069 - A2DD - 08002B30309DD}\" goto UNLOCK";
            firstLine[3] = "if NOT EXIST database goto MDLOCKER";
            firstLine[4] = ":CONFIRM";
            firstLine[5] = "goto LOCK";
            firstLine[6] = "goto CONFIRM";
            firstLine[7] = ":LOCK";
            firstLine[8] = "ren database \"Control Panel.{ 21EC2020 - 3AEA - 1069 - A2DD - 08002B30309DD}\"";
            firstLine[9] = "attrib +h +s +r +i \"Control Panel.{ 21EC2020 - 3AEA - 1069 - A2DD - 08002B30309DD}\"";
            firstLine[10] = "echo database locked";
            firstLine[11] = "goto End";
            firstLine[12] = ":UNLOCK";
            intput_Password = "SET pass=" + input_pass;

            system_Password = "if NOT %pass%==" + system_pass + " goto FAIL";


            secondLine = new String[9];
            secondLine[0] = "attrib -h -s \"Control Panel.{ 21EC2020 - 3AEA - 1069 - A2DD - 08002B30309DD}\"";
            secondLine[1] = "ren \"Control Panel.{ 21EC2020 - 3AEA - 1069 - A2DD - 08002B30309DD}\" database";
            secondLine[2] = "goto End";
            secondLine[3] = ":FAIL";
            secondLine[4] = "goto UNLOCK";
            secondLine[5] = ":MDLOCKER";
            secondLine[6] = "md database";
            secondLine[7] = "goto End";
            secondLine[8] = ":End";



        }

        public void create_bat_File()
        {
            String filepath = "dbsecure.bat";
            FileStream fs = new FileStream(filepath, FileMode.Create);     
            StreamWriter sWriter = new StreamWriter(fs, Encoding.UTF8);
            for(int i = 0; i<=12; i++)
                sWriter.WriteLine(firstLine[i]);

            sWriter.WriteLine(intput_Password);
            sWriter.WriteLine(system_Password);

            for (int i = 0; i <= 8; i++)
                sWriter.WriteLine(secondLine[i]);
            sWriter.Flush();
            fs.Close();


   
        }


        public void delete_bat_file()
        {
            string filePath = Application.StartupPath + "/dbsecure.bat";
 
            if (File.Exists(filePath))
            {

                File.Delete(filePath);
            }
        }

        public void run_bat_file()
        {
            string filePath = Application.StartupPath + "/dbsecure.bat";
            if (File.Exists(filePath))
            {
                System.Diagnostics.Process.Start("dbsecure.bat");
            }
        }
    }
}
