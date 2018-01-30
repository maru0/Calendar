using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calendar
{
	public partial class Form2 : Form
	{
		Dictionary<String, String> keyToValue = new Dictionary<string, string>();
		private string filepath = System.Windows.Forms.Application.StartupPath + "\\dic";
		DateTime dt;
		private string date;
		bool firstshow = true;

		public Form2()
		{
			InitializeComponent();
			dt = dateTimePicker1.Value;
			dt = dt.AddDays(1);
			date = dt.ToShortDateString();
			date = Regex.Replace(date, "/", "_");
			showtask();
			firstshow = false;
			
		}

		// ファイルの内容を返却
		public static string openfile(string path)
		{
			StreamReader sr;

			try
			{
				sr = File.OpenText(path);
			}
			catch (FileNotFoundException e)
			{
				System.Console.WriteLine(e.Message);
				return "";
			}
			// ファイル読み込み
			string s = sr.ReadToEnd();
			sr.Close();
			return s;
		}

		private void searchdate(string data)
		{
			string s;

			System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(@filepath);
			System.IO.FileInfo[] files =
				di.GetFiles("*.txt", System.IO.SearchOption.AllDirectories);
			foreach (System.IO.FileInfo f in files)
			{
				// dataにあっているのか判定

				if (firstshow == true)
				{
					if (System.Text.RegularExpressions.Regex.IsMatch(
					Path.GetFileNameWithoutExtension(f.Name), data))
					{
						s = openfile(f.FullName);
						if (s != "")
						{
							MessageBox.Show("明日の予定は"+ "\n" + s + "です");
						}
					}
				}

				if (System.Text.RegularExpressions.Regex.IsMatch(
					Path.GetFileNameWithoutExtension(f.Name),data + "\\S*"))
				{
					// sに内容が入る
					s = openfile(f.FullName);
					// 配列にデータを格納(例:2018_1_20)
					listBox1.Items.Add(string.Format("{0,-15}", Path.GetFileNameWithoutExtension(f.Name)) + s);
				}
			}
		}

		private void all_Click(object sender, EventArgs e)
		{
			// 全てのファイル名を取る
			string s;
			string nowkey;

			listBox1.Items.Clear();
			System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(@filepath);
			System.IO.FileInfo[] files =
				di.GetFiles("*.txt", System.IO.SearchOption.AllDirectories);
			foreach (System.IO.FileInfo f in files)
			{
				nowkey = f.Name.Replace(f.Extension, "");
				if (!keyToValue.ContainsKey(nowkey))
				{
					// sに内容が入る
					s = openfile(f.FullName);
					// 配列にデータを格納(例:2018_1_20)
					keyToValue.Add(nowkey, s);
				}
				listBox1.Items.Add(String.Format("{0,-15}",nowkey) + keyToValue[nowkey]);
			}
		}

		private void radioButton1_Click(object sender, EventArgs e)
		{
			dt = dateTimePicker1.Value;
			date = dt.ToShortDateString();
			date = Regex.Replace(date, "/", "_");

			listBox1.Items.Clear();
			// 例(2018)が取れている
			Match year = Regex.Match(date, @"2...");
			searchdate(year.Value);
		}

		private void radioButton2_Click(object sender, EventArgs e)
		{
			dt = dateTimePicker1.Value;
			date = dt.ToShortDateString();
			date = Regex.Replace(date, "/", "_");

			listBox1.Items.Clear();
			// 例(2018_01)
			Match month = Regex.Match(date, @"2..._\d{2}");
			searchdate(month.Value);
		}

		private void radioButton3_Click(object sender, EventArgs e)
		{
			dt = dateTimePicker1.Value;
			date = dt.ToShortDateString();
			date = Regex.Replace(date, "/", "_");

			listBox1.Items.Clear();
			// 例(2018_01)
			Match day = Regex.Match(date, @"2..._\d{2}_\d{2}");
			searchdate(day.Value);
		}

		private void showtask()
		{

			if (firstshow == true)
			{
				searchdate(date);
			}
		}

	}
}
