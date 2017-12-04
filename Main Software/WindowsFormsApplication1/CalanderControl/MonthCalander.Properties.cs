using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Windows.Forms;
using CalanderControl.Design;
using CalanderControl.Design.Attributes;
using CalanderControl.Design.Editors;
using CalanderControl.Design.Layout;
using CalanderControl.Design.Generics;
using FontConverter=CalanderControl.Design.Editors.FontConverter;
using FontEditor=CalanderControl.Design.Editors.FontEditor;

namespace CalanderControl
{
    partial class MonthCalander
    {
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DateTime SelectedDate
        {
            get { return selectedDate; }
            set
            {
                if (value != selectedDate)
                {
                    UpdateSelected(value);
                }
            }
        }
        [Category("Appearance")]
        [DefaultValue(true)]
        public bool HotAppearance
        {
            get { return hotAppearance; }
            set
            {
                if (hotAppearance != value)
                {
                    hotAppearance = value;
                    Invalidate();
                }
            }
        }
        [Editor(typeof(RangeEditor), typeof(UITypeEditor))]
        [MinMax(0, 100)]
        [Category("Appearance")]
        [DefaultValue(90)]
        public int BackGroundImageAlpha
        {
            get { return backGroundImageAlpha; }
            set
            {
                if (backGroundImageAlpha != value)
                {
                    backGroundImageAlpha = value;
                    Invalidate();
                }
            }
        }
        [Category("Appearance")]
        [DefaultValue(true)]
        public bool DrawFocused
        {
            get { return drawFocused; }
            set
            {
                if (drawFocused != value)
                {
                    drawFocused = value;
                    Invalidate();
                }
            }
        }
        [Category("Appearance")]
        [TypeConverter(typeof(GenericConverter<ThemeProperty>))]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ThemeProperty ThemeProperty
        {
            get { return themeProperty; }
        }
        [Category("Appearance")]
        [TypeConverter(typeof(ReadOnlyConverter))]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public MonthCalanderAppearance CurrentAppearance
        {
            get { return currentAppearance; }
        }
        [Category("Appearance")]
        [Editor(typeof(MonthCalanderAppearanceEditor), typeof(UITypeEditor))]
        [TypeConverter(typeof(GenericConverter<MonthCalanderAppearance>))]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public MonthCalanderAppearance Appearance
        {
            get { return appearance; }
        }
        [DefaultValue("Arial")]
        [Category("Appearance")]
        [TypeConverter(typeof(FontConverter)), Editor(typeof(FontEditor), typeof(UITypeEditor))]
        public string CaptionFont
        {
            get { return captionFont.FontFamily.Name; }
            set
            {
                if (captionFont.FontFamily.Name != value)
                {
                    captionFont = new Font(value, 9f, FontStyle.Bold);
                    Invalidate();
                }
            }
        }
        [Category("Appearance")]
        [DefaultValue("Arial")]
        [TypeConverter(typeof(FontConverter)), Editor(typeof(FontEditor), typeof(UITypeEditor))]
        public string NumberFont
        {
            get { return base.Font.FontFamily.Name; }
            set
            {
                if (base.Font.FontFamily.Name != value)
                {
                    base.Font = new Font(value, 9f, FontStyle.Regular);
                    Invalidate();
                }
            }
        }
        [Browsable(false)]
        public override Font Font
        {
            get { return base.Font; }
            set { base.Font = value; }
        }
        [Browsable(false)]
        public override Color BackColor
        {
            get { return base.BackColor; }
            set { base.BackColor = value; }
        }
        [Browsable(false)]
        public override Color ForeColor
        {
            get { return base.ForeColor; }
            set { base.ForeColor = value; }
        }
        [Browsable(false)]
        public override string Text
        {
            get { return base.Text; }
            set { base.Text = value; }
        }
        [Browsable(false)]
        public override RightToLeft RightToLeft
        {
            get { return base.RightToLeft; }
            set { base.RightToLeft = value; }
        }
        [Browsable(false)]
        public new Padding Padding
        {
            get { return base.Padding; }
            set { base.Padding = value; }
        }
        [Browsable(false)]
        public new Padding Margin
        {
            get { return base.Margin; }
            set { base.Margin = value; }
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Size MaximumSize
        {
            get { return new Size(164, 152); }
            set { base.MaximumSize = new Size(164, 152); }
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Size MinimumSize
        {
            get { return new Size(164, 152); }
            set { base.MinimumSize = value; }
        }
    }
}
