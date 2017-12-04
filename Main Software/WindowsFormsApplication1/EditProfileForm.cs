using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
namespace WindowsFormsApplication1
{
    public partial class EditProfileForm : Form
    {
        public EditProfileForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string gender;
                if (radioButton1.Checked == true)
                    gender = "Male";
                else
                    gender = "Female";
                string source = "UPDATE Profile SET PatientName ='" + PatientNameBox.Text + "',Birthdate='" + BirthdateBox.Text + "',RecordLastUpdate='" + DateTime.Today.ToString("MM/dd/yyyy") + "',Address='" + AddressBox.Text + "',ContactNo='" + ContactNoBox.Text + "',Gender='" + gender + "' WHERE PatientID = '" + MainForm.patientID + "'";
                OleDbConnection cn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + "C:\\Patient\'s Record.accdb");
                OleDbCommand cmd = new OleDbCommand(source, cn);
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                this.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid operation has been detected!");
                Application.Exit();
            }
        
        }

        private void EditProfileForm_Load(object sender, EventArgs e)
        {
            try
            {
                timer1.Enabled = true;
                timer1.Start();
                string source = "SELECT * from Profile where [PatientID] = '" + MainForm.patientID + "'";
                OleDbConnection cn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + "C:\\Patient\'s Record.accdb");
                cn.Open();
                OleDbCommand cmd = new OleDbCommand(source, cn);
                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (MainForm.patientID == reader.GetValue(0).ToString())
                    {
                        PatientIDBox.Text = reader.GetValue(0).ToString();
                        PatientNameBox.Text = reader.GetValue(1).ToString();
                        BirthdateBox.Text = reader.GetValue(2).ToString();
                        AddressBox.Text = reader.GetValue(4).ToString();
                        ContactNoBox.Text = reader.GetValue(6).ToString();
                        if (reader.GetValue(5).ToString() == "Male")
                            radioButton1.Checked = true;
                        else
                            radioButton2.Checked = true;

                        break;
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid operation has been detected!");
                Application.Exit();
            }
        
        
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime dateValue;

            if (AddressBox.Text != "" && PatientIDBox.Text != "" && PatientNameBox.Text != "" && (DateTime.TryParse(BirthdateBox.Text, out dateValue)) && ContactNoBox.Text.Length > 5 && ContactNoBox.Text.Length < 12 && (radioButton1.Checked == true || radioButton2.Checked == true))// && !(picturePath == String.Empty))
                button1.Enabled = true;
            else
                button1.Enabled = false;
        }
    }
}
