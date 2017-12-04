using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ZedGraph;
using System.IO.Ports;
using System.Data.OleDb;
using System.Text.RegularExpressions;
using System.Threading;


namespace WindowsFormsApplication1
{
    public partial class NewReadingForm : Form
    {
        bool buttonIsClicked = false;
        double xAxis = 0;
        double sysPointX = 0;
        double sysPointY = 0;
        double diasPointX = 0;
        double diasPointY = 0;
        IPointListEdit forPointAnalysis;
        GraphPane myPane;
        int count = 0;
        int count2 = 0;
        double MAP = 0;
        private static string serialRead = "";
        private static string[] SysDia;

        public NewReadingForm()
        {
            InitializeComponent();
        }

        private void NewReadingForm_Load(object sender, EventArgs e)
        {
            this.Activate();
            serialPort1.PortName = MainForm.comPort;
            serialPort1.Open();
            richTextBox1.ReadOnly = true;
            myPane = zedGraphControl1.GraphPane;
            myPane.Title.Text = "Analog Values";
            myPane.XAxis.Title.Text = "Time(s)";
            myPane.YAxis.Title.Text = "Pulses(V)";
            RollingPointPairList list = new RollingPointPairList(6000);
            LineItem curve = myPane.AddCurve("Values", list, Color.Blue, SymbolType.None);
            myPane.XAxis.Scale.Min = 0;
            myPane.YAxis.Scale.Max = 5;
            myPane.XAxis.Scale.Min = 0;
            myPane.XAxis.Scale.Max = 30;
            myPane.XAxis.Scale.MinorStep = 1;
            myPane.YAxis.Scale.MajorStep = 5;
            zedGraphControl1.AxisChange();
        }

        public void Draw(string setpoint)
        {
            double insetpoint;
            double.TryParse(setpoint, out insetpoint);
            LineItem curve = zedGraphControl1.GraphPane.CurveList[0] as LineItem;
            if (curve == null)
                return;
            IPointListEdit list = curve.Points as IPointListEdit;
            forPointAnalysis = list;
            if (list == null)
                return;
            list.Add(xAxis *0.03, insetpoint);
            
            if (xAxis *0.03 > 25)
            {
                zedGraphControl1.GraphPane.XAxis.Scale.Max = xAxis* 0.03 + 2.03;
                zedGraphControl1.GraphPane.XAxis.Scale.Min += 0.03;
            }

            zedGraphControl1.AxisChange();
            zedGraphControl1.Invalidate();
            if (MAP < insetpoint)
                MAP = insetpoint;
            xAxis++;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            buttonIsClicked = true;
            CloseForm();
        }

        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                double adc_val, temp_adc;
                serialRead = serialPort1.ReadExisting();
                string prevRead="1.00";

