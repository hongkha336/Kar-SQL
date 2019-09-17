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
    public partial class frmNewDatabase : Form
    {
        public frmNewDatabase()
        {
            InitializeComponent();
        }

        private void frmNewDatabase_Load(object sender, EventArgs e)
        {

        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {

                string directoryPath = "Database/"+txtName.Text;

                if (!System.IO.Directory.Exists(directoryPath))
                {
                    System.IO.Directory.CreateDirectory(directoryPath);
                    MessageBox.Show("Database " + txtName.Text + " đã được tạo", "Thông báo");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Tên Database đã tồn tại", "Thông báo");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException.ToString());
            }
        }
    }
}
