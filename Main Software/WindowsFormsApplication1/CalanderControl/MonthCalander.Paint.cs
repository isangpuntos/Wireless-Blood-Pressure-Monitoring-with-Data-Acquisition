using System;
using System.Drawing;
using System.Drawing.Imaging;
using CalanderControl.Design.Utility;

namespace CalanderControl
{
    partial class MonthCalander
    {
        private void DrawBottomLabels(Graphics g)
        {
            var s = string.Format("Today: {0}", DateTime.Now.ToShortDateString());
            g.DrawString(s, captionFont, new SolidBrush(currentAppearance.TodayColor), BottomLabelsPos.X, BottomLabelsPos.Y);
        }

        private void DrawCaption(Graphics g)
        {
            Rectangle rect = new Rectangle(0, 0, Width, CaptionHeight);
            g.FillRectangle(currentAppearance.CaptionBackColor.GetBrush(rect), rect);
            switch (displayType)
            {
                case DisplayType.Dates:
                    {
                        var text = selectedDate.ToString("MMMM, yyyy");
                        var size = g.MeasureString(text, captionFont).ToSize();
                        var num = (Width - size.Width) / 2;
                        var num2 = (CaptionHeight - size.Height) / 2;
                        g.DrawString(text, captionFont, new SolidBrush(currentAppearance.CaptionTextColor), num, num2);
                        text = selectedDate.ToString("MMMM");
                        var size2 = g.MeasureString(text, captionFont).ToSize();
                        monthRectangle.X = num;
                        monthRectangle.Y = num2;
                        monthRectangle.Width = size2.Width;
                        monthRectangle.Height = size2.Height;
                        text = selectedDate.ToString("yyyy");
                        size2 = g.MeasureString(text, captionFont).ToSize();
                        yearRectangle.X = (num + size.Width) - size2.Width;
                        yearRectangle.Y = num2;
                        yearRectangle.Width = size2.Width;
                        yearRectangle.Height = size2.Height;
                    }
                    break;
                case DisplayType.Monthes:
                    {
                        var text = selectedDate.ToString("yyyy");
                        var size = g.MeasureString(text, captionFont).ToSize();
                        var num = (Width - size.Width) / 2;
                        var num2 = (CaptionHeight - size.Height) / 2;
                        g.DrawString(text, captionFont, new SolidBrush(currentAppearance.CaptionTextColor), num, num2);
                        var size2 = g.MeasureString(text, captionFont).ToSize();
                        monthRectangle = Rectangle.Empty;
                        yearRectangle.X = num;
                        yearRectangle.Y = num2;
                        yearRectangle.Width = size2.Width;
                        yearRectangle.Height = size2.Height;
                    }
                    break;
                case DisplayType.Years:
                    {
                        var startYear = (10 * (selectedDate.Year / 10));
                        var text = startYear.ToString().PadLeft(4, '0') + " - " + (startYear + 11).ToString().PadLeft(4, '0');
                        var size = g.MeasureString(text, captionFont).ToSize();
                        var num = (Width - size.Width) / 2;
                        var num2 = (CaptionHeight - size.Height) / 2;
                        g.DrawString(text, captionFont, new SolidBrush(currentAppearance.CaptionTextColor), num, num2);
                        var size2 = g.MeasureString(text, captionFont).ToSize();
                        monthRectangle = Rectangle.Empty;
                        yearRectangle.X = num;
                        yearRectangle.Y = num2;
                        yearRectangle.Width = size2.Width;
                        yearRectangle.Height = size2.Height;
                    }
                    break;
                case DisplayType.YearsRange:
                    {
                        var startYear = (100 * (selectedDate.Year / 100));
                        var text = startYear.ToString().PadLeft(4, '0') + " - " + (startYear + 100 * 12 - 1).ToString().PadLeft(4, '0');
                        var size = g.MeasureString(text, captionFont).ToSize();
                        var num = (Width - size.Width) / 2;
                        var num2 = (CaptionHeight - size.Height) / 2;
                        g.DrawString(text, captionFont, new SolidBrush(currentAppearance.CaptionTextColor), num, num2);
                        var size2 = g.MeasureString(text, captionFont).ToSize();
                        monthRectangle = Rectangle.Empty;
                        yearRectangle.X = num;
                        yearRectangle.Y = num2;
                        yearRectangle.Width = size2.Width;
                        yearRectangle.Height = size2.Height;
                    }
                    break;
            }
            g.FillRectangle(currentAppearance.ButtonBackColor.GetBrush(leftRectangle), leftRectangle);
            g.DrawRectangle(new Pen(currentAppearance.ControlBorderColor), leftRectangle);
            g.FillPolygon(new SolidBrush(currentAppearance.ArrowColor), leftArrow);
            g.FillRectangle(currentAppearance.ButtonBackColor.GetBrush(rightRectangle), rightRectangle);
            g.DrawRectangle(new Pen(currentAppearance.ControlBorderColor), rightRectangle);
            g.FillPolygon(new SolidBrush(currentAppearance.ArrowColor), rightArrow);
        }