                MethodInvoker setAll = delegate
                {
                    if (serialRead.Contains(":"))
                    {
                        SysDia = Regex.Split(serialRead, @":|\n");
                        richTextBox1.ReadOnly = false;
                        MainForm.serialDiastolic = SysDia[1];
                        MainForm.serialSystolic = SysDia[0];
                        textBox1.Text = MainForm.serialSystolic;
                        textBox2.Text = MainForm.serialDiastolic;
                        MainForm.comments=richTextBox1.Text;
                        MainForm.time = DateTime.Now.ToLongTimeString();
                        MainForm.date = DateTime.Now.ToShortDateString();
                        SysDia = null;
                        serialRead = null;
                        if (textBox1.Text == "" || textBox1.Text == null || textBox2.Text == "" || textBox2.Text == null)
                        {
                            MessageBox.Show("Invalid Data");
                        }
                        else
                        {
                            if (forPointAnalysis != null)
                            {
                                for (int i = 0; i < forPointAnalysis.Count; i++)
                                {
                                    if (forPointAnalysis[i].Y > 0 && forPointAnalysis[i].Y < 1.8 && count2 < 10)
                                        count++;
                                    else
                                    {
                                        if (count > 85)
                                        {
                                            count = 0;
                                            count2 = 0;
                                            sysPointX = 0;
                                            sysPointY = 0;
                                            diasPointX = 0;
                                            diasPointY = 0;
                                        }
                                        if (forPointAnalysis[i].Y >= 1.8)
                                        {
                                            count2++;
                                            if (count2 > 20)
                                                count = 0;
                                            if ((forPointAnalysis[i].Y / MAP > 0.75) && sysPointX == 0 && sysPointY == 0)
                                            {
                                                sysPointX = forPointAnalysis[i].X;
                                                sysPointY = forPointAnalysis[i].Y;
                                            }
                                            if ((forPointAnalysis[i].Y / MAP > 0.9) && sysPointX != 0 && sysPointY != 0)
                                            {
                                                diasPointX = forPointAnalysis[i].X;
                                                diasPointY = forPointAnalysis[i].Y;
                                            }
                                        }
                                    }
                                }
                                TextObj text = new TextObj("Systolic", sysPointX, 3.8);
                                text.Location.AlignH = AlignH.Center;
                                text.Location.AlignV = AlignV.Bottom;
                                text.FontSpec.Fill = new Fill(Color.White, Color.PowderBlue, 45F);
                                text.FontSpec.StringAlignment = StringAlignment.Near;
                                myPane.GraphObjList.Add(text);
                                ArrowObj arrow = new ArrowObj(Color.Black, 1.9F, sysPointX, 3.8, sysPointX, sysPointY);
                                arrow.Location.CoordinateFrame = CoordType.AxisXYScale;
                                myPane.GraphObjList.Add(arrow);
                                zedGraphControl1.AxisChange();

                                TextObj text2 = new TextObj("Diastolic", diasPointX, 3.8);
                                text2.Location.AlignH = AlignH.Center;
                                text2.Location.AlignV = AlignV.Bottom;
                                text2.FontSpec.Fill = new Fill(Color.White, Color.PowderBlue, 45F);
                                text2.FontSpec.StringAlignment = StringAlignment.Near;
                                myPane.GraphObjList.Add(text2);
                                ArrowObj arrow2 = new ArrowObj(Color.Black, 1.9F, diasPointX, 3.8, diasPointX, diasPointY);
                                arrow.Location.CoordinateFrame = CoordType.AxisXYScale;
                                myPane.GraphObjList.Add(arrow2);
                                zedGraphControl1.AxisChange();
                                zedGraphControl1.Refresh();
                            }
                         }
                        }
                    if (MainForm.serialDiastolic != null && MainForm.serialDiastolic != null && MainForm.serialSystolic != "" && MainForm.serialDiastolic != "")
                    {
                        try
                        {
                            if (Convert.ToInt32(MainForm.serialSystolic) > 139 && Convert.ToInt32(MainForm.serialSystolic) <= 159 || Convert.ToInt32(MainForm.serialDiastolic) <= 99 && Convert.ToInt32(MainForm.serialDiastolic) > 89)
                            {
                                textBox3.Text = "Stage1 Hypertension";
                                MainForm.status = textBox3.Text;
                            }
                            else if (Convert.ToInt32(MainForm.serialSystolic) > 159 && Convert.ToInt32(MainForm.serialSystolic) <= 179 || Convert.ToInt32(MainForm.serialDiastolic) > 99 && Convert.ToInt32(MainForm.serialDiastolic) <= 109)
                            {
                                textBox3.Text = "Stage2 Hypertension";
                                MainForm.status = textBox3.Text;
                            }
                            else if (Convert.ToInt32(MainForm.serialSystolic) > 179 && Convert.ToInt32(MainForm.serialSystolic) <= 209 || Convert.ToInt32(MainForm.serialDiastolic) > 109 && Convert.ToInt32(MainForm.serialDiastolic) <= 119)
                            {
                                textBox3.Text = "Stage3 Hypertension";
                                MainForm.status = textBox3.Text;
                            }
                            else if (Convert.ToInt32(MainForm.serialSystolic) < 91 || Convert.ToInt32(MainForm.serialDiastolic) < 61)
                            {
                                textBox3.Text = "LowBlood";
                                MainForm.status = textBox3.Text;
                            }
                            else if (Convert.ToInt32(MainForm.serialSystolic) > 91 && Convert.ToInt32(MainForm.serialSystolic) <= 139 || Convert.ToInt32(MainForm.serialDiastolic) > 70 && Convert.ToInt32(MainForm.serialDiastolic) <= 89)
                            {
                                textBox3.Text = "Normal";
                                MainForm.status = textBox3.Text;
                            }
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Invalid data");
                        }

                    }
                    if (serialRead!=null&&serialRead.Contains("r") || buttonIsClicked)
                    {
                        timer1.Enabled = true;
                        timer1.Start();
                        return;
                    }
                    else if (Double.TryParse(serialRead, out adc_val) && adc_val < 3.8)
                    {
                        if (Convert.ToDouble(serialRead)>=3&&Math.Abs(Convert.ToDouble(serialRead) - MAP) > 0.7 && Double.TryParse(prevRead, out temp_adc))
                            serialRead = ((Convert.ToDouble(serialRead) + Convert.ToDouble(prevRead)) / 3).ToString();
                        if (serialRead.Length == 1 && prevRead.Length < 4)
                        {
                            prevRead += serialRead;
                            serialRead = prevRead;
                        }
                        if (Convert.ToDouble(serialRead) < 0.5)
                            serialRead = (Convert.ToDouble(serialRead)+1).ToString();
                            Draw(serialRead + "\n");
                    }
                    prevRead = serialRead;
                };

                if (zedGraphControl1.InvokeRequired)
                    zedGraphControl1.Invoke(setAll);
                else
                    setAll();
            }
            catch (Exception)
            {
                CloseForm();
            }
        }

        private void NewReadingForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            serialPort1.Close();
            MainForm.serialDiastolic = textBox2.Text;
            MainForm.serialSystolic = textBox1.Text;
            MainForm.comments = richTextBox1.Text;
        }

        private void CloseForm()
        {
            MethodInvoker setAll = delegate
            {
                //if (serialPort1.IsOpen && (serialPort1.BytesToRead == 0 || serialPort1.BytesToRead > 0))
                //{
                    serialPort1.ReadTimeout = 1000;
                    serialPort1.ReadExisting();
                    Thread.Sleep(1000);
                    serialPort1.Close();
                    if(!serialPort1.IsOpen)
                    this.Close();
               // }
                MainForm.serialDiastolic = textBox2.Text;
                MainForm.serialSystolic = textBox1.Text;
                MainForm.comments = richTextBox1.Text;
            };
            if (this.InvokeRequired)
                this.Invoke(setAll);
            else
                setAll();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            Thread.Sleep(500);
            CloseForm();
        }
    }
}
