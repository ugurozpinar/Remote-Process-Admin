using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BilDestekAdmin
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Kaydet
            DB dbb = new DB(textBox6.Text, textBox7.Text, textBox8.Text, textBox9.Text);
            try
            {
                int keep = checkBox1.Checked ? 1 : 0;
                dbb.AddTask(textBox5.Text, textBox4.Text, Convert.ToInt32(numericUpDown1.Value), textBox1.Text,keep);

                //public int AddTask(String process,String param1,int delay,String msg)
            }
            catch (Exception ex)
            {
                //throw;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Mesaj Gonder
        }
    }
}
