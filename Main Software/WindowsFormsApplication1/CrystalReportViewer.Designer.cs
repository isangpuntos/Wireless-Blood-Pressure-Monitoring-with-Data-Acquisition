namespace WindowsFormsApplication1
{
    partial class CrystalReportViewer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.calendar1 = new MonthCalendar.Calendar();
            this.zedGraphControl1 = new ZedGraph.ZedGraphControl();
            this.CrystalReport11 = new WindowsFormsApplication1.CrystalReport1();
            this.SuspendLayout();
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.DisplayStatusBar = false;
            this.crystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewer1.Location = new System.Drawing.Point(0, 0);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.Size = new System.Drawing.Size(968, 647);
            this.crystalReportViewer1.TabIndex = 0;
            this.crystalReportViewer1.ToolPanelWidth = 300;
            this.crystalReportViewer1.Load += new System.EventHandler(this.crystalReportViewer1_Load);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "View all readings in a selected date",
            "Average Per Hour",
            "Average Per Month",
            "Average Per Year"});
            this.comboBox1.Location = new System.Drawing.Point(13, 90);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(274, 21);
            this.comboBox1.TabIndex = 3;
            this.comboBox1.SelectedValueChanged += new System.EventHandler(this.comboBox1_SelectedValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Time Mode:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 154);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Date/Time:";
            // 
            // calendar1
            // 
            this.calendar1.Border.BorderColor = System.Drawing.Color.Black;
            this.calendar1.Border.Parent = this.calendar1;
            this.calendar1.Border.Transparency = 255;
            this.calendar1.Border.Visible = false;
            this.calendar1.CanSelectTrailingDates = true;
            this.calendar1.Culture = new System.Globalization.CultureInfo("en-US");
            this.calendar1.FirstDayOfWeek = System.Windows.Forms.Day.Default;
            this.calendar1.Footer.Align = MonthCalendar.HeaderAlign.Left;
            this.calendar1.Footer.Background.EndColor = System.Drawing.Color.Black;
            this.calendar1.Footer.Background.Gradient = MonthCalendar.GradientStyle.Vertical;
            this.calendar1.Footer.Background.Parent = this.calendar1.Footer;
            this.calendar1.Footer.Background.StartColor = System.Drawing.Color.White;
            this.calendar1.Footer.Background.Style = MonthCalendar.EStyle.esParent;
            this.calendar1.Footer.Background.TransparencyEndColor = 255;
            this.calendar1.Footer.Background.TransparencyStartColor = 255;
            this.calendar1.Footer.Border.BorderColor = System.Drawing.Color.White;
            this.calendar1.Footer.Border.Parent = this.calendar1.Footer;
            this.calendar1.Footer.Border.Transparency = 255;
            this.calendar1.Footer.Border.Visible = false;
            this.calendar1.Footer.DateFormat = MonthCalendar.DateFormat.Long;
            this.calendar1.Footer.Font = new System.Drawing.Font("Tahoma", 9F);
            this.calendar1.Footer.ForeColor = System.Drawing.Color.Blue;
            this.calendar1.Footer.Padding = new System.Windows.Forms.Padding(20, 5, 20, 5);
            this.calendar1.Footer.Text = "";
            this.calendar1.Footer.TextTransparency = 255;
            this.calendar1.Footer.Visible = true;
            this.calendar1.Header.Align = MonthCalendar.HeaderAlign.Center;
            this.calendar1.Header.Background.EndColor = System.Drawing.Color.Black;
            this.calendar1.Header.Background.Gradient = MonthCalendar.GradientStyle.Vertical;
            this.calendar1.Header.Background.Parent = this.calendar1.Header;
            this.calendar1.Header.Background.StartColor = System.Drawing.Color.White;
            this.calendar1.Header.Background.Style = MonthCalendar.EStyle.esParent;
            this.calendar1.Header.Background.TransparencyEndColor = 255;
            this.calendar1.Header.Background.TransparencyStartColor = 255;
            this.calendar1.Header.Border.BorderColor = System.Drawing.Color.Black;
            this.calendar1.Header.Border.Parent = this.calendar1.Header;
            this.calendar1.Header.Border.Transparency = 255;
            this.calendar1.Header.Border.Visible = false;
            this.calendar1.Header.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.calendar1.Header.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(155)))), ((int)(((byte)(155)))));
            this.calendar1.Header.HoverColor = System.Drawing.Color.DarkGray;
            this.calendar1.Header.Padding.Horizontal = 10;
            this.calendar1.Header.Padding.Vertical = 6;
            this.calendar1.Header.ShowNav = true;
            this.calendar1.Header.TextTransparency = 255;
            this.calendar1.Header.Visible = true;
            this.calendar1.ImageList = null;
            this.calendar1.Keyboard.AllowKeyboardSteering = true;
            this.calendar1.Keyboard.Down = System.Windows.Forms.Keys.Down;
            this.calendar1.Keyboard.GoToday = System.Windows.Forms.Keys.F12;
            this.calendar1.Keyboard.Left = System.Windows.Forms.Keys.Left;
            this.calendar1.Keyboard.MultipleSelection = MonthCalendar.ExtendedSelection.Ctrl;
            this.calendar1.Keyboard.NavNext = System.Windows.Forms.Keys.Insert;
            this.calendar1.Keyboard.NavPrev = System.Windows.Forms.Keys.Delete;
            this.calendar1.Keyboard.NextMonth = System.Windows.Forms.Keys.Home;
            this.calendar1.Keyboard.NextYear = System.Windows.Forms.Keys.PageUp;
            this.calendar1.Keyboard.PrevMonth = System.Windows.Forms.Keys.End;
            this.calendar1.Keyboard.PrevYear = System.Windows.Forms.Keys.Next;
            this.calendar1.Keyboard.Right = System.Windows.Forms.Keys.Right;
            this.calendar1.Keyboard.Select = System.Windows.Forms.Keys.Space;
            this.calendar1.Keyboard.Up = System.Windows.Forms.Keys.Up;
            this.calendar1.Keyboard.Zoomin = System.Windows.Forms.Keys.Subtract;
            this.calendar1.Keyboard.ZoomOut = System.Windows.Forms.Keys.Add;
            this.calendar1.Location = new System.Drawing.Point(12, 181);
            this.calendar1.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.calendar1.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.calendar1.MonthDays.Align = System.Drawing.ContentAlignment.MiddleCenter;
            this.calendar1.MonthDays.Background.EndColor = System.Drawing.Color.Black;
            this.calendar1.MonthDays.Background.Gradient = MonthCalendar.GradientStyle.Vertical;
            this.calendar1.MonthDays.Background.Parent = this.calendar1.MonthDays;
            this.calendar1.MonthDays.Background.StartColor = System.Drawing.Color.White;
            this.calendar1.MonthDays.Background.Style = MonthCalendar.EStyle.esParent;
            this.calendar1.MonthDays.Background.TransparencyEndColor = 255;
            this.calendar1.MonthDays.Background.TransparencyStartColor = 255;
            this.calendar1.MonthDays.Border.BorderColor = System.Drawing.Color.Black;
            this.calendar1.MonthDays.Border.Parent = this.calendar1.MonthDays;
            this.calendar1.MonthDays.Border.Transparency = 255;
            this.calendar1.MonthDays.Border.Visible = false;
            this.calendar1.MonthDays.DaysPadding.Horizontal = 2;
            this.calendar1.MonthDays.DaysPadding.Vertical = 2;
            this.calendar1.MonthDays.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.calendar1.MonthDays.ForeColor = System.Drawing.Color.Black;
            this.calendar1.MonthDays.HoverStyle.Background.EndColor = System.Drawing.Color.Black;
            this.calendar1.MonthDays.HoverStyle.Background.Gradient = MonthCalendar.GradientStyle.Vertical;
            this.calendar1.MonthDays.HoverStyle.Background.Parent = this.calendar1.MonthDays.HoverStyle;
            this.calendar1.MonthDays.HoverStyle.Background.StartColor = System.Drawing.Color.Blue;
            this.calendar1.MonthDays.HoverStyle.Background.Style = MonthCalendar.EStyle.esColor;
            this.calendar1.MonthDays.HoverStyle.Background.TransparencyEndColor = 255;
            this.calendar1.MonthDays.HoverStyle.Background.TransparencyStartColor = 128;
            this.calendar1.MonthDays.HoverStyle.Border.BorderColor = System.Drawing.Color.DarkBlue;
            this.calendar1.MonthDays.HoverStyle.Border.Parent = this.calendar1.MonthDays.HoverStyle;
            this.calendar1.MonthDays.HoverStyle.Border.Transparency = 128;
            this.calendar1.MonthDays.HoverStyle.Border.Visible = true;
            this.calendar1.MonthDays.MarkHover = true;
            this.calendar1.MonthDays.MarkSaturday = false;
            this.calendar1.MonthDays.MarkSelectedDay = true;
            this.calendar1.MonthDays.MarkSunday = true;
            this.calendar1.MonthDays.MarkToday = true;
            this.calendar1.MonthDays.Padding = new System.Windows.Forms.Padding(2);
            this.calendar1.MonthDays.SaturdayColor = System.Drawing.Color.DarkGoldenrod;
            this.calendar1.MonthDays.SelectedDay.Background.EndColor = System.Drawing.Color.Black;
            this.calendar1.MonthDays.SelectedDay.Background.Gradient = MonthCalendar.GradientStyle.Vertical;
            this.calendar1.MonthDays.SelectedDay.Background.Parent = this.calendar1.MonthDays.SelectedDay;
            this.calendar1.MonthDays.SelectedDay.Background.StartColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(222)))), ((int)(((byte)(185)))));
            this.calendar1.MonthDays.SelectedDay.Background.Style = MonthCalendar.EStyle.esColor;
            this.calendar1.MonthDays.SelectedDay.Background.TransparencyEndColor = 255;
            this.calendar1.MonthDays.SelectedDay.Background.TransparencyStartColor = 255;
            this.calendar1.MonthDays.SelectedDay.Border.BorderColor = System.Drawing.Color.White;
            this.calendar1.MonthDays.SelectedDay.Border.Parent = this.calendar1.MonthDays.SelectedDay;
            this.calendar1.MonthDays.SelectedDay.Border.Transparency = 255;
            this.calendar1.MonthDays.SelectedDay.Border.Visible = false;
            this.calendar1.MonthDays.SelectedDay.Font = new System.Drawing.Font("Tahoma", 9F);
            this.calendar1.MonthDays.SelectedDay.ForeColor = System.Drawing.Color.Black;
            this.calendar1.MonthDays.ShowTrailingDays = true;
            this.calendar1.MonthDays.SundayColor = System.Drawing.Color.Red;
            this.calendar1.MonthDays.TextTransparency = 255;
            this.calendar1.MonthDays.TodayColor = System.Drawing.Color.Blue;
            this.calendar1.MonthDays.TrailingDays.Background.EndColor = System.Drawing.Color.Black;
            this.calendar1.MonthDays.TrailingDays.Background.Gradient = MonthCalendar.GradientStyle.Vertical;
            this.calendar1.MonthDays.TrailingDays.Background.Parent = this.calendar1.MonthDays.TrailingDays;
            this.calendar1.MonthDays.TrailingDays.Background.StartColor = System.Drawing.Color.White;
            this.calendar1.MonthDays.TrailingDays.Background.Style = MonthCalendar.EStyle.esParent;
            this.calendar1.MonthDays.TrailingDays.Background.TransparencyEndColor = 255;
            this.calendar1.MonthDays.TrailingDays.Background.TransparencyStartColor = 255;
            this.calendar1.MonthDays.TrailingDays.Border.BorderColor = System.Drawing.Color.White;
            this.calendar1.MonthDays.TrailingDays.Border.Parent = this.calendar1.MonthDays.TrailingDays;
            this.calendar1.MonthDays.TrailingDays.Border.Transparency = 255;
            this.calendar1.MonthDays.TrailingDays.Border.Visible = false;
            this.calendar1.MonthDays.TrailingDays.Font = new System.Drawing.Font("Tahoma", 9F);
            this.calendar1.MonthDays.TrailingDays.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.calendar1.MonthImages.AprilImage = null;
            this.calendar1.MonthImages.AugustImage = null;
            this.calendar1.MonthImages.DecemberImage = null;
            this.calendar1.MonthImages.FebruaryImage = null;
            this.calendar1.MonthImages.ImagePosition = MonthCalendar.MonthImagePosition.Top;
            this.calendar1.MonthImages.ImagesHeight = 68;
            this.calendar1.MonthImages.JanuaryImage = null;
            this.calendar1.MonthImages.JulyImage = null;
            this.calendar1.MonthImages.JuneImage = null;
            this.calendar1.MonthImages.MarchImage = null;
            this.calendar1.MonthImages.MayImage = null;
            this.calendar1.MonthImages.NovemberImage = null;
            this.calendar1.MonthImages.OctoberImage = null;
            this.calendar1.MonthImages.SeptemberImage = null;
            this.calendar1.MonthImages.UseImages = false;
            this.calendar1.Name = "calendar1";
            this.calendar1.OnlyMonthMode = false;
            this.calendar1.pub_Year = "February 2012";
            this.calendar1.SelectedDate = new System.DateTime(2012, 2, 3, 0, 0, 0, 0);
            this.calendar1.SelectionMode = MonthCalendar.SelectionMode.smOne;
            this.calendar1.Size = new System.Drawing.Size(275, 175);
            this.calendar1.StartWithZoom = MonthCalendar.ViewMode.vmMonth;
            this.calendar1.TabIndex = 6;
            this.calendar1.valMonth = 1;
            this.calendar1.WeekDays.Align = MonthCalendar.HeaderAlign.Center;
            this.calendar1.WeekDays.Background.EndColor = System.Drawing.Color.Black;
            this.calendar1.WeekDays.Background.Gradient = MonthCalendar.GradientStyle.Vertical;
            this.calendar1.WeekDays.Background.Parent = this.calendar1.WeekDays;
            this.calendar1.WeekDays.Background.StartColor = System.Drawing.Color.White;
            this.calendar1.WeekDays.Background.Style = MonthCalendar.EStyle.esParent;
            this.calendar1.WeekDays.Background.TransparencyEndColor = 255;
            this.calendar1.WeekDays.Background.TransparencyStartColor = 255;
            this.calendar1.WeekDays.Border.BorderColor = System.Drawing.Color.Black;
            this.calendar1.WeekDays.Border.Parent = this.calendar1.WeekDays;
            this.calendar1.WeekDays.Border.Transparency = 255;
            this.calendar1.WeekDays.Border.Visible = true;
            this.calendar1.WeekDays.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.calendar1.WeekDays.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(155)))), ((int)(((byte)(155)))));
            this.calendar1.WeekDays.TextTransparency = 255;
            this.calendar1.WeekDays.Visible = true;
            this.calendar1.Weeknumbers.Align = MonthCalendar.WeekNumberAlign.Center;
            this.calendar1.Weeknumbers.Background.EndColor = System.Drawing.Color.Black;
            this.calendar1.Weeknumbers.Background.Gradient = MonthCalendar.GradientStyle.Vertical;
            this.calendar1.Weeknumbers.Background.Parent = this.calendar1.Weeknumbers;
            this.calendar1.Weeknumbers.Background.StartColor = System.Drawing.Color.White;
            this.calendar1.Weeknumbers.Background.Style = MonthCalendar.EStyle.esParent;
            this.calendar1.Weeknumbers.Background.TransparencyEndColor = 255;
            this.calendar1.Weeknumbers.Background.TransparencyStartColor = 255;
            this.calendar1.Weeknumbers.Border.BorderColor = System.Drawing.Color.Black;
            this.calendar1.Weeknumbers.Border.Parent = this.calendar1.Weeknumbers;
            this.calendar1.Weeknumbers.Border.Transparency = 255;
            this.calendar1.Weeknumbers.Border.Visible = true;
            this.calendar1.Weeknumbers.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.calendar1.Weeknumbers.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(155)))), ((int)(((byte)(155)))));
            this.calendar1.Weeknumbers.Padding = 5;
            this.calendar1.Weeknumbers.TextTransparency = 255;
            this.calendar1.Weeknumbers.Visible = false;
            this.calendar1.year1 = 2001;
            this.calendar1.year12 = 2012;
            this.calendar1.PClick += new System.EventHandler(this.calendar1_PClick);
            this.calendar1.NClick += new System.EventHandler(this.calendar1_NClick);
            this.calendar1.SelectDay += new MonthCalendar.SelectDayEventHandler(this.calendar1_SelectDay);
            // 
            // zedGraphControl1
            // 
            this.zedGraphControl1.Location = new System.Drawing.Point(319, 59);
            this.zedGraphControl1.Name = "zedGraphControl1";
            this.zedGraphControl1.ScrollGrace = 0D;
            this.zedGraphControl1.ScrollMaxX = 0D;
            this.zedGraphControl1.ScrollMaxY = 0D;
            this.zedGraphControl1.ScrollMaxY2 = 0D;
            this.zedGraphControl1.ScrollMinX = 0D;
            this.zedGraphControl1.ScrollMinY = 0D;
            this.zedGraphControl1.ScrollMinY2 = 0D;
            this.zedGraphControl1.Size = new System.Drawing.Size(462, 246);
            this.zedGraphControl1.TabIndex = 7;
            this.zedGraphControl1.Visible = false;
            // 
            // CrystalReportViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(968, 647);
            this.Controls.Add(this.zedGraphControl1);
            this.Controls.Add(this.calendar1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.crystalReportViewer1);
            this.Name = "CrystalReportViewer";
            this.Text = "Form5";
            this.Load += new System.EventHandler(this.CrystalReportViewer_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private CrystalReport1 CrystalReport11;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private MonthCalendar.Calendar calendar1;
        private ZedGraph.ZedGraphControl zedGraphControl1;
    }
}