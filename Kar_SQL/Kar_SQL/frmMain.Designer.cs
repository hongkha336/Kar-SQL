namespace Kar_SQL
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnDropDatabase = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnNewSchema = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnCloseSchema = new System.Windows.Forms.Button();
            this.cmbDatabase = new System.Windows.Forms.ComboBox();
            this.btnRun = new System.Windows.Forms.Button();
            this.btnChon = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnFK = new System.Windows.Forms.Button();
            this.btnUpdateValue = new System.Windows.Forms.Button();
            this.btnDisconnect = new System.Windows.Forms.Button();
            this.btnNewTable = new System.Windows.Forms.Button();
            this.cmbTables = new System.Windows.Forms.ComboBox();
            this.btnAlter = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtschema = new System.Windows.Forms.RichTextBox();
            this.pnInsertTable = new System.Windows.Forms.Panel();
            this.btnHuy = new System.Windows.Forms.Button();
            this.btnHoanThanh = new System.Windows.Forms.Button();
            this.btnAddCol = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btnDrop = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTableName = new System.Windows.Forms.TextBox();
            this.floData = new System.Windows.Forms.FlowLayoutPanel();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.heThongToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thoatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thoatctToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.caiDatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.matKhauToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.maHoaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnDB = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.pnInsertTable.SuspendLayout();
            this.panel5.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.pnDB.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel1.Location = new System.Drawing.Point(0, 31);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(226, 615);
            this.panel1.TabIndex = 1;
            // 
            // btnDropDatabase
            // 
            this.btnDropDatabase.BackColor = System.Drawing.Color.Red;
            this.btnDropDatabase.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDropDatabase.ForeColor = System.Drawing.Color.White;
            this.btnDropDatabase.Location = new System.Drawing.Point(13, 548);
            this.btnDropDatabase.Name = "btnDropDatabase";
            this.btnDropDatabase.Size = new System.Drawing.Size(201, 36);
            this.btnDropDatabase.TabIndex = 10;
            this.btnDropDatabase.Text = "Drop Database";
            this.btnDropDatabase.UseVisualStyleBackColor = false;
            this.btnDropDatabase.Click += new System.EventHandler(this.btnDropDatabase_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnNew);
            this.panel3.Controls.Add(this.cmbDatabase);
            this.panel3.Controls.Add(this.btnChon);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Location = new System.Drawing.Point(3, 15);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(210, 119);
            this.panel3.TabIndex = 10;
            // 
            // btnNewSchema
            // 
            this.btnNewSchema.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnNewSchema.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewSchema.Location = new System.Drawing.Point(13, 9);
            this.btnNewSchema.Name = "btnNewSchema";
            this.btnNewSchema.Size = new System.Drawing.Size(201, 36);
            this.btnNewSchema.TabIndex = 6;
            this.btnNewSchema.Text = "New schema";
            this.btnNewSchema.UseVisualStyleBackColor = false;
            this.btnNewSchema.Click += new System.EventHandler(this.btnNewSchema_Click);
            // 
            // btnNew
            // 
            this.btnNew.BackColor = System.Drawing.Color.ForestGreen;
            this.btnNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.ForeColor = System.Drawing.Color.White;
            this.btnNew.Location = new System.Drawing.Point(110, 78);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(97, 36);
            this.btnNew.TabIndex = 5;
            this.btnNew.Text = "Mới";
            this.btnNew.UseVisualStyleBackColor = false;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnCloseSchema
            // 
            this.btnCloseSchema.BackColor = System.Drawing.Color.Red;
            this.btnCloseSchema.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCloseSchema.ForeColor = System.Drawing.Color.White;
            this.btnCloseSchema.Location = new System.Drawing.Point(12, 9);
            this.btnCloseSchema.Name = "btnCloseSchema";
            this.btnCloseSchema.Size = new System.Drawing.Size(97, 36);
            this.btnCloseSchema.TabIndex = 7;
            this.btnCloseSchema.Text = "Close schema";
            this.btnCloseSchema.UseVisualStyleBackColor = false;
            this.btnCloseSchema.Click += new System.EventHandler(this.btnCloseSchema_Click);
            // 
            // cmbDatabase
            // 
            this.cmbDatabase.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDatabase.ForeColor = System.Drawing.Color.Navy;
            this.cmbDatabase.FormattingEnabled = true;
            this.cmbDatabase.Location = new System.Drawing.Point(9, 39);
            this.cmbDatabase.Name = "cmbDatabase";
            this.cmbDatabase.Size = new System.Drawing.Size(198, 33);
            this.cmbDatabase.TabIndex = 2;
            // 
            // btnRun
            // 
            this.btnRun.BackColor = System.Drawing.Color.Green;
            this.btnRun.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRun.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnRun.Location = new System.Drawing.Point(119, 9);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(94, 36);
            this.btnRun.TabIndex = 8;
            this.btnRun.Text = "Run";
            this.btnRun.UseVisualStyleBackColor = false;
            // 
            // btnChon
            // 
            this.btnChon.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChon.ForeColor = System.Drawing.Color.Black;
            this.btnChon.Location = new System.Drawing.Point(8, 78);
            this.btnChon.Name = "btnChon";
            this.btnChon.Size = new System.Drawing.Size(97, 36);
            this.btnChon.TabIndex = 3;
            this.btnChon.Text = "Chọn";
            this.btnChon.UseVisualStyleBackColor = true;
            this.btnChon.Click += new System.EventHandler(this.btnChon_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(3, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(251, 23);
            this.label1.TabIndex = 4;
            this.label1.Text = "Database có trong Server";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnFK);
            this.panel2.Controls.Add(this.btnUpdateValue);
            this.panel2.Controls.Add(this.btnDisconnect);
            this.panel2.Controls.Add(this.btnNewTable);
            this.panel2.Controls.Add(this.cmbTables);
            this.panel2.Controls.Add(this.btnAlter);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(3, 140);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(210, 198);
            this.panel2.TabIndex = 3;
            // 
            // btnFK
            // 
            this.btnFK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnFK.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFK.Location = new System.Drawing.Point(5, 111);
            this.btnFK.Name = "btnFK";
            this.btnFK.Size = new System.Drawing.Size(97, 36);
            this.btnFK.TabIndex = 15;
            this.btnFK.Text = "FK";
            this.btnFK.UseVisualStyleBackColor = false;
            this.btnFK.Click += new System.EventHandler(this.btnFK_Click);
            // 
            // btnUpdateValue
            // 
            this.btnUpdateValue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnUpdateValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateValue.Location = new System.Drawing.Point(107, 111);
            this.btnUpdateValue.Name = "btnUpdateValue";
            this.btnUpdateValue.Size = new System.Drawing.Size(99, 36);
            this.btnUpdateValue.TabIndex = 14;
            this.btnUpdateValue.Text = "Values";
            this.btnUpdateValue.UseVisualStyleBackColor = false;
            this.btnUpdateValue.Click += new System.EventHandler(this.btnUpdateValue_Click);
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.BackColor = System.Drawing.Color.Red;
            this.btnDisconnect.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDisconnect.Location = new System.Drawing.Point(5, 153);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(201, 36);
            this.btnDisconnect.TabIndex = 9;
            this.btnDisconnect.Text = "Disconnect";
            this.btnDisconnect.UseVisualStyleBackColor = false;
            this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
            // 
            // btnNewTable
            // 
            this.btnNewTable.BackColor = System.Drawing.Color.ForestGreen;
            this.btnNewTable.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewTable.ForeColor = System.Drawing.Color.White;
            this.btnNewTable.Location = new System.Drawing.Point(110, 69);
            this.btnNewTable.Name = "btnNewTable";
            this.btnNewTable.Size = new System.Drawing.Size(97, 36);
            this.btnNewTable.TabIndex = 13;
            this.btnNewTable.Text = "Mới";
            this.btnNewTable.UseVisualStyleBackColor = false;
            this.btnNewTable.Click += new System.EventHandler(this.btnNewTable_Click);
            // 
            // cmbTables
            // 
            this.cmbTables.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTables.FormattingEnabled = true;
            this.cmbTables.Location = new System.Drawing.Point(8, 30);
            this.cmbTables.Name = "cmbTables";
            this.cmbTables.Size = new System.Drawing.Size(201, 33);
            this.cmbTables.TabIndex = 10;
            // 
            // btnAlter
            // 
            this.btnAlter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAlter.ForeColor = System.Drawing.Color.Black;
            this.btnAlter.Location = new System.Drawing.Point(5, 69);
            this.btnAlter.Name = "btnAlter";
            this.btnAlter.Size = new System.Drawing.Size(97, 36);
            this.btnAlter.TabIndex = 12;
            this.btnAlter.Text = "Alter";
            this.btnAlter.UseVisualStyleBackColor = true;
            this.btnAlter.Click += new System.EventHandler(this.btnAlter_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(26, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(198, 23);
            this.label2.TabIndex = 11;
            this.label2.Text = "Danh sách các bảng";
            // 
            // txtschema
            // 
            this.txtschema.AcceptsTab = true;
            this.txtschema.BackColor = System.Drawing.Color.White;
            this.txtschema.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtschema.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtschema.ForeColor = System.Drawing.Color.Navy;
            this.txtschema.Location = new System.Drawing.Point(231, 31);
            this.txtschema.Name = "txtschema";
            this.txtschema.Size = new System.Drawing.Size(14, 14);
            this.txtschema.TabIndex = 2;
            this.txtschema.Text = "";
            // 
            // pnInsertTable
            // 
            this.pnInsertTable.BackColor = System.Drawing.SystemColors.Control;
            this.pnInsertTable.Controls.Add(this.btnHuy);
            this.pnInsertTable.Controls.Add(this.btnHoanThanh);
            this.pnInsertTable.Controls.Add(this.btnAddCol);
            this.pnInsertTable.Controls.Add(this.panel5);
            this.pnInsertTable.Controls.Add(this.floData);
            this.pnInsertTable.Controls.Add(this.label6);
            this.pnInsertTable.Controls.Add(this.label5);
            this.pnInsertTable.Controls.Add(this.label4);
            this.pnInsertTable.Location = new System.Drawing.Point(231, 31);
            this.pnInsertTable.Name = "pnInsertTable";
            this.pnInsertTable.Size = new System.Drawing.Size(502, 614);
            this.pnInsertTable.TabIndex = 3;
            // 
            // btnHuy
            // 
            this.btnHuy.BackColor = System.Drawing.Color.Red;
            this.btnHuy.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHuy.ForeColor = System.Drawing.Color.White;
            this.btnHuy.Location = new System.Drawing.Point(177, 99);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(142, 36);
            this.btnHuy.TabIndex = 16;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.UseVisualStyleBackColor = false;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // btnHoanThanh
            // 
            this.btnHoanThanh.BackColor = System.Drawing.Color.ForestGreen;
            this.btnHoanThanh.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHoanThanh.ForeColor = System.Drawing.Color.White;
            this.btnHoanThanh.Location = new System.Drawing.Point(348, 99);
            this.btnHoanThanh.Name = "btnHoanThanh";
            this.btnHoanThanh.Size = new System.Drawing.Size(142, 36);
            this.btnHoanThanh.TabIndex = 15;
            this.btnHoanThanh.Text = "Hoàn thành";
            this.btnHoanThanh.UseVisualStyleBackColor = false;
            this.btnHoanThanh.Click += new System.EventHandler(this.btnHoanThanh_Click);
            // 
            // btnAddCol
            // 
            this.btnAddCol.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnAddCol.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddCol.ForeColor = System.Drawing.Color.White;
            this.btnAddCol.Location = new System.Drawing.Point(3, 99);
            this.btnAddCol.Name = "btnAddCol";
            this.btnAddCol.Size = new System.Drawing.Size(142, 36);
            this.btnAddCol.TabIndex = 14;
            this.btnAddCol.Text = "Thêm cột";
            this.btnAddCol.UseVisualStyleBackColor = false;
            this.btnAddCol.Click += new System.EventHandler(this.btnAddCol_Click);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel5.Controls.Add(this.btnDrop);
            this.panel5.Controls.Add(this.label3);
            this.panel5.Controls.Add(this.txtTableName);
            this.panel5.Location = new System.Drawing.Point(0, 2);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(496, 38);
            this.panel5.TabIndex = 6;
            // 
            // btnDrop
            // 
            this.btnDrop.BackColor = System.Drawing.Color.Red;
            this.btnDrop.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDrop.ForeColor = System.Drawing.Color.White;
            this.btnDrop.Location = new System.Drawing.Point(416, 1);
            this.btnDrop.Name = "btnDrop";
            this.btnDrop.Size = new System.Drawing.Size(80, 36);
            this.btnDrop.TabIndex = 17;
            this.btnDrop.Text = "Drop";
            this.btnDrop.UseVisualStyleBackColor = false;
            this.btnDrop.Click += new System.EventHandler(this.btnDrop_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(4, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 23);
            this.label3.TabIndex = 7;
            this.label3.Text = "Tên bảng:";
            // 
            // txtTableName
            // 
            this.txtTableName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTableName.Location = new System.Drawing.Point(115, 4);
            this.txtTableName.Name = "txtTableName";
            this.txtTableName.Size = new System.Drawing.Size(295, 30);
            this.txtTableName.TabIndex = 6;
            this.txtTableName.TextChanged += new System.EventHandler(this.txtTableName_TextChanged);
            this.txtTableName.Leave += new System.EventHandler(this.txtTableName_Leave);
            // 
            // floData
            // 
            this.floData.Location = new System.Drawing.Point(3, 83);
            this.floData.Name = "floData";
            this.floData.Size = new System.Drawing.Size(496, 10);
            this.floData.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(456, 57);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 23);
            this.label6.TabIndex = 10;
            this.label6.Text = "PK";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(229, 55);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(124, 23);
            this.label5.TabIndex = 9;
            this.label5.Text = "Kiểu dữ liệu";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(8, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 23);
            this.label4.TabIndex = 8;
            this.label4.Text = "Tên cột";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.heThongToolStripMenuItem,
            this.caiDatToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(977, 31);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // heThongToolStripMenuItem
            // 
            this.heThongToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.thoatToolStripMenuItem,
            this.thoatctToolStripMenuItem});
            this.heThongToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.heThongToolStripMenuItem.Name = "heThongToolStripMenuItem";
            this.heThongToolStripMenuItem.Size = new System.Drawing.Size(100, 27);
            this.heThongToolStripMenuItem.Text = "Hệ Thống";
            // 
            // thoatToolStripMenuItem
            // 
            this.thoatToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.thoatToolStripMenuItem.Name = "thoatToolStripMenuItem";
            this.thoatToolStripMenuItem.Size = new System.Drawing.Size(234, 28);
            this.thoatToolStripMenuItem.Text = "Đăng xuất";
            this.thoatToolStripMenuItem.Click += new System.EventHandler(this.thoatToolStripMenuItem_Click);
            // 
            // thoatctToolStripMenuItem
            // 
            this.thoatctToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.thoatctToolStripMenuItem.Name = "thoatctToolStripMenuItem";
            this.thoatctToolStripMenuItem.Size = new System.Drawing.Size(234, 28);
            this.thoatctToolStripMenuItem.Text = "Thoát chương trình";
            this.thoatctToolStripMenuItem.Click += new System.EventHandler(this.thoatctToolStripMenuItem_Click);
            // 
            // caiDatToolStripMenuItem
            // 
            this.caiDatToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.matKhauToolStripMenuItem,
            this.maHoaToolStripMenuItem});
            this.caiDatToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.caiDatToolStripMenuItem.Name = "caiDatToolStripMenuItem";
            this.caiDatToolStripMenuItem.Size = new System.Drawing.Size(81, 27);
            this.caiDatToolStripMenuItem.Text = "Cài Đặt";
            // 
            // matKhauToolStripMenuItem
            // 
            this.matKhauToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.matKhauToolStripMenuItem.Name = "matKhauToolStripMenuItem";
            this.matKhauToolStripMenuItem.Size = new System.Drawing.Size(158, 28);
            this.matKhauToolStripMenuItem.Text = "Mật khẩu";
            // 
            // maHoaToolStripMenuItem
            // 
            this.maHoaToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.maHoaToolStripMenuItem.Name = "maHoaToolStripMenuItem";
            this.maHoaToolStripMenuItem.Size = new System.Drawing.Size(158, 28);
            this.maHoaToolStripMenuItem.Text = "Mã hóa";
            // 
            // pnDB
            // 
            this.pnDB.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pnDB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnDB.Controls.Add(this.btnNewSchema);
            this.pnDB.Controls.Add(this.btnDropDatabase);
            this.pnDB.Controls.Add(this.btnCloseSchema);
            this.pnDB.Controls.Add(this.btnRun);
            this.pnDB.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.pnDB.Location = new System.Drawing.Point(739, 31);
            this.pnDB.Name = "pnDB";
            this.pnDB.Size = new System.Drawing.Size(237, 615);
            this.pnDB.TabIndex = 11;
            // 
            // frmMain
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(977, 640);
            this.ControlBox = false;
            this.Controls.Add(this.pnInsertTable);
            this.Controls.Add(this.txtschema);
            this.Controls.Add(this.pnDB);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kar_SQL | Main";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.pnInsertTable.ResumeLayout(false);
            this.pnInsertTable.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.pnDB.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cmbDatabase;
        private System.Windows.Forms.Button btnChon;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnNewSchema;
        private System.Windows.Forms.RichTextBox txtschema;
        private System.Windows.Forms.Button btnCloseSchema;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.ComboBox cmbTables;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAlter;
        private System.Windows.Forms.Button btnNewTable;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnDisconnect;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel pnInsertTable;
        private System.Windows.Forms.FlowLayoutPanel floData;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTableName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnAddCol;
        private System.Windows.Forms.Button btnHoanThanh;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem heThongToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thoatToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem caiDatToolStripMenuItem;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Button btnUpdateValue;
        private System.Windows.Forms.ToolStripMenuItem thoatctToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem matKhauToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem maHoaToolStripMenuItem;
        private System.Windows.Forms.Button btnDrop;
        private System.Windows.Forms.Button btnDropDatabase;
        private System.Windows.Forms.Button btnFK;
        private System.Windows.Forms.Panel pnDB;
    }
}