using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SimpleTextEditor
{
    public partial class PropDlg : Form
    {
        public PropDlg()
        {
            InitializeComponent();
        }

        private Color _TxtBackColor;
        //文本框背景色
        public Color TxtBackColor
        {
            get 
            {
                return this._TxtBackColor;
            }
            set
            {
                this._TxtBackColor = value;
            }
        }

        private Color _TxtForeColor;
        //文本框前景色属性
        public Color TxtForeColor
        {
            get
            {
                return this._TxtForeColor;
            }
            set
            {
                this._TxtForeColor = value;
            }
        }

        private Font _TxtFont;
        //文本框字体属性
        public Font TxtFont
        {
            get
            {
                return this._TxtFont;
            }
            set
            {
                this._TxtFont = value;
            }
        }

        private void PropDlg_Load(object sender, EventArgs e)
        {
            //初始化字体按钮
            this.btnFont.Font = this._TxtFont;
            this.btnFont.Text = this._TxtFont.Name;
            //初始化前景色和背景色按钮
            this.btnForeColor.BackColor = this._TxtForeColor;
            this.btnBackColor.BackColor = this._TxtBackColor;
            //初始化示例框
            this.tbExample.Font = this._TxtFont;
            this.tbExample.BackColor = this.TxtBackColor;
            this.tbExample.ForeColor = this._TxtForeColor;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            //关闭，返回dialogresult.OK
            this.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //关闭，返回dialogresult.cancel
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnBackColor_Click(object sender, EventArgs e)
        {
            //创建ColorDialog对话框对象
            ColorDialog cdlg = new ColorDialog();
            //将现有的值传递到“颜色选择”对话框
            cdlg.Color = this._TxtBackColor;
            //显示“颜色选择”对话框，并判断是否确定
            if (cdlg.ShowDialog() == DialogResult.OK)
            {
                //将新的颜色应用到界面和类字段
                this._TxtBackColor = cdlg.Color;
                this.btnBackColor.BackColor = cdlg.Color;
                this.tbExample.BackColor = cdlg.Color;
            }
        }

        private void btnForeColor_Click(object sender, EventArgs e)
        {
            //创建ColorDialog对话框对象
            ColorDialog cdlg = new ColorDialog();
            //将现有的值传递到“颜色选择”对话框
            cdlg.Color = this._TxtForeColor;
            //显示“颜色选择”对话框，并判断是否确定
            if (cdlg.ShowDialog() == DialogResult.OK)
            {
                //将新的颜色应用到界面和类字段
                this._TxtForeColor = cdlg.Color;
                this.btnForeColor.BackColor = cdlg.Color;
                this.tbExample.ForeColor = cdlg.Color;
            }
        }

        private void btnFont_Click(object sender, EventArgs e)
        {
            //创建FontDialog对话框对象
            FontDialog fdlg = new FontDialog();
            //将现有的值传递到“颜色选择”对话框
            fdlg.Font = this._TxtFont;
            //显示“颜色选择”对话框，并判断是否确定
            if (fdlg.ShowDialog() == DialogResult.OK)
            {
                //将新的颜色应用到界面和类字段
                this._TxtFont = fdlg.Font;
                this.btnFont.Font = this._TxtFont;
                this.tbExample.Font = this._TxtFont;
                this.btnFont.Text = this._TxtFont.Name;
            }
        }
    }
}
