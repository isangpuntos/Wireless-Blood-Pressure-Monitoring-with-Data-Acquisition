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
    public partial class Form3 : Form
    {
        string picturePath = "";
        public static string pID, pName, pAddress, pGender, pContact, pBday, pLastUpdate;


        private string GenerateString() 
        { 
            Random rnd = new Random(); 
            List<char> availableNumbers = new List<char> { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' }; 
            Dictionary<char, int> counts = new Dictionary<char, int>(); 
            for (int i = 0; i < 10; i++) 
            { 
                counts.Add(availableNumbers[i], 0); 
            } 
            char[] generatedCharacters = new char[10]; 
            
            for (int i = 0; i < generatedCharacters.Length; i++) 
            { char digit = availableNumbers[rnd.Next(availableNumbers.Count)]; 
                generatedCharacters[i] = digit; 
                counts[digit]++; 
                if (counts[digit] == 3)               
                    availableNumbers.Remove(digit); 
            } 
            return new string(generatedCharacters); 
        } 
        
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            timer1.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            a: ;
                int p = 0;
                string patientID = GenerateString();
                string source = "SELECT * from Profile";
                string gender = "";
                if (radioButton1.Checked == true)
                    gender = radioButton1.Text;
                else if (radioButton2.Checked == true)
                    gender = radioButton2.Text;
                OleDbConnection cn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source = "+ "C:\\Patient\'s Record.accdb");
                cn.Open();
                OleDbCommand cmd = new OleDbCommand(source, cn);
                OleDbDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    if (patientID == reader.GetValue(0).ToString())
                    {
                        p = 1;
                        break;
                    }
                }
                reader.Close();
                cn.Close();

                if (p == 1)
                {
                    goto a;
                }

                else
                {
                    pID = patientID;
                    pName = textBox1.Text;
                    pBday = maskedTextBox2.Text;
                    pLastUpdate = DateTime.Today.ToShortDateString();
                    pAddress = textBox2.Text;
                    pContact = textBox3.Text;
                    pGender = gender;
                    NewRegisteredProfileViewer NRPV = new NewRegisteredProfileViewer();
                    NRPV.ShowDialog();
                    source = "insert into Profile ([PatientID],[PatientName],[BirthDate],[RecordLastUpdate],[Address],[ContactNo],[Gender]) values('" + patientID + "','" + textBox1.Text + "','" + maskedTextBox2.Text + "','" + DateTime.Today.ToShortDateString() + "','" + textBox2.Text + "','" + textBox3.Text + "','" + gender + "')";
                    cn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source="+ "C:\\Patient\'s Record.accdb");
                    cmd = new OleDbCommand(source, cn);
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    cn.Close();
                    this.Close();
                }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime dateValue;

            if (textBox1.Text != "" && textBox2.Text != "" && (DateTime.TryParse(maskedTextBox2.Text, out dateValue)) && textBox3.Text.Length>5 && textBox3.Text.Length<12 && (radioButton1.Checked == true || radioButton2.Checked == true) && !(picturePath == String.Empty) )
                button1.Enabled = true;
            else
                button1.Enabled = false;
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Bitmap (*.bmp)|*.bmp|JPEG (*.jpg)|*.jpg|GIF (*.gif)|*.gif";
            dialog.InitialDirectory = "C:";
            dialog.Title = "Select an image file";
            if (dialog.ShowDialog() == DialogResult.OK)
                picturePath = dialog.FileName;
            if (picturePath == String.Empty)
                return;
        }

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }
    }
}
