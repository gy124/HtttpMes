using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form_load : Form
    {
        public Form_load()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //if (textBox_name.Text.ToString() == "")
            //{
            //    MessageBox.Show("请输入用户名");
            //   // this.DialogResult = DialogResult.Cancel;
            //}
            //else
            //    if (textBox_password.Text.ToString() == "")
            //    {
            //        MessageBox.Show("请输入密码");
            //      //  this.DialogResult = DialogResult.Cancel;
            //    }
            //    else
            //    {
            //        this.DialogResult = DialogResult.OK;
            //        this.Close();
            //    }
            if (textBox_name.Text.ToString() == "")
            {
                MessageBox.Show("请输入账户");
                return;
            }

            //else
            //  Main.Mes.userId = textBox_name.Text;

            if (textBox_password.Text.ToString() == "")
            {
                MessageBox.Show("请输入密码");
                return;
            }

            //else
            //    Main.Mes.password = textBox_password.Text;

            this.DialogResult = DialogResult.OK;
            Main.UserId = textBox_name.Text;
            Main.Password = textBox_password.Text;
            this.Close();
          //  MessageBox.Show("登录成功");
            return;
            //if (textBox_name.Text.Equals("1072389") )
            //{
            //    if (textBox_password.Text.Equals("sap12345"))
            //    {
            //        this.DialogResult = DialogResult.OK;
            //        Main.UserId= textBox_name.Text;
            //        Main.Password = textBox_password.Text;
            //        this.Close();
            //        MessageBox.Show("登录成功");
            //        return;
            //    }
            //    else
            //        MessageBox.Show("密码错误");

            //    return;
            //}

            //    MessageBox.Show("用户名错误");
       
            
        }
    }
}
