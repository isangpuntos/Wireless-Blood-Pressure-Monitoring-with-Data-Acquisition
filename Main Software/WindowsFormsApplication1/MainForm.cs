using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using System.Data.OleDb;
using System.Windows.Forms.DataVisualization.Charting;
using System.Collections;
using System.Text.RegularExpressions;
using System.Globalization;
using System.IO;
using System.Threading;

namespace WindowsFormsApplication1
{
    public partial class MainForm : Form
    {
        public static string patientID;
        private static string prevMode = "";
        public static string serialSystolic = "";
        public static string serialDiastolic = "";
        public static string CRDate30min = "";
        public static string CRTime30min = "";
        public static string status = "";
        private static string lastSys = "";
        private static string lastDias = "";
        private static string lastDateTime = "";
        public static double alreadyLog = 0;
        public static string comPort;
        public static string cSelected = "";
        public static int option;
        private static int delCount = -1;
        private static int count = -1; 
        private static int eCount = -1;
        private static int ccount = 0;
        public static string graphVal = "";
        public static string time;
        public static string date;
        public static string comments;
        public static bool checkConnection = false;
        NewReadingForm form4;

        ArrayList eventIndicator = new ArrayList();
        ArrayList dateList = new ArrayList();
        ArrayList timeList = new ArrayList();

        ArrayList urSystolic = new ArrayList();
        ArrayList urDiastolic = new ArrayList();
        ArrayList urStatus = new ArrayList();

        ArrayList delDateList = new ArrayList();
        ArrayList delTimeList = new ArrayList();

        ArrayList delStatus = new ArrayList();
        ArrayList delSystolic = new ArrayList();
        ArrayList delDiastolic = new ArrayList();

        string intervalChoice;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
            PatientIDBox.ReadOnly = true;
            PatientNameBox.ReadOnly = true;
            BirthdateBox.ReadOnly = true;
            GenderBox.ReadOnly = true;
            ContactNoBox.ReadOnly = true;
            AddressBox.ReadOnly = true;
            LastUpdateBox.ReadOnly = true;

