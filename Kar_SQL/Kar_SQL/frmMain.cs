using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace Kar_SQL
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }


        Datatypes datatype;
        protectDatabase pd;
        List<String> myDatabases;
        readFile rF;
        writeFile wF;
        List<String> myTables;
        // chiều cao mặc định flow
        public int defaultHight_flow;
        public int isAlter;


        private void openConnect()
        {
            
            pd.create_bat_File();      
            pd.run_bat_file();
            Thread.Sleep(300);
        }

        private String accessCode;

        public frmMain(String accessCode)
        {
            InitializeComponent();
            this.accessCode = accessCode;
            rF = new readFile();
            wF = new writeFile();
            datatype = new Datatypes();
            isAlter = 0;
            pd = new protectDatabase("1", "1");

        }


        private void loadDataBase()
        {
           
            myDatabases = rF.loadDataBase();
            if (myDatabases.Count == 0)
                frmMain_Load(null, null);

        }

        private void visible()
        {
            txtschema.Hide();
            panel2.Hide();
            panel3.Enabled = true;
            cmbDatabase.Text = "master";
            pnInsertTable.Hide();
           
            btnDropDatabase.Hide();
        }


 
        private void frmMain_Load(object sender, EventArgs e)
        {
            
            openConnect();
            loadDataBase();
            cmbDatabase.DataSource = myDatabases;
            visible();
            // độ cao mặc định
            defaultHight_flow = floData.Height;
        }

    

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {


            if (frmMain.ModifierKeys == Keys.Alt || frmMain.ModifierKeys == Keys.F4)
            {
                e.Cancel = true;
                return;
            }

            // chạy lần nữa để đóng
            pd.run_bat_file();
            Thread.Sleep(200);
            pd.delete_bat_file();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            frmNewDatabase f = new frmNewDatabase();
            f.ShowDialog();
            loadDataBase();
            cmbDatabase.DataSource = myDatabases;
        }

        private void btnNewSchema_Click(object sender, EventArgs e)
        {
            txtschema.Show();
            txtschema.Width = this.Width - panel1.Width - pnDB.Width - 30 ;
            txtschema.Height = this.Height - menuStrip1.Height;
            btnNewSchema.Hide();
            txtschema.Focus();
        }

        private void btnCloseSchema_Click(object sender, EventArgs e)
        {
            btnNewSchema.Show();
            txtschema.Hide();

        }

        private void btnNewTable_Click(object sender, EventArgs e)
        {

            isAlter_firsTime = false;

            old_name_table = "";
            btnDrop.Hide();
            colCount = -1;
            txtTableName.ResetText();
            btnAlter.Enabled = false;
            btnUpdateValue.Enabled = false;
            btnNewTable.Enabled = false;
            btnDisconnect.Enabled = false;
            btnDropDatabase.Enabled = false;
            cmbTables.Enabled = false;
            isAlter = 0;
            pnInsertTable.Show();
            txtTableName.Focus();
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            DialogResult tl = MessageBox.Show("Bạn muốn ngắt kết nối với database hiện hành?", "Thông báo",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if(tl==DialogResult.Yes)
            {
                panel3.Enabled = true;
                panel2.Hide();
                txtschema.ResetText();
                cmbDatabase.Text = "master";
                resetTable();
              
            }
        }

        private void btnChon_Click(object sender, EventArgs e)
        {
           
            panel3.Enabled = false;
            myTables = rF.loadTableInDatabase(cmbDatabase.SelectedValue.ToString());
            cmbTables.ResetText();
            cmbTables.DataSource = myTables;
            btnDropDatabase.Show();
            panel2.Show();
            checkException();

            pnDB.Show();

        }

        private void checkException()
        {
            if (myTables.Count == 0)
            {
                btnAlter.Enabled = false;
                btnUpdateValue.Enabled = false;
                btnFK.Enabled = false;
  
            }
            else
            {
                btnAlter.Enabled = true;
                btnUpdateValue.Enabled = true;
                btnFK.Enabled = true;


            }
        }

        private void btnAddCol_Click(object sender, EventArgs e)
        {
       

            if (isAlter == 1)
                resetTemp();


            
        
                foreach (Control items in floData.Controls)
                {
                    if (items.Name.Equals("txtColName" + colCount.ToString()))
                    {
                        TextBox txt = (TextBox)items;
                        if (txt.Text.Equals("") && !isAlter_firsTime)
                        {
                            MessageBox.Show("Vui lòng điền đầy đủ thông tin để thêm thuộc tính mới");
                            txt.Focus();
                            return;
                        }
                        break;
                    }
                }
           
            floData.Height += 32;
            btnAddCol.Top = floData.Bottom;
            btnHoanThanh.Top = floData.Bottom;
            btnHuy.Top = floData.Bottom;
            colCount++;
            addButton();
        }

        int colCount = -1;

        public String txtColname_values ="";
        public String txtProp_values = "";
        public bool chk_PK_Values = false;
        private void addButton()
        {
            TextBox txt = new TextBox();
            // txtColName0
            // 
            txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txt.Location = new System.Drawing.Point(3, 3);
            txt.Name = "txtColName"+colCount.ToString();
            txt.Size = new System.Drawing.Size(221, 30);
            txt.Text = txtColname_values;
            txt.TabIndex = 7;
            txt.Leave += new System.EventHandler(this.txt_Leave);
            this.floData.Controls.Add(txt);
            txt.Focus();
            // 
            // txtColPro0
            // 
            txt = new TextBox();
            txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txt.Location = new System.Drawing.Point(3, 3);
            txt.Name = "txtColPro" + colCount.ToString();
            txt.Size = new System.Drawing.Size(221, 30);
            if (!txtProp_values.Trim().Equals(""))
                txt.Text = txtProp_values;
            else
                txt.Text = "VARCHAR";
            txt.TabIndex = 7;
            txt.Leave += new System.EventHandler(this.txtPro_Leave);
            this.floData.Controls.Add(txt);
            // 
            // chk0
            // 
            CheckBox chk = new CheckBox();
            chk.AutoSize = true;
            chk.FlatAppearance.BorderColor = System.Drawing.Color.White;
            chk.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chk.ForeColor = System.Drawing.Color.Green;
            chk.Location = new System.Drawing.Point(457, 3);
            chk.Name = "chk"+colCount.ToString();
            chk.Size = new System.Drawing.Size(18, 17);
            chk.TabIndex = 9;
            chk.UseVisualStyleBackColor = true;

            if (chk_PK_Values)
                chk.CheckState = CheckState.Checked;

            this.floData.Controls.Add(chk);
        }

        private void txtPro_Leave(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender; //lấy Textbox đang được click 
            String tagtext = txt.Name.ToString();
            if(!datatype.isExistDataType(txt.Text.Trim()))
            {
                MessageBox.Show("Kiểu dữ liệu không đúng! Kiểu dữ liệu phải là INT,VARCHAR,NVARCHAR,CHAR,BIT");
                txt.Focus();
            }
            else
            {
                txt.Text = txt.Text.ToUpper();
            }
        }

        private bool isSameField(List<Field> M1, List<Field> M2)
        {
            for(int i = 0; i<M1.Count; i++)
            {
                if (M1[i] != M2[i])
                    return false;
            }
            return true;
        }


        private bool isInDelete(int i, List<int> myList)
        {
               for(int j = 0; j<myList.Count; j++)
                {
                if (myList[j] == i)
                    return true;
                }
            return false;
        }

        private void btnHoanThanh_Click(object sender, EventArgs e)
        {
      
            


            if (txtTableName.Text.Trim().Equals(""))
            {
                MessageBox.Show("Tên bảng không được để trống");
                txtTableName.Focus();
                return;
            }

            List<Field> myField_1 = new List<Field>();

            if (isAlter == 1)
            {
                myField_1 = rF.read_File_Infor(cmbTables.SelectedValue.ToString(), cmbDatabase.SelectedValue.ToString());
            }


            List<int> delete_index = new List<int>();
            List<Field> myField = new List<Field>();



            for (int i = 0; i <= colCount; i++)
            {
                String text1 = getText("txtColName" + i.ToString());
                String text2 = getText("txtColPro" + i.ToString());
                bool text3 = isCheck("chk" + i.ToString());

                if (!text1.Trim().Equals("") && !text2.Trim().Equals(""))
                {

                    Field fi = new Field(text1,text2,text3);
                    myField.Add(fi);
                }
                else
                {
                     if(isAlter == 1)
                        delete_index.Add(i);
                }
            }
            if (isAlter == 1)
            {
                try
                {
                    rF.delete_file("database/" + cmbDatabase.SelectedValue.ToString() + "/" + cmbTables.SelectedValue.ToString() + "inf_.txt");
                }
                catch
                {

                }
            }
            wF.write_Table_Infor(myField, txtTableName.Text.Trim(), cmbDatabase.SelectedValue.ToString());

            if (isAlter == 1)
            {


                if (isSameField(myField, myField_1))
                    return;

                // lấy myField ra trước
                myField = rF.read_File_Infor(cmbTables.SelectedValue.ToString(), cmbDatabase.SelectedValue.ToString());
                //Xóa file cũ.

                //backup file mới.

                List<String[]> my_Table_Contents = rF.read_Table_Contents(cmbTables.SelectedValue.ToString(), cmbDatabase.SelectedValue.ToString(), myField_1);
                List<String> myContents = new List<String>();
                foreach (String[] str in my_Table_Contents)
                {
                    String temp = "";
                    for (int i = 0; i < str.Length; i++)
                    {
                       if(!isInDelete(i,delete_index))
                            temp += '\'' + str[i];
                    }
                    myContents.Add(temp);

                }
                if (isAlter == 1)
                {
                    try
                    {
                        rF.delete_file("database/" + cmbDatabase.SelectedValue.ToString() + "/" + cmbTables.SelectedValue.ToString() + ".txt");
                    }
                    catch { }
                }
                wF.write_Table_Contents(myContents, txtTableName.Text.ToString(), cmbDatabase.SelectedValue.ToString());
            }


            if (isAlter == 1)
                MessageBox.Show("Đã update table thành công");
            
            resetTable();
            isAlter = 0;

        }


        private void resetTable()
        {

            txtTableName.ResetText();
            cmbTables.ResetText();
            floData.Controls.Clear();
            floData.Height = defaultHight_flow;
            btnAddCol.Top = floData.Bottom;
            btnHoanThanh.Top = floData.Bottom;
            btnHuy.Top = floData.Bottom;
            pnInsertTable.Hide();
            myTables = rF.loadTableInDatabase(cmbDatabase.SelectedValue.ToString());
            cmbTables.DataSource = myTables;
            resetTemp();

            btnAlter.Enabled = true;
            btnUpdateValue.Enabled = true;
            btnNewTable.Enabled = true;
            btnDisconnect.Enabled = true;
            btnDropDatabase.Enabled = true;
            cmbTables.Enabled = true;
            checkException();
        }

        private void resetTemp()
        {
            txtColname_values = "";
            txtProp_values = "";
            chk_PK_Values = false;
        }

    

        private String getText(String txtName)
        {
            String text = "";
            foreach(Control txt in floData.Controls)
            {
                if(txt.Name.Equals(txtName))
                {
                    TextBox txt1 = (TextBox)txt;
                    text = txt1.Text;
                    break;
                }
            }
            return text;
        }


        private bool isCheck(String chkName)
        {
            bool check = false;
            foreach (Control chk_ in floData.Controls)
            {

                if (chk_.Name.Equals(chkName))
                {
                    CheckBox ch = (CheckBox)chk_;
                    if (ch.Checked)
                        check = true;
                    break;
                }
            }
            return check;
        }

        private void thoatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pd.run_bat_file();
            Thread.Sleep(200);
            pd.delete_bat_file();
            this.Close();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            DialogResult tl = MessageBox.Show("Xác nhận hủy", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (tl == DialogResult.Yes)
            {
                resetTable();
                isAlter = 0;
            }
        }

        private String old_name_table;
        private bool isAlter_firsTime;
        private void btnAlter_Click(object sender, EventArgs e)
        {
            colCount = -1;
            isAlter_firsTime = true;
            old_name_table = cmbTables.SelectedValue.ToString();

            btnDrop.Show();
            btnAlter.Enabled = false;
            btnUpdateValue.Enabled = false;
            btnNewTable.Enabled = false;
            btnDisconnect.Enabled = false;
            btnDropDatabase.Enabled = false;
            cmbTables.Enabled = false;

            txtTableName.ResetText();
            txtTableName.Text = cmbTables.SelectedValue.ToString();
            pnInsertTable.Show();

            List<Field> myField = rF.read_File_Infor(cmbTables.SelectedValue.ToString(),cmbDatabase.SelectedValue.ToString());
            colCount = -1;
            for (int i =0; i<myField.Count; i++)
            {
                txtColname_values = myField[i].ColName;
                txtProp_values = myField[i].ColPro;
                chk_PK_Values = myField[i].isPK;
                btnAddCol_Click(null, null);
            }


            isAlter_firsTime = false;
            isAlter = 1;
            txtTableName.Focus();
        }

        private void btnUpdateValue_Click(object sender, EventArgs e)
        {
            String db = cmbDatabase.SelectedValue.ToString();
            String tb = cmbTables.SelectedValue.ToString();
            frmUpdateValues f = new frmUpdateValues(db, tb);
            f.ShowDialog();
        }

        private void thoatctToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult tl = MessageBox.Show("Bạn muốn đóng chương trình", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (tl == DialogResult.Yes)
            {
                pd.run_bat_file();
                Thread.Sleep(200);
                pd.delete_bat_file();

                Application.Exit();
            }
        }

        private void btnDrop_Click(object sender, EventArgs e)
        {
            DialogResult tl = MessageBox.Show("Thao tác này sẽ khiến bạn mất toàn bộ dữ liệu của bảng này và không thể khôi phục, Tiếp tục", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (tl == DialogResult.Yes)
            {

                //check FK 

                // Droptable
                drop_table();

                MessageBox.Show("Đã drop thành công");
               
                myTables = rF.loadTableInDatabase(cmbDatabase.SelectedValue.ToString());
                cmbTables.ResetText();
                cmbTables.DataSource = myTables;
                floData.Controls.Clear();
             
            floData.Height = defaultHight_flow;
            btnAddCol.Top = floData.Bottom;
            btnHoanThanh.Top = floData.Bottom;
            btnHuy.Top = floData.Bottom;
            pnInsertTable.Hide();
                old_name_table = "";

                btnAlter.Enabled = true;
                btnDisconnect.Enabled = true;
                cmbTables.Enabled = true;
                checkException();
                resetTable();
              //  resetTable();
                isAlter = 0;
            }
        }


        private void drop_table()
        {
            wF.delete_file("database/" + cmbDatabase.SelectedValue.ToString() + "/" + cmbTables.SelectedValue.ToString() + ".txt");
            wF.delete_file("database/" + cmbDatabase.SelectedValue.ToString() + "/" + cmbTables.SelectedValue.ToString() + "inf_.txt");
        }

        private void txtTableName_Leave(object sender, EventArgs e)
        {
            if(txtTableName.Text.Trim().Equals("") && colCount !=-1 && pnInsertTable.Visible == true)
            {
                MessageBox.Show("Tên bảng không được để trống");
                txtTableName.Focus();
            }


            int i = 0;
            foreach (String str in myTables )
            {
                if (str.Trim().ToLower().Equals(txtTableName.Text.Trim().ToLower()))
                    i++;
            }
            
            if(i>0 && isNameChange)
            {
                MessageBox.Show("Tên bảng bị trùng lắp");
                txtTableName.Focus();
            }
            

        }

        private void txt_Leave(object sender, EventArgs e)
        {
            if (isAlter_firsTime)
                return;

           TextBox txt = (TextBox)sender; //lấy Textbox đang được click 
           String tagtext =  txt.Name.ToString();

            List<String> valuesCol = new List<String>();
            foreach(Control items in floData.Controls)
            {
                if(items.Name.StartsWith("txtColName"))
                {
                    TextBox txt_temp = (TextBox)items;
                    valuesCol.Add(txt_temp.Text);
                }
            }

            int i = 0;
            foreach(String str in valuesCol)
            {
                if (str.ToLower().Trim().Equals(txt.Text.ToLower().Trim()))
                    i++;
            }

            if (i > 1)
            {
                MessageBox.Show("Tên trường bị trùng lặp");
                txt.Focus();
            }

        }

        private void btnDropDatabase_Click(object sender, EventArgs e)
        {
            DialogResult tl = MessageBox.Show("Database đã chọn sẽ bị xóa vĩnh viễn và không thể khôi phục", "Cảnh báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if(tl == DialogResult.OK)
            {
                if (cmbDatabase.SelectedValue.ToString().Equals("master"))
                    MessageBox.Show("Không thể xóa database mặc định", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                else
                {
                    DialogResult tl2 = MessageBox.Show("Xác nhận", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if(tl2 == DialogResult.Yes)
                    {
                        dropDatabase();
                        MessageBox.Show("Đã drop database thành công");
                        frmMain_Load(null, null);
                    }
                }
            }
        }


        public void dropDatabase()
        {
            rF.delete_dr("database/" + cmbDatabase.SelectedValue.ToString());
        }

        private  bool isNameChange;
        private void txtTableName_TextChanged(object sender, EventArgs e)
        {
            if (txtTableName.Text.Trim().ToLower().Equals(old_name_table.Trim().ToLower()))
                isNameChange = false;
            else
                isNameChange = true;
        }

        private void btnFK_Click(object sender, EventArgs e)
        {
            frmFK f = new frmFK(cmbDatabase.SelectedValue.ToString(),cmbTables.SelectedValue.ToString(),myTables);
            f.ShowDialog();
        }
    }
}
