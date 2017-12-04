using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using CalanderControl.Design.Enums;
using CalanderControl.Design.Generics;
using CalanderControl.Design.Utility;
using Microsoft.Win32;

namespace CalanderControl.Design
{
    [TypeConverter(typeof (GenericConverter<ThemeProperty>))]
    public class ThemeProperty
    {
        private ColorScheme colorScheme;
        private bool useTheme;

        public ThemeProperty()
        {
            Reset();
        }

        public ColorScheme ColorScheme
        {
            get { return colorScheme; }
            set
            {
                if (colorScheme != value)
                {
                    colorScheme = value;
                    OnThemeChanged(new GenericEventArgs<AppearanceAction>(AppearanceAction.Repaint));
                }
            }
        }

        public bool UseTheme
        {
            get { return useTheme; }
            set
            {
                if (useTheme != value)
                {
                    useTheme = value;
                    OnThemeChanged(new GenericEventArgs<AppearanceAction>(AppearanceAction.Repaint));
                }
            }
        }

        public event GenericEventHandler<AppearanceAction> ThemeChanged;

        protected virtual void OnThemeChanged(GenericEventArgs<AppearanceAction> e)
        {
            if (ThemeChanged != null)
            {
                ThemeChanged(this, e);
            }
        }

        public virtual bool DefaultChanged()
        {
            return ShouldSerializeColorScheme() || ShouldSerializeUseTheme();
        }

        internal void Reset()
        {
            ResetColorScheme();
            ResetUseTheme();
        }

        private bool ShouldSerializeUseTheme()
        {
            return useTheme != true;
        }


        private bool ShouldSerializeColorScheme()
        {
            return colorScheme != ColorScheme.Default;
        }

        private void ResetUseTheme()
        {
            useTheme = true;
        }


        private void ResetColorScheme()
        {
            colorScheme = ColorScheme.Default;
        }
    }

    public enum ColorScheme
    {
        Default,
        Classic,
        Blue,
        OliveGreen,
        Royale,
        Silver,
        VS2005
    }

    public class ColorSchemeDefinition : IDisposable
    {
        private static ColorSchemeDefinition blue;
        private static ColorSchemeDefinition classic;
        private static ColorSchemeDefinition @default;
        private static ColorSchemeDefinition oliveGreen;
        private static ColorSchemeDefinition royale;
        private static ColorSchemeDefinition silver;
        private static ColorSchemeDefinition vS2005;
        private readonly ColorScheme baseColorScheme;
        private ColorScheme colorScheme;
        private Hashtable colorTable;


        protected ColorSchemeDefinition(ColorScheme baseColorScheme)
        {
            this.baseColorScheme = baseColorScheme;
            Initialize();
            SystemEvents.UserPreferenceChanged += OnUserPreferenceChanged;
        }

        public virtual Color SelectedBackColor
        {
            get { return (Color) colorTable[ColorIndex.SelectedBackColor]; }
        }

        public virtual Color SelectedDateBorderColor
        {
            get { return (Color) colorTable[ColorIndex.SelectedDateBorderColor]; }
        }

        public virtual Color ArrowHoverColor
        {
            get { return (Color) colorTable[ColorIndex.ArrowHoverColor]; }
        }

        public virtual Color HoverColor
        {
            get { return (Color) colorTable[ColorIndex.HoverColor]; }
        }

        public virtual Color ArrowColor
        {
            get { return (Color) colorTable[ColorIndex.ArrowColor]; }
        }

        public virtual Color CaptionTextColor
        {
            get { return (Color) colorTable[ColorIndex.CaptionTextColor]; }
        }

        public virtual Color InactiveTextColor
        {
            get { return (Color) colorTable[ColorIndex.InactiveTextColor]; }
        }

        public virtual Color CaptionBackColor
        {
            get { return (Color) colorTable[ColorIndex.CaptionBackColor]; }
        }

        public virtual Color DayMarker
        {
            get { return (Color) colorTable[ColorIndex.DayMarker]; }
        }

        public virtual Color ControlBackColor
        {
            get { return (Color) colorTable[ColorIndex.ControlBackColor]; }
        }

        public virtual Color ControlBorderColor
        {
            get { return (Color) colorTable[ColorIndex.ControlBorderColor]; }
        }

        public virtual Color DateDaySaperatorColor
        {
            get { return (Color) colorTable[ColorIndex.DateDaySaperatorColor]; }
        }

