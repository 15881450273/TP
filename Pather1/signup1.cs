using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pather1
{
    public partial class signup1 : Form
    {
        public signup1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            log form1 = new log();
            form1.Show();
            this.Hide();
        }
    }
}
