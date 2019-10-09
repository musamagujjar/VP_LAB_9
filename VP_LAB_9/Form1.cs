using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VP_LAB_9
{
    public partial class Form1 : Form
    {
        DataTable dtall = new DataTable();
        DataTable dtselected = new DataTable();
        public Form1()
        {
            InitializeComponent();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dtall.Columns.Add("Rollno", typeof(int));
            dtall.Columns.Add("Name");
            dtall.Columns.Add("Contact");
            dtall.Columns.Add("Location");
            dtall.Rows.Add(1, "ali", "03000000000", "khanapull");
            dtall.Rows.Add(2, "aliya", "03111111111", "lahore");
            dtall.Rows.Add(3, "fizza", "03222222200", "karachi");
            dtall.Rows.Add(4, "Awais", "030000222", "islambad");
            dtall.Rows.Add(5, "Arsalan", "0344440", "khashmir");
            dtall.Rows.Add(6, "Hussain", "0355550", "multan");

            dtselected.Columns.Add("Rollno", typeof(int));
            dtselected.Columns.Add("Name");
            dtselected.Columns.Add("Contact");
            dtselected.Columns.Add("Location");


            listBox1.DataSource = dtall;
            listBox1.DisplayMember = "Name";
            listBox2.DataSource = dtselected;
            listBox2.DisplayMember = "Name";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count != 0)
            {
                dtselected.ImportRow(dtall.Rows[listBox1.SelectedIndex]);
                dtall.Rows[listBox1.SelectedIndex].Delete();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox2.Items.Count != 0)
            {
                dtall.ImportRow(dtselected.Rows[listBox2.SelectedIndex]);
                dtselected.Rows[listBox2.SelectedIndex].Delete();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            while (listBox1.Items.Count != 0)
            {
                dtselected.ImportRow(dtall.Rows[0]);
                dtall.Rows[0].Delete();

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            {
               var a= MessageBox.Show("Are u sure this is the final list", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (a==DialogResult.Yes)
                {
                    dataGridView1.DataSource = dtselected;
                    button1.Enabled = false;
                    button2.Enabled = false;
                    button3.Enabled = false;
                    button4.Enabled = false;
                }
            }
        }
    }
}