        private void DrawCurSelection()
        {
            switch (displayType)
            {
                case DisplayType.Dates:
                    {
                        var dayIndex = GetCellIndex(selectedDate);
                        var dayCellPosition = GetCellAtIndex(dayIndex);
                        var rect = new Rectangle(dayCellPosition.X - 4, dayCellPosition.Y + 1, DaysCell.Width - 1, DaysCell.Height - 1);
                        PaintUtility.DrawBackground(graphics, rect, currentAppearance.SelectedBackColor.GetBrush(rect), currentAppearance.SelectedDateAppearance.CornerShape, currentAppearance.Radius, null);
                        if (selectedDate.Day < 10)
                        {
                            dayCellPosition.X += 4;
                        }
                        graphics.DrawString(selectedDate.Day.ToString(), Font, new SolidBrush(currentAppearance.SelectedDateTextColor), dayCellPosition.X, dayCellPosition.Y);
                    }
                    break;
                case DisplayType.Monthes:
                    {
                        var monthPosition = GetCellAtIndex(selectedDate.Month - 1);
                        var rect = new Rectangle(monthPosition.X - 5, monthPosition.Y, MonthCell.Width, MonthCell.Height);
                        PaintUtility.DrawBackground(graphics, rect, currentAppearance.SelectedBackColor.GetBrush(rect), currentAppearance.SelectedDateAppearance.CornerShape, currentAppearance.Radius, null);
                        graphics.DrawString(selectedDate.ToString("MMM"), Font, new SolidBrush(currentAppearance.SelectedDateTextColor), monthPosition.X, monthPosition.Y + MonthCell.Height / 2 - Font.Height / 2);
                    }
                    break;
                case DisplayType.Years:
                    {
                        var startYear = 10 * (selectedDate.Year / 10);
                        var yearPosition = GetCellAtIndex(selectedDate.Year - startYear);
                        var rect = new Rectangle(yearPosition.X - 5, yearPosition.Y, MonthCell.Width, MonthCell.Height);
                        PaintUtility.DrawBackground(graphics, rect, currentAppearance.SelectedBackColor.GetBrush(rect), currentAppearance.SelectedDateAppearance.CornerShape, currentAppearance.Radius, null);
                        graphics.DrawString(selectedDate.ToString("yyyy"), Font, new SolidBrush(currentAppearance.SelectedDateTextColor), yearPosition.X, yearPosition.Y + MonthCell.Height / 2 - Font.Height / 2);
                    }
                    break;
                case DisplayType.YearsRange:
                    {
                        var startYear = 100 * (selectedDate.Year / 100);
                        var rangePosition = GetCellAtIndex((selectedDate.Year - startYear) / 100);
                        GetCellIndex(selectedDate);
                        var rect = new Rectangle(rangePosition.X - 5, rangePosition.Y, MonthCell.Width, MonthCell.Height);
                        PaintUtility.DrawBackground(graphics, rect, currentAppearance.SelectedBackColor.GetBrush(rect), currentAppearance.SelectedDateAppearance.CornerShape, currentAppearance.Radius, null);
                        var text = (startYear + (100 * ((selectedDate.Year - startYear) / 100))).ToString().PadLeft(4, '0') + "-\n" + (startYear + (100 * ((selectedDate.Year - startYear) / 100)) + 99).ToString().PadLeft(4, '0');
                        graphics.DrawString(text, Font, new SolidBrush(currentAppearance.SelectedDateTextColor), rangePosition.X, rangePosition.Y);
                    }
                    break;
            }
        }

