namespace QLBH_KiemThuPhanMem
{
	partial class Frm_SignIn
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
			this.components = new System.ComponentModel.Container();
			System.Windows.Forms.Button btnDangNhap;
			System.Windows.Forms.Button btnDangKy;
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_SignIn));
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage_SignIn = new System.Windows.Forms.TabPage();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.txtMatKhau = new System.Windows.Forms.TextBox();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.btnForgotPW = new System.Windows.Forms.Button();
			this.btnDoipw = new System.Windows.Forms.Button();
			this.btnDong = new System.Windows.Forms.Button();
			this.txtTenDangNhap = new System.Windows.Forms.TextBox();
			this.lbMatKhau = new System.Windows.Forms.Label();
			this.lbTenDangNhap = new System.Windows.Forms.Label();
			this.tabPage_SignUp = new System.Windows.Forms.TabPage();
			this.txtID = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txtCPw = new System.Windows.Forms.TextBox();
			this.txtPw = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.rdbNu = new System.Windows.Forms.RadioButton();
			this.rdbNam = new System.Windows.Forms.RadioButton();
			this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
			this.label7 = new System.Windows.Forms.Label();
			this.txtLName = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.txtFName = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.checkBox3 = new System.Windows.Forms.CheckBox();
			this.label3 = new System.Windows.Forms.Label();
			this.checkBox2 = new System.Windows.Forms.CheckBox();
			this.label1 = new System.Windows.Forms.Label();
			this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			btnDangNhap = new System.Windows.Forms.Button();
			btnDangKy = new System.Windows.Forms.Button();
			this.tabControl1.SuspendLayout();
			this.tabPage_SignIn.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.tabPage_SignUp.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
			this.SuspendLayout();
			// 
			// btnDangNhap
			// 
			btnDangNhap.BackColor = System.Drawing.Color.LightSeaGreen;
			btnDangNhap.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			btnDangNhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			btnDangNhap.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			btnDangNhap.Location = new System.Drawing.Point(70, 290);
			btnDangNhap.Name = "btnDangNhap";
			btnDangNhap.Size = new System.Drawing.Size(138, 44);
			btnDangNhap.TabIndex = 4;
			btnDangNhap.Text = "Sign In";
			this.toolTip1.SetToolTip(btnDangNhap, "Press Enter to sign in");
			btnDangNhap.UseVisualStyleBackColor = false;
			btnDangNhap.Click += new System.EventHandler(this.btnDangNhap_Click);
			// 
			// btnDangKy
			// 
			btnDangKy.BackColor = System.Drawing.Color.LightSeaGreen;
			btnDangKy.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			btnDangKy.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			btnDangKy.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			btnDangKy.Location = new System.Drawing.Point(331, 315);
			btnDangKy.Name = "btnDangKy";
			btnDangKy.Size = new System.Drawing.Size(138, 44);
			btnDangKy.TabIndex = 11;
			btnDangKy.Text = "Sign Up";
			this.toolTip1.SetToolTip(btnDangKy, "Press Y to sign up ");
			btnDangKy.UseVisualStyleBackColor = false;
			btnDangKy.Click += new System.EventHandler(this.btnDangKy_Click);
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage_SignIn);
			this.tabControl1.Controls.Add(this.tabPage_SignUp);
			this.tabControl1.Location = new System.Drawing.Point(26, 12);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(750, 460);
			this.tabControl1.TabIndex = 8;
			// 
			// tabPage_SignIn
			// 
			this.tabPage_SignIn.Controls.Add(this.checkBox1);
			this.tabPage_SignIn.Controls.Add(this.txtMatKhau);
			this.tabPage_SignIn.Controls.Add(this.pictureBox1);
			this.tabPage_SignIn.Controls.Add(this.btnForgotPW);
			this.tabPage_SignIn.Controls.Add(this.btnDoipw);
			this.tabPage_SignIn.Controls.Add(this.btnDong);
			this.tabPage_SignIn.Controls.Add(btnDangNhap);
			this.tabPage_SignIn.Controls.Add(this.txtTenDangNhap);
			this.tabPage_SignIn.Controls.Add(this.lbMatKhau);
			this.tabPage_SignIn.Controls.Add(this.lbTenDangNhap);
			this.tabPage_SignIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tabPage_SignIn.Location = new System.Drawing.Point(4, 25);
			this.tabPage_SignIn.Name = "tabPage_SignIn";
			this.tabPage_SignIn.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage_SignIn.Size = new System.Drawing.Size(742, 431);
			this.tabPage_SignIn.TabIndex = 0;
			this.tabPage_SignIn.Text = "Sign In";
			this.tabPage_SignIn.UseVisualStyleBackColor = true;
			// 
			// checkBox1
			// 
			this.checkBox1.AutoSize = true;
			this.checkBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.checkBox1.Location = new System.Drawing.Point(290, 244);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(181, 22);
			this.checkBox1.TabIndex = 3;
			this.checkBox1.Text = "Hide / Show Password";
			this.checkBox1.UseVisualStyleBackColor = true;
			this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged_1);
			// 
			// txtMatKhau
			// 
			this.txtMatKhau.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtMatKhau.Location = new System.Drawing.Point(255, 199);
			this.txtMatKhau.Name = "txtMatKhau";
			this.txtMatKhau.ShortcutsEnabled = false;
			this.txtMatKhau.Size = new System.Drawing.Size(244, 28);
			this.txtMatKhau.TabIndex = 2;
			this.txtMatKhau.UseSystemPasswordChar = true;
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(308, 19);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(139, 119);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox1.TabIndex = 19;
			this.pictureBox1.TabStop = false;
			// 
			// btnForgotPW
			// 
			this.btnForgotPW.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnForgotPW.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnForgotPW.ForeColor = System.Drawing.Color.DarkGray;
			this.btnForgotPW.Location = new System.Drawing.Point(448, 381);
			this.btnForgotPW.Name = "btnForgotPW";
			this.btnForgotPW.Size = new System.Drawing.Size(232, 36);
			this.btnForgotPW.TabIndex = 7;
			this.btnForgotPW.Text = "Forgot your password ?";
			this.btnForgotPW.UseVisualStyleBackColor = true;
			this.btnForgotPW.Click += new System.EventHandler(this.btnForgotPW_Click);
			// 
			// btnDoipw
			// 
			this.btnDoipw.BackColor = System.Drawing.Color.LightSeaGreen;
			this.btnDoipw.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnDoipw.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnDoipw.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			this.btnDoipw.Location = new System.Drawing.Point(277, 290);
			this.btnDoipw.Name = "btnDoipw";
			this.btnDoipw.Size = new System.Drawing.Size(204, 44);
			this.btnDoipw.TabIndex = 5;
			this.btnDoipw.Text = "Change Password";
			this.toolTip1.SetToolTip(this.btnDoipw, "Press P to change password");
			this.btnDoipw.UseVisualStyleBackColor = false;
			this.btnDoipw.Click += new System.EventHandler(this.btnDoipw_Click);
			// 
			// btnDong
			// 
			this.btnDong.BackColor = System.Drawing.Color.LightSeaGreen;
			this.btnDong.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnDong.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnDong.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			this.btnDong.Location = new System.Drawing.Point(538, 289);
			this.btnDong.Name = "btnDong";
			this.btnDong.Size = new System.Drawing.Size(142, 44);
			this.btnDong.TabIndex = 6;
			this.btnDong.Text = "Close";
			this.toolTip1.SetToolTip(this.btnDong, "Press Escape to clos");
			this.btnDong.UseVisualStyleBackColor = false;
			this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
			// 
			// txtTenDangNhap
			// 
			this.txtTenDangNhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtTenDangNhap.Location = new System.Drawing.Point(255, 165);
			this.txtTenDangNhap.Name = "txtTenDangNhap";
			this.txtTenDangNhap.ShortcutsEnabled = false;
			this.txtTenDangNhap.Size = new System.Drawing.Size(242, 28);
			this.txtTenDangNhap.TabIndex = 1;
			// 
			// lbMatKhau
			// 
			this.lbMatKhau.AutoSize = true;
			this.lbMatKhau.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbMatKhau.Location = new System.Drawing.Point(130, 211);
			this.lbMatKhau.Name = "lbMatKhau";
			this.lbMatKhau.Size = new System.Drawing.Size(119, 25);
			this.lbMatKhau.TabIndex = 10;
			this.lbMatKhau.Text = "Password :  ";
			// 
			// lbTenDangNhap
			// 
			this.lbTenDangNhap.AutoSize = true;
			this.lbTenDangNhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbTenDangNhap.Location = new System.Drawing.Point(155, 168);
			this.lbTenDangNhap.Name = "lbTenDangNhap";
			this.lbTenDangNhap.Size = new System.Drawing.Size(85, 25);
			this.lbTenDangNhap.TabIndex = 11;
			this.lbTenDangNhap.Text = "Phone : ";
			// 
			// tabPage_SignUp
			// 
			this.tabPage_SignUp.Controls.Add(this.txtID);
			this.tabPage_SignUp.Controls.Add(this.label2);
			this.tabPage_SignUp.Controls.Add(btnDangKy);
			this.tabPage_SignUp.Controls.Add(this.txtCPw);
			this.tabPage_SignUp.Controls.Add(this.txtPw);
			this.tabPage_SignUp.Controls.Add(this.label6);
			this.tabPage_SignUp.Controls.Add(this.rdbNu);
			this.tabPage_SignUp.Controls.Add(this.rdbNam);
			this.tabPage_SignUp.Controls.Add(this.dateTimePicker1);
			this.tabPage_SignUp.Controls.Add(this.label7);
			this.tabPage_SignUp.Controls.Add(this.txtLName);
			this.tabPage_SignUp.Controls.Add(this.label5);
			this.tabPage_SignUp.Controls.Add(this.txtFName);
			this.tabPage_SignUp.Controls.Add(this.label4);
			this.tabPage_SignUp.Controls.Add(this.checkBox3);
			this.tabPage_SignUp.Controls.Add(this.label3);
			this.tabPage_SignUp.Controls.Add(this.checkBox2);
			this.tabPage_SignUp.Controls.Add(this.label1);
			this.tabPage_SignUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tabPage_SignUp.Location = new System.Drawing.Point(4, 25);
			this.tabPage_SignUp.Name = "tabPage_SignUp";
			this.tabPage_SignUp.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage_SignUp.Size = new System.Drawing.Size(742, 431);
			this.tabPage_SignUp.TabIndex = 1;
			this.tabPage_SignUp.Text = "Sign Up";
			this.tabPage_SignUp.UseVisualStyleBackColor = true;
			this.tabPage_SignUp.Click += new System.EventHandler(this.tabPage_SignUp_Click);
			// 
			// txtID
			// 
			this.txtID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtID.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtID.Location = new System.Drawing.Point(271, 22);
			this.txtID.Multiline = true;
			this.txtID.Name = "txtID";
			this.txtID.Size = new System.Drawing.Size(243, 35);
			this.txtID.TabIndex = 33;
			this.txtID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(212, 31);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(42, 25);
			this.label2.TabIndex = 32;
			this.label2.Text = "ID :";
			// 
			// txtCPw
			// 
			this.txtCPw.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtCPw.Location = new System.Drawing.Point(271, 189);
			this.txtCPw.Multiline = true;
			this.txtCPw.Name = "txtCPw";
			this.txtCPw.PasswordChar = '*';
			this.txtCPw.Size = new System.Drawing.Size(244, 35);
			this.txtCPw.TabIndex = 5;
			// 
			// txtPw
			// 
			this.txtPw.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtPw.Location = new System.Drawing.Point(271, 148);
			this.txtPw.Multiline = true;
			this.txtPw.Name = "txtPw";
			this.txtPw.PasswordChar = '*';
			this.txtPw.Size = new System.Drawing.Size(244, 35);
			this.txtPw.TabIndex = 3;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label6.Location = new System.Drawing.Point(166, 267);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(88, 25);
			this.label6.TabIndex = 31;
			this.label6.Text = "Gender :";
			// 
			// rdbNu
			// 
			this.rdbNu.AutoSize = true;
			this.rdbNu.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.rdbNu.Location = new System.Drawing.Point(374, 264);
			this.rdbNu.Name = "rdbNu";
			this.rdbNu.Size = new System.Drawing.Size(95, 28);
			this.rdbNu.TabIndex = 9;
			this.rdbNu.Text = "Female";
			this.rdbNu.UseVisualStyleBackColor = true;
			// 
			// rdbNam
			// 
			this.rdbNam.AutoSize = true;
			this.rdbNam.Checked = true;
			this.rdbNam.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.rdbNam.Location = new System.Drawing.Point(271, 264);
			this.rdbNam.Name = "rdbNam";
			this.rdbNam.Size = new System.Drawing.Size(72, 28);
			this.rdbNam.TabIndex = 8;
			this.rdbNam.TabStop = true;
			this.rdbNam.Text = "Male";
			this.rdbNam.UseVisualStyleBackColor = true;
			// 
			// dateTimePicker1
			// 
			this.dateTimePicker1.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.dateTimePicker1.CustomFormat = "dd/MM/yyyy";
			this.dateTimePicker1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dateTimePicker1.Location = new System.Drawing.Point(271, 230);
			this.dateTimePicker1.Name = "dateTimePicker1";
			this.dateTimePicker1.Size = new System.Drawing.Size(244, 28);
			this.dateTimePicker1.TabIndex = 7;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label7.Location = new System.Drawing.Point(160, 233);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(94, 25);
			this.label7.TabIndex = 27;
			this.label7.Text = "Birthday :";
			// 
			// txtLName
			// 
			this.txtLName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtLName.Location = new System.Drawing.Point(271, 104);
			this.txtLName.Multiline = true;
			this.txtLName.Name = "txtLName";
			this.txtLName.Size = new System.Drawing.Size(243, 35);
			this.txtLName.TabIndex = 1;
			this.txtLName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLName_KeyPress);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label5.Location = new System.Drawing.Point(137, 114);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(117, 25);
			this.label5.TabIndex = 25;
			this.label5.Text = "Last Name :";
			// 
			// txtFName
			// 
			this.txtFName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtFName.Location = new System.Drawing.Point(271, 63);
			this.txtFName.Multiline = true;
			this.txtFName.Name = "txtFName";
			this.txtFName.Size = new System.Drawing.Size(243, 35);
			this.txtFName.TabIndex = 0;
			this.txtFName.TextChanged += new System.EventHandler(this.txtFName_TextChanged);
			this.txtFName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFName_KeyPress);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.Location = new System.Drawing.Point(137, 73);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(117, 25);
			this.label4.TabIndex = 23;
			this.label4.Text = "First Name :";
			// 
			// checkBox3
			// 
			this.checkBox3.AutoSize = true;
			this.checkBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.checkBox3.Location = new System.Drawing.Point(521, 205);
			this.checkBox3.Name = "checkBox3";
			this.checkBox3.Size = new System.Drawing.Size(110, 22);
			this.checkBox3.TabIndex = 6;
			this.checkBox3.Text = "Hide / Show";
			this.checkBox3.UseVisualStyleBackColor = true;
			this.checkBox3.CheckedChanged += new System.EventHandler(this.checkBox3_CheckedChanged);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(74, 199);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(192, 25);
			this.label3.TabIndex = 20;
			this.label3.Text = "Confirm Password :  ";
			// 
			// checkBox2
			// 
			this.checkBox2.AutoSize = true;
			this.checkBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.checkBox2.Location = new System.Drawing.Point(521, 158);
			this.checkBox2.Name = "checkBox2";
			this.checkBox2.Size = new System.Drawing.Size(110, 22);
			this.checkBox2.TabIndex = 4;
			this.checkBox2.Text = "Hide / Show";
			this.checkBox2.UseVisualStyleBackColor = true;
			this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(146, 158);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(119, 25);
			this.label1.TabIndex = 15;
			this.label1.Text = "Password :  ";
			// 
			// errorProvider1
			// 
			this.errorProvider1.ContainerControl = this;
			// 
			// toolTip1
			// 
			this.toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
			this.toolTip1.ToolTipTitle = "Suggestion";
			// 
			// Frm_SignIn
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.LightSeaGreen;
			this.ClientSize = new System.Drawing.Size(800, 490);
			this.Controls.Add(this.tabControl1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "Frm_SignIn";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "WELCOME ";
			this.TopMost = true;
			this.Load += new System.EventHandler(this.Frm_SignIn_Load);
			this.tabControl1.ResumeLayout(false);
			this.tabPage_SignIn.ResumeLayout(false);
			this.tabPage_SignIn.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.tabPage_SignUp.ResumeLayout(false);
			this.tabPage_SignUp.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage_SignIn;
		private System.Windows.Forms.TabPage tabPage_SignUp;
		private System.Windows.Forms.Button btnForgotPW;
		private System.Windows.Forms.Button btnDoipw;
		private System.Windows.Forms.Button btnDong;
		private System.Windows.Forms.TextBox txtTenDangNhap;
		private System.Windows.Forms.Label lbMatKhau;
		private System.Windows.Forms.Label lbTenDangNhap;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.TextBox txtCPw;
		private System.Windows.Forms.TextBox txtPw;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.RadioButton rdbNu;
		private System.Windows.Forms.RadioButton rdbNam;
		private System.Windows.Forms.DateTimePicker dateTimePicker1;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox txtLName;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox txtFName;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.CheckBox checkBox3;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.CheckBox checkBox2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ErrorProvider errorProvider1;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.TextBox txtMatKhau;
		private System.Windows.Forms.CheckBox checkBox1;
		private System.Windows.Forms.TextBox txtID;
		private System.Windows.Forms.Label label2;
	}
}