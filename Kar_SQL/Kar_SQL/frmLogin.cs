using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kar_SQL
{
    public partial class frmLogin : Form
    {

       private String accessCode;

        public frmLogin()
        {
            InitializeComponent();
            accessCode = ""; 
            loadConfig();
        }

        

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void loadConfig()
        {
            protectFolder pF = new protectFolder("1", "1");
            try
            {
                if (accessCode.Equals(""))
                {
                    pF.create_bat_File();
                    //Mở khóa config;
                    pF.run_bat_file();
                    Thread.Sleep(200);
                    accessCode = readPassword();
                    //Khóa config;
                     pF.run_bat_file();
                    //xóa file bat
                    Thread.Sleep(200);
                    pF.delete_bat_file();
                }
            }
            catch {
                loadConfig();
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            //id là key mã hóa md5
            HashMD5 hm = new HashMD5("id@");
            String encript = hm.Encrypt(txtCode.Text);
            if (encript.Equals(accessCode))
            {
                frmMain f = new frmMain(accessCode);
                this.Hide();
                f.ShowDialog();
                this.Show();
                txtCode.ResetText();
            }
            else
                MessageBox.Show("Mật khẩu sai");
        }


        private String readPassword()
        {
            string[] lines = File.ReadAllLines("secured/config.inf");
            return lines[0];
        }

        private void txtCode_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                btnLogin_Click(null, null);
            }
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            protectDatabase pd = new protectDatabase("1","1");
            pd.delete_bat_file();
        }
    }
}