        private void DrawDay(Graphics g, DateTime day, bool selected)
        {
            var dayIndex = GetCellIndex(day);
            var dayCellPosition = GetCellAtIndex(dayIndex);
            var rect = new Rectangle(dayCellPosition.X - 4, dayCellPosition.Y + 1, DaysCell.Width - 1, DaysCell.Height - 1);
            var br = selected ? currentAppearance.SelectedBackColor.GetBrush(rect) : currentAppearance.ButtonBackColor.GetBrush(rect);
            PaintUtility.DrawBackground(g, rect, br, currentAppearance.SelectedDateAppearance.CornerShape, currentAppearance.Radius, null);
            if (day.Day < 10)
            {
                dayCellPosition.X += 4;
            }
            g.DrawString(day.Day.ToString(), Font, new SolidBrush(((selected) ? currentAppearance.SelectedDateTextColor : currentAppearance.ActiveTextColor)), dayCellPosition.X, dayCellPosition.Y);
        }

        private void DrawDays(Graphics g)
        {
            if ((selectedDate.Month != currentMonth) || (selectedDate.Year != currentYear))
            {
                CalculateDays();
                currentMonth = selectedDate.Month;
                currentYear = selectedDate.Year;
            }
            var daysGrid = DaysGrid;
            for (var i = 0; i < NumRows; i++)
            {
                for (var j = 0; j < NumCols; j++)
                {
                    var time = days[(i * 7) + j];
                    var num = (time.Day < 10) ? 4 : 0;
                    g.DrawString(time.Day.ToString(), Font, new SolidBrush((time.Month == currentMonth) ? currentAppearance.ActiveTextColor : currentAppearance.InactiveTextColor), daysGrid.X + num, daysGrid.Y);
                    daysGrid.X += DaysCell.Width;
                }
                daysGrid.X = DaysGrid.X;
                daysGrid.Y += DaysCell.Height + 1;
            }
        }

        private void DrawMonths(Graphics g)
        {
            var daysGrid = DaysGrid;
            var s = "1/1/2001";
            for (var i = 0; i < 3; i++)
            {
                for (var j = 0; j < 4; j++)
                {
                    var text = DateTime.Parse(s).ToString("MMM");
                    s = DateTime.Parse(s).AddMonths(1).ToString();
                    g.DrawString(text, Font, new SolidBrush(currentAppearance.ActiveTextColor), daysGrid.X, daysGrid.Y + MonthCell.Height / 2 - Font.Height / 2);
                    daysGrid.X += MonthCell.Width;
                }
                daysGrid.X = DaysGrid.X;
                daysGrid.Y += MonthCell.Height + 1;
            }
        }

        private void DrawYears(Graphics g)
        {
            var daysGrid = DaysGrid;
            var startYear = 10 * (selectedDate.Year / 10);
            for (var i = 0; i < 3; i++)
            {
                for (var j = 0; j < 4; j++)
                {
                    g.DrawString(startYear.ToString().PadLeft(4, '0'), Font, new SolidBrush(currentAppearance.ActiveTextColor), daysGrid.X, daysGrid.Y + MonthCell.Height / 2 - Font.Height / 2);
                    daysGrid.X += MonthCell.Width;
                    startYear++;
                }
                daysGrid.X = DaysGrid.X;
                daysGrid.Y += MonthCell.Height + 1;
            }
        }

