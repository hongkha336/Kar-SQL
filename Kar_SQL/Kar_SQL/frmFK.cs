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
    public partial class frmFK : Form
    {
        public frmFK()
        {
            InitializeComponent();
            dt = new data_table();
        }

        String dbName;
        String tbName;
        List<String> myTableNames;
        writeFile wF;
        readFile rF;
        List<String> listThuocTinh1;
        List<Field> myField;
        List<String[]> myContents;
        int BeforeCells;
        int BeforeRows;


        public frmFK(String db, String dt, List<String> myTableNames)
        {
            InitializeComponent();
            dbName = db;
            tbName = dt;
            this.myTableNames = myTableNames;
            wF = new writeFile(dbName);
            rF = new readFile();
            myField = new List<Field>();
            BeforeCells = -1;
            BeforeRows = -1;

        }



        private data_table dt;

        private void dgvData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = dgvData.CurrentCell.RowIndex;
            int c = dgvData.CurrentCell.ColumnIndex;


            if (c==1)
            {
                // Kiểm tra xem 0 có chữ chưa?
                //focus 0
                if (dgvData.Rows[r].Cells[0].Value == null)
                {
                    MessageBox.Show("Vui lòng chọn thuộc tính 1 trước");
                    // focus lại ô 0
                    dgvData.CurrentCell = dgvData.Rows[0].Cells[0];
                    return;
                }

                //======
            }


            try
            {

                String colContents = "";
                try
                {
                    colContents = dgvData.Rows[r].Cells[c].Value.ToString();
                }
                catch { };

                if (!colContents.Equals(""))
                {
                    // ĐỌC DỮ LIỆU QUA BÊN KIA


                    String myTB = dgvData.Rows[r].Cells[1].Value.ToString();

                    List<Field> myField2 = new List<Field>();
                    myField2 = rF.read_File_Infor(myTB, dbName);

                    if (myField2.Count == 0)
                        return;

                    List<String> listThuocTinh3 = new List<String>();
                    foreach (Field fi in myField2)
                    {
                        String str1 = dgvData.Rows[r].Cells[0].Value.ToString();
                        if (isSameDataType(str1, fi.ColName, myField2))
                        {
                            listThuocTinh3.Add(fi.ColName);
                        }
                    }
                    dataGridView1.DataSource = null;
                    dataGridView1.Rows[0].Cells[0].Value = "";
                    cmbthuoctinh3.DataSource = listThuocTinh3;



                    try
                    {
                        dataGridView1.Rows.RemoveAt(0);
                        dataGridView1.Rows.RemoveAt(1);
                    }
                    catch { }

                    dataGridView1.Rows.Add(myContents[r][2]);
                    //  MessageBox.Show(myContents[r][2]);
                }
            }
            catch { }
        }

        private void dgvData_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // Sau khi endit
            int r = dgvData.CurrentCell.RowIndex ;
            int c = BeforeCells;

            String  str = "null nè";
            if (c == 1)
            {
                try
                {
                    str = dgvData.Rows[r].Cells[1].Value.ToString();
                }
                catch { }


                // lấy được str // với str là tên bảng.
                // sau đó load qua cái dgv bên kia;


                List<Field> myField2 = new List<Field>();
                myField2 = rF.read_File_Infor(str, dbName);

                if (myField2.Count == 0)
                    return;

                List<String> listThuocTinh3 = new List<String>();
                foreach(Field fi in myField2)
                {
                    String str1 = dgvData.Rows[r].Cells[0].Value.ToString();
                    if(isSameDataType(str1,fi.ColName,myField2))
                    {
                        listThuocTinh3.Add(fi.ColName);
                    }
                }

                dataGridView1.Rows[0].Cells[0].Value = "";
                cmbthuoctinh3.DataSource = listThuocTinh3;

            }


            if (BeforeCells == 0)
            {
                String[] arr = new String[3];
                arr[0] = ""; arr[1] = ""; arr[2]="";

                
                myContents.Add(arr);
                myContents[BeforeRows][0] = dgvData.Rows[BeforeRows].Cells[BeforeCells].Value.ToString();

            }

            if(BeforeCells == 1)
            {
                myContents[BeforeRows][1] = dgvData.Rows[BeforeRows].Cells[BeforeCells].Value.ToString();
            }


     
        }



        private void loadData()
        {
            // Load xong dữ liệu cần

            myField = rF.read_File_Infor(tbName, dbName);

            listThuocTinh1 = new List<String>();

            foreach (Field fi in myField)
            {
                listThuocTinh1.Add(fi.ColName);
            }

            cmbthuoctinh1.DataSource = listThuocTinh1;
            cmbBanggFK.DataSource = myTableNames;
            //Load dữ liệu đã ghi trước đó


            myContents = new List<String[]>();
            try
            {
                myContents = rF.read_File_Infor_FK(tbName, dbName);
            }
            catch { }

            //Không có thì dừng
            if (myContents.Count == 0)
                return;


            // có thì load nó lên

            for(int i = 0; i<myContents.Count; i++)
            {
                dgvData.Rows.Add(myContents[i][0], myContents[i][1]);
            }
        }

        private void frmFK_Load(object sender, EventArgs e)
        {
            lbTableName.Text += "BẢNG " + tbName + " - " + dbName;
            lbTableName.Left = this.Width / 2 - lbTableName.Width / 2;
            loadData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            List<String> newContents = new List<String>();
            foreach(String[] str in myContents)
            {
                newContents.Add("/" + str[0] + "/" + str[1] + "/"+ str[2]);
            }

            wF.delete_file("database/" + dbName + "/" + tbName + "_FK_inf_.txt");
            wF.write_Table_Infor_FK(newContents, tbName);
            MessageBox.Show("Đã update FK");
            this.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
           
            myContents[BeforeRows][2] = dataGridView1.Rows[0].Cells[0].Value.ToString();
          
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs anError)
        {
            MessageBox.Show("Xãy ra lỗi " + anError.Context.ToString());

            if (anError.Context == DataGridViewDataErrorContexts.Commit)
            {
                MessageBox.Show("Commit error");
            }
            if (anError.Context == DataGridViewDataErrorContexts.CurrentCellChange)
            {
                MessageBox.Show("Cell change");
            }
            if (anError.Context == DataGridViewDataErrorContexts.Parsing)
            {
                MessageBox.Show("parsing error");
            }
            if (anError.Context == DataGridViewDataErrorContexts.LeaveControl)
            {
                MessageBox.Show("leave control error");
            }

            if ((anError.Exception) is ConstraintException)
            {
                DataGridView view = (DataGridView)sender;
                view.Rows[anError.RowIndex].ErrorText = "an error";
                view.Rows[anError.RowIndex].Cells[anError.ColumnIndex].ErrorText = "an error";

                anError.ThrowException = false;
            }
        }
    
        private bool isSameDataType(String str1, String str2, List<Field> myField2)
        {
            String dtType = "";
            foreach(Field fi in myField)
            {
                if(fi.ColName.Equals(str1))
                {
                    dtType = fi.ColPro;
                    break;
                }
            }



            foreach(Field fi in myField2)
            {
                if(fi.ColName.Equals(str2))
                {
                    if (dtType.Equals(fi.ColPro))
                        return true;
                    return false;
                }
            }

            return false;

        }

        private void dgvData_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            BeforeCells = dgvData.CurrentCell.ColumnIndex;
            BeforeRows = dgvData.CurrentCell.RowIndex;
        }
    }
}
