using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Pather1
{
    public partial class signup : Form
    {
        public signup()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnectionStringBuilder stu = new SqlConnectionStringBuilder();
             stu.DataSource ="118.24.162.142";
            stu.UserID = "sa";
            stu.Password = "123";
            stu.InitialCatalog = "SIGNIN";
            SqlConnection conn1 = new SqlConnection(stu.ToString());
            if (conn1.State == ConnectionState.Closed)
                conn1.Open();
            string username = textBox1.Text; //select COUNT(*) from 表名 where 条件语句
            string userpassword = textBox2.Text;
            if (string.IsNullOrEmpty(textBox1.Text.Trim()) || string.IsNullOrEmpty(textBox2.Text.Trim()))
                MessageBox.Show("请检查是否输入内容");
            else if (textBox2.Text != textBox3.Text)
                MessageBox.Show("两次密码输入不一致");
            else
            {
                string sqlstr = "INSERT usertable(username, userpassword) VALUES('" + username + "', '" + userpassword + "')";
                SqlCommand comm = new SqlCommand(sqlstr, conn1);
                comm.ExecuteNonQuery();
                MessageBox.Show("您已成功完成注册");
            }
            
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void signup_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            log form1 = new log();
            form1.Show();
            this.Hide();
        }
    }
}