        private void DrawYearRange(Graphics g)
        {
            var daysGrid = DaysGrid;
            var startYear = 100 * (selectedDate.Year / 100);
            for (var i = 0; i < 3; i++)
            {
                for (var j = 0; j < 4; j++)
                {
                    g.DrawString(startYear.ToString().PadLeft(4, '0') + "-\n" + (startYear + 99).ToString().PadLeft(4, '0'), Font, new SolidBrush(currentAppearance.ActiveTextColor), daysGrid.X, daysGrid.Y);
                    daysGrid.X += MonthCell.Width;
                    startYear += 100;
                }
                daysGrid.X = DaysGrid.X;
                daysGrid.Y += MonthCell.Height + 1;
            }
        }

        private void DrawDaysOfWeek(Graphics g)
        {
            var point = new Point(DaysGrid.X + 3, CaptionHeight);
            const string s = "SMTWTFS";
            foreach (var ch in s)
            {
                g.DrawString(ch.ToString(), captionFont, new SolidBrush(currentAppearance.DayMarker), point.X, point.Y);
                point.X += DaysCell.Width;
            }
            MarkerRectangle = new Rectangle(DaysGrid.X + 3, CaptionHeight, 7 * DaysCell.Width, CaptionHeight/2);
            g.DrawLine(new Pen(currentAppearance.DateDaySaperatorColor), DaysGrid.X, DaysGrid.Y - 1, Width - DaysGrid.X, DaysGrid.Y - 1);
        }

        private void DrawHoverSelection(Graphics g, int index, bool drawOrErase)
        {
            if (!hotAppearance)
                return;
            if ((index < 0) || (index >= 12)) 
                return;
            var rangeCellPosition = GetCellAtIndex(index);
            var rect = new Rectangle(rangeCellPosition.X - 5, rangeCellPosition.Y, MonthCell.Width, MonthCell.Height);
            var br = new SolidBrush(drawOrErase ? currentAppearance.HoverColor : currentAppearance.ControlBackColor);
            PaintUtility.DrawBorder(g, rect, currentAppearance.SelectedDateAppearance.CornerShape, currentAppearance.SelectedDateAppearance.BorderVisibility, currentAppearance.SelectedDateAppearance.BorderLineStyle, currentAppearance.Radius, br, null);
        }

        private void DrawHoverSelection(Graphics g, DateTime date, bool drawOrErase)
        {
            if (!hotAppearance)
                return;
            var dayIndex = GetCellIndex(date);
            if ((dayIndex < 0) || (dayIndex >= days.Length))
                return;
            var dayCellPosition = GetCellAtIndex(dayIndex);
            var rect = new Rectangle(dayCellPosition.X - 5, dayCellPosition.Y, DaysCell.Width, DaysCell.Height);
            var br = new SolidBrush(drawOrErase ? currentAppearance.HoverColor : currentAppearance.ControlBackColor);
            PaintUtility.DrawBorder(g, rect, currentAppearance.SelectedDateAppearance.CornerShape, currentAppearance.SelectedDateAppearance.BorderVisibility, currentAppearance.SelectedDateAppearance.BorderLineStyle, currentAppearance.Radius, br, null);
        }

        private void DrawTodaySelection(Graphics g)
        {
            if (displayType != DisplayType.Dates) 
                return;
            var dayIndex = GetCellIndex(DateTime.Now);
            if (((dayIndex < 0) || (dayIndex >= days.Length)) || (DateTime.Now.Month != selectedDate.Month)) 
                return;
            var dayCellPosition = GetCellAtIndex(dayIndex);
            var rect = new Rectangle(dayCellPosition.X - 5, dayCellPosition.Y, DaysCell.Width, DaysCell.Height);
            var br = new SolidBrush(currentAppearance.TodayBorderColor);
            PaintUtility.DrawBorder(g, rect, currentAppearance.SelectedDateAppearance.CornerShape, currentAppearance.SelectedDateAppearance.BorderVisibility, currentAppearance.SelectedDateAppearance.BorderLineStyle, currentAppearance.Radius, br, null);
        }
    }
}
