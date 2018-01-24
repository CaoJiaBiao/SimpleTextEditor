using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace SimpleTextEditor
{
    delegate void MyEventHandler(object sender,EventArgs e);
    public partial class FrmEditor : Form
    {
        bool flag = false;//判断是不是新建//////////////////////////////////////////
        string _FileName;
        bool _Modified;
        public FrmEditor()
        {
            InitializeComponent();
        }

        public void SaveFile()
        {
            //以覆盖方式打开文件写入流
            StreamWriter sw = new StreamWriter(this._FileName, false, Encoding.Default);
            foreach (string str in this.tbText.Lines)
            {
                //写入一行到文件
                sw.WriteLine(str);
            }
            //关闭写入流
            sw.Close();
        }

        private void InitUI()
        {
            this.tbText.Text = "";//清空初始文本
            this.tbText.ReadOnly = true;//////////////////////////
            //初始化样式示例
            this.tsslbStyle.ForeColor = this.tbText.ForeColor;
            this.tsslbStyle.BackColor = this.tbText.BackColor;
            this.tsslbStyle.Font = this.tbText.Font;
            //初始化修改属性
            this.tsslbModify.Text = "未修改";
            this.tsslbModify.ForeColor = Color.Green;
            //初始化大小属性提示
            this.tsslbSize.ForeColor = Color.Indigo;
            this.tsslbSize.Text = "字符数：0";
            //初始化显示标题
            this.Text = "SimpleTextEditor--新建文本";
        }

        private void InitData()
        {
            //没有打开文件
            this._FileName = "";
            //修改状态为没有修改
            this._Modified = false;
        }

        private void FrmEditor_Load(object sender, EventArgs e)
        {
            //窗体第一次加载，初始化界面
            InitUI();
            //窗体第一次加载，初始化数据
            InitData();
        }

        private bool AskSave()
        {
            if (this._Modified)
            {
                switch (MessageBox.Show("文件已修改，是否保存？", "提示", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1))
                {
                    case DialogResult.Yes://需要保存，则保存，返回true
                        if (string.IsNullOrEmpty(this._FileName))
                        {
                            SaveFileDialog sfdlg = new SaveFileDialog();
                            sfdlg.Filter = "文本文件(*.txt)|*.TXT";
                            sfdlg.FileName = this._FileName;
                            if (sfdlg.ShowDialog() == DialogResult.OK)
                            { 
                                this._FileName = sfdlg.FileName;
                            }
                            else //没有选择文件，退出
                            {
                                return true;
                            }
                        }
                        //保存到新文件
                        this.SaveFile();
                        return true;
                    case DialogResult.Cancel:
                        return false;
                    case DialogResult.No:
                        return true;
                }
            }
            //文件没有修改，继续操作
            return true;
        }

        private void FrmEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!this.AskSave())
            {
                e.Cancel = true;
                return;
            }
        }

        private void tsbtnNew_Click(object sender, EventArgs e)
        {
            //询问是否需要保存
            if (!AskSave())
                return;
            this.tbText.ReadOnly = false;///////////////////////////////
            //新建文件
            this.Text = "简易文本编辑器--新建文本";
            this.tbText.Text = "";
            this._Modified = false;
            this.tsslbModify.Text = "未修改";
            this.tsslbModify.ForeColor = Color.Green;
            flag = true;//判断是不是新建////////////////////////
        }

        private void LoadFile()
        {
            //先清空原有文件
            this.tbText.Text = "";
            //打开文件读取流
            StreamReader sr = new StreamReader(this._FileName,Encoding.Default);
            while (!sr.EndOfStream)
            {
                //读取一行文本并添加到编辑框
                this.tbText.AppendText(sr.ReadLine());
                //在编辑框追加换行符
                this.tbText.AppendText(System.Environment.NewLine);
            }
            //关闭数据流
            sr.Close();
        }

        private void tsbtnOpen_Click(object sender, EventArgs e)
        {
            //打开文件，通过OpenFileDialog对话框选择TXT文件
            OpenFileDialog ofdlg = new OpenFileDialog();
            ofdlg.Filter = "文本文件(*.txt)|*.TXT";
            if (ofdlg.ShowDialog() == DialogResult.OK)
            {
                this.tbText.ReadOnly = false;///////////////////////////////
                this._FileName = ofdlg.FileName;
                this.LoadFile();
                //更新界面
                this.Text = "简易文本编辑器" + this._FileName;
                this._Modified = false;
                this.tsslbModify.Text = "未修改";
                this.tsslbModify.ForeColor = Color.Green;
                this.tsslbSize.Text = "字符数:" + this.tbText.Text.Length.ToString();
            }
        }

        private void tsmiAbout_Click(object sender, EventArgs e)
        {
            //创建“关于”对话框
            AboutDlg dlg = new AboutDlg();
            dlg.ShowDialog(this);
        }

        private void tsbtnSave_Click(object sender, EventArgs e)
        {
            if (!this._Modified)
            {
                MessageBox.Show("文件没有被修改，不需要保存！", "提示");
                return;
            }
            //文件为空，则是“另存为”，让用户选择文件名
            if (string.IsNullOrEmpty(this._FileName))
            {
                SaveFileDialog sfdlg = new SaveFileDialog();
                sfdlg.Filter = "文本文件(*.txt)|*.TXT";
                sfdlg.FileName = this._FileName;
                if (sfdlg.ShowDialog() == DialogResult.OK)
                {
                    this._FileName = sfdlg.FileName;
                }
                else//没有选择文件，退出
                {
                    return;
                }
            }
            //保存文件
            this.SaveFile();
            //更新界面和数据
            this.Text = "简易文本编辑器--" + this._FileName;
            this._Modified = false;
            this.tsslbModify.Text = "未修改";
            this.tsslbModify.ForeColor = Color.Green;
            this.tsslbSize.Text = "字符数:" + this.tbText.Text.Length.ToString();
            MessageBox.Show("成功保存文件：" + this._FileName, "提示");
        }

        private void tsmiSaveAs_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfdlg = new SaveFileDialog();
            sfdlg.Filter = "文本文件(*.txt)|*.TXT";
            sfdlg.FileName = this._FileName;
            if (sfdlg.ShowDialog() == DialogResult.OK)
            {
                this._FileName = sfdlg.FileName;
            }
            else//没有选择文件，退出
            {
                return;
            }
            //保存新文件
            this.SaveFile();
            //更新界面和数据
            this.Text = "简易文本编辑器--" + this._FileName;
            this._Modified = false;
            this.tsslbModify.Text = "未修改";
            this.tsslbModify.ForeColor = Color.Green;
            this.tsslbSize.Text = "字符数:" + this.tbText.Text.Length.ToString();
            MessageBox.Show("成功保存文件：" + this._FileName, "提示");
        }

        private void tsbtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbtnProp_Click(object sender, EventArgs e)
        {
            PropDlg pdlg = new PropDlg();
            //传递属性
            pdlg.TxtBackColor = this.tbText.BackColor;
            pdlg.TxtForeColor = this.tbText.ForeColor;
            pdlg.TxtFont = this.tbText.Font;
            //显示属性配置窗体，并判断是否确认修改
            if (pdlg.ShowDialog() == DialogResult.OK)
            {
                //将新的属性应用到文本编辑框
                this.tbText.BackColor = pdlg.TxtBackColor;
                this.tbText.ForeColor = pdlg.TxtForeColor;
                this.tbText.Font = pdlg.TxtFont;
                //将新的属性应用到文本模式提示
                this.tsslbStyle.ForeColor = this.tbText.ForeColor;
                this.tsslbStyle.BackColor = this.tbText.BackColor;
                this.tsslbStyle.Font = this.tbText.Font;
            }
        }

        private void tbText_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.tbText.Text.Length.ToString()))
                this.tsslbModify.Text = "已修改";
            this.tsslbSize.Text = "字符数:" + this.tbText.Text.Length.ToString();
            this._Modified = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hello World !");
        }
    }
}
