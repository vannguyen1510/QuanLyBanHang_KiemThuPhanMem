namespace QLBH_KiemThuPhanMem
{
	partial class Frm_Report
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Report));
			this.lbQLNV = new System.Windows.Forms.Label();
			this.btnMenu = new System.Windows.Forms.Button();
			this.btnOut = new System.Windows.Forms.Button();
			this.btnReport = new System.Windows.Forms.Button();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.SuspendLayout();
			// 
			// lbQLNV
			// 
			this.lbQLNV.BackColor = System.Drawing.Color.LightSeaGreen;
			this.lbQLNV.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.lbQLNV.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbQLNV.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			this.lbQLNV.Location = new System.Drawing.Point(0, 9);
			this.lbQLNV.Name = "lbQLNV";
			this.lbQLNV.Size = new System.Drawing.Size(1465, 36);
			this.lbQLNV.TabIndex = 39;
			this.lbQLNV.Text = "REVENUE SYSTEM";
			this.lbQLNV.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.lbQLNV.UseWaitCursor = true;
			// 
			// btnMenu
			// 
			this.btnMenu.BackColor = System.Drawing.Color.LightSeaGreen;
			this.btnMenu.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnMenu.ForeColor = System.Drawing.Color.GhostWhite;
			this.btnMenu.Image = global::QLBH_KiemThuPhanMem.Properties.Resources._3643769_building_home_house_main_menu_start_113416__1_;
			this.btnMenu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnMenu.Location = new System.Drawing.Point(670, 71);
			this.btnMenu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.btnMenu.Name = "btnMenu";
			this.btnMenu.Size = new System.Drawing.Size(171, 47);
			this.btnMenu.TabIndex = 71;
			this.btnMenu.Text = "MENU";
			this.btnMenu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.toolTip1.SetToolTip(this.btnMenu, "Back to menu");
			this.btnMenu.UseVisualStyleBackColor = false;
			this.btnMenu.UseWaitCursor = true;
			this.btnMenu.Click += new System.EventHandler(this.btnMenu_Click);
			// 
			// btnOut
			// 
			this.btnOut.BackColor = System.Drawing.Color.LightSeaGreen;
			this.btnOut.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnOut.ForeColor = System.Drawing.Color.GhostWhite;
			this.btnOut.Image = global::QLBH_KiemThuPhanMem.Properties.Resources.sign_error_icon_34362;
			this.btnOut.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnOut.Location = new System.Drawing.Point(847, 71);
			this.btnOut.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.btnOut.Name = "btnOut";
			this.btnOut.Size = new System.Drawing.Size(171, 47);
			this.btnOut.TabIndex = 70;
			this.btnOut.Text = "OUT";
			this.btnOut.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.toolTip1.SetToolTip(this.btnOut, "Sign out");
			this.btnOut.UseVisualStyleBackColor = false;
			this.btnOut.UseWaitCursor = true;
			this.btnOut.Click += new System.EventHandler(this.btnOut_Click);
			// 
			// btnReport
			// 
			this.btnReport.BackColor = System.Drawing.Color.LightSeaGreen;
			this.btnReport.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnReport.ForeColor = System.Drawing.Color.GhostWhite;
			this.btnReport.Image = global::QLBH_KiemThuPhanMem.Properties.Resources._8medical_report_102120;
			this.btnReport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnReport.Location = new System.Drawing.Point(493, 71);
			this.btnReport.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.btnReport.Name = "btnReport";
			this.btnReport.Size = new System.Drawing.Size(171, 47);
			this.btnReport.TabIndex = 60;
			this.btnReport.Text = "REPORT";
			this.btnReport.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.toolTip1.SetToolTip(this.btnReport, "Export data to excel file");
			this.btnReport.UseVisualStyleBackColor = false;
			this.btnReport.UseWaitCursor = true;
			this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
			// 
			// toolTip1
			// 
			this.toolTip1.ToolTipTitle = "Information";
			// 
			// dataGridView1
			// 
			this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Location = new System.Drawing.Point(12, 157);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.RowHeadersWidth = 51;
			this.dataGridView1.RowTemplate.Height = 24;
			this.dataGridView1.Size = new System.Drawing.Size(1439, 500);
			this.dataGridView1.TabIndex = 73;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.ForeColor = System.Drawing.Color.LightSeaGreen;
			this.label2.Location = new System.Drawing.Point(1318, 82);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(20, 28);
			this.label2.TabIndex = 75;
			this.label2.Text = "_";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.ForeColor = System.Drawing.Color.LightSeaGreen;
			this.label1.Location = new System.Drawing.Point(1258, 82);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(65, 28);
			this.label1.TabIndex = 74;
			this.label1.Text = "User: ";
			// 
			// Frm_Report
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1463, 669);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.dataGridView1);
			this.Controls.Add(this.btnMenu);
			this.Controls.Add(this.btnOut);
			this.Controls.Add(this.btnReport);
			this.Controls.Add(this.lbQLNV);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "Frm_Report";
			this.Text = "Report";
			this.Load += new System.EventHandler(this.Frm_Report_Load);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label lbQLNV;
		private System.Windows.Forms.Button btnReport;
		private System.Windows.Forms.Button btnMenu;
		private System.Windows.Forms.Button btnOut;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
	}
}