            calendar1.SelectedDate = DateTime.Now;
            intervalChoice = "30mins";
            if (chart1.Series.Count == 1)
            {
                chart1.Series["Series1"].Name = "Systolic";
                chart1.Series.Add("Diastolic");

                chart1.Series.Add("Systolic2");
                chart1.Series.Add("Diastolic2");
            }
            if (alreadyLog == 0)
            {
                LoginForm login = new LoginForm();

                login.ShowDialog();
            }
            PortSelectionForm form5 = new PortSelectionForm();
            form5.ShowDialog();
            if (serialPort1.IsOpen)
                serialPort1.Close();
            serialPort1.PortName = comPort;
            serialPort1.Open();
            if (!checkConnection)
                MessageBox.Show("WARNING: The console has not been yet detected!");
            alreadyLog = 1;
            string source = "SELECT * from Profile where [PatientID] = '" + patientID + "'";
            OleDbConnection cn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source="+ "C:\\Patient\'s Record.accdb");
            cn.Open();
            OleDbCommand cmd = new OleDbCommand(source, cn);
            OleDbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                if (patientID == reader.GetValue(0).ToString())
                {
                    PatientIDBox.Text = reader.GetValue(0).ToString();
                    PatientNameBox.Text = reader.GetValue(1).ToString();
                    BirthdateBox.Text = reader.GetValue(2).ToString();
                    LastUpdateBox.Text = reader.GetValue(3).ToString();
                    AddressBox.Text = reader.GetValue(4).ToString();
                    ContactNoBox.Text = reader.GetValue(6).ToString();
                    GenderBox.Text = reader.GetValue(5).ToString();
                    pictureBox1.ImageLocation = reader.GetValue(7).ToString();
                   try
                   {
                        pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
                        pictureBox1.Load();
                   }
                    catch(Exception)
                   {
                    pictureBox1.Enabled=false;
                   }
                    break;
                }
            }
            reader.Close();
            cn.Close();
            calendar1.OnlyMonthMode = true;
            show30MinuteChart();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show("Invalid operation has been detected!");
                Application.Exit();
            }
        }

        private void ribbonBar5_ItemClick(object sender, EventArgs e)
        {

        }

        private void ribbonControl1_Click(object sender, EventArgs e)
        {

        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            serialPort1.Close();
            PortSelectionForm form5 = new PortSelectionForm();
            form5.ShowDialog();
            serialPort1.PortName = comPort;
            serialPort1.Open();
            checkConnection = false;
        }

        private void buttonX6_Click(object sender, EventArgs e)
        {
            cSelected = calendar1.SelectedDate.ToShortDateString();
            CrystalReportViewer CRV = new CrystalReportViewer();
            CRV.ShowDialog();
        }

        private void buttonX5_Click(object sender, EventArgs e)
        {

        }

        private void buttonItem75_Click(object sender, EventArgs e)
        {
            calendar1.OnlyMonthMode = true;
            intervalChoice = "1day";
            calendar1.SetViewMode(MonthCalendar.ViewMode.vmMonth, MonthCalendar.ViewMode.vmYear);
            calendar1.SetViewMode(MonthCalendar.ViewMode.vmMonth, MonthCalendar.ViewMode.vm12Years);
            calendar1.SetViewMode(MonthCalendar.ViewMode.vmMonth, MonthCalendar.ViewMode.vm120Years);
        }

        private void buttonItem30_Click(object sender, EventArgs e)
        {

        }

        private void buttonItem204_Click(object sender, EventArgs e)
        {
            calendar1.SetViewMode(MonthCalendar.ViewMode.vmMonth, MonthCalendar.ViewMode.vmYear);
            calendar1.SetViewMode(MonthCalendar.ViewMode.vmMonth, MonthCalendar.ViewMode.vm12Years);
            calendar1.SetViewMode(MonthCalendar.ViewMode.vmMonth, MonthCalendar.ViewMode.vm120Years);
            calendar1.OnlyMonthMode = true;
            intervalChoice = "30mins";
            show30MinuteChart();
        }

        private void buttonItem205_Click(object sender, EventArgs e)
        {
            calendar1.SetViewMode(MonthCalendar.ViewMode.vmMonth, MonthCalendar.ViewMode.vmYear);
            calendar1.SetViewMode(MonthCalendar.ViewMode.vmMonth, MonthCalendar.ViewMode.vm12Years);
            calendar1.SetViewMode(MonthCalendar.ViewMode.vmMonth, MonthCalendar.ViewMode.vm120Years);
            calendar1.OnlyMonthMode = true;
            show1hrChart();
        }

        private void buttonItem206_Click(object sender, EventArgs e)
        {
            calendar1.OnlyMonthMode = false;
            intervalChoice = "1month";
            calendar1.SetViewMode(MonthCalendar.ViewMode.vmYear, MonthCalendar.ViewMode.vmYear);
            calendar1.SetViewMode(MonthCalendar.ViewMode.vmYear, MonthCalendar.ViewMode.vm12Years);
            calendar1.SetViewMode(MonthCalendar.ViewMode.vmYear, MonthCalendar.ViewMode.vm120Years);
            
            showMonthlyChart();
            
        }

        private void buttonItem207_Click(object sender, EventArgs e)
        {
            calendar1.OnlyMonthMode = false;
            intervalChoice = "1year";
            prevMode = intervalChoice;
            calendar1.SetViewMode(MonthCalendar.ViewMode.vm12Years, MonthCalendar.ViewMode.vmYear);
            calendar1.SetViewMode(MonthCalendar.ViewMode.vm12Years, MonthCalendar.ViewMode.vm12Years);
            calendar1.SetViewMode(MonthCalendar.ViewMode.vm12Years, MonthCalendar.ViewMode.vm120Years);
            showYearlyChart(calendar1.year1,calendar1.year12);
        }

        private void buttonItem208_Click(object sender, EventArgs e)
        {
            calendar1.OnlyMonthMode = false;
            intervalChoice = "12years";
            calendar1.SetViewMode(MonthCalendar.ViewMode.vm120Years, MonthCalendar.ViewMode.vmYear);
            calendar1.SetViewMode(MonthCalendar.ViewMode.vm120Years, MonthCalendar.ViewMode.vm12Years);
            calendar1.SetViewMode(MonthCalendar.ViewMode.vm120Years, MonthCalendar.ViewMode.vm120Years);
        }  

        private void calendar1_SelectDay(object sender, MonthCalendar.SelectDayEventArgs e)
        {
            MethodInvoker setAll = delegate
            {
                if (intervalChoice == "30mins")
                {
                    show30MinuteChart();
                   
                }
                else if (intervalChoice == "1hour")
                {
                    show1hrChart();
                }

                else if (intervalChoice == "1month")
                {
                    showMonthlyChart();
                }
            };

            if (listView1.InvokeRequired)
            {
                listView1.Invoke(setAll);
            }

            else
            {
                setAll();
            }
           
        }

        private void calendar1_Click(object sender, EventArgs e)
        {
            
        }

        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e) 
        {
            bool opened = false;
            string readPort;
            if (alreadyLog == 1)
            {
                readPort = serialPort1.ReadExisting(); 
                
                if (readPort.Contains("c"))
                {
                    serialPort1.Write("c");
                    MessageBox.Show("Connection to console has been established!");
                    readPort = "";
                    checkConnection = true;
                }
                if (checkConnection == true)
                {
                    foreach (Form a in Application.OpenForms)
                    {
                        if (a is NewReadingForm)
                            opened = true;
                    }
                   
                    if (ccount == 0 && readPort.Contains("s"))
                    {
                        if (opened == false)
                        {
                            serialPort1.Close();
                            form4 = new NewReadingForm();
                            form4.ShowDialog();
                            serialPort1.Open();
                        }
                        ccount++;
                    }
                    try
                    {
                       while(opened) 
                        foreach (Form a in Application.OpenForms)
                        {
                            if (a is NewReadingForm)
                            {
                                opened = true;
                                break;
                            }
                            else
                                opened = false;
                        }
                        if (ccount == 1)
                        {
                            if (serialSystolic != null && serialDiastolic != null)
                            {
                                serialPort1.Close();
                                serialPort1.Open();
                                opened = false;
                                ccount = 0;

                                serialSystolic = NonNumericString(serialSystolic);
                                serialDiastolic = NonNumericString(serialDiastolic);
                                string source = "INSERT INTO Record (PatientID, Systolic, Diastolic, CDate, CTime,Status,Comments) VALUES('" + patientID + "'," + Convert.ToInt32(serialSystolic) + "," + Convert.ToInt32(serialDiastolic) + ",#" + DateTime.Parse(date) + "#,'" + time + "','" + status + "','" + comments + "') ";
                                OleDbConnection cn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + "C:\\Patient\'s Record.accdb");
                                OleDbCommand cmd = new OleDbCommand(source, cn);
                                cn.Open();
                                cmd.ExecuteNonQuery();
                                cn.Close();

                                timeList.Add(time);
                                dateList.Add(date);
                                urSystolic.Add(serialSystolic);
                                urDiastolic.Add(serialDiastolic);
                                urStatus.Add(status);
                                show30MinuteChart();
                                eventIndicator.Add("add");
                                eCount++;
                                serialDiastolic = null;
                                serialSystolic = null;
                                status = null;
                                comments = null;
                            }
                            else
                                MessageBox.Show("Invalid reading has been received!\nPlease check the connections");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }

            }
          
        }
       
        private void calendar1_NClick(object sender, EventArgs e)
        {
            calendar1.year1 = calendar1.year1 + 1;
            calendar1.year12 = calendar1.year12 + 1;
            if (intervalChoice == "1month")
                showMonthlyChart();
            else if (intervalChoice == "1year")
                showYearlyChart(calendar1.year1 + 1, calendar1.year12 + 1);

        }

        private void calendar1_PClick(object sender, EventArgs e)
        {

            calendar1.year1 = calendar1.year1 - 1;
            calendar1.year12 = calendar1.year12 - 1;
            if (intervalChoice == "1month")
                showMonthlyChart();
            if (intervalChoice == "1year")
                showYearlyChart(calendar1.year1, calendar1.year12);
        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            try
            {
                if (eCount > -1)
                {
                    if (eventIndicator[eCount].ToString() == "add")
                    {
                        if (count > -1)
                        {
                            string source = "DELETE FROM Record WHERE CDate = # " + DateTime.Parse(dateList[count].ToString()) + "# and CTime = '" + timeList[count].ToString() + "'";
                            OleDbConnection cn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source="+ "C:\\Patient\'s Record.accdb");
                            OleDbCommand cmd = new OleDbCommand(source, cn);
                            cn.Open();
                            cmd.ExecuteNonQuery();
                            cn.Close();
                            count--;
                            eCount--;
                            show30MinuteChart();
                        }
                    }
                    else if (eventIndicator[eCount].ToString() == "delete")
                    {
                        if (delCount > -1)
                        {
                            string source = "INSERT INTO Record (PatientID, Systolic, Diastolic, CDate, CTime,Status) VALUES('" + patientID + "'," + Convert.ToInt32(delSystolic[delCount].ToString()) + "," + Convert.ToInt32(delDiastolic[delCount].ToString()) + ",#" + DateTime.Parse(delDateList[delCount].ToString()) + "#," + delTimeList[delCount].ToString() + ",'" + delStatus[delCount].ToString() + "') ";
                            OleDbConnection cn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source="+ "C:\\Patient\'s Record.accdb");
                            OleDbCommand cmd = new OleDbCommand(source, cn);
                            cn.Open();
                            cmd.ExecuteNonQuery();
                            cn.Close();
                            eCount--;
                            delCount--;
                            show30MinuteChart();
                        }
                    }
                }
                else
                    MessageBox.Show("Nothing to undo");
            }
            catch (Exception)
            {
                MessageBox.Show("Nothing to undo");
            }
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
           try{
            EditProfileForm epf = new EditProfileForm();
            epf.ShowDialog();
            string source = "SELECT * from Profile where [PatientID] = '" + MainForm.patientID + "'";
            OleDbConnection cn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source="+ "C:\\Patient\'s Record.accdb");
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
                    GenderBox.Text = reader.GetValue(5).ToString();
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

        private void listView1_MouseUp(object sender, MouseEventArgs e)
        {
            if (intervalChoice == "30mins")
            {
                switch (e.Button)
                {
                    case MouseButtons.Right:
                        ContextMenu myContextMenu = new ContextMenu();
                        MenuItem menuItem1 = new MenuItem("Delete");
                        myContextMenu.MenuItems.Clear();
                        myContextMenu.MenuItems.Add(menuItem1);
                        if (listView1.SelectedItems.Count > 0)
                        {
                            foreach (ListViewItem item in listView1.SelectedItems)
                            {
                                myContextMenu.MenuItems[0].Visible = true;
                            }
                        }

                        else
                        {
                            myContextMenu.MenuItems[0].Visible = false;
                        }
                        myContextMenu.Show(listView1, e.Location, LeftRightAlignment.Right);
                        menuItem1.Click += new System.EventHandler(this.menuItem1_Click);
                        break;
                }
            }
        }

        private void menuItem1_Click(object sender, System.EventArgs e)
        {
            try
            {
                delDateList.Add(calendar1.SelectedDate);
                delTimeList.Add(listView1.Items[Convert.ToInt32(listView1.SelectedIndices[0].ToString())].SubItems[2].ToString().Replace("ListViewSubItem: {", "'").Replace("}", "'"));
                delSystolic.Add(listView1.Items[Convert.ToInt32(listView1.SelectedIndices[0].ToString())].SubItems[0].ToString().Replace("ListViewSubItem: {", "").Replace("}", ""));
                delDiastolic.Add(listView1.Items[Convert.ToInt32(listView1.SelectedIndices[0].ToString())].SubItems[1].ToString().Replace("ListViewSubItem: {", "").Replace("}", ""));
                delStatus.Add(listView1.Items[Convert.ToInt32(listView1.SelectedIndices[0].ToString())].SubItems[3].ToString().Replace("ListViewSubItem: {", "").Replace("}", ""));
                delCount++;
                string source = "DELETE * FROM Record WHERE CDate = #" + calendar1.SelectedDate + "# and CTime = " + listView1.Items[Convert.ToInt32(listView1.SelectedIndices[0].ToString())].SubItems[2].ToString().Replace("ListViewSubItem: {", "'").Replace("}", "'");
                OleDbConnection cn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + "C:\\Patient\'s Record.accdb");
                OleDbCommand cmd = new OleDbCommand(source, cn);
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                show30MinuteChart();
                eventIndicator.Add("delete");
                eCount++;
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid operation has been detected!");
                Application.Exit();
            }
        
        }

        private void buttonX4_Click(object sender, EventArgs e)
        {

            try
            {
                if (eventIndicator.Count > 0 && eCount < eventIndicator.Count - 1)
                {
                    if (eventIndicator[eCount + 1].ToString() == "add")
                    {
                        if (count + 1 > -1 && count != urSystolic.Count - 1)
                        {
                            string source = "INSERT INTO Record (PatientID, Systolic, Diastolic, CDate, CTime,Status) VALUES('" + patientID + "'," + Convert.ToInt32(urSystolic[count + 1].ToString()) + "," + Convert.ToInt32(urDiastolic[count + 1].ToString()) + ",#" + DateTime.Parse(dateList[count + 1].ToString()) + "#," + timeList[count + 1].ToString() + ",'" + urStatus[count + 1].ToString() + "') ";
                            OleDbConnection cn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source="+ "C:\\Patient\'s Record.accdb");
                            OleDbCommand cmd = new OleDbCommand(source, cn);
                            cn.Open();
                            cmd.ExecuteNonQuery();
                            cn.Close();
                            count++;
                            eCount++;
                            show30MinuteChart();
                        }
                    }
                    else if (eventIndicator[eCount + 1].ToString() == "delete")
                    {
                        if (delCount + 1 > -1 && delCount != delSystolic.Count - 1)
                        {
                            string source = "DELETE FROM Record WHERE CDate = # " + DateTime.Parse(delDateList[delCount + 1].ToString()) + "# and CTime = " + delTimeList[delCount + 1].ToString() + "";
                            OleDbConnection cn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source="+ "C:\\Patient\'s Record.accdb");
                            OleDbCommand cmd = new OleDbCommand(source, cn);
                            cn.Open();
                            cmd.ExecuteNonQuery();
                            cn.Close();
                            eCount++;
                            delCount++;
                            show30MinuteChart();
                        }
                    }
                }
                else
                    MessageBox.Show("Nothing to redo");
            }
            catch (Exception)
            {
                MessageBox.Show("Nothing to redo");
            }
        }

        private void buttonX7_Click(object sender, EventArgs e)
        {
            LoginForm login = new LoginForm();
            login.ShowDialog();
            MainForm_Load(sender, e);
        }

////////////////////////////////////////////////////////////////////////////////////////////////////////////

        void show30MinuteChart()
        {
            try
            {
            graphType();
            forListView();
            string listComments;
            MethodInvoker setAll = delegate
            {
            double Systolic = 0.0, Diastolic = 0.0;
            string CTime = "";
            chart1.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Minutes;
            chart1.ChartAreas[0].AxisX.LabelStyle.Format = "h:mm tt";
            chart1.ChartAreas[0].AxisX.Minimum = Double.NaN;
            chart1.ChartAreas[0].AxisX.Maximum = Double.NaN;
            chart1.Series[0].IsXValueIndexed = true;
            chart1.Series[1].IsXValueIndexed = true;
            chart1.Series[2].IsXValueIndexed = true; 
            chart1.Series[3].IsXValueIndexed = true;
            
            chart1.ChartAreas[0].AxisX.Interval = 0;
            chart1.ChartAreas[0].AxisX.ScrollBar.IsPositionedInside = true;
            chart1.ChartAreas[0].AxisX.ScrollBar.Size = 20;
            chart1.ChartAreas[0].AxisX.ScrollBar.Enabled = true;
            chart1.ChartAreas[0].AxisX.ScaleView.SizeType = DateTimeIntervalType.Minutes;
            chart1.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
            chart1.ChartAreas[0].AxisX.ScaleView.Size = 15;
            chart1.ChartAreas[0].AxisX.ScaleView.SmallScrollSizeType = DateTimeIntervalType.Minutes;
            chart1.ChartAreas[0].AxisX.ScaleView.SmallScrollSize = 1;

            CRDate30min = calendar1.SelectedDate.ToShortDateString();
            string source = "SELECT * from Record where [PatientID] = '" + patientID + "' and [CDate] = #" + calendar1.SelectedDate + "# ORDER BY CTime Asc";
            OleDbConnection cn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source="+ "C:\\Patient\'s Record.accdb");
            cn.Open();
            OleDbCommand cmd = new OleDbCommand(source, cn);
            OleDbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Systolic = Convert.ToDouble(reader.GetValue(1).ToString());
                Diastolic = Convert.ToDouble(reader.GetValue(2).ToString());
                CTime = reader.GetValue(4).ToString();
                status = reader.GetValue(5).ToString();
                listComments = reader.GetValue(6).ToString();

                ListViewItem item1 = new ListViewItem(Systolic.ToString());
                item1.SubItems.Add(Diastolic.ToString());
                item1.SubItems.Add(DateTime.Parse(CTime).ToLongTimeString());
                item1.SubItems.Add(status);
                item1.SubItems.Add(listComments);
                listView1.Items.AddRange(new ListViewItem[] { item1 });

                chart1.Series["Systolic"].Points.AddXY(DateTime.Parse(CTime), Systolic);
                chart1.Series["Diastolic"].Points.AddXY(DateTime.Parse(CTime), Diastolic);
                chart1.Series["Systolic2"].Points.AddXY(DateTime.Parse(CTime), Systolic);
                chart1.Series["Diastolic2"].Points.AddXY(DateTime.Parse(CTime), Diastolic);
            } 
            
             reader.Close();
             cn.Close();
             lastSys = Systolic.ToString();
             lastDias = Diastolic.ToString();
             lastDateTime = CTime;
            };

            if (listView1.InvokeRequired)
            {
                listView1.Invoke(setAll);
            }

            else
            {
                setAll();
            }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Invalid operation has been detected!" + ex.Message);
                Application.Exit();
            }
        
        }

        void show1hrChart()
        {
            try
            {
            double S_ave = 0.0, D_ave = 0.0;
            graphType();
            forListView();

            MethodInvoker setAll = delegate
            {
                ListViewItem item1;
                chart1.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Hours;
                chart1.ChartAreas[0].AxisX.IntervalOffsetType = DateTimeIntervalType.Hours;
                chart1.ChartAreas[0].AxisX.Minimum = new DateTime(calendar1.SelectedDate.Year, calendar1.SelectedDate.Month, calendar1.SelectedDate.Day, 0, 0, 0).ToOADate();
                chart1.ChartAreas[0].AxisX.Maximum = new DateTime(calendar1.SelectedDate.Year, calendar1.SelectedDate.Month, calendar1.SelectedDate.Day, 23, 0, 0).ToOADate();
                chart1.ChartAreas[0].AxisX.Interval = 1;
                chart1.ChartAreas[0].AxisX.LabelStyle.Format = "h:mm tt";

                chart1.ChartAreas[0].AxisX.ScrollBar.IsPositionedInside = false;
                chart1.ChartAreas[0].AxisX.ScrollBar.Size = 14;
                chart1.ChartAreas[0].AxisX.ScrollBar.Enabled = false;
                chart1.ChartAreas[0].AxisX.ScaleView.Zoomable = false;
                chart1.ChartAreas[0].AxisX.ScaleView.Size = Double.NaN;

                chart1.Series[0].IsXValueIndexed = false;
                chart1.Series[1].IsXValueIndexed = false;
                chart1.Series[2].IsXValueIndexed = false;
                chart1.Series[3].IsXValueIndexed = false;
                string source = source = "SELECT Sys, Dias, Hour, CDate, Stat From HourTable Where PatientID ='" + MainForm.patientID + "' and CDate = #" + calendar1.SelectedDate + "#";
                OleDbConnection cn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source="+ "C:\\Patient\'s Record.accdb");
                cn.Open();
                OleDbCommand cmd = new OleDbCommand(source, cn);
                OleDbDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    S_ave = reader.GetDouble(0);
                    D_ave = reader.GetDouble(1);
                    if (S_ave > 139 && S_ave <= 159 || D_ave <= 99 && D_ave > 89)
                    {
                        status = "Stage1 Hypertension";
                    }
                    if (S_ave > 159 && S_ave <= 179 || D_ave > 99 && D_ave < 109)
                    {
                        status = "Stage1 Hypertension";
                    }
                    else if (S_ave > 179 && S_ave <= 209 || D_ave > 109 && D_ave <= 119)
                    {
                        status = "Stage3 Hypertension";
                    }
                    else if (S_ave < 91 || D_ave < 61)
                    {
                        status = "LowBlood";
                    }
                    else if (S_ave > 91 && S_ave <= 139 || D_ave > 70 && D_ave <= 139)
                    {
                        status = "Normal";
                    }

                    chart1.Series["Systolic"].XValueType = ChartValueType.Time;
                    chart1.Series["Diastolic"].XValueType = ChartValueType.Time;
                    chart1.Series["Systolic2"].XValueType = ChartValueType.Time;
                    chart1.Series["Diastolic2"].XValueType = ChartValueType.Time;

                    chart1.Series["Systolic"].Points.AddXY(DateTime.Parse(calendar1.SelectedDate.ToShortDateString()+ " " + reader.GetValue(2).ToString()).ToOADate(), S_ave);
                    chart1.Series["Diastolic"].Points.AddXY(DateTime.Parse(calendar1.SelectedDate.ToShortDateString() + " " + reader.GetValue(2).ToString()).ToOADate(), D_ave);

                    chart1.Series["Systolic2"].Points.AddXY(DateTime.Parse(calendar1.SelectedDate.ToShortDateString() + " " + reader.GetValue(2).ToString()).ToOADate(), S_ave);
                    chart1.Series["Diastolic2"].Points.AddXY(DateTime.Parse(calendar1.SelectedDate.ToShortDateString() + " " + reader.GetValue(2).ToString()).ToOADate(), D_ave);

                    item1 = new ListViewItem(S_ave.ToString());
                    item1.SubItems.Add(D_ave.ToString());
                    item1.SubItems.Add(DateTime.Parse(reader.GetValue(2).ToString()).ToShortTimeString());
                    item1.SubItems.Add(status);
                    listView1.Items.AddRange(new ListViewItem[] { item1 });
                }

                reader.Close();
                cn.Close();

            };

            if (listView1.InvokeRequired)
            {
                listView1.Invoke(setAll);
            }

            else
            {
                setAll();
            }
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid operation has been detected!");
                Application.Exit();
            }
          }

        void showMonthlyChart()
        {
            try
            {
            double S_ave = 0.0, D_ave = 0.0;
            DateTime month = new DateTime(2999, 12, 31);

            graphType();
            forListView();
           
                MethodInvoker setAll = delegate
                {
                        ListViewItem item1;
                        string source = "SELECT Sys, Dias, Month, Year, Stat From MonthTable Where PatientID ='" + MainForm.patientID + "' and Year = " + calendar1.SelectedDate.Year;
                        OleDbConnection cn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source="+ "C:\\Patient\'s Record.accdb");
                        cn.Open();
                        OleDbCommand cmd = new OleDbCommand(source, cn);
                        OleDbDataReader reader = cmd.ExecuteReader();

                        chart1.ChartAreas[0].AxisX.ScrollBar.IsPositionedInside = false;
                        chart1.ChartAreas[0].AxisX.ScrollBar.Size = 14;
                        chart1.ChartAreas[0].AxisX.ScrollBar.Enabled = false;
                        chart1.ChartAreas[0].AxisX.ScaleView.Zoomable = false;
                        chart1.ChartAreas[0].AxisX.ScaleView.Size = Double.NaN;

                        chart1.Series["Systolic"].XValueType = ChartValueType.DateTime;
                        chart1.Series["Diastolic"].XValueType = ChartValueType.DateTime;
                        chart1.Series["Systolic2"].XValueType = ChartValueType.DateTime;
                        chart1.Series["Diastolic2"].XValueType = ChartValueType.DateTime;

                        chart1.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Months;
                        chart1.ChartAreas[0].AxisX.Minimum = new DateTime(calendar1.SelectedDate.Year, 1, 1).ToOADate();
                        chart1.ChartAreas[0].AxisX.Maximum = new DateTime(calendar1.SelectedDate.Year, 12, 31).ToOADate();
                        chart1.ChartAreas[0].AxisX.Interval = 1;
                        chart1.ChartAreas[0].AxisX.LabelStyle.Format = "MMMM";

                        chart1.Series[0].IsXValueIndexed = false;
                        chart1.Series[1].IsXValueIndexed = false;
                        chart1.Series[2].IsXValueIndexed = false;
                        chart1.Series[3].IsXValueIndexed = false;

                        while (reader.Read())
                        {
                            S_ave = reader.GetDouble(0);
                            D_ave = reader.GetDouble(1);
                            if (S_ave > 139 && S_ave <= 159 || D_ave <= 99 && D_ave > 89)
                            {
                                status = "Stage1 Hypertension";
                            }
                            if (S_ave > 159 && S_ave <= 179 || D_ave > 99 && D_ave < 109)
                            {
                                status = "Stage1 Hypertension";
                            }
                            else if (S_ave > 179 && S_ave <= 209 || D_ave > 109 && D_ave <= 119)
                            {
                                status = "Stage3 Hypertension";
                            }
                            else if (S_ave < 91 || D_ave < 61)
                            {
                                status = "LowBlood";
                            }
                            else if (S_ave > 91 && S_ave <= 139 || D_ave > 70 && D_ave <= 139)
                            {
                                status = "Normal";
                            }

                            chart1.Series["Systolic"].Points.AddXY(DateTime.Parse(reader.GetValue(2).ToString() +","+ calendar1.SelectedDate.Year).ToOADate(), S_ave);
                            chart1.Series["Diastolic"].Points.AddXY(DateTime.Parse(reader.GetValue(2).ToString() + "," + calendar1.SelectedDate.Year).ToOADate(), D_ave);

                            chart1.Series["Systolic2"].Points.AddXY(DateTime.Parse(reader.GetValue(2).ToString() + "," + calendar1.SelectedDate.Year).ToOADate(), S_ave);
                            chart1.Series["Diastolic2"].Points.AddXY(DateTime.Parse(reader.GetValue(2).ToString() + "," + calendar1.SelectedDate.Year).ToOADate(), D_ave);

                            item1 = new ListViewItem(S_ave.ToString());
                            item1.SubItems.Add(D_ave.ToString());
                            item1.SubItems.Add(reader.GetValue(2).ToString());
                            item1.SubItems.Add(status);
                            listView1.Items.AddRange(new ListViewItem[] { item1 });
                        }

                };

                if (listView1.InvokeRequired)
                {
                    listView1.Invoke(setAll);
                }

                else
                {
                    setAll();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid operation has been detected!");
                Application.Exit();
            }
        
        }

        void showYearlyChart(int year1, int year12)
        {
            try
            {
            double S_ave = 0.0, D_ave = 0.0;
            DateTime year = new DateTime(2999, 12, 31);
            ListViewItem item1;

            graphType();
            forListView();

            chart1.Series["Systolic"].XValueType = ChartValueType.DateTime;
            chart1.Series["Diastolic"].XValueType = ChartValueType.DateTime;
            chart1.Series["Systolic2"].XValueType = ChartValueType.DateTime;
            chart1.Series["Diastolic2"].XValueType = ChartValueType.DateTime;

            chart1.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Years;
            chart1.ChartAreas[0].AxisX.Minimum = DateTime.ParseExact(calendar1.year1.ToString(), "yyyy", CultureInfo.CurrentCulture).AddYears(0).ToOADate();
            chart1.ChartAreas[0].AxisX.Maximum = DateTime.ParseExact(calendar1.year12.ToString(), "yyyy", CultureInfo.CurrentCulture).AddYears(0).ToOADate();
            chart1.ChartAreas[0].AxisX.Interval = 1;
            chart1.ChartAreas[0].AxisX.LabelStyle.Format = "yyyy";

            chart1.ChartAreas[0].AxisX.ScrollBar.IsPositionedInside = false;
            chart1.ChartAreas[0].AxisX.ScrollBar.Size = 14;
            chart1.ChartAreas[0].AxisX.ScrollBar.Enabled = false;
            chart1.ChartAreas[0].AxisX.ScaleView.Zoomable = false;
            chart1.ChartAreas[0].AxisX.ScaleView.Size = Double.NaN;
            
            chart1.Series[0].IsXValueIndexed = false;
            chart1.Series[1].IsXValueIndexed = false;
            chart1.Series[2].IsXValueIndexed = false;
            chart1.Series[3].IsXValueIndexed = false;
            
            string source = "SELECT Sys, Dias, Year, Stat From YearTable Where PatientID ='" + MainForm.patientID + "' and Year BETWEEN " + year1 + " and " + year12;
            OleDbConnection cn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source="+ "C:\\Patient\'s Record.accdb");
            cn.Open();
            OleDbCommand cmd = new OleDbCommand(source, cn);
            OleDbDataReader reader = cmd.ExecuteReader();


            while (reader.Read())
            {
                S_ave = reader.GetDouble(0);
                D_ave = reader.GetDouble(1);

                if (S_ave > 139 && S_ave <= 159 || D_ave <= 99 && D_ave > 89)
                {
                    status = "Stage1 Hypertension";
                }
                if (S_ave > 159 && S_ave <= 179 || D_ave > 99 && D_ave < 109)
                {
                    status = "Stage1 Hypertension";
                }
                else if (S_ave > 179 && S_ave <= 209 || D_ave > 109 && D_ave <= 119)
                {
                    status = "Stage3 Hypertension";
                }
                else if (S_ave < 91 || D_ave < 61)
                {
                    status = "LowBlood";
                }
                else if (S_ave > 91 && S_ave <= 139 || D_ave > 70 && D_ave <= 139)
                {
                    status = "Normal";
                }

                chart1.Series["Systolic"].Points.AddXY(DateTime.Parse("1/1/" + reader.GetValue(2).ToString()).ToOADate(), S_ave);
                chart1.Series["Diastolic"].Points.AddXY(DateTime.Parse("1/1/" + reader.GetValue(2).ToString()).ToOADate(), D_ave);

                chart1.Series["Systolic2"].Points.AddXY(DateTime.Parse("1/1/" + reader.GetValue(2).ToString()).ToOADate(), S_ave);
                chart1.Series["Diastolic2"].Points.AddXY(DateTime.Parse("1/1/" + reader.GetValue(2).ToString()).ToOADate(), D_ave);

                item1 = new ListViewItem(S_ave.ToString());
                item1.SubItems.Add(D_ave.ToString());
                item1.SubItems.Add(reader.GetValue(2).ToString());
                item1.SubItems.Add(status);
                listView1.Items.AddRange(new ListViewItem[] { item1 });
            }
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid operation has been detected!");
                Application.Exit();
            }
        
        }

        void graphType()
        {
            MethodInvoker setGraph = delegate
            {

                chart1.Series["Systolic"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                chart1.Series["Diastolic"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;

                chart1.Series["Systolic"].XValueType = ChartValueType.Time;
                chart1.Series["Diastolic"].XValueType = ChartValueType.Time;

                chart1.Series["Systolic2"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
                chart1.Series["Diastolic2"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;

                chart1.Series["Systolic2"].XValueType = ChartValueType.Time;
                chart1.Series["Diastolic2"].XValueType = ChartValueType.Time;

                chart1.Series["Systolic2"].IsVisibleInLegend = false;
                chart1.Series["Diastolic2"].IsVisibleInLegend = false;

                chart1.Series["Systolic"].Color = Color.Red;
                chart1.Series["Diastolic"].Color = Color.Blue;
                chart1.Series["Systolic2"].Color = Color.Red;
                chart1.Series["Diastolic2"].Color = Color.Blue;


                chart1.Series["Systolic"].Points.Clear();
                chart1.Series["Diastolic"].Points.Clear();
                chart1.Series["Systolic2"].Points.Clear();
                chart1.Series["Diastolic2"].Points.Clear();
            };

            if (chart1.InvokeRequired)
            {
                chart1.Invoke(setGraph);
            }

            else
            {
                setGraph();
            }
            
        }

        void forListView()
        {
            MethodInvoker setListView = delegate
            {
                listView1.Clear();
                listView1.View = View.Details;
                listView1.Columns.Add("Ave Sys", 70);
                listView1.Columns.Add("Ave Dia", 70);
                listView1.Columns.Add("Time/Date", 100);
                listView1.Columns.Add("Status", 120);
                listView1.Columns.Add("Comments", 200);
            };

            if (listView1.InvokeRequired)
            {
                listView1.Invoke(setListView);
            }

            else
            {
                setListView();
            }
        }

        private string NonNumericString(string input)  

        {  
           Regex nonNumericRegex = new Regex(@"[^0-9]");  
           return  nonNumericRegex.Replace(input, String.Empty);  
        }

        private string EquivalentStatus()
        {
            if (Convert.ToDouble(listView1.Items[listView1.Items.Count - 1].SubItems[0].Text) > 139 && Convert.ToDouble(listView1.Items[listView1.Items.Count - 1].SubItems[0].Text) <= 159 || Convert.ToDouble(listView1.Items[listView1.Items.Count - 1].SubItems[1].Text) <= 99 && Convert.ToDouble(listView1.Items[listView1.Items.Count - 1].SubItems[1].Text) > 89)
            {
                return "Stage1 Hypertension";
            }
            if (Convert.ToDouble(listView1.Items[listView1.Items.Count - 1].SubItems[0].Text) > 159 && Convert.ToDouble(listView1.Items[listView1.Items.Count - 1].SubItems[0].Text) <= 179 || Convert.ToDouble(listView1.Items[listView1.Items.Count - 1].SubItems[1].Text) > 99 && Convert.ToDouble(listView1.Items[listView1.Items.Count - 1].SubItems[1].Text) < 109)
            {
                return "Stage1 Hypertension";
            }
            else if (Convert.ToDouble(listView1.Items[listView1.Items.Count - 1].SubItems[0].Text) > 179 && Convert.ToDouble(listView1.Items[listView1.Items.Count - 1].SubItems[0].Text) <= 209 || Convert.ToDouble(listView1.Items[listView1.Items.Count - 1].SubItems[1].Text) > 109 && Convert.ToDouble(listView1.Items[listView1.Items.Count - 1].SubItems[1].Text) <= 119)
            {
                return "Stage3 Hypertension";
            }
            else if (Convert.ToDouble(listView1.Items[listView1.Items.Count - 1].SubItems[0].Text) < 91 || Convert.ToDouble(listView1.Items[listView1.Items.Count - 1].SubItems[1].Text) < 61)
            {
                return "LowBlood";
            }
            else if (Convert.ToDouble(listView1.Items[listView1.Items.Count - 1].SubItems[0].Text) > 91 && Convert.ToDouble(listView1.Items[listView1.Items.Count - 1].SubItems[0].Text) <= 139 || Convert.ToDouble(listView1.Items[listView1.Items.Count - 1].SubItems[1].Text) > 70 && Convert.ToDouble(listView1.Items[listView1.Items.Count - 1].SubItems[1].Text) <= 139)
            {
                return "Normal";
            }

            return "";
        }

    }
}