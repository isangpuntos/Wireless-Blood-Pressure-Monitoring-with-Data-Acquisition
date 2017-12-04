using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.Threading;

namespace WindowsFormsApplication1
{
    public partial class PortSelectionForm : Form
    {
        public PortSelectionForm()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            listBox1.Items.AddRange( SerialPort.GetPortNames());
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                MainForm.comPort = listBox1.SelectedItem.ToString();
                serialPort1.Close();
                this.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Please select an appropriate COM port!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                serialPort1.Close();
                serialPort1.PortName = listBox1.SelectedItem.ToString();
                serialPort1.Open();
                Thread.Sleep(1000);
                serialPort1.Write("c");
            }
            catch (Exception)
            {
                MessageBox.Show("Please choose an appropriate COM port!");
            }
        }

        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
           
        }
    }
}
