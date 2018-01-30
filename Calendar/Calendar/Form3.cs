using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Calendar
{
	public partial class Form3 : Form
	{
		string date;    // 選択日にち

		Dictionary<String, String> keyToValue = new Dictionary<string, string>();
		private string filepath = System.Windows.Forms.Application.StartupPath + "\\dic";

		public Form3()
		{
			InitializeComponent();
			//			monthCalendar1.BackColor = Color.Cyan;
			//			monthCalendar1.CalendarDimensions = new System.Drawing.Size(4, 4);
			webBrowser1.Visible = false;
			comboBox1.Visible = false;
			button1.Visible = false;
			button2.Visible = false;
			button3.Visible = false;
			button4.Visible = false;
			textBox1.Visible = false;			
		}

		private void changeDictionary(string date)
		{
			string newdate = filepath + "\\" + date + ".txt";

			keyToValue[date] = textBox1.Text;
			StreamWriter write = new StreamWriter(@newdate);
			write.WriteLine(keyToValue[date]);
			write.Close();
		}
		public void deleteDictionary(string date)
		{
			string newdata = filepath + "\\" + date + ".txt";
			keyToValue[date] = "";
			textBox1.ResetText();
			File.Delete(@newdata);

		}

		// 配列にデータを格納
		public void createDictionary(string date)
		{
			// 全てのファイル名を取る
			string s;
			string nowkey;
			System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(@filepath);
			System.IO.FileInfo[] files =
				di.GetFiles("*.txt", System.IO.SearchOption.AllDirectories);
			foreach (System.IO.FileInfo f in files)
			{
				nowkey = f.Name.Replace(f.Extension, "");
				if (keyToValue.ContainsKey(nowkey))
				{
					break;
				}
				else
				{
					// sに内容が入る
					s = openfile(f.FullName);
					// 配列にデータを格納(例:2018_1_20)
					keyToValue.Add(nowkey, s);
				}
			}
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


		// ディレクトリ作成
		public static DirectoryInfo createDirectory(string path)
		{
			if (Directory.Exists(path))
			{
				return null;
			}
			return Directory.CreateDirectory(path);
		}

		private bool showMessage(bool flag, string Message)
		{
			DialogResult result = MessageBox.Show(Message + "しますか？",
					"警告",
					MessageBoxButtons.YesNo,
					MessageBoxIcon.Asterisk,
					MessageBoxDefaultButton.Button2);
			if (result == DialogResult.Yes)
			{
				return true;
			}
			else if (result == DialogResult.No)
			{
				return false;
			}
			return true;
		}

		private void button1_Click_1(object sender, EventArgs e)
		{
			bool flag = true;
			string Message = "保存";
			if (showMessage(flag, Message) == true)
			{
				if (textBox1.Text != "")
				{
					changeDictionary(date);
					button1.Visible = false;
					button2.Visible = false;
					button3.Visible = false;
				}
				else
				{
					MessageBox.Show("空白文字のため保存できません", "警告", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}
			}
		}

		private void button3_Click_1(object sender, EventArgs e)
		{
			string Message = "初期化";
			bool flag = false;

			if (showMessage(flag, Message) == true)
			{
				textBox1.ResetText();
			}
		}

		private void textBox1_KeyDown_1(object sender, KeyEventArgs e)
		{
			bool flag = false;
			string previous = textBox1.Text;
			string Message;

			if (e.Control && e.KeyCode.ToString() == "S")
			{
				// ここで保存と修正
				flag = false;
				Message = "保存";
				if (showMessage(flag, Message) == true)
				{
					if (textBox1.Text != "")
					{
						changeDictionary(date);
						button1.Visible = false;
//						button1.Visible = false;
//						button1.Visible = false;
					}
					else
					{
						MessageBox.Show("空白文字のため保存できません", "警告", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					}
				}
			}
			else if (e.Control && e.KeyCode.ToString() == "X")
			{
				// ここで初期化
				flag = false;
				Message = "初期化";
				if (showMessage(flag, Message) == true)
				{
					textBox1.ResetText();
				}
			}
		}

		private void monthCalendar1_DateSelected_1(object sender, DateRangeEventArgs e)
		{
			// テキストの内容初期化
			textBox1.ResetText();
			// テキスト、ボタン表示
			textBox1.Visible = true;
			button1.Visible = true;
			button2.Visible = true;
			button3.Visible = true;
			button4.Visible = true;
			// これで選択時間が得られる
			date = e.Start.ToShortDateString();
			date = Regex.Replace(date, "/", "_");

			// ディレクトリと配列作成
			createDirectory(filepath);
			createDictionary(date);
			// ここで選択した日のデータを示す
			foreach (string key in keyToValue.Keys)
			{
				if (key == date)
				{
					textBox1.Text = keyToValue[key];
					break;
				}
			}
		}

		private void monthCalendar1_KeyDown_1(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape)
			{
				this.Close();
			}
		}

		private void comboBox1_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				try
				{
					string nextUrl = comboBox1.Text;
					webBrowser1.Navigate(new Uri(nextUrl));
				} catch { }
			}
			if (e.KeyCode == Keys.Escape)
			{
				webBrowser1.Navigate("about:blank");
				webBrowser1.Visible = false;
				comboBox1.Visible = false;
				comboBox1.Items.Clear();
				button1.Visible = true;
				button2.Visible = true;
				button3.Visible = true;
				textBox1.Visible = true;

			}
		}

		private void webBrowser1_Navigated(object sender, WebBrowserNavigatedEventArgs e)
		{
			comboBox1.Text = webBrowser1.Url.AbsoluteUri;
		}

		private void button2_Click(object sender, EventArgs e)
		{
			string urlname;

			button1.Visible = false;
			button2.Visible = false;
			button3.Visible = false;
			button4.Visible = false;
			textBox1.Visible = false;

			webBrowser1.Visible = true;
			comboBox1.Visible = true;
			urlname = date;
			urlname = Regex.Replace(urlname, "_", "/");
			Uri nextUri = new Uri("https://japan.cnet.com/archives/" + urlname + "/");
			this.webBrowser1.Navigate(nextUri);
		}

		private void button4_Click(object sender, EventArgs e)
		{
			bool flag = true;
			string Message = "削除";
			if (showMessage(flag, Message) == true)
			{
				changeDictionary(date);
				button1.Visible = false;
				button3.Visible = false;
				button4.Visible = false;
				deleteDictionary(date);
			}
		}
	}
}
