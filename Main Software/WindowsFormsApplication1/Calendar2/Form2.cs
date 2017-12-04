using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            calendar1.SetViewMode(MonthCalendar.ViewMode.vmYear, MonthCalendar.ViewMode.vmMonth);
        }

        private void calendar1_Click(object sender, EventArgs e)
        {
           textBox1.Text = (MonthCalendar.Calendar.monthVal+1).ToString();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {
        }

    }
}
