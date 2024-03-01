using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Electronic_Reading
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
     
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.WordWrap = false;
        }

        private void 打开ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "请选择书籍";
            openFileDialog1.Filter = "TXT File(*.txt)|*.txt";
            // 可选择多个文件
            openFileDialog1.Multiselect = true;
            openFileDialog1.InitialDirectory = System.IO.Directory.GetCurrentDirectory();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                for (int i = 0; i < openFileDialog1.FileNames.Length; i++)
                {
                    // 在 listBox1 中显示文件名
                    string filePath = openFileDialog1.FileNames[i];
                    int index = filePath.LastIndexOf("\\");
                    listBox1.Items.Add(filePath.Substring(index + 1, filePath.Length - index - 1));
                    // 在 listBox2 中显示路径名
                    listBox2.Visible = false;
                    listBox2.Items.Add( openFileDialog1.FileNames[i] + "\r\n");
                }
            }
        }

        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "TXT File(*.txt)|*.txt";
            // 默认文件名
            saveFileDialog1.FileName = "undefined-file";
            // 默认文件扩展
            saveFileDialog1.DefaultExt = "txt";
            DialogResult result = saveFileDialog1.ShowDialog();
            // string localFilePath = "";
            if (result == DialogResult.OK && saveFileDialog1.FileName != "")
            {
                // 获取文件路径
                // localFilePath = saveFileDialog1.FileName.ToString();
                // 逐行写文本
                // StreamWriter sw = new StreamWriter(Application.StartupPath + "\\undefined-file.txt");
                StreamWriter sw = new StreamWriter(Application.StartupPath + "\\undefined-file.txt", append:true);
                for (int i = 0; i < textBox1.Lines.Length; i ++)
                {
                    sw.WriteLine(textBox1.Lines[i]);
                }
                // 关闭文件
                sw.Close();
                sw.Dispose();

            }
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult a = MessageBox.Show("是否退出？", "提示", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (Convert.ToString (a) == "Yes")
            {
                Application.Exit();
            }
            else
            {
                return;
            }
            
        }

        private void 字体ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fontDialog1.Font = textBox1.Font;
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Font = fontDialog1.Font;
            }
        }

        private void 颜色ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void 帮助ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void 文档ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process P = new Process();
            P.StartInfo.FileName = Application.StartupPath + "\\help.htm";
            P.StartInfo.Verb = "Open";
            P.Start();
        }

        private void 关于记事本ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAbout ob_FrmAbout = new frmAbout();
            ob_FrmAbout.Show();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            
        }

        private void listBox1_MouseDown(object sender, MouseEventArgs e)
        {
            
        }

        private void listBox1_MouseMove(object sender, MouseEventArgs e)
        {

        }

        // 双击文件名，在 textBox1 中显示文件内容
        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index = this.listBox1.IndexFromPoint(e.Location);
            if (index != System.Windows.Forms.ListBox.NoMatches)
            {
                for (int i = 0; i < listBox1.Items.Count; i ++)
                {
                    if (i == index)
                    {
                        System.IO.StreamReader st;
                        st = new System.IO.StreamReader(openFileDialog1.FileNames[i], System.Text.Encoding.Default);
                        //UTF-8通用编码
                        textBox1.Text = st.ReadToEnd();
                        st.Close();
                    } 
                }
            }

        }

        
        private void 背景颜色ToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }

        private void 字体颜色ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = textBox1.ForeColor;
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.ForeColor = colorDialog1.Color;
            }
        }

        // 更改 textBox1 背景颜色
        private void 背景颜色ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

        }

        private void 绿色护眼ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.BackColor = Color.PaleGreen;
        }

        private void 蓝色清新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.BackColor = Color.SkyBlue;
        }

        private void 灰色夜晚ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.BackColor = Color.DimGray;
        }

        private void 系统默认ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.BackColor = Color.White;
        }

        // 显示文件路径名
        private void listBox1_MouseCaptureChanged(object sender, EventArgs e)
        {
            listBox2.Visible = true;
            listBox2.Items.Clear();
            listBox2.Items.Add(openFileDialog1.FileNames[0]);
        }
    }
}
