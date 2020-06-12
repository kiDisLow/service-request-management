using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AnyStore.DAL;
using AnyStore.BLL;

namespace AnyStore.UI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        queryDAL qd = new queryDAL();
        private void Form1_Load(object sender, EventArgs e)
        {
    
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            DateTime startdate = dateTimePicker1.Value;
            DateTime enddate = dateTimePicker2.Value;
            string company = "*";
            string user = "*";
            if (comboBox1.Text != "")
            {  company = comboBox1.Text; }
           if (comboBox2.Text != "")
             user = comboBox2.Text;
            dataGridView1.DataSource = qd.Select(startdate,enddate,user,company);
            dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string company = "*";
            string user = "*";
            if (comboBox1.Text != "")
            { company = comboBox1.Text; }
            if (comboBox2.Text != "")
                user = comboBox2.Text;
            dataGridView1.DataSource = qd.Select(user, company);
            dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }
    }
}
