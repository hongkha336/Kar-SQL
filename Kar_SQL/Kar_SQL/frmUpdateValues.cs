using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kar_SQL
{
    public partial class frmUpdateValues : Form
    {
        public frmUpdateValues()
        {
            InitializeComponent();
        }


        bool isUpdate;
        private String db;
        private String tb;
        readFile rF;
        writeFile wF;
        List<Field> myField;
        data_table dt;
        HashMD5 hash;
        String keyHash;
        List<string> myDatatype;
        Datatypes datatype;
        List<int> myPK_index;
        private List<string[]> myContents_FK;
        List<String> myFKList;

        public frmUpdateValues(string db, string tb)
        {
            keyHash = db;
            InitializeComponent();
            this.db = db;
            this.tb = tb;
            rF = new readFile();
            dt = new data_table();
            wF = new writeFile();
            myField = rF.read_File_Infor(tb, db);
            myPK_index = getListPrimaryKey(myField);
            myContents_FK = new List<String[]>();
            datatype = new Datatypes();
            myDatatype = new List<String>();
            getDataType();

            isUpdate = true;
            hash= new HashMD5(keyHash);
            
        }

        private void getDataType()
        {
            foreach(Field fi in myField)
            {
                myDatatype.Add(fi.ColPro);
            }
        }       
        


        public void loadFKdata()
        {
            myContents_FK = new List<String[]>();
            try
            {
                myContents_FK = rF.read_File_Infor_FK(tb, db);
            }
            catch { }

            myFKList = new List<string>();

            lbFK.Text += " ";
            foreach (String[] fi in myContents_FK)
            {
                myFKList.Add(fi[0]);
                lbFK.Text += fi[0] +" ";
            }
            
            

        }

        private void frmUpdateValues_Load(object sender, EventArgs e)
        {
            lbTableName.Text += " " + tb + " - " + db;

            lbTableName.Left = (panel1.Right - panel1.Left) / 2 - lbTableName.Width / 2;

            List<String[]> my_Table_Contents = rF.read_Table_Contents(tb, db, myField);
            lbPK.Text += getPrimaryKey(myField);

            dgvData.DataSource = dt.ConvertListToDataTable(myField, my_Table_Contents);

            loadFKdata();
        }

        private String getPrimaryKey(List<Field> myList)
        {
            String myPK = "";
            foreach(Field fi in myList)
            {
                if(fi.isPK)
                {
                    if (myPK.Trim().Equals(""))
                        myPK += " " +fi.ColName;
                    else
                        myPK += " "+ fi.ColName;
                }
            }
            return myPK;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            List<String> myContents = new List<String>();
            // ghi lại nội dung trên file
            int r = dgvData.RowCount;
            int c = dgvData.ColumnCount;
            for (int i = 0; i < r-1; i++)
            {
                String lineContents = "";
                for (int j = 0; j < c; j++)
                {
                    //  lineContents = lineContents+ '\'' + hash.Encrypt(dgvData.Rows[i].Cells[j].Value.ToString());
                    lineContents = lineContents + '\'' + dgvData.Rows[i].Cells[j].Value.ToString();
                }
                myContents.Add(lineContents);   
            }

            wF.write_Table_Contents(myContents, tb, db);
            MessageBox.Show("Đã updates dữ liệu");
            isUpdate = true;
            
        }

        private void btnRevert_Click(object sender, EventArgs e)
        {
            List<String[]> my_Table_Contents = rF.read_Table_Contents(tb, db, myField);
            dgvData.DataSource = dt.ConvertListToDataTable(myField, my_Table_Contents);
            isUpdate = true;
        }

        private void frmUpdateValues_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(!isUpdate)
            {
                DialogResult tl = MessageBox.Show("Dữ liệu chưa được cập nhật, Vẫn đóng cửa sổ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (tl == DialogResult.No)
                    e.Cancel = true;
            }
        }


     

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            isUpdate = false;
        }



        private String getColDatatype(int c)
        {
            return myDatatype[c];
        }


        private void dgvData_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int cPos = dgvData.CurrentCell.ColumnIndex;
            String dataType = getColDatatype(cPos);
            int rPos = dgvData.CurrentCell.RowIndex;
            String txt = dgvData.Rows[rPos].Cells[cPos].Value.ToString();
            if (txt.Equals(""))
                return;
            try
            {

                if (!datatype.isCorrectDataType(txt, dataType))
                {
                    MessageBox.Show("Sai định dạng dữ liệu " +dataType);
                    dgvData.Rows[rPos].Cells[cPos].Value = "";
                }
            }
            catch
            { }



            if(isInPKList(cPos,myPK_index))
            {

                if (txt.Trim().Equals(""))
                {
                    MessageBox.Show("Khóa chính không được để trống");
                    return;
                }
                // Kiểm tra trùng dữ liệu. 
                //Lấy kiểu string so sánh.
                List<String> myCol_Values = new List<String>();
                for(int i = 0; i<dgvData.RowCount-1; i++)
                {
                    myCol_Values.Add(dgvData.Rows[i].Cells[cPos].Value.ToString());
                }


                int count = 0;
                foreach (String str in myCol_Values)
                {
                    if(str.Trim().ToLower().Equals(txt.Trim().ToLower().ToString()))
                    {
                        count++;
                    }
                }

                if(count>1)
                {
                    MessageBox.Show("Khóa chính bị trùng");
                    dgvData.Rows[rPos].Cells[cPos].Value = "";
                    return;
                }
            }


            if(isInFKList(pre_cPos))
            {
                String thisContents = "";
                try
                { thisContents = dgvData.Rows[pre_rPos].Cells[pre_cPos].Value.ToString();
                }
                catch { }


                if (thisContents.Equals(""))
                    return;
                // phải lấy được cái fkey là cái key của bảng query tới
               
                if(!isKeyInTable(pre_cPos,thisContents))
                {
                    MessageBox.Show("Nội dung khóa ngoại không tồn tại");
                    dgvData.Rows[pre_rPos].Cells[pre_cPos].Value = "";
                    return;
                }
            }

        }


        private List<int> getListPrimaryKey(List<Field> myFi)
        {
            List<int> myPK = new List<int>();
            for (int i = 0; i < myFi.Count; i++)
                if (myFi[i].isPK)
                    myPK.Add(i);
            return myPK;
        }


        private bool isInPKList(int i, List<int> myList)
        {
            foreach(int k in myList)
            {
                if (i == k)
                    return true;
            }
            return false;
        }


        private bool isInFKList(int col)
        {
            // lấy cái tên trong của myField ra

            String colName = myField[col].ColName;

            foreach(String str in myFKList)
            {
                if (str.Equals(colName))
                    return true;
            }
            return false;
        }



        int pre_cPos;
        int pre_rPos;
        private void dgvData_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            pre_cPos = dgvData.CurrentCell.ColumnIndex;
            pre_rPos = dgvData.CurrentCell.RowIndex;
        }


        private bool isKeyInTable( int Col, String key)
        {
            List<Field> myField = rF.read_File_Infor(tb, db);
            List<String[]> my_Table_Contents = rF.read_File_Infor_FK(tb, db);

            // nội dung của cột hiện hành key
            // cột này ở vị trí col => kiểm tra xem Fkey với cái nào
            String myC = myField[Col].ColName;
            String myFKColName = "";
            String myFKColTable = "";
            //vào my tab contentsFK
            foreach(String [] str in my_Table_Contents)
            {
                if(str[0].Equals(myC))
                {
                    myFKColTable = str[1];
                    myFKColName = str[2];
                    break;
                }
            }

            // Lấy được tên cột và bảng cần tìm rồi.

            //đọc dữ liệu từ bảng FK lên 
            List<Field> myField_FK = rF.read_File_Infor(myFKColTable, db);
            List<String[]> my_Table_Contents_FK = rF.read_Table_Contents(myFKColTable, db, myField_FK);
            // tìm vị trí có tên là khóa ngoại ở Field;
            int t = 0;
            for(int i = 0; i<myField_FK.Count; i++)
            {
                if(myField_FK[i].ColName.Equals(myFKColName))
                {
                    t = i; break;
                }
            }


            for(int i= 0; i<my_Table_Contents_FK.Count;i++)
            {
                if (my_Table_Contents_FK[i][t].Equals(key))
                    return true;
            }

            return false;

            
        }
    }
}
