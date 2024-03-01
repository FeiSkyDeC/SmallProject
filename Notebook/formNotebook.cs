using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Notebook
{
    public partial class formNotebook : Form
    {
        // 声明两个公共变量， b 用于判断文件是新建的还是从磁盘打开的， s 用于判断文件是否被保存
        bool b = false;
        bool s = true;

        public formNotebook()
        {
            InitializeComponent();
        }

        private void tsbPaste_Click(object sender, EventArgs e)
        {

        }

        private void formNotebook_Load(object sender, EventArgs e)
        {

        }

        // 多格式文本框的 TextChanged 事件
        private void rtxtNotepad_TextChanged(object sender, EventArgs e)
        {
            // 文本被修改后， s 为 false， 表示文件未被保存
            s = false;
        }

        // 【新建】 菜单代码
        private void tsmiNew_Click(object sender, EventArgs e)
        {
            // 判断当前文件是否从磁盘打开，或则新建文档时不为空，并且文档未被保存
            if (b == true || rtxtNotepad.Text.Trim() != "")
            {
                // 若文件未保存
                if (s == false)
                {
                    string result;
                    result = MessageBox.Show("文件尚未保存，是否保存？", "保存文件", MessageBoxButtons.YesNoCancel).ToString();
                    switch(result)
                    {
                        case "Yes":
                            // 若文件是从磁盘打开的
                            if (b == true)
                            {
                                // 按文件打开的路径保存文件
                                rtxtNotepad.SaveFile(odlgNotepad.FileName);
                            }
                            // 若文件不是从磁盘打开的
                            else if (sdlgNotepad.ShowDialog() == DialogResult.OK)
                            {
                                rtxtNotepad.SaveFile(sdlgNotepad.FileName);
                            }
                            s = true;
                            rtxtNotepad.Text = "";
                            break;
                        case "No":
                            b = false;
                            rtxtNotepad.Text = "";
                            break;
                    }
                }
            }
            

        }
        // 【打开】 菜单代码
        private void tsmiOpen_Click(object sender, EventArgs e)
        {
            if (b == true || rtxtNotepad.Text.Trim() != "")
            {
                if (s == false)
                {
                    string result;
                    result = MessageBox.Show("文件尚未保存，是否保存?", "保存文件", MessageBoxButtons.YesNoCancel).ToString();
                    switch (result)
                    {
                        case "Yes":
                            if (b == true)
                            {
                                rtxtNotepad.SaveFile(odlgNotepad.FileName);
                            }
                            else if (sdlgNotepad.ShowDialog() == DialogResult.OK)
                            {
                                rtxtNotepad.SaveFile(sdlgNotepad.FileName);
                            }
                            s = true;
                            break;
                        case "No":
                            b = false;
                            rtxtNotepad.Text = "";
                            break;
                    }
                }
            }
            odlgNotepad.RestoreDirectory = true;
            if ((odlgNotepad.ShowDialog() == DialogResult.OK) && odlgNotepad.FileName != "")
            {
                // 获取文档的扩展名
                string ex = Path.GetExtension(odlgNotepad .FileName);
                // 如果为 .txt 文件则打开
                if (ex == ".txt")
                {
                    rtxtNotepad.LoadFile(odlgNotepad.FileName, RichTextBoxStreamType.PlainText);
                }
                // 否则，若为 .rtf、.doc 文件则打开
                else
                { 
                    rtxtNotepad.LoadFile(odlgNotepad.FileName, RichTextBoxStreamType.RichText); 
                }
                b = true;
            }
            s = true;
        }

        // 【保存】 菜单代码
        private void tsmiSave_Click(object sender, EventArgs e)
        {
            MessageBox.Show("保存成功", "提示", MessageBoxButtons.OK);
            // 若文件从磁盘打开并且修改了其内容
            if (b == true && rtxtNotepad.Modified == true)
            {
                // 获取文件扩展名, 保存 .txt 或 .rtf/.doc文件
                string ex = Path.GetExtension(odlgNotepad.FileName);
                if (ex == ".txt")
                {
                    rtxtNotepad.SaveFile(odlgNotepad.FileName, RichTextBoxStreamType.PlainText);
                }
                else if (ex == ".doc" || ex == ".rtf")
                {
                    rtxtNotepad.SaveFile(odlgNotepad.FileName, RichTextBoxStreamType.RichText);
                }
                s = true;
            }
            else if (b == false && rtxtNotepad.Text.Trim() != "" && sdlgNotepad.ShowDialog() == DialogResult.OK)
            {
                // 获取文件扩展名, 保存 .txt 或 .rtf/.doc文件
                string ex = Path.GetExtension(odlgNotepad.FileName);
                if (ex == ".txt")
                {
                    rtxtNotepad.SaveFile(odlgNotepad.FileName, RichTextBoxStreamType.PlainText);
                }
                else if (ex == ".doc" || ex == ".rtf")
                {
                    rtxtNotepad.SaveFile(odlgNotepad.FileName, RichTextBoxStreamType.RichText);
                }
                s = true;
                b = true;
                odlgNotepad.FileName = sdlgNotepad.FileName;
            }
        }

        // 【另存为】 菜单代码
        private void tsmiSaveAs_Click(object sender, EventArgs e)
        {
            if (sdlgNotepad.ShowDialog() == DialogResult.OK)
            {
                // 获取文件扩展名, 保存 .txt 或 .rtf/.doc文件
                string ex = Path.GetExtension(odlgNotepad.FileName);
                if (ex == ".txt")
                {
                    rtxtNotepad.SaveFile(odlgNotepad.FileName, RichTextBoxStreamType.PlainText);
                }
                else if (ex == ".doc" || ex == ".rtf")
                {
                    rtxtNotepad.SaveFile(odlgNotepad.FileName, RichTextBoxStreamType.RichText);
                }
                s = true;
            }
        }

        // 【退出】 菜单代码
        private void tsmiClose_Click(object sender, EventArgs e)
        {
            DialogResult a = MessageBox.Show("是否退出?", "退出", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (Convert .ToString (a) == "Yes")
            {
                Application.Exit();
            }
            else
            {
                return;
            }
        }

        private void tsmiEdit_Click(object sender, EventArgs e)
        {

        }

        // 【撤销】 菜单代码
        private void tsmiUndo_Click(object sender, EventArgs e)
        {
            rtxtNotepad.Undo();
        }

        // 【复制】 菜单代码
        private void tsmiCopy_Click(object sender, EventArgs e)
        {
            rtxtNotepad.Copy();
        }

        // 【剪切】 菜单代码
        private void tsmiCut_Click(object sender, EventArgs e)
        {
            rtxtNotepad.Cut();
        }

        // 【粘贴】 菜单代码
        private void tsmiPaste_Click(object sender, EventArgs e)
        {
            rtxtNotepad.Paste();
        }

        // 【全选】 菜单代码
        private void tsmiSelectAll_Click(object sender, EventArgs e)
        {
            rtxtNotepad.SelectAll();
        }

        // 【日期】 菜单代码
        private void tsmiDate_Click(object sender, EventArgs e)
        {
            rtxtNotepad.AppendText(System.DateTime.Now.ToString());
        }

        private void tsmiFormat_Click(object sender, EventArgs e)
        {

        }

        // 【自动换行】 菜单代码

        private void tsmiAuto_Click(object sender, EventArgs e)
        {
            if (tsmiAuto.Checked == false)
            {
                tsmiAuto.Checked = true;    // 选中该菜单栏
                rtxtNotepad.WordWrap = true;   // 设置为自动换行
            }
            else
            {
                tsmiAuto.Checked = false;
                rtxtNotepad.WordWrap = false;
            }
        }

        // 【字体】 菜单代码
        private void tsmiFont_Click(object sender, EventArgs e)
        {
            fdlgNotepad.ShowColor = true;
            if (fdlgNotepad.ShowDialog() == DialogResult.OK)
            {
                rtxtNotepad.SelectionColor = fdlgNotepad.Color;
                rtxtNotepad.SelectionFont = fdlgNotepad.Font;
            }
        }

        private void tsmiView_Click(object sender, EventArgs e)
        {

        }

        // 【工具栏】
        private void tsmiToolStrip_Click(object sender, EventArgs e)
        {
            Point point;
            if (tsmiToolStrip .Checked == true)
            {
                // 隐藏工具栏时，把坐标设为 （0，24）， 因为菜单的高度为 24
                point = new Point(0,24);
                tsmiToolStrip.Checked = false;
                tlsNotepad.Visible = false;

                // 设置多格式文本框左上角位置
                rtxtNotepad.Location = point;

                // 隐藏工具栏后，增加文本框高度
                rtxtNotepad.Height += tlsNotepad.Height;
            }
            else
            {
                // 显示工具栏时，多格式文本框左上角位置为（0，45）
                point = new Point(0, 49);
                tsmiToolStrip.Checked = true;
                tlsNotepad.Visible = true;
                rtxtNotepad.Location = point;
                rtxtNotepad.Height -= tlsNotepad.Height;
            }
        }

        // 【状态栏】
        private void tsmiStatusStrip_Click(object sender, EventArgs e)
        {
            if(tsmiStatusStrip .Checked == true)
            {
                tsmiStatusStrip.Checked = false;
                stsNotepad.Visible = false;
                rtxtNotepad.Height += stsNotepad.Height;
            }
            else
            {
                tsmiStatusStrip.Checked = true;
                stsNotepad.Visible = true;
                rtxtNotepad.Height -= stsNotepad.Height;
            }
        }

        private void tsmiHelp_Click(object sender, EventArgs e)
        {

        }

        // 【关于记事本】
        private void tsmiAbout_Click(object sender, EventArgs e)
        {
            frmAbout ob_FrmAbout = new frmAbout();
            ob_FrmAbout.Show();
        }

        // 【工具栏】
        private void tlsNotepad_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            int n;
            n = tlsNotepad.Items.IndexOf(e.ClickedItem);
            switch(n)
            {
                case 0:
                    tsmiNew_Click(sender, e);
                    break;
                case 1:
                    tsmiOpen_Click(sender, e);
                    break;
                case 2:
                    tsmiSave_Click(sender, e);
                    break;
                case 4:
                    tsmiCopy_Click(sender, e);
                    break;
                case 5:
                    tsmiCut_Click(sender, e);
                    break;
                case 6:
                    tsmiPaste_Click(sender, e);
                    break;
                case 7:
                    tsmiUndo_Click(sender, e);
                    break;
                case 9:
                    tsmiFont_Click(sender, e);
                    break;
                case 10:
                    tsmiAbout_Click(sender, e);
                    break;
            }

        }

        // 【计时器】
        private void tmrNotepad_Tick(object sender, EventArgs e)
        {
            tssLBl2.Text = System.DateTime.Now.ToString();
        }

        // 【窗体大小】
        private void formNotebook_SizeChanged(object sender, EventArgs e)
        {
            formNotebook ob_fromNotebook = new formNotebook();
            tssLBl1.Width = this.Width / 2 - 12;
            tssLBl2.Width = tssLBl1.Width;
        }

        // 【颜色】
        private void 颜色ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = rtxtNotepad.SelectionColor;
            if (colorDialog1 .ShowDialog () == DialogResult.OK)
            {
                rtxtNotepad.ForeColor = colorDialog1.Color;
            }
        }

        // 【删除】
        private void tsmiDelete_Click(object sender, EventArgs e)
        {
            rtxtNotepad.Clear();
        }

        // 【文档】
        private void 帮助文档ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process P = new Process();
            P.StartInfo.FileName = Application.StartupPath + "\\help.htm";
            P.StartInfo.Verb = "Open";
            P.Start();
        }

        private void odlgNotepad_FileOk(object sender, CancelEventArgs e)
        {

        }
    }
}
