using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using CalanderControl.Design;
using CalanderControl.Design.Enums;
using CalanderControl.Design.Generics;
using CalanderControl.Design.Layout;
using CalanderControl.Design.HitTest;

namespace CalanderControl
{
    partial class MonthCalander
    {
        internal void SetThemeDefaults()
        {
            currentAppearance.Reset();
            if (!themeProperty.UseTheme)
            {
                currentAppearance.SelectedDateAppearance.Assign(appearance.SelectedDateAppearance);
                currentAppearance.ActiveTextColor = appearance.ActiveTextColor;
                currentAppearance.InactiveTextColor = appearance.InactiveTextColor;
                currentAppearance.SelectedDateTextColor = appearance.SelectedDateTextColor;
                currentAppearance.TodayBorderColor = appearance.TodayBorderColor;
                currentAppearance.ButtonBackColor.Assign(appearance.ButtonBackColor);
                currentAppearance.SelectedBackColor.Assign(appearance.SelectedBackColor);
                currentAppearance.ArrowColor = appearance.ArrowColor;
                currentAppearance.ArrowHoverColor = appearance.ArrowHoverColor;
                currentAppearance.CaptionBackColor.Assign(appearance.CaptionBackColor);
                currentAppearance.CaptionTextColor = appearance.CaptionTextColor;
                currentAppearance.HoverColor = appearance.HoverColor;
                currentAppearance.ControlBorderColor = appearance.ControlBorderColor;
                currentAppearance.TodayColor = appearance.TodayColor;
                currentAppearance.DayMarker = appearance.DayMarker;
                currentAppearance.ControlBackColor = appearance.ControlBackColor;
                currentAppearance.DateDaySaperatorColor = appearance.DateDaySaperatorColor;
                currentAppearance.Radius = 2;
                currentAppearance.DisabledMask = appearance.DisabledMask;
            }
            else
            {
                switch (themeProperty.ColorScheme)
                {
                    case ColorScheme.VS2005:
                        SetColors(ColorSchemeDefinition.VS2005);
                        break;
                    case ColorScheme.Classic:
                        SetColors(ColorSchemeDefinition.Classic);
                        break;
                    case ColorScheme.Blue:
                        SetColors(ColorSchemeDefinition.Blue);
                        break;
                    case ColorScheme.Default:
                        SetColors(ColorSchemeDefinition.GetColorScheme(ColorScheme.Default));
                        break;
                    case ColorScheme.OliveGreen:
                        SetColors(ColorSchemeDefinition.OliveGreen);
                        break;
                    case ColorScheme.Royale:
                        SetColors(ColorSchemeDefinition.Royale);
                        break;
                    case ColorScheme.Silver:
                        SetColors(ColorSchemeDefinition.Silver);
                        break;
                }
            }
        }

        private void SetColors(ColorSchemeDefinition schemeDefinition)
        {
            currentAppearance.SelectedDateAppearance.Assign(new BorderAppearance());
            currentAppearance.ActiveTextColor = schemeDefinition.CaptionTextColor;
            currentAppearance.InactiveTextColor = schemeDefinition.InactiveTextColor;
            currentAppearance.SelectedDateTextColor = schemeDefinition.DayMarker;
            currentAppearance.TodayBorderColor = schemeDefinition.SelectedDateBorderColor;
            currentAppearance.ButtonBackColor.Assign(new ColorPair(schemeDefinition.CaptionBackColor));
            currentAppearance.SelectedBackColor.Assign(new ColorPair(schemeDefinition.SelectedBackColor));
            currentAppearance.ArrowColor = schemeDefinition.ArrowColor;
            currentAppearance.CaptionBackColor.Assign(new ColorPair(schemeDefinition.CaptionBackColor));
            currentAppearance.CaptionTextColor = schemeDefinition.CaptionTextColor;
            currentAppearance.HoverColor = schemeDefinition.HoverColor;
            currentAppearance.ControlBorderColor = schemeDefinition.ControlBorderColor;
            currentAppearance.TodayColor = schemeDefinition.TodayColor;
            currentAppearance.DayMarker = schemeDefinition.DayMarker;
            currentAppearance.ControlBackColor = schemeDefinition.ControlBackColor;
            currentAppearance.DateDaySaperatorColor = schemeDefinition.DateDaySaperatorColor;
            currentAppearance.Radius = 2;
            currentAppearance.ArrowHoverColor = schemeDefinition.ArrowHoverColor;
            currentAppearance.DisabledMask = schemeDefinition.TodayColor;
        }

