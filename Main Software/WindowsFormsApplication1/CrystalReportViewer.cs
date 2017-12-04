using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Odbc;
using System.Data.OleDb;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.IO;
using System.Windows.Forms.DataVisualization.Charting;
using Microsoft.Win32;
using System.Globalization;
using ZedGraph;

namespace WindowsFormsApplication1
{
    public partial class CrystalReportViewer : Form
    {
        public CrystalReportViewer()
        {
            InitializeComponent();
        }

        GraphPane myPane;

        private void CrystalReportViewer_Load(object sender, EventArgs e)
        {
            comboBox1.Text = "(Choose Time/Date Mode)";
            calendar1.Visible = false;
            myPane = zedGraphControl1.GraphPane;
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            
        }

        void PictureLoad()
        {
            try
            {
                if (comboBox1.Text == "View all readings in a selected date")
                {
                    double Systolic = 0.0, Diastolic = 0.0;
                    string CTime = "";

                    myPane.Title.Text = "All Readings\n   (" + calendar1.SelectedDate.ToShortDateString() + ")";
                    myPane.XAxis.Title.Text = "Time(Hours)";
                    myPane.YAxis.Title.Text = "Pressure Readings";
                    myPane.XAxis.Type = ZedGraph.AxisType.Date;
                    myPane.XAxis.Scale.Format = @"h tt";
                    myPane.XAxis.Scale.MajorUnit = DateUnit.Hour;
                    myPane.XAxis.Scale.MajorStep = 1.0;
                    myPane.XAxis.Scale.MinorUnit = DateUnit.Minute;
                    myPane.XAxis.Scale.MinorStep = 4.0;
                    myPane.YAxis.Scale.Min = 0;
                    myPane.YAxis.Scale.Max = 250.0;
                    myPane.XAxis.Scale.Min = new XDate(calendar1.SelectedDate.Year, calendar1.SelectedDate.Month, calendar1.SelectedDate.Day, 0, 0, 0);
                    myPane.XAxis.Scale.Max = new XDate(calendar1.SelectedDate.Year, calendar1.SelectedDate.Month, calendar1.SelectedDate.Day, 23, 0, 0);
                    zedGraphControl1.AxisChange();
                    zedGraphControl1.Invalidate();

                    string source = "SELECT * from Record where [PatientID] = '" + MainForm.patientID + "' and [CDate] = #" + calendar1.SelectedDate + "#";
                    OleDbConnection cn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + "C:\\Patient\'s Record.accdb");
                    cn.Open();
                    OleDbCommand cmd = new OleDbCommand(source, cn);
                    OleDbDataReader reader = cmd.ExecuteReader();

                    PointPairList list1 = new PointPairList();
                    PointPairList list2 = new PointPairList();

                    while (reader.Read())
                    {
                        Systolic = Convert.ToDouble(reader.GetValue(1).ToString());
                        Diastolic = Convert.ToDouble(reader.GetValue(2).ToString());
                        CTime = reader.GetValue(4).ToString();
                        list1.Add(new XDate(DateTime.Parse(calendar1.SelectedDate.ToShortDateString() + " " + CTime)), Systolic);
                        list2.Add(new XDate(DateTime.Parse(calendar1.SelectedDate.ToShortDateString() + " " + CTime)), Diastolic);
                    }

                    LineItem myCurve;

                    myCurve = myPane.AddCurve("Systolic", list1, Color.Red, SymbolType.Circle);
                    myCurve = myPane.AddCurve("Diastolic", list2, Color.Blue, SymbolType.Circle);
                    myPane.GetImage(462, 220, 10000, true);
                    myPane.GetImage().Save("C:\\graph.png");
                    myPane.CurveList.Clear();

                    reader.Close();
                    cn.Close();
                }

                else if (comboBox1.Text == "Average Per Hour")
                {

                    myPane.Title.Text = "Average Per Hour";
                    myPane.XAxis.Title.Text = "Time(Hour)";
                    myPane.YAxis.Title.Text = "Pressure Readings";
                    myPane.XAxis.Type = ZedGraph.AxisType.Date;
                    myPane.XAxis.Scale.Format = @"h tt";
                    myPane.XAxis.Scale.MajorUnit = DateUnit.Hour;
                    myPane.XAxis.Scale.MajorStep = 1.0;
                    myPane.XAxis.Scale.IsSkipCrossLabel = false;
                    myPane.XAxis.Scale.IsPreventLabelOverlap = true;
                    myPane.XAxis.Scale.Min = new XDate(calendar1.SelectedDate.Year, calendar1.SelectedDate.Month, calendar1.SelectedDate.Day, 0, 0, 0);
                    myPane.XAxis.Scale.Max = new XDate(calendar1.SelectedDate.Year, calendar1.SelectedDate.Month, calendar1.SelectedDate.Day, 23, 0, 0);
                    myPane.YAxis.Scale.Min = 0;
                    myPane.YAxis.Scale.Max = 250.0;
                    zedGraphControl1.AxisChange();
                    zedGraphControl1.Invalidate();

                    PointPairList list1 = new PointPairList();
                    PointPairList list2 = new PointPairList();


                    string source = source = "SELECT Sys, Dias, Hour From HourTable Where PatientID ='" + MainForm.patientID + "' and CDate = #" + calendar1.SelectedDate + "#";
                    OleDbConnection cn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source= " + "C:\\Patient\'s Record.accdb");
                    cn.Open();
                    OleDbCommand cmd = new OleDbCommand(source, cn);
                    OleDbDataReader reader = cmd.ExecuteReader();


                    while (reader.Read())
                    {
                        list1.Add(new XDate(DateTime.Parse(calendar1.SelectedDate.ToShortDateString() + " " + reader.GetValue(2).ToString()).ToOADate()), Convert.ToDouble(reader.GetValue(0).ToString()));
                        list2.Add(new XDate(DateTime.Parse(calendar1.SelectedDate.ToShortDateString() + " " + reader.GetValue(2).ToString()).ToOADate()), Convert.ToDouble(reader.GetValue(1).ToString()));
                    }
                    LineItem myCurve;

                    myCurve = myPane.AddCurve("Systolic", list1, Color.Red, SymbolType.Circle);
                    myCurve = myPane.AddCurve("Diastolic", list2, Color.Blue, SymbolType.Circle);
                    myPane.GetImage(462, 220, 10000, true);
                    myPane.GetImage().Save("C:\\graph.png");
                    myPane.CurveList.Clear();


                    reader.Close();
                    cn.Close();
                }
                else if (comboBox1.Text == "Average Per Month")
                {
                    string source = "SELECT Sys, Dias, Month, Year, Stat From MonthTable Where PatientID ='" + MainForm.patientID + "' and Year = " + calendar1.SelectedDate.Year;
                    OleDbConnection cn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + "C:\\Patient\'s Record.accdb");
                    cn.Open();
                    OleDbCommand cmd = new OleDbCommand(source, cn);
                    OleDbDataReader reader = cmd.ExecuteReader();

                    myPane.Title.Text = "Average Per Month\n    (" + calendar1.SelectedDate.Year.ToString() + ")";
                    myPane.XAxis.Title.Text = "Time(Month)";
                    myPane.YAxis.Title.Text = "Pressure Readings";
                    myPane.XAxis.Type = ZedGraph.AxisType.Date;
                    myPane.XAxis.Scale.Format = @"MM";
                    myPane.XAxis.Scale.MajorUnit = DateUnit.Month;
                    myPane.XAxis.Scale.MajorStep = 1.0;
                    myPane.YAxis.Scale.Min = 0;
                    myPane.YAxis.Scale.Max = 250.0;
                    myPane.XAxis.Scale.Min = new XDate(calendar1.SelectedDate.Year, 1, 1);
                    myPane.XAxis.Scale.Max = new XDate(calendar1.SelectedDate.Year, 12, 1);
                    zedGraphControl1.AxisChange();
                    zedGraphControl1.Invalidate();


                    PointPairList list1 = new PointPairList();
                    PointPairList list2 = new PointPairList();

                    while (reader.Read())
                    {
                        list1.Add(new XDate(reader.GetInt16(3), DateTime.Parse("1." + reader.GetString(2) + "2011").Month, 1), reader.GetDouble(0));//DateTime.ParseExact(reader.GetString(2), "MM", CultureInfo.CurrentCulture).Month
                        list2.Add(new XDate(reader.GetInt16(3), DateTime.Parse("1." + reader.GetString(2) + "2011").Month, 1), reader.GetDouble(1));
                    }

                    LineItem myCurve;

                    myCurve = myPane.AddCurve("Systolic", list1, Color.Red, SymbolType.Circle);
                    myCurve = myPane.AddCurve("Diastolic", list2, Color.Blue, SymbolType.Circle);
                    myPane.GetImage(462, 220, 10000, true);
                    myPane.GetImage().Save("C:\\graph.png");
                    myPane.CurveList.Clear();

                }
                else if (comboBox1.Text == "Average Per Year")
                {
                    myPane.Title.Text = "Average Per Year\n   (" + calendar1.year1 + "-" + calendar1.year12 + ")";
                    myPane.XAxis.Title.Text = "Time(Year)";
                    myPane.YAxis.Title.Text = "Pressure Readings";
                    myPane.XAxis.Type = ZedGraph.AxisType.Date;
                    myPane.XAxis.Scale.Format = @"yyyy";
                    myPane.XAxis.Scale.MajorUnit = DateUnit.Year;
                    myPane.XAxis.Scale.MajorStep = 1.0;
                    myPane.XAxis.Scale.MinorUnit = DateUnit.Year;
                    myPane.XAxis.Scale.MajorStep = 1.0;
                    myPane.YAxis.Scale.Min = 0;
                    myPane.YAxis.Scale.Max = 250.0;
                    myPane.XAxis.Scale.Min = new XDate(calendar1.year1, 1, 1);
                    myPane.XAxis.Scale.Max = new XDate(calendar1.year12, 12, 1);
                    zedGraphControl1.AxisChange();
                    zedGraphControl1.Invalidate();

                    string source = "SELECT Sys, Dias, Year, Stat From YearTable Where PatientID ='" + MainForm.patientID + "' and Year BETWEEN " + calendar1.year1 + " and " + calendar1.year12;
                    OleDbConnection cn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source= " + "C:\\Patient\'s Record.accdb");
                    cn.Open();
                    OleDbCommand cmd = new OleDbCommand(source, cn);
                    OleDbDataReader reader = cmd.ExecuteReader();


                    PointPairList list1 = new PointPairList();
                    PointPairList list2 = new PointPairList();

                    while (reader.Read())
                    {
                        list1.Add(new XDate(reader.GetInt16(2), 1, 1), reader.GetDouble(0));
                        list2.Add(new XDate(reader.GetInt16(2), 1, 1), reader.GetDouble(1));
                    }

                    LineItem myCurve;

                    myCurve = myPane.AddCurve("Systolic", list1, Color.Red, SymbolType.Circle);
                    myCurve = myPane.AddCurve("Diastolic", list2, Color.Blue, SymbolType.Circle);
                    myPane.GetImage(462, 220, 10000, true);
                    myPane.GetImage().Save("C:\\graph.png");
                    myPane.CurveList.Clear();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid operation has been detected!");
                Application.Exit();
            }
            
        }