        public virtual Color TodayColor
        {
            get { return (Color) colorTable[ColorIndex.TodayColor]; }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public ColorScheme BaseColorScheme
        {
            get { return baseColorScheme; }
        }

        public ColorScheme ColorScheme
        {
            get { return colorScheme; }
        }

        private static string CurrentVisualStyleColorScheme
        {
            get
            {
                if (!UXTHEME.IsThemeActive())
                {
                    return null;
                }
                var builder = new StringBuilder(255);
                var builder2 = new StringBuilder(255);
                UXTHEME.GetCurrentThemeName(builder, builder.Capacity, builder2, builder2.Capacity, null, 0);
                return builder2.ToString();
            }
        }

        private static string CurrentVisualStyleThemeFileName
        {
            get
            {
                if (!IsThemeActive)
                {
                    return null;
                }
                var builder = new StringBuilder(255);
                var builder2 = new StringBuilder(255);
                UXTHEME.GetCurrentThemeName(builder, builder.Capacity, builder2, builder2.Capacity, null, 0);
                return builder.ToString();
            }
        }

        public static ColorScheme DefaultColorScheme
        {
            get
            {
                const ColorScheme colorScheme1 = ColorScheme.Classic;
                if (!IsThemeActive)
                {
                    return colorScheme1;
                }
                string themeFile = Path.GetFileName(CurrentVisualStyleThemeFileName);
                string currentTheme = CurrentVisualStyleColorScheme;
                if (string.Compare(themeFile, "LUNA.MSSTYLES", true) != 0)
                {
                    if (string.Compare(themeFile, "Aero.msstyles", true) != 0)
                    {
                        return colorScheme1;
                    }
                    return ColorScheme.Classic;
                }
                if (!string.IsNullOrEmpty(currentTheme))
                {
                    if (string.Compare(themeFile, "HOMESTEAD", true) != 0)
                    {
                        return ColorScheme.OliveGreen;
                    }
                    if (string.Compare(themeFile, "METALLIC", true) != 0)
                    {
                        return ColorScheme.Silver;
                    }
                }
                return ColorScheme.Blue;
            }
        }

        internal static bool IsThemeActive
        {
            get
            {
                if (Environment.OSVersion.Version >= new Version(5, 1))
                {
                    while (OSFeature.Feature.GetVersionPresent(OSFeature.Themes) != null)
                    {
                        return UXTHEME.IsThemeActive();
                    }
                }
                return false;
            }
        }

        public static ColorSchemeDefinition VS2005
        {
            get
            {
                if (vS2005 == null)
                {
                    vS2005 = new ColorSchemeDefinition(ColorScheme.VS2005);
                }
                return vS2005;
            }
        }

        public static ColorSchemeDefinition Classic
        {
            get
            {
                if (classic == null)
                {
                    classic = new ColorSchemeDefinition(ColorScheme.Classic);
                }
                return classic;
            }
        }

        public static ColorSchemeDefinition Default
        {
            get
            {
                if (@default == null)
                {
                    @default = new ColorSchemeDefinition(ColorScheme.Default);
                }
                return @default;
            }
        }

        public static ColorSchemeDefinition Blue
        {
            get
            {
                if (blue == null)
                {
                    blue = new ColorSchemeDefinition(ColorScheme.Blue);
                }
                return blue;
            }
        }

        public static ColorSchemeDefinition OliveGreen
        {
            get
            {
                if (oliveGreen == null)
                {
                    oliveGreen = new ColorSchemeDefinition(ColorScheme.OliveGreen);
                }
                return oliveGreen;
            }
        }

        public static ColorSchemeDefinition Royale
        {
            get
            {
                if (royale == null)
                {
                    royale = new ColorSchemeDefinition(ColorScheme.Royale);
                }
                return royale;
            }
        }

        public static ColorSchemeDefinition Silver
        {
            get
            {
                if (silver == null)
                {
                    silver = new ColorSchemeDefinition(ColorScheme.Silver);
                }
                return silver;
            }
        }

        #region IDisposable Members

        public void Dispose()
        {
            SystemEvents.UserPreferenceChanged -= OnUserPreferenceChanged;
            colorTable = null;
        }

        #endregion

        private void OnUserPreferenceChanged(object sender, UserPreferenceChangedEventArgs e)
        {
            if (e.Category == UserPreferenceCategory.Color)
            {
                Initialize();
            }
        }

        private void InitializeSilver()
        {
            InitializeCommonColors();
            colorTable[ColorIndex.HoverColor] = Color.FromArgb(75, 75, 111);
            colorTable[ColorIndex.SelectedDateBorderColor] = Color.FromArgb(75, 75, 111);
            colorTable[ColorIndex.ControlBackColor] = Color.FromArgb(186, 185, 206);
            colorTable[ColorIndex.CaptionBackColor] = Color.FromArgb(212, 212, 226);
            colorTable[ColorIndex.TodayColor] = Color.FromArgb(124, 124, 148);
            colorTable[ColorIndex.ControlBorderColor] = Color.FromArgb(110, 109, 143);
            colorTable[ColorIndex.DateDaySaperatorColor] = Color.FromArgb(255, 255, 255);
            colorTable[ColorIndex.DayMarker] = Color.FromArgb(255, 255, 255);
        }

        private void InitializeRoyale()
        {
            colorTable[ColorIndex.HoverColor] = Color.FromArgb(51, 94, 168);
            colorTable[ColorIndex.SelectedDateBorderColor] = Color.FromArgb(51, 94, 168);
            colorTable[ColorIndex.ArrowColor] = Color.FromArgb(153, 175, 212);
            colorTable[ColorIndex.ArrowHoverColor] = Color.FromArgb(194, 207, 229);
            colorTable[ColorIndex.SelectedBackColor] = Color.FromArgb(226, 229, 238);
            colorTable[ColorIndex.CaptionTextColor] = Color.FromArgb(0, 0, 0);
            colorTable[ColorIndex.InactiveTextColor] = Color.FromArgb(176, 175, 179);
            colorTable[ColorIndex.ControlBackColor] = Color.FromArgb(238, 238, 238);
            colorTable[ColorIndex.CaptionBackColor] = Color.FromArgb(235, 233, 237);
            colorTable[ColorIndex.TodayColor] = Color.FromArgb(200, 200, 200);
            colorTable[ColorIndex.ControlBorderColor] = Color.FromArgb(193, 193, 196);
            colorTable[ColorIndex.DateDaySaperatorColor] = Color.FromArgb(255, 255, 255);
            colorTable[ColorIndex.DayMarker] = Color.FromArgb(255, 255, 255);
        }

        private void InitializeOliveGreen()
        {
            InitializeCommonColors();
            colorTable[ColorIndex.HoverColor] = Color.FromArgb(63, 93, 56);
            colorTable[ColorIndex.SelectedDateBorderColor] = Color.FromArgb(63, 93, 56);
            colorTable[ColorIndex.ControlBackColor] = Color.FromArgb(176, 194, 140);
            colorTable[ColorIndex.CaptionBackColor] = Color.FromArgb(218, 227, 187);
            colorTable[ColorIndex.TodayColor] = Color.FromArgb(96, 128, 88);
            colorTable[ColorIndex.ControlBorderColor] = Color.FromArgb(96, 128, 88);
            colorTable[ColorIndex.DateDaySaperatorColor] = Color.FromArgb(244, 247, 222);
            colorTable[ColorIndex.DayMarker] = Color.FromArgb(255, 255, 255);
        }

        private void InitializeBlue()
        {
            InitializeCommonColors();
            colorTable[ColorIndex.HoverColor] = Color.FromArgb(0, 0, 128);
            colorTable[ColorIndex.SelectedDateBorderColor] = Color.FromArgb(0, 0, 128);
            colorTable[ColorIndex.ControlBackColor] = Color.FromArgb(127, 177, 250);
            colorTable[ColorIndex.CaptionBackColor] = Color.FromArgb(186, 211, 245);
            colorTable[ColorIndex.TodayColor] = Color.FromArgb(59, 97, 156);
            colorTable[ColorIndex.ControlBorderColor] = Color.FromArgb(106, 140, 203);
            colorTable[ColorIndex.DateDaySaperatorColor] = Color.FromArgb(241, 249, 255);
            colorTable[ColorIndex.DayMarker] = Color.FromArgb(255, 255, 255);
        }

        private void InitializeVS2005()
        {
            Color control = SystemColors.Control;
            Color controlDark = SystemColors.ControlDark;
            Color highlight = SystemColors.Highlight;
            Color window = SystemColors.Window;
            Color controlText = SystemColors.ControlText;
            Color controlLightLight = SystemColors.ControlLightLight;
            CalculateColor(control, window, 0.23f);
            CalculateColor(control, window, 0.5f);
            colorTable[ColorIndex.HoverColor] = highlight;
            colorTable[ColorIndex.SelectedDateBorderColor] = highlight;
            colorTable[ColorIndex.ArrowColor] = CalculateColor(SystemColors.Highlight, SystemColors.Window,
                                                               0.55f);
            colorTable[ColorIndex.ArrowHoverColor] = CalculateColor(SystemColors.Highlight, SystemColors.Window, 0.7f);
            colorTable[ColorIndex.SelectedBackColor] = CalculateColor(SystemColors.Highlight, SystemColors.Window,
                                                                      0.85f);
            colorTable[ColorIndex.CaptionTextColor] = controlText;
            colorTable[ColorIndex.InactiveTextColor] = controlDark;
            colorTable[ColorIndex.ControlBackColor] = CalculateColor(controlDark, window, 0.25f);
            colorTable[ColorIndex.CaptionBackColor] = control;
            colorTable[ColorIndex.TodayColor] = CalculateColor(control, window, 0.165f);
            colorTable[ColorIndex.ControlBorderColor] = CalculateColor(controlDark, window, 0.3f);
            colorTable[ColorIndex.DateDaySaperatorColor] = controlLightLight;
            colorTable[ColorIndex.DayMarker] = controlLightLight;
        }

        private void InitializeMisc()
        {
            colorTable[ColorIndex.ControlBackColor] = CalculateColor(SystemColors.ControlDark, SystemColors.Window, 0.7f);
            colorTable[ColorIndex.TodayColor] = SystemColors.ControlDark;
        }

        public static ColorSchemeDefinition GetColorScheme(ColorScheme _colorScheme)
        {
            switch (_colorScheme)
            {
                case ColorScheme.Classic:
                    return Classic;

                case ColorScheme.Blue:
                    return Blue;

                case ColorScheme.OliveGreen:
                    return OliveGreen;

                case ColorScheme.Royale:
                    return Royale;

                case ColorScheme.Silver:
                    return Silver;

                case ColorScheme.VS2005:
                    return VS2005;
            }
            return Default;
        }

        private void InitializeCommonColors()
        {
            colorTable[ColorIndex.ArrowColor] = Color.FromArgb(254, 128, 62);
            colorTable[ColorIndex.ArrowHoverColor] = Color.FromArgb(255, 238, 194);
            colorTable[ColorIndex.SelectedBackColor] = Color.FromArgb(255, 192, 111);
            colorTable[ColorIndex.CaptionTextColor] = Color.FromArgb(0, 0, 0);
            colorTable[ColorIndex.InactiveTextColor] = Color.FromArgb(141, 141, 141);
        }

        private void Initialize()
        {
            colorScheme = baseColorScheme;
            if (colorScheme == ColorScheme.Default)
            {
                colorScheme = DefaultColorScheme;
            }
            colorTable = new Hashtable();
            switch (colorScheme)
            {
                case ColorScheme.Blue:
                    InitializeBlue();
                    break;

                case ColorScheme.OliveGreen:
                    InitializeOliveGreen();
                    break;

                case ColorScheme.Royale:
                    InitializeRoyale();
                    break;

                case ColorScheme.Silver:
                    InitializeSilver();
                    break;

                case ColorScheme.VS2005:
                    InitializeVS2005();
                    if (DefaultColorScheme != ColorScheme.Silver)
                    {
                        InitializeMisc();
                        break;
                    }
                    InitializeSilver();
                    break;

                default:
                    InitializeVS2005();
                    break;
            }
        }

        public static Color CalculateColor(Color color1, Color color2, float percentage)
        {
            var r = (byte) (color1.R - ((color1.R - color2.R)*percentage));
            var g = (byte) (color1.G - ((color1.G - color2.G)*percentage));
            var b = (byte) (color1.B - ((color1.B - color2.B)*percentage));
            return Color.FromArgb(r, g, b);
        }

        #region Nested type: ColorIndex

        private enum ColorIndex
        {
            CaptionBackColor = 1,
            TodayColor = 2,
            ControlBorderColor = 3,
            DateDaySaperatorColor = 4,
            DayMarker = 5,
            HoverColor = 6,
            SelectedDateBorderColor = 7,
            ArrowColor = 8,
            ArrowHoverColor = 9,
            SelectedBackColor = 10,
            CaptionTextColor = 11,
            InactiveTextColor = 12,
            ControlBackColor = 13,
        }

        #endregion
    }
}