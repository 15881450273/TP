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
using Pantherstu;
using Pather;

namespace Pather1
{
    public partial class log : Form
    {
        public log()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            signup form3 = new signup();
            form3.Show();
            this.Hide();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {

                if (checkBox2.Checked == true)
                {
                    SqlConnectionStringBuilder stu = new SqlConnectionStringBuilder();
                      stu.DataSource ="118.24.162.142";
                    stu.UserID = "sa";
                    stu.Password = "123";
                    stu.InitialCatalog = "SIGNIN";
                    SqlConnection conn1 = new SqlConnection(stu.ToString());
                    if (conn1.State == ConnectionState.Closed)
                        conn1.Open();
                    usernumber.sno = textBox1.Text; //select COUNT(*) from 表名 where 条件语句
                    string code = textBox2.Text;
                    string sqlstr = "select COUNT(*) as number from usertable where username = '" + usernumber.sno + "' and userpassword='"+code+"'";
                    SqlCommand comm = new SqlCommand(sqlstr, conn1);
                    SqlDataReader sdr = comm.ExecuteReader();
                    sdr.Read();
                    if (sdr["number"].ToString() == "1")
                    {
                        sdr.Close();
                        string sqlstr1 = "select sname from student where sno = '" + usernumber.sno + "' ";
                        SqlCommand comm1 = new SqlCommand(sqlstr1, conn1);
                        SqlDataReader sdr1 = comm1.ExecuteReader();
                        sdr1.Read();
                        try
                        {
                            string sname = sdr1["sname"].ToString();
                            Pantherstu.stumenu stumenu = new Pantherstu.stumenu();
                            stumenu.Text = "" + usernumber.sno + "/" + sname + "";
                            stumenu.Show();
                            this.Hide();
                            conn1.Close();
                        }
                        catch (System.InvalidOperationException) { MessageBox.Show("请检查您的账号密码输入是否正确"); };
                    }
                    else
                    {
                        MessageBox.Show("用户名或密码错误");
                        conn1.Close();
                    }
                }
             
                
            }
            if (checkBox1.Checked)
            {
                SqlConnectionStringBuilder stu = new SqlConnectionStringBuilder();
                 stu.DataSource ="118.24.162.142";
                stu.UserID = "sa";
                stu.Password = "123";
                stu.InitialCatalog = "SIGNIN";
                SqlConnection conn1 = new SqlConnection(stu.ToString());
                if (conn1.State == ConnectionState.Closed)
                    conn1.Open();
                usernum.tno = textBox1.Text; //select COUNT(*) from 表名 where 条件语句
                string code = textBox2.Text;
                string sqlstr = "select COUNT(*) as number from usertable where username = '" + usernum.tno + "' and userpassword='"+code+"'";
                SqlCommand comm = new SqlCommand(sqlstr, conn1);
                SqlDataReader sdr = comm.ExecuteReader();
                sdr.Read();
                if (sdr["number"].ToString() == "1")
                {
                    sdr.Close();
                    string sqlstr1 = "select tname from teacher where TNO = '" + usernum.tno + "' ";
                    SqlCommand comm1 = new SqlCommand(sqlstr1, conn1);
                    SqlDataReader sdr1 = comm1.ExecuteReader();
                    sdr1.Read();
                    try
                    {
                        string tname = sdr1["TNAME"].ToString();
                        Pather.teamenu teamenu = new Pather.teamenu();
                        teamenu.Show();
                        this.Hide();
                        teamenu.Text = "" + usernum.tno + "/" + tname + "";
                        teamenu.Show();
                        conn1.Close();
                    }
                    catch (System.InvalidOperationException) { MessageBox.Show("请检查您的账号密码输入是否正确"); };
                }
                else
                    MessageBox.Show("用户名或密码错误");
            }

            
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                checkBox1.Checked = false;
                checkBox2.Checked = true;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

            if (checkBox1.Checked)
            {
                checkBox2.Checked = false;
                checkBox1.Checked = true;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
           
        }
    }
   

}
