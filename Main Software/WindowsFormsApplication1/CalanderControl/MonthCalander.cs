using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using CalanderControl.Design;
using CalanderControl.Design.Designer;
using CalanderControl.Design.Generics;
using CalanderControl.Design.Layout;

namespace CalanderControl
{
    [Designer(typeof (MonthCalanderDesigner))]
    public partial class MonthCalander : Control
    {
        #region Constants

        private const int BottomLabelHeight = 12;
        private const int CaptionHeight = 28;
        private const int ControlWidth = 164;
        private const int NumCols = 7;
        private const int NumRows = 6;

        #endregion

        #region Field Declaration

        private static Size ArrowButtonOffset = new Size(6, 6);
        private static Size ArrowButtonSize = new Size(20, 15);
        private static Size ArrowPointsOffset = new Size(13, 9);
        private static Size ArrowPointsSize = new Size(5, 10);
        private static Point BottomLabelsPos = new Point(6, 135);
        private static Size DaysCell = new Size(23, 14);
        private static Point DaysGrid = new Point(6, 43);
        private static Rectangle MarkerRectangle = Rectangle.Empty;
        private static Size MonthCell = new Size(40, 28);
        private readonly MonthCalanderAppearance appearance;
        private readonly MonthCalanderAppearance currentAppearance = new MonthCalanderAppearance();
        private readonly DateTime[] days = new DateTime[42];
        private readonly Point[] leftArrow = new Point[3];
        private readonly ThemeProperty themeProperty;
        private int backGroundImageAlpha = 90;
        private Bitmap bmp;
        private Font captionFont;
        private ContextMenu ctmMonths;
        private int currentMonth = -1;
        private int currentYear = -1;
        private DisplayType displayType = DisplayType.Dates;
        private bool drawFocused = true;
        private DateTime firstDate;
        private Graphics graphics;
        private bool hotAppearance = true;
        private DateTime hoverDate = DateTime.Now;
        private int lastIndex;
        private Rectangle leftRectangle = Rectangle.Empty;
        private Rectangle monthRectangle = Rectangle.Empty;
        private Point[] rightArrow = new Point[3];
        private Rectangle rightRectangle = Rectangle.Empty;
        private DateTime selectedDate = DateTime.Now;
        private Rectangle yearRectangle = Rectangle.Empty;

        #endregion

        #region Constructor

        public MonthCalander()
        {
            InitMonthContextMenu();
            Location = new Point(0, 0);
            selectedDate = DateTime.Now;
            Size = new Size(ControlWidth, (BottomLabelsPos.Y + BottomLabelHeight) + 5);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.DoubleBuffer, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.Selectable, true);
            themeProperty = new ThemeProperty();
            appearance = new MonthCalanderAppearance();
            appearance.AppearanceChanged += OnAppearanceChanged;
            themeProperty.ThemeChanged += OnAppearanceChanged;
            CreateMemoryBitmap();
            SetDefaults();
            SetThemeDefaults();
        }

        #endregion

        #region Events

        public event GenericEventHandler<DateTime> ValueChanged;

        public event GenericValueChangingHandler<DateTime> ValueChanging;

        #endregion

        #region Virtual Methods

        protected virtual void OnValueChanging(GenericChangeEventArgs<DateTime> e)
        {
            if (ValueChanging != null)
            {
                ValueChanging(this, e);
            }
        }

        protected virtual void OnValueChanged()
        {
            if (ValueChanged != null)
            {
                ValueChanged(this, new GenericEventArgs<DateTime>(SelectedDate));
            }
        }

        #endregion

        #region Nested Class

        private enum DisplayType
        {
            Dates,
            Monthes,
            Years,
            YearsRange,
        }

        #endregion
    }
}