        private void OnAppearanceChanged(object sender, GenericEventArgs<AppearanceAction> tArgs)
        {
            SetThemeDefaults();
            Invalidate();
        }

        private void CalculateDays()
        {
            for (var i = 0; i < days.Length; i++)
            {
                days[i] = firstDate.AddDays(i);
            }
        }

        private void CalculateFirstDate()
        {
            firstDate = new DateTime(selectedDate.Year, selectedDate.Month, 1);
            if (firstDate == DateTime.MinValue) return;
            firstDate = firstDate.DayOfWeek == DayOfWeek.Sunday ? firstDate.AddDays(-7.0) : firstDate.AddDays((-(double)firstDate.DayOfWeek));
        }

        private void SetDefaults()
        {
            Font = new Font("Arial", 9f, FontStyle.Regular);

            if (captionFont == null)
            {
                captionFont = new Font("Arial", 9f, FontStyle.Bold);
            }
        }

        private void CreateMemoryBitmap()
        {
            if (((bmp != null) && (bmp.Width == Width)) && (bmp.Height == Height))
                return;
            bmp = new Bitmap(Width, Height);
            graphics = Graphics.FromImage(bmp);
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            graphics.CompositingQuality = CompositingQuality.HighQuality;
            graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            leftRectangle = new Rectangle(ArrowButtonOffset.Width, ArrowButtonOffset.Height, ArrowButtonSize.Width, ArrowButtonSize.Height);
            rightRectangle = new Rectangle(((Width - ArrowButtonOffset.Width) - ArrowButtonSize.Width) - 1, ArrowButtonOffset.Height, ArrowButtonSize.Width, ArrowButtonSize.Height);
            leftArrow[0].X = ArrowPointsOffset.Width;
            leftArrow[0].Y = ArrowPointsOffset.Height + (ArrowPointsSize.Height / 2);
            leftArrow[1].X = leftArrow[0].X + ArrowPointsSize.Width;
            leftArrow[1].Y = ArrowPointsOffset.Height;
            leftArrow[2].X = leftArrow[1].X;
            leftArrow[2].Y = leftArrow[1].Y + ArrowPointsSize.Height;
            rightArrow = (Point[])leftArrow.Clone();
            rightArrow[0].X = Width - ArrowPointsOffset.Width;
            rightArrow[1].X = rightArrow[2].X = rightArrow[0].X - ArrowPointsSize.Width;
        }

        private void DisplayMonthMenu(int x, int y)
        {
            ctmMonths.Show(this, new Point(x, y));
        }

        private Point GetCellAtIndex(int cellIndex)
        {
            switch (displayType)
            {
                case DisplayType.Dates:
                    return new Point(DaysGrid.X + ((cellIndex % NumCols) * DaysCell.Width), DaysGrid.Y + ((cellIndex / NumCols) * (DaysCell.Height + 1)));
                case DisplayType.Monthes:
                    return new Point(DaysGrid.X + (((cellIndex % 4)) * MonthCell.Width), DaysGrid.Y + ((cellIndex / 4) * (MonthCell.Height + 1)));
                case DisplayType.Years:
                    return new Point(DaysGrid.X + (((cellIndex % 4)) * MonthCell.Width), DaysGrid.Y + ((cellIndex / 4) * (MonthCell.Height + 1)));
                case DisplayType.YearsRange:
                    return new Point(DaysGrid.X + (((cellIndex % 4)) * MonthCell.Width), DaysGrid.Y + ((cellIndex / 4) * (MonthCell.Height + 1)));
            }
            return new Point(0, 0);
        }

        private int GetCellIndex(DateTime date)
        {
            switch (displayType)
            {
                case DisplayType.Dates:
                    return (int)date.Subtract(firstDate).TotalDays;
                case DisplayType.Monthes:
                    return date.Month - 1;
                case DisplayType.Years:
                    return date.Year - 12 * (selectedDate.Year / 12);
                case DisplayType.YearsRange:
                    return (date.Year - (100 * (selectedDate.Year / 100))) / 100;
            }
            return -1;
        }