        private void SetGraph()
        {
        }

        private void chart2_Click(object sender, EventArgs e)
        {

        }

        private void treeGX1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            CRReloader();
        }

        private void calendar1_SelectDay(object sender, MonthCalendar.SelectDayEventArgs e)
        {
            CRReloader();
        }

        private void calendar1_PClick(object sender, EventArgs e)
        {
            CRReloader();
        }

        private void calendar1_NClick(object sender, EventArgs e)
        {
            CRReloader();
        }

        private void CRReloader()
        {
            calendar1.Visible = true;
            try
            {
                if (comboBox1.Text == "View all readings in a selected date" || comboBox1.Text == "Average Per Hour")
                {
                    calendar1.SetViewMode(MonthCalendar.ViewMode.vmMonth, MonthCalendar.ViewMode.vmYear);
                    calendar1.SetViewMode(MonthCalendar.ViewMode.vmMonth, MonthCalendar.ViewMode.vm12Years);
                    calendar1.SetViewMode(MonthCalendar.ViewMode.vmMonth, MonthCalendar.ViewMode.vm120Years);
                    calendar1.OnlyMonthMode = true;
                    if (comboBox1.Text == "View all readings in a selected date")
                    {
                        PictureLoad();
                        string source = "SELECT [Systolic],[Diastolic],[CDate],[CTime],[Status] from Record WHERE [PatientID] = '" + MainForm.patientID + "' and [CDate] = #" + calendar1.SelectedDate + "#";
                        OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + "C:\\Patient\'s Record.accdb");
                        con.Open();
                        OleDbDataAdapter adapt = new OleDbDataAdapter(source, con);
                        DataSet ds = new DataSet();
                        ds.Tables.Add();
                        adapt.Fill(ds.Tables[0]);
                        con.Close();

                        source = "SELECT * from Profile";
                        con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + "C:\\Patient\'s Record.accdb");
                        con.Open();
                        adapt = new OleDbDataAdapter(source, con);
                        ds.Tables.Add();
                        adapt.Fill(ds.Tables[1]);
                        con.Close();

                        CrystalReport1 rep = new CrystalReport1();
                        rep.Database.Tables[0].SetDataSource(ds.Tables[0]);
                        rep.Database.Tables[1].SetDataSource(ds.Tables[1]);

                        crystalReportViewer1.ReportSource = rep;
                        crystalReportViewer1.Refresh();
                    }
                    else if (comboBox1.Text == "Average Per Hour")
                    {
                        PictureLoad();
                        string source = "SELECT Sys, Dias, Hour, CDate, Stat From HourTable Where PatientID ='" + MainForm.patientID + "' and CDate = #" + calendar1.SelectedDate + "#";
                        OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + "C:\\Patient\'s Record.accdb");
                        con.Open();
                        OleDbDataAdapter adapt = new OleDbDataAdapter(source, con);
                        DataSet ds = new DataSet();
                        ds.Tables.Add();
                        adapt.Fill(ds.Tables[0]);
                        con.Close();

                        source = "SELECT * from Profile WHERE PatientID ='" + MainForm.patientID + "'";
                        con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + "C:\\Patient\'s Record.accdb");
                        con.Open();
                        adapt = new OleDbDataAdapter(source, con);
                        ds.Tables.Add();
                        adapt.Fill(ds.Tables[1]);
                        con.Close();

                        CrystalReport2 rep = new CrystalReport2();
                        rep.Database.Tables[0].SetDataSource(ds.Tables[0]);
                        rep.Database.Tables[1].SetDataSource(ds.Tables[1]);

                        crystalReportViewer1.ReportSource = rep;
                        crystalReportViewer1.Refresh();
                    }
                }
                else if (comboBox1.Text == "Average Per Month")
                {
                    PictureLoad();
                    calendar1.OnlyMonthMode = false;
                    calendar1.SetViewMode(MonthCalendar.ViewMode.vmYear, MonthCalendar.ViewMode.vmYear);
                    calendar1.SetViewMode(MonthCalendar.ViewMode.vmYear, MonthCalendar.ViewMode.vm12Years);
                    calendar1.SetViewMode(MonthCalendar.ViewMode.vmYear, MonthCalendar.ViewMode.vm120Years);

                    string source = "SELECT Sys, Dias, Month, Year, Stat From MonthTable Where PatientID ='" + MainForm.patientID + "' and Year = " + calendar1.SelectedDate.Year;
                    OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + "C:\\Patient\'s Record.accdb");
                    con.Open();
                    OleDbDataAdapter adapt = new OleDbDataAdapter(source, con);
                    DataSet ds = new DataSet();
                    ds.Tables.Add();
                    adapt.Fill(ds.Tables[0]);
                    con.Close();

                    source = "SELECT * from Profile WHERE PatientID ='" + MainForm.patientID + "'";
                    con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + "C:\\Patient\'s Record.accdb");
                    con.Open();
                    adapt = new OleDbDataAdapter(source, con);
                    ds.Tables.Add();
                    adapt.Fill(ds.Tables[1]);
                    con.Close();

                    CrystalReport3 rep = new CrystalReport3();
                    rep.Database.Tables[0].SetDataSource(ds.Tables[0]);
                    rep.Database.Tables[1].SetDataSource(ds.Tables[1]);

                    crystalReportViewer1.ReportSource = rep;
                    crystalReportViewer1.Refresh();
                }
                else if (comboBox1.Text == "Average Per Year")
                {
                    PictureLoad();
                    calendar1.OnlyMonthMode = false;
                    calendar1.SetViewMode(MonthCalendar.ViewMode.vm12Years, MonthCalendar.ViewMode.vmYear);
                    calendar1.SetViewMode(MonthCalendar.ViewMode.vm12Years, MonthCalendar.ViewMode.vm12Years);
                    calendar1.SetViewMode(MonthCalendar.ViewMode.vm12Years, MonthCalendar.ViewMode.vm120Years);
                    string source = "SELECT Sys, Dias, Year, Stat From YearTable Where PatientID ='" + MainForm.patientID + "' and Year BETWEEN " + calendar1.year1 + " and " + calendar1.year12;
                    OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + "C:\\Patient\'s Record.accdb");
                    con.Open();
                    OleDbDataAdapter adapt = new OleDbDataAdapter(source, con);
                    DataSet ds = new DataSet();
                    ds.Tables.Add();
                    adapt.Fill(ds.Tables[0]);
                    con.Close();

                    source = "SELECT * from Profile WHERE PatientID ='" + MainForm.patientID + "'";
                    con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + "C:\\Patient\'s Record.accdb");
                    con.Open();
                    adapt = new OleDbDataAdapter(source, con);
                    ds.Tables.Add();
                    adapt.Fill(ds.Tables[1]);
                    con.Close();

                    CrystalReport4 rep = new CrystalReport4();
                    rep.Database.Tables[0].SetDataSource(ds.Tables[0]);
                    rep.Database.Tables[1].SetDataSource(ds.Tables[1]);

                    crystalReportViewer1.ReportSource = rep;
                    crystalReportViewer1.Refresh();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid operation has been detected!");
                Application.Exit();
            }
        }
    }
}
