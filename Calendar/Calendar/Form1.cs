using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calendar
{
	public partial class Form1 : Form
	{
		bool flag1 = false;
		bool flag2 = false;

		public Form1()
		{
			InitializeComponent();
		}

		private void radioButton1_Click(object sender, EventArgs e)
		{
			flag1 = true;
			flag2 = false;
		}

		private void radioButton2_Click(object sender, EventArgs e)
		{
			flag1 = false;
			flag2 = true;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			if (flag1 == true)
			{
				Form3 f = new Form3();
				f.ShowDialog(this);
			}
			else if (flag2 == true)
			{
				Form2 f = new Form2();
				f.ShowDialog(this);
			}
		}
	}
}
