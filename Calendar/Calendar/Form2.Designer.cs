namespace Calendar
{
	partial class Form2
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
			this.listBox1 = new System.Windows.Forms.ListBox();
			this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
			this.radioButton1 = new System.Windows.Forms.RadioButton();
			this.radioButton2 = new System.Windows.Forms.RadioButton();
			this.radioButton3 = new System.Windows.Forms.RadioButton();
			this.all = new System.Windows.Forms.RadioButton();
			this.SuspendLayout();
			// 
			// listBox1
			// 
			this.listBox1.FormattingEnabled = true;
			this.listBox1.ItemHeight = 12;
			this.listBox1.Items.AddRange(new object[] {
            "予定一覧"});
			this.listBox1.Location = new System.Drawing.Point(26, 74);
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size(330, 220);
			this.listBox1.TabIndex = 7;
			// 
			// dateTimePicker1
			// 
			this.dateTimePicker1.Location = new System.Drawing.Point(126, 12);
			this.dateTimePicker1.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
			this.dateTimePicker1.Name = "dateTimePicker1";
			this.dateTimePicker1.Size = new System.Drawing.Size(200, 19);
			this.dateTimePicker1.TabIndex = 8;
			// 
			// radioButton1
			// 
			this.radioButton1.AutoSize = true;
			this.radioButton1.Location = new System.Drawing.Point(26, 52);
			this.radioButton1.Name = "radioButton1";
			this.radioButton1.Size = new System.Drawing.Size(45, 16);
			this.radioButton1.TabIndex = 9;
			this.radioButton1.TabStop = true;
			this.radioButton1.Text = "year";
			this.radioButton1.UseVisualStyleBackColor = true;
			this.radioButton1.Click += new System.EventHandler(this.radioButton1_Click);
			// 
			// radioButton2
			// 
			this.radioButton2.AutoSize = true;
			this.radioButton2.Location = new System.Drawing.Point(126, 51);
			this.radioButton2.Name = "radioButton2";
			this.radioButton2.Size = new System.Drawing.Size(54, 16);
			this.radioButton2.TabIndex = 10;
			this.radioButton2.TabStop = true;
			this.radioButton2.Text = "month";
			this.radioButton2.UseVisualStyleBackColor = true;
			this.radioButton2.Click += new System.EventHandler(this.radioButton2_Click);
			// 
			// radioButton3
			// 
			this.radioButton3.AutoSize = true;
			this.radioButton3.Location = new System.Drawing.Point(235, 51);
			this.radioButton3.Name = "radioButton3";
			this.radioButton3.Size = new System.Drawing.Size(41, 16);
			this.radioButton3.TabIndex = 11;
			this.radioButton3.TabStop = true;
			this.radioButton3.Text = "day";
			this.radioButton3.UseVisualStyleBackColor = true;
			this.radioButton3.Click += new System.EventHandler(this.radioButton3_Click);
			// 
			// all
			// 
			this.all.AutoSize = true;
			this.all.Location = new System.Drawing.Point(26, 30);
			this.all.Name = "all";
			this.all.Size = new System.Drawing.Size(37, 16);
			this.all.TabIndex = 12;
			this.all.TabStop = true;
			this.all.Text = "All";
			this.all.UseVisualStyleBackColor = true;
			this.all.Click += new System.EventHandler(this.all_Click);
			// 
			// Form2
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(451, 324);
			this.Controls.Add(this.all);
			this.Controls.Add(this.radioButton3);
			this.Controls.Add(this.radioButton2);
			this.Controls.Add(this.radioButton1);
			this.Controls.Add(this.dateTimePicker1);
			this.Controls.Add(this.listBox1);
			this.Name = "Form2";
			this.Text = "予定一覧";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.ListBox listBox1;
		private System.Windows.Forms.DateTimePicker dateTimePicker1;
		private System.Windows.Forms.RadioButton radioButton1;
		private System.Windows.Forms.RadioButton radioButton2;
		private System.Windows.Forms.RadioButton radioButton3;
		private System.Windows.Forms.RadioButton all;
	}
}