        private int GetCellIndex(int x, int y)
        {
            switch (displayType)
            {
                case DisplayType.Dates:
                    var rectangle = new Rectangle(0, DaysGrid.Y, NumCols * DaysCell.Width, BottomLabelsPos.Y);
                    if (!rectangle.Contains(x, y))
                    {
                        return -1;
                    }
                    int day = (x / DaysCell.Width) + (((y - DaysGrid.Y) / (DaysCell.Height + 1)) * NumCols);
                    return day >= 42 ? -1 : day;
                case DisplayType.Monthes:
                case DisplayType.Years:
                case DisplayType.YearsRange:
                    var rectangle2 = new Rectangle(0, DaysGrid.Y, 4 * MonthCell.Width, BottomLabelsPos.Y);
                    if (!rectangle2.Contains(x, y))
                    {
                        return -1;
                    }
                    return (x / MonthCell.Width) + (((y - DaysGrid.Y) / (MonthCell.Height + 1)) * 4);
            }
            return -1;
        }

        private void InitMonthContextMenu()
        {
            ctmMonths = new ContextMenu();
            var s = "1/1/2000";
            for (var i = 1; i <= 12; i++)
            {
                var item = new MenuItem();
                ctmMonths.MenuItems.Add(item);
                item.Click += OnMonthMenuClick;
                item.Text = DateTime.Parse(s).ToString("MMMM");
                s = DateTime.Parse(s).AddMonths(1).ToString();
            }
            ctmMonths.Popup += OnMonthMenuPopup;
        }

        private void OnMonthMenuClick(object sender, EventArgs e)
        {
            var item = sender as MenuItem;
            if (item == null)
                return;
            var day = selectedDate.Day;
            var time = DateTime.Parse(string.Format("{0}, {1} {2}", item.Text, 1, selectedDate.Year));
            if (day > DateTime.DaysInMonth(selectedDate.Year, time.Month))
            {
                day = DateTime.DaysInMonth(selectedDate.Year, time.Month);
            }
            var newDate = DateTime.Parse(string.Format("{0}, {1} {2}", item.Text, day, selectedDate.Year));
            UpdateSelected(newDate);
        }

        private void OnMonthMenuPopup(object sender, EventArgs e)
        {
            foreach (MenuItem item in ctmMonths.MenuItems)
            {
                item.Checked = false;
            }
            if ((currentMonth > 0) && (currentMonth <= 12))
            {
                ctmMonths.MenuItems[currentMonth - 1].Checked = true;
            }
        }

        private void UpdateSelected(DateTime newDate)
        {
            hoverDate = newDate;
            var valChange = selectedDate != newDate && hoverDate != DateTime.MinValue;
            if (valChange)
            {
                var args = new GenericChangeEventArgs<DateTime>(selectedDate, newDate, false);
                OnValueChanging(args);
                if (!args.Cancel)
                {
                    selectedDate = newDate;
                    OnValueChanged();
                }
            }
            Refresh();
            Update();
        }

        private void UpdateHoverCell(int newIndex)
        {
            switch (displayType)
            {
                case DisplayType.Dates:
                    if ((newIndex < 0) || (newIndex >= days.Length))
                    {
                        var g = CreateGraphics();
                        DrawHoverSelection(g, hoverDate, false);
                        DrawTodaySelection(g);
                        g.Dispose();
                        hoverDate = DateTime.MinValue;
                    }
                    else if (hoverDate != days[newIndex])
                    {
                        var graphics2 = CreateGraphics();
                        DrawHoverSelection(graphics2, hoverDate, false);
                        DrawHoverSelection(graphics2, days[newIndex], true);
                        DrawTodaySelection(graphics2);
                        graphics2.Dispose();
                        hoverDate = days[newIndex];
                    }
                    break;
                case DisplayType.Monthes:
                case DisplayType.Years:
                case DisplayType.YearsRange:
                    if (lastIndex != newIndex)
                    {
                        Graphics graphics2 = CreateGraphics();
                        DrawHoverSelection(graphics2, lastIndex, false);
                        DrawHoverSelection(graphics2, newIndex, true);
                        DrawTodaySelection(graphics2);
                        graphics2.Dispose();
                        lastIndex = newIndex;
                    }
                    break;
            }
        }

        private void UpdateHoverCell(int x, int y)
        {
            var dayIndex = GetCellIndex(x, y);
            if (dayIndex < 0 && hotAppearance)
            {
                var g = CreateGraphics();
                g.FillPolygon(new SolidBrush((leftRectangle.Contains(x, y)) ? currentAppearance.ArrowHoverColor : CurrentAppearance.ArrowColor), leftArrow);
                g.FillPolygon(new SolidBrush(rightRectangle.Contains(x, y) ? currentAppearance.ArrowHoverColor : currentAppearance.ArrowColor), rightArrow);
                g.Dispose();
            }
            UpdateHoverCell(dayIndex);
        }

        public MonthCalanderHitTestInfo HitTest(Point p)
        {
            var info = new MonthCalanderHitTestInfo();
            if (leftRectangle.Contains(p))
                info.Area = HitTestArea.LeftButton;
            else if (rightRectangle.Contains(p))
                info.Area = HitTestArea.RightButton;
            else if (monthRectangle.Contains(p))
                info.Area = HitTestArea.MonthText;
            else if (yearRectangle.Contains(p))
                info.Area = HitTestArea.YearText;
            else if (MarkerRectangle.Contains(p))
            {
                info.Area = HitTestArea.DayMarker;
                int dayIndx = (p.X - MarkerRectangle.X) / (MarkerRectangle.Width / 7);
                info.MarkerDay = ((DayOfWeek)dayIndx);
            }
            else
            {
                int indx = GetCellIndex(p.X, p.Y);
                if (indx >= 0)
                {
                    switch (displayType)
                    {
                        case DisplayType.Dates:
                            info.Area = HitTestArea.Days;
                            info.Day = days[indx];
                            break;
                        case DisplayType.Monthes:
                            info.Area = HitTestArea.Month;
                            info.Month = indx + 1;
                            break;
                        case DisplayType.Years:
                            info.Area = HitTestArea.Year;
                            info.Year = 10 * (selectedDate.Year / 10) + indx;
                            break;
                        case DisplayType.YearsRange:
                            info.Area = HitTestArea.YearsRange;
                            info.YearRangeStart = 100 * (selectedDate.Year / 100) + indx * 100;
                            info.YearRangeEnd = info.YearRangeStart + 99;
                            break;
                    }
                }
                else
                {
                    var rect = new Rectangle(BottomLabelsPos.X, BottomLabelsPos.Y, Width - BottomLabelsPos.X, Height - BottomLabelsPos.Y);
                    if (rect.Contains(p))
                        info.Area = HitTestArea.TodayBar;
                    else if (ClientRectangle.Contains(p))
                        info.Area = HitTestArea.Client;
                }
            }
            return info;
        }

        private bool ShouldSerializeThemeProperty()
        {
            return themeProperty.DefaultChanged();
        }

        private void ResetThemeProperty()
        {
            themeProperty.Reset();
        }

        private bool ShouldSerializeAppearance()
        {
            return Appearance.DefaultChanged();
        }

        public void ResetAppearance()
        {
            Appearance.Reset();
            Invalidate();
        }

        private bool ShouldSerializeFont()
        {
            return Font.FontFamily.Name != "Arial" && Font.Size != 9f && Font.Style != FontStyle.Regular;
        }

        private new void ResetFont()
        {
            Font = new Font("Arial", 9f, FontStyle.Regular);
        }

        public bool SaveTheme(string fileName)
        {
            try
            {
                using (XmlWriter writer = new XmlTextWriter(fileName, Encoding.UTF8))
                {
                    var serializer = new XmlSerializer(typeof(MonthCalanderAppearance));
                    serializer.Serialize(writer, Appearance);
                    writer.Flush();
                    writer.Close();
                }
            }
            catch { }
            return false;
        }

        public bool LoadTheme(string fileName)
        {
            try
            {
                using (var fs = new FileStream(fileName, FileMode.Open))
                {
                    var serializer = new XmlSerializer(typeof (MonthCalanderAppearance));
                    var app = (MonthCalanderAppearance) serializer.Deserialize(fs);
                    var appearance = Appearance;
                    appearance.Assign(app);
                    Invalidate();
                    return true;
                }
            }
            catch{ }
            return false;
        }
    }
}
