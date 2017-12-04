using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;
using CalanderControl.Design.Generics;
using CalanderControl.Design.Utility;

namespace CalanderControl
{
    partial class MonthCalander
    {
        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.SystemColorsChanged"/> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs"/> that contains the event data. </param>
        protected override void OnSystemColorsChanged(EventArgs e)
        {
            base.OnSystemColorsChanged(e);
            SetThemeDefaults();
        }

        /// <summary>
        /// Gets a value indicating whether the control should display focus rectangles.
        /// </summary>
        /// <returns>
        /// true if the control should display focus rectangles; otherwise, false.
        /// </returns>
        protected override bool ShowFocusCues
        {
            get
            {
                return true;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the user interface is in the appropriate state to show or hide keyboard accelerators.
        /// </summary>
        /// <returns>
        /// true if the keyboard accelerators are visible; otherwise, false.
        /// </returns>
        protected override bool ShowKeyboardCues
        {
            get
            {
                return true;
            }
        }

        /// <summary>
        /// Processes a command key.
        /// </summary>
        /// <returns>
        /// true if the character was processed by the control; otherwise, false.
        /// </returns>
        /// <param name="msg">A <see cref="T:System.Windows.Forms.Message"/>, passed by reference, that represents the window message to process. </param><param name="keyData">One of the <see cref="T:System.Windows.Forms.Keys"/> values that represents the key to process. </param>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Left || keyData == Keys.Right || keyData == Keys.Up || keyData == Keys.Down)
            {
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.KeyUp"/> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.KeyEventArgs"/> that contains the event data. </param>
        protected override void OnKeyUp(KeyEventArgs e)
        {
            int dayAdvance = 0;
            switch (e.KeyCode)
            {
                case Keys.Left:
                    dayAdvance = -1;
                    break;

                case Keys.Up:
                    dayAdvance = (displayType == DisplayType.Dates) ? -NumCols : -4;
                    break;

                case Keys.Right:
                    dayAdvance = 1;
                    break;

                case Keys.Down:
                    dayAdvance = (displayType == DisplayType.Dates) ? NumCols : 4;
                    break;
            }
            if (dayAdvance != 0)
            {
                DateTime newDate = selectedDate;
                if (displayType == DisplayType.Dates)
                    newDate = selectedDate.AddDays(dayAdvance);
                if (displayType == DisplayType.Monthes)
                    newDate = selectedDate.AddMonths(dayAdvance);
                if (displayType == DisplayType.Years)
                    newDate = selectedDate.AddYears(dayAdvance);
                if (displayType == DisplayType.YearsRange)
                    newDate = selectedDate.AddYears(dayAdvance * 100 - 1);

                if (selectedDate.Month != newDate.Month)
                {
                    UpdateSelected(newDate);
                }
                else
                {
                    Graphics g = CreateGraphics();
                    DrawDay(g, selectedDate, false);
                    DrawDay(g, newDate, true);
                    g.Dispose();
                    UpdateHoverCell(GetCellIndex(newDate));
                    if (selectedDate != newDate)
                    {
                        var args = new GenericChangeEventArgs<DateTime>(selectedDate, newDate, false);
                        OnValueChanging(args);
                        if (!args.Cancel)
                        {
                            selectedDate = newDate;
                            OnValueChanged();
                            Invalidate();
                        }
                    }
                }
                e.Handled = true;
            }
            if (e.KeyData == Keys.Enter)
            {
                if (displayType == DisplayType.YearsRange)
                {
                    displayType = DisplayType.Years;
                }
                else if (displayType == DisplayType.Years)
                {
                    displayType = DisplayType.Monthes;
                }
                else if (displayType == DisplayType.Monthes)
                {
                    displayType = DisplayType.Dates;
                }
                Invalidate();
                e.Handled = true;
            }
            if (e.KeyData == Keys.Space)
            {
                if (displayType == DisplayType.Dates)
                {
                    displayType = DisplayType.Monthes;
                }
                else if (displayType == DisplayType.Monthes)
                {
                    displayType = DisplayType.Years;
                }
                else if (displayType == DisplayType.Years)
                {
                    displayType = DisplayType.YearsRange;
                }
                Invalidate();
                e.Handled = true;
            }
            if (e.KeyCode == Keys.Escape && displayType != DisplayType.Dates)
            {
                displayType = DisplayType.Dates;
                Invalidate();
                e.Handled = true;
            }
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseLeave"/> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs"/> that contains the event data. </param>
        protected override void OnMouseLeave(EventArgs e)
        {
            hoverDate = DateTime.MinValue;
            lastIndex = -1;
            Invalidate();
            base.OnMouseLeave(e);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseDown"/> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs"/> that contains the event data. </param>
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (CanSelect)
                Select();
            if (leftRectangle.Contains(e.X, e.Y) && e.Button == MouseButtons.Left)
            {
                if (displayType == DisplayType.Dates)
                {
                    UpdateSelected(selectedDate.AddMonths(-1));
                }
                else if (displayType == DisplayType.Monthes)
                {
                    UpdateSelected(selectedDate.AddYears(-1));
                }
                else if (displayType == DisplayType.Years)
                {
                    UpdateSelected(selectedDate.AddYears(-12));
                }
                else if (displayType == DisplayType.YearsRange)
                {
                    UpdateSelected(selectedDate.AddYears(-100));
                }
                Invalidate();
            }
            else if (rightRectangle.Contains(e.X, e.Y) && e.Button == MouseButtons.Left)
            {
                if (displayType == DisplayType.Dates)
                {
                    UpdateSelected(selectedDate.AddMonths(1));
                }
                else if (displayType == DisplayType.Monthes)
                {
                    UpdateSelected(selectedDate.AddYears(1));
                }
                else if (displayType == DisplayType.Years)
                {
                    UpdateSelected(selectedDate.AddYears(12));
                }
                else if (displayType == DisplayType.YearsRange)
                {
                    UpdateSelected(selectedDate.AddYears(100));
                }
                Invalidate();
            }
            else
            {
                if (e.Button == MouseButtons.Right)
                {
                    if (monthRectangle.Contains(e.X, e.Y) || (yearRectangle.Contains(e.X, e.Y)))
                    {
                        DisplayMonthMenu(e.X, e.Y);
                    }
                    int dayIndex = GetCellIndex(e.X, e.Y);
                    if (dayIndex > 0)
                    {
                        if (displayType == DisplayType.YearsRange)
                        {
                            displayType = DisplayType.Years;
                        }
                        else if (displayType == DisplayType.Years)
                        {
                            displayType = DisplayType.Monthes;
                        }
                        else if (displayType == DisplayType.Monthes)
                        {
                            displayType = DisplayType.Dates;
                        }
                        Invalidate();
                    }
                }
                else if (e.Button == MouseButtons.Left)
                {
                    if (monthRectangle.Contains(e.X, e.Y))
                    {
                        if (displayType == DisplayType.Dates)
                        {
                            displayType = DisplayType.Monthes;
                        }
                        else if (displayType == DisplayType.Monthes)
                        {
                            displayType = DisplayType.Years;
                        }
                        else if (displayType == DisplayType.Years)
                        {
                            displayType = DisplayType.YearsRange;
                        }
                        Invalidate();
                    }
                    else if (yearRectangle.Contains(e.X, e.Y))
                    {
                        if (displayType == DisplayType.Dates)
                        {
                            displayType = DisplayType.Monthes;
                        }
                        else if (displayType == DisplayType.Monthes)
                        {
                            displayType = DisplayType.Years;
                        }
                        else if (displayType == DisplayType.Years)
                        {
                            displayType = DisplayType.YearsRange;
                        }
                        Invalidate();
                    }
                    else if (e.Y >= BottomLabelsPos.Y)
                    {
                        displayType = DisplayType.Dates;
                        UpdateSelected(DateTime.Now);
                    }
                    else
                    {
                        int dayIndex = GetCellIndex(e.X, e.Y);
                        if (displayType == DisplayType.YearsRange)
                        {
                            int startYear = 100 * (selectedDate.Year / 100);
                            selectedDate = selectedDate.AddYears(startYear + dayIndex * 100 - selectedDate.Year);
                            displayType = DisplayType.Years;
                        }
                        else if (displayType == DisplayType.Years)
                        {
                            int startYear = 10 * (selectedDate.Year / 10);
                            selectedDate = selectedDate.AddYears(startYear + dayIndex - selectedDate.Year);
                            displayType = DisplayType.Monthes;
                        }
                        else if (displayType == DisplayType.Monthes)
                        {
                            selectedDate = selectedDate.AddMonths(dayIndex - selectedDate.Month + 1);
                            hoverDate = selectedDate;
                            displayType = DisplayType.Dates;
                            Invalidate();
                        }
                        else if (displayType == DisplayType.Dates)
                        {
                            dayIndex = GetCellIndex(hoverDate);
                            if ((dayIndex >= 0) && (dayIndex < days.Length))
                            {
                                UpdateSelected(hoverDate);
                            }
                        }
                        UpdateHoverCell(e.X, e.Y);
                        UpdateSelected(selectedDate);
                    }
                }
            }
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseMove"/> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs"/> that contains the event data. </param>
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            UpdateHoverCell(e.X, e.Y);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint"/> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs"/> that contains the event data. </param>
        protected override void OnPaint(PaintEventArgs e)
        {
            CreateMemoryBitmap();
            //SetDefaults();
            CalculateFirstDate();
            graphics.Clear(currentAppearance.ControlBackColor);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            e.Graphics.CompositingQuality = CompositingQuality.HighQuality;
            e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            DrawCaption(graphics);
            switch (displayType)
            {
                case DisplayType.Dates:
                    DrawDaysOfWeek(graphics);
                    DrawDays(graphics);
                    break;
                case DisplayType.Monthes:
                    DrawMonths(graphics);
                    MarkerRectangle = Rectangle.Empty;
                    break;
                case DisplayType.Years:
                    DrawYears(graphics);
                    MarkerRectangle = Rectangle.Empty;
                    break;
                case DisplayType.YearsRange:
                    DrawYearRange(graphics);
                    MarkerRectangle = Rectangle.Empty;
                    break;
            }
            DrawCurSelection();
            DrawTodaySelection(graphics);
            DrawBottomLabels(graphics);
            graphics.DrawRectangle(new Pen(currentAppearance.ControlBorderColor), 0, 0, Width - 1, Height - 1);
            if (!Enabled)
                graphics.FillRectangle(new SolidBrush(Color.FromArgb(150, currentAppearance.DisabledMask)), 0, 0, Width - 1, Height - 1);
            if (Focused && drawFocused)
                graphics.DrawRectangle(new Pen(currentAppearance.FocusedBorder), 0, 0, Width - 1, Height - 1);
            PaintUtility.DrawImage(e.Graphics, new Rectangle(0, 0, bmp.Width, bmp.Height), bmp, (int) (BackgroundImage == null ? 100*2.55 : backGroundImageAlpha*2.55));
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.GotFocus"/> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs"/> that contains the event data. </param>
        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);
            Invalidate();
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.LostFocus"/> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs"/> that contains the event data. </param>
        protected override void OnLostFocus(EventArgs e)
        {
            base.OnLostFocus(e);
            Invalidate();
        }
    }
}
