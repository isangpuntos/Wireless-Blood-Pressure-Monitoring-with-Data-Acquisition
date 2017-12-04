namespace WindowsFormsApplication1
{
    partial class Form2
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.calendar1 = new MonthCalendar.Calendar();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.detectConnectionButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.deleteEntryButton = new System.Windows.Forms.ToolStripButton();
            this.undoButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.saveToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.printToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.maskedTextBox1 = new System.Windows.Forms.MaskedTextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.yearlyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printPreviewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.monthlyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dailyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Turquoise;
            this.groupBox1.Controls.Add(this.chart1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(479, 270);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(479, 372);
            this.groupBox1.TabIndex = 29;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Blood Pressure Pattern";
            // 
            // chart1
            // 
            chartArea3.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.chart1.Legends.Add(legend3);
            this.chart1.Location = new System.Drawing.Point(6, 20);
            this.chart1.Name = "chart1";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.chart1.Series.Add(series3);
            this.chart1.Size = new System.Drawing.Size(467, 346);
            this.chart1.TabIndex = 5;
            this.chart1.Text = "chart1";
            // 
            // calendar1
            // 
            this.calendar1.BackColor = System.Drawing.Color.Firebrick;
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
            this.calendar1.Location = new System.Drawing.Point(6, 16);
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
            this.calendar1.SelectedDate = new System.DateTime(2011, 9, 25, 0, 0, 0, 0);
            this.calendar1.SelectionMode = MonthCalendar.SelectionMode.smOne;
            this.calendar1.Size = new System.Drawing.Size(449, 169);
            this.calendar1.StartWithZoom = MonthCalendar.ViewMode.vmMonth;
            this.calendar1.TabIndex = 17;
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
            this.calendar1.Click += new System.EventHandler(this.calendar1_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.Turquoise;
            this.groupBox4.Controls.Add(this.calendar1);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(12, 270);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(461, 191);
            this.groupBox4.TabIndex = 32;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Calendar";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(362, 116);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(121, 13);
            this.label6.TabIndex = 24;
            this.label6.Text = "Record Last Update";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(75, 38);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(140, 20);
            this.textBox4.TabIndex = 22;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(72, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 13);
            this.label5.TabIndex = 21;
            this.label5.Text = "ID Number:";
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.detectConnectionButton,
            this.toolStripSeparator5,
            this.deleteEntryButton,
            this.undoButton,
            this.toolStripSeparator3,
            this.saveToolStripButton,
            this.toolStripButton2,
            this.toolStripSeparator4,
            this.printToolStripButton,
            this.toolStripSeparator6});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(966, 36);
            this.toolStrip1.TabIndex = 33;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // detectConnectionButton
            // 
            this.detectConnectionButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.detectConnectionButton.Image = ((System.Drawing.Image)(resources.GetObject("detectConnectionButton.Image")));
            this.detectConnectionButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.detectConnectionButton.Name = "detectConnectionButton";
            this.detectConnectionButton.Size = new System.Drawing.Size(23, 33);
            this.detectConnectionButton.Text = "Detect Connection";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 36);
            // 
            // deleteEntryButton
            // 
            this.deleteEntryButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.deleteEntryButton.Image = ((System.Drawing.Image)(resources.GetObject("deleteEntryButton.Image")));
            this.deleteEntryButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.deleteEntryButton.Name = "deleteEntryButton";
            this.deleteEntryButton.Size = new System.Drawing.Size(23, 33);
            this.deleteEntryButton.Text = "Delete Entry";
            // 
            // undoButton
            // 
            this.undoButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.undoButton.Image = ((System.Drawing.Image)(resources.GetObject("undoButton.Image")));
            this.undoButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.undoButton.Name = "undoButton";
            this.undoButton.Size = new System.Drawing.Size(23, 33);
            this.undoButton.Text = "Undo adding data";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 36);
            // 
            // saveToolStripButton
            // 
            this.saveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripButton.Image")));
            this.saveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveToolStripButton.Name = "saveToolStripButton";
            this.saveToolStripButton.Size = new System.Drawing.Size(23, 33);
            this.saveToolStripButton.Text = "&Save";
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.AutoSize = false;
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(23, 33);
            this.toolStripButton2.Text = "toolStripButton2";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 36);
            // 
            // printToolStripButton
            // 
            this.printToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.printToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("printToolStripButton.Image")));
            this.printToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.printToolStripButton.Name = "printToolStripButton";
            this.printToolStripButton.Size = new System.Drawing.Size(23, 33);
            this.printToolStripButton.Text = "&Print";
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 36);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(75, 132);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(117, 20);
            this.textBox3.TabIndex = 20;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(72, 116);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "BirthDate:";
            // 
            // maskedTextBox1
            // 
            this.maskedTextBox1.Location = new System.Drawing.Point(365, 38);
            this.maskedTextBox1.Mask = "(999) 000-0000";
            this.maskedTextBox1.Name = "maskedTextBox1";
            this.maskedTextBox1.Size = new System.Drawing.Size(133, 20);
            this.maskedTextBox1.TabIndex = 18;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(75, 86);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(226, 20);
            this.textBox1.TabIndex = 14;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(365, 132);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(133, 20);
            this.textBox5.TabIndex = 25;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(795, 19);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(133, 133);
            this.pictureBox1.TabIndex = 23;
            this.pictureBox1.TabStop = false;
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(219, 22);
            this.openToolStripMenuItem.Text = "&Logout Patient";
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Turquoise;
            this.groupBox3.Controls.Add(this.textBox5);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.pictureBox1);
            this.groupBox3.Controls.Add(this.textBox4);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.textBox3);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.maskedTextBox1);
            this.groupBox3.Controls.Add(this.textBox1);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.textBox2);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(12, 100);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(946, 164);
            this.groupBox3.TabIndex = 31;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Patient\'s Profile";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(362, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Contact No.:";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(365, 87);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(382, 20);
            this.textBox2.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(72, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(362, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Address:";
            // 
            // yearlyToolStripMenuItem
            // 
            this.yearlyToolStripMenuItem.Name = "yearlyToolStripMenuItem";
            this.yearlyToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.yearlyToolStripMenuItem.Text = "Yearly";
            // 
            // printPreviewToolStripMenuItem
            // 
            this.printPreviewToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.printPreviewToolStripMenuItem.Name = "printPreviewToolStripMenuItem";
            this.printPreviewToolStripMenuItem.Size = new System.Drawing.Size(219, 22);
            this.printPreviewToolStripMenuItem.Text = "Print Pre&view";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(216, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(219, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            // 
            // monthlyToolStripMenuItem
            // 
            this.monthlyToolStripMenuItem.Name = "monthlyToolStripMenuItem";
            this.monthlyToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.monthlyToolStripMenuItem.Text = "Monthly";
            // 
            // dailyToolStripMenuItem
            // 
            this.dailyToolStripMenuItem.Name = "dailyToolStripMenuItem";
            this.dailyToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.dailyToolStripMenuItem.Text = "Daily";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dailyToolStripMenuItem,
            this.monthlyToolStripMenuItem,
            this.yearlyToolStripMenuItem});
            this.toolStripMenuItem1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(219, 22);
            this.toolStripMenuItem1.Text = "&Generate Printable Record";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(219, 22);
            this.newToolStripMenuItem.Text = "&Register New Patient";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(219, 22);
            this.saveToolStripMenuItem.Text = "&Save";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.toolStripSeparator,
            this.saveToolStripMenuItem,
            this.toolStripSeparator1,
            this.toolStripMenuItem1,
            this.printPreviewToolStripMenuItem,
            this.toolStripSeparator2,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(216, 6);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(216, 6);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoToolStripMenuItem,
            this.redoToolStripMenuItem,
            this.selectAllToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "&Edit";
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            this.undoToolStripMenuItem.Text = "&Undo Last Data Entry";
            // 
            // redoToolStripMenuItem
            // 
            this.redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            this.redoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
            this.redoToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            this.redoToolStripMenuItem.Text = "&Delete Selected Entry";
            // 
            // selectAllToolStripMenuItem
            // 
            this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
            this.selectAllToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            this.selectAllToolStripMenuItem.Text = "Delete &All Entries";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.aboutToolStripMenuItem.Text = "&About...";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(6, 19);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(449, 150);
            this.dataGridView1.TabIndex = 12;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Turquoise;
            this.groupBox2.Controls.Add(this.dataGridView1);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(12, 467);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(461, 175);
            this.groupBox2.TabIndex = 30;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Reading Entry";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.optionsToolStripMenuItem.Text = "&Options";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(966, 24);
            this.menuStrip1.TabIndex = 28;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.customizeToolStripMenuItem,
            this.optionsToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.toolsToolStripMenuItem.Text = "&Tools";
            // 
            // customizeToolStripMenuItem
            // 
            this.customizeToolStripMenuItem.Name = "customizeToolStripMenuItem";
            this.customizeToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.customizeToolStripMenuItem.Text = "&Customize";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(966, 644);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.menuStrip1);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private MonthCalendar.Calendar calendar1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton detectConnectionButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton deleteEntryButton;
        private System.Windows.Forms.ToolStripButton undoButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton saveToolStripButton;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton printToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.MaskedTextBox maskedTextBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripMenuItem yearlyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printPreviewToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem monthlyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dailyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem customizeToolStripMenuItem;
    }
}