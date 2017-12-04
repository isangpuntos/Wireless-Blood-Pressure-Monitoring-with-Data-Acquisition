using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Threading;
using System.Diagnostics;

namespace WindowsFormsApplication1
{
    public partial class LoginForm : Form
    {
        int q = 0;
        public static string patientID = "";

        public LoginForm()
        {
            if (MainForm.alreadyLog == 0)
            {
                Process.Start(@"Splashscreen.exe");
                Thread.Sleep(6800);
            }
                InitializeComponent();
        }


        private void LoginForm_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            timer1.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int p = 0;
                string source = "SELECT [PatientID] from Profile where [PatientID] = '" + textBox1.Text + "'";
                OleDbConnection cn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + "C:\\Patient\'s Record.accdb");
                cn.Open();
                OleDbCommand cmd = new OleDbCommand(source, cn);
                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    patientID = reader.GetValue(0).ToString();
                    if (patientID == textBox1.Text)
                    {
                        p = 1;
                    }
                }
                reader.Close();
                cn.Close();
                if (p == 1)
                {
                    q = 1;
                    this.Close();
                }
                else
                    MessageBox.Show("Input ID Number does not exist!");
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid operation has been detected!");
                Application.Exit();
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form3 form3 = new Form3();
            form3.ShowDialog();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 10)
                button1.Enabled = true;
            else
                button1.Enabled = false;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            MainForm.patientID = patientID;
            if(q != 1)
             Application.Exit();
        }

        private void LoginForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainForm.patientID = patientID;
            if (q != 1)
              Application.Exit();
        }

    }
}
