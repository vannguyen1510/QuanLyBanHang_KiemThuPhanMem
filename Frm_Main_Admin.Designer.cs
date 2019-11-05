namespace QLBH_KiemThuPhanMem
{
	partial class Frm_Main_Admin
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
			this.btnBill = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// btnBill
			// 
			this.btnBill.Location = new System.Drawing.Point(204, 147);
			this.btnBill.Name = "btnBill";
			this.btnBill.Size = new System.Drawing.Size(241, 133);
			this.btnBill.TabIndex = 0;
			this.btnBill.Text = "Call bill";
			this.btnBill.UseVisualStyleBackColor = true;
			this.btnBill.Click += new System.EventHandler(this.btnBill_Click);
			// 
			// Frm_Main_Admin
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(876, 527);
			this.Controls.Add(this.btnBill);
			this.Name = "Frm_Main_Admin";
			this.Text = "Frm_Main_Admin";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button btnBill;
	}
}