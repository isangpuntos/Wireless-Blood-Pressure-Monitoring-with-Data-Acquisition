using System;
using System.ComponentModel;
using System.Drawing;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using CalanderControl.Design.Enums;
using CalanderControl.Design.Generics;

namespace CalanderControl.Design.Layout
{
    [TypeConverter(typeof (GenericConverter<MonthCalanderAppearance>))]
    public class MonthCalanderAppearance : ICloneable, IXmlSerializable
    {
        private Color activeTextColor;
        private Color arrowColor;
        private Color arrowHoverColor;
        private ColorPair buttonBackColor;
        private ColorPair captionBackColor;
        private Color captionTextColor;
        private Color controlBackColor;
        private Color controlBorderColor;
        private Color dateDaySaperatorColor;
        private Color dayMarker;
        private Color disabledMask;
        private Color focusedBorder;
        private Color hoverColor;
        private Color inactiveTextColor;
        private int radius;
        private ColorPair selectedBackColor;
        private BorderAppearance selectedDateAppearance;
        private Color selectedDateBorderColor;
        private Color selectedDateColor;
        private Color todayColor;


        public MonthCalanderAppearance()
        {
            Reset();
            buttonBackColor.AppearanceChanged += OnAppearanceChanged;
            captionBackColor.AppearanceChanged += OnAppearanceChanged;
            selectedBackColor.AppearanceChanged += OnAppearanceChanged;
            selectedDateAppearance.AppearanceChanged += OnAppearanceChanged;
        }

        public Color FocusedBorder
        {
            get { return focusedBorder; }
            set
            {
                if (focusedBorder != value)
                {
                    focusedBorder = value;
                    OnAppearanceChanged(new GenericEventArgs<AppearanceAction>(AppearanceAction.Repaint));
                }
            }
        }

        public Color DisabledMask
        {
            get { return disabledMask; }
            set
            {
                if (disabledMask != value)
                {
                    disabledMask = value;
                    OnAppearanceChanged(new GenericEventArgs<AppearanceAction>(AppearanceAction.Repaint));
                }
            }
        }

        public Color ArrowHoverColor
        {
            get { return arrowHoverColor; }
            set
            {
                if (arrowHoverColor != value)
                {
                    arrowHoverColor = value;
                    OnAppearanceChanged(new GenericEventArgs<AppearanceAction>(AppearanceAction.Repaint));
                }
            }
        }

        public Color ControlBackColor
        {
            get { return controlBackColor; }
            set
            {
                if (controlBackColor != value)
                {
                    controlBackColor = value;
                    OnAppearanceChanged(new GenericEventArgs<AppearanceAction>(AppearanceAction.Repaint));
                }
            }
        }

        [TypeConverter(typeof (GenericConverter<BorderAppearance>))]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public BorderAppearance SelectedDateAppearance
        {
            get { return selectedDateAppearance; }
        }

        public Color TodayBorderColor
        {
            get { return selectedDateBorderColor; }
            set
            {
                if (selectedDateBorderColor != value)
                {
                    selectedDateBorderColor = value;
                    OnAppearanceChanged(new GenericEventArgs<AppearanceAction>(AppearanceAction.Repaint));
                }
            }
        }

        public Color ActiveTextColor
        {
            get { return activeTextColor; }
            set
            {
                if (activeTextColor != value)
                {
                    activeTextColor = value;
                    OnAppearanceChanged(new GenericEventArgs<AppearanceAction>(AppearanceAction.Repaint));
                }
            }
        }

        public Color TodayColor
        {
            get { return todayColor; }
            set
            {
                if (todayColor != value)
                {
                    todayColor = value;
                    OnAppearanceChanged(new GenericEventArgs<AppearanceAction>(AppearanceAction.Repaint));
                }
            }
        }

        public Color InactiveTextColor
        {
            get { return inactiveTextColor; }
            set
            {
                if (inactiveTextColor != value)
                {
                    inactiveTextColor = value;
                    OnAppearanceChanged(new GenericEventArgs<AppearanceAction>(AppearanceAction.Repaint));
                }
            }
        }

        public Color SelectedDateTextColor
        {
            get { return selectedDateColor; }
            set
            {
                if (selectedDateColor != value)
                {
                    selectedDateColor = value;
                    OnAppearanceChanged(new GenericEventArgs<AppearanceAction>(AppearanceAction.Repaint));
                }
            }
        }

        public ColorPair ButtonBackColor
        {
            get { return buttonBackColor; }
            set
            {
                if (buttonBackColor != value)
                {
                    buttonBackColor = value;
                    buttonBackColor.AppearanceChanged += OnAppearanceChanged;
                }
            }
        }

        public Color DayMarker
        {
            get { return dayMarker; }
            set
            {
                if (dayMarker != value)
                {
                    dayMarker = value;
                    OnAppearanceChanged(new GenericEventArgs<AppearanceAction>(AppearanceAction.Repaint));
                }
            }
        }

        public ColorPair SelectedBackColor
        {
            get { return selectedBackColor; }
            set
            {
                if (selectedBackColor != value)
                {
                    selectedBackColor = value;
                    selectedBackColor.AppearanceChanged += OnAppearanceChanged;
                }
            }
        }

        public Color ArrowColor
        {
            get { return arrowColor; }
            set
            {
                if (arrowColor != value)
                {
                    arrowColor = value;
                    OnAppearanceChanged(new GenericEventArgs<AppearanceAction>(AppearanceAction.Repaint));
                }
            }
        }

        public ColorPair CaptionBackColor
        {
            get { return captionBackColor; }
            set
            {
                if (captionBackColor != value)
                {
                    captionBackColor = value;
                    captionBackColor.AppearanceChanged += OnAppearanceChanged;
                }
            }
        }

        public Color CaptionTextColor
        {
            get { return captionTextColor; }
            set
            {
                if (captionTextColor != value)
                {
                    captionTextColor = value;
                    OnAppearanceChanged(new GenericEventArgs<AppearanceAction>(AppearanceAction.Repaint));
                }
            }
        }

        public Color HoverColor
        {
            get { return hoverColor; }
            set
            {
                if (hoverColor != value)
                {
                    hoverColor = value;
                    OnAppearanceChanged(new GenericEventArgs<AppearanceAction>(AppearanceAction.Repaint));
                }
            }
        }

        public Color ControlBorderColor
        {
            get { return controlBorderColor; }
            set
            {
                if (controlBorderColor != value)
                {
                    controlBorderColor = value;
                    OnAppearanceChanged(new GenericEventArgs<AppearanceAction>(AppearanceAction.Repaint));
                }
            }
        }

        public Color DateDaySaperatorColor
        {
            get { return dateDaySaperatorColor; }
            set
            {
                if (dateDaySaperatorColor != value)
                {
                    dateDaySaperatorColor = value;
                    OnAppearanceChanged(new GenericEventArgs<AppearanceAction>(AppearanceAction.Repaint));
                }
            }
        }

        public int Radius
        {
            get { return radius; }
            set
            {
                if (radius != value)
                {
                    radius = value;
                    OnAppearanceChanged(new GenericEventArgs<AppearanceAction>(AppearanceAction.Repaint));
                }
            }
        }

        #region ICloneable Members

        public object Clone()
        {
            var obj = new MonthCalanderAppearance
                          {
                              ActiveTextColor = activeTextColor,
                              ArrowColor = arrowColor,
                              ArrowHoverColor = arrowHoverColor,
                              CaptionTextColor = captionTextColor,
                              ControlBackColor = controlBackColor,
                              ControlBorderColor = controlBorderColor,
                              DateDaySaperatorColor = dateDaySaperatorColor,
                              DayMarker = dayMarker,
                              DisabledMask = disabledMask,
                              FocusedBorder = focusedBorder,
                              HoverColor = hoverColor,
                              InactiveTextColor = inactiveTextColor,
                              Radius = radius,
                              TodayBorderColor = selectedDateBorderColor,
                              SelectedDateTextColor = selectedDateColor,
                              TodayColor = todayColor
                          };
            SelectedDateAppearance.Assign((BorderAppearance) selectedDateAppearance.Clone());
            ButtonBackColor.Assign((ColorPair) buttonBackColor.Clone());
            CaptionBackColor.Assign((ColorPair) captionBackColor.Clone());
            SelectedBackColor.Assign((ColorPair) selectedBackColor.Clone());
            return obj;
        }

        #endregion

        public event GenericEventHandler<AppearanceAction> AppearanceChanged;

        private void OnAppearanceChanged(object sender, GenericEventArgs<AppearanceAction> tArgs)
        {
            OnAppearanceChanged(tArgs);
        }

        protected virtual void OnAppearanceChanged(GenericEventArgs<AppearanceAction> e)
        {
            if (AppearanceChanged != null)
            {
                AppearanceChanged(this, e);
            }
        }

        public virtual bool DefaultChanged()
        {
            return ShouldSerializeActiveTextColor() && ShouldSerializeArrowColor() || ShouldSerializeButtonBackColor() ||
                   ShouldSerializeCaptionTextColor() || ShouldSerializeControlBorderColor() ||
                   ShouldSerializeDateDaySaperatorColor() || ShouldSerializeControlBackColor()
                   || ShouldSerializeDayMarker() || ShouldSerializeHoverColor() || ShouldSerializeInactiveTextColor() ||
                   ShouldSerializeRadius() || ShouldSerializeSelectedBackColor() ||
                   ShouldSerializeSelectedDateAppearance() || ShouldSerializeSelectedDateBorderColor()
                   || ShouldSerializeSelectedDateColor() || ShouldSerializeTodayColor() ||
                   ShouldSerializeCaptionBackColor() || ShouldSerializeArrowHoverColor() ||
                   ShouldSerializeDisabledMask() || ShouldSerializeFocusedBorder();
        }

        public void Reset()
        {
            ResetSelectedDateAppearance();
            ResetActiveTextColor();
            ResetInactiveTextColor();
            ResetSelectedDateColor();
            ResetSelectedDateBorderColor();
            ResetButtonBackColor();
            ResetSelectedBackColor();
            ResetArrowColor();
            ResetCaptionBackColor();
            ResetCaptionTextColor();
            ResetHoverColor();
            ResetControlBorderColor();
            ResetControlBackColor();
            ResetTodayColor();
            ResetDayMarker();
            ResetDateDaySaperatorColor();
            ResetRadius();
            ResetArrowHoverColor();
            ResetDisabledMask();
            ResetFocusedBorder();
        }

        public void Assign(MonthCalanderAppearance appearance)
        {
            ActiveTextColor = appearance.activeTextColor;
            ArrowColor = appearance.arrowColor;
            ArrowHoverColor = appearance.arrowHoverColor;
            ButtonBackColor.Assign(appearance.buttonBackColor);
            CaptionBackColor.Assign(appearance.captionBackColor);
            CaptionTextColor = appearance.captionTextColor;
            ControlBackColor = appearance.controlBackColor;
            ControlBorderColor = appearance.controlBorderColor;
            DateDaySaperatorColor = appearance.dateDaySaperatorColor;
            DayMarker = appearance.dayMarker;
            DisabledMask = appearance.disabledMask;
            FocusedBorder = appearance.focusedBorder;
            HoverColor = appearance.hoverColor;
            InactiveTextColor = appearance.inactiveTextColor;
            Radius = appearance.radius;
            SelectedBackColor.Assign(appearance.selectedBackColor);
            SelectedDateAppearance.Assign((BorderAppearance) appearance.selectedDateAppearance.Clone());
            TodayBorderColor = appearance.selectedDateBorderColor;
            SelectedDateTextColor = appearance.selectedDateColor;
            TodayColor = appearance.todayColor;
        }

        #region ShouldSerialize implementation

        private bool ShouldSerializeFocusedBorder()
        {
            return focusedBorder != SystemColors.Highlight;
        }

        private bool ShouldSerializeDisabledMask()
        {
            return disabledMask != SystemColors.Highlight;
        }

        private bool ShouldSerializeArrowHoverColor()
        {
            return arrowHoverColor != SystemColors.Highlight;
        }

        private bool ShouldSerializeRadius()
        {
            return radius != 2;
        }

        private bool ShouldSerializeDateDaySaperatorColor()
        {
            return dateDaySaperatorColor != SystemColors.ActiveBorder;
        }

        private bool ShouldSerializeDayMarker()
        {
            return dayMarker != SystemColors.ActiveCaption;
        }

        private bool ShouldSerializeTodayColor()
        {
            return todayColor != SystemColors.ControlText;
        }

        private bool ShouldSerializeControlBorderColor()
        {
            return controlBorderColor != SystemColors.ControlText;
        }

        private bool ShouldSerializeControlBackColor()
        {
            return controlBackColor != SystemColors.Window;
        }

        private bool ShouldSerializeHoverColor()
        {
            return hoverColor != SystemColors.MenuHighlight;
        }

        private bool ShouldSerializeCaptionTextColor()
        {
            return captionTextColor != SystemColors.Window;
        }

        private bool ShouldSerializeCaptionBackColor()
        {
            return captionBackColor != new ColorPair(SystemColors.HotTrack);
        }

        private bool ShouldSerializeArrowColor()
        {
            return arrowColor != SystemColors.Window;
        }

        private bool ShouldSerializeSelectedBackColor()
        {
            return selectedBackColor != new ColorPair(SystemColors.HotTrack, SystemColors.HotTrack, 0);
        }

        private bool ShouldSerializeButtonBackColor()
        {
            return buttonBackColor != new ColorPair(SystemColors.Control, SystemColors.Control, 0);
        }

        private bool ShouldSerializeSelectedDateBorderColor()
        {
            return selectedDateBorderColor != Color.Red;
        }

        private bool ShouldSerializeSelectedDateColor()
        {
            return selectedDateColor != SystemColors.Window;
        }

        private bool ShouldSerializeInactiveTextColor()
        {
            return inactiveTextColor != SystemColors.ControlLight;
        }

        private bool ShouldSerializeActiveTextColor()
        {
            return activeTextColor != SystemColors.ControlText;
        }

        private bool ShouldSerializeSelectedDateAppearance()
        {
            return selectedDateAppearance.DefaultChanged();
        }

        #endregion

        #region Reset Implementation

        private void ResetFocusedBorder()
        {
            focusedBorder = SystemColors.Highlight;
        }

        private void ResetDisabledMask()
        {
            disabledMask = SystemColors.Highlight;
        }

        private void ResetArrowHoverColor()
        {
            arrowHoverColor = SystemColors.Highlight;
        }

        private void ResetRadius()
        {
            radius = 2;
        }

        private void ResetDateDaySaperatorColor()
        {
            dateDaySaperatorColor = SystemColors.ActiveBorder;
        }

        private void ResetDayMarker()
        {
            dayMarker = SystemColors.ActiveCaption;
        }

        private void ResetTodayColor()
        {
            todayColor = SystemColors.ControlText;
        }

        private void ResetControlBorderColor()
        {
            controlBorderColor = SystemColors.ControlText;
        }

        private void ResetControlBackColor()
        {
            controlBackColor = SystemColors.Window;
        }

        private void ResetHoverColor()
        {
            hoverColor = SystemColors.MenuHighlight;
        }

        private void ResetCaptionTextColor()
        {
            captionTextColor = SystemColors.Window;
        }

        private void ResetCaptionBackColor()
        {
            captionBackColor = new ColorPair(SystemColors.HotTrack);
        }

        private void ResetArrowColor()
        {
            arrowColor = SystemColors.Window;
        }

        private void ResetSelectedBackColor()
        {
            selectedBackColor = new ColorPair(SystemColors.HotTrack, SystemColors.HotTrack, 0);
        }

        private void ResetButtonBackColor()
        {
            buttonBackColor = new ColorPair(SystemColors.Control, SystemColors.Control, 0);
        }

        private void ResetSelectedDateBorderColor()
        {
            selectedDateBorderColor = Color.Red;
        }

        private void ResetSelectedDateColor()
        {
            selectedDateColor = SystemColors.Window;
        }

        private void ResetInactiveTextColor()
        {
            inactiveTextColor = SystemColors.ControlLight;
        }

        private void ResetActiveTextColor()
        {
            activeTextColor = SystemColors.ControlText;
        }

        private void ResetSelectedDateAppearance()
        {
            selectedDateAppearance = new BorderAppearance();
            selectedDateAppearance.AppearanceChanged += OnAppearanceChanged;
        }

        #endregion

        #region Implementation of IXmlSerializable

        /// <summary>
        /// This method is reserved and should not be used. When implementing the IXmlSerializable interface, you should return null (Nothing in Visual Basic) from this method, and instead, if specifying a custom schema is required, apply the <see cref="T:System.Xml.Serialization.XmlSchemaProviderAttribute"/> to the class.
        /// </summary>
        /// <returns>
        /// An <see cref="T:System.Xml.Schema.XmlSchema"/> that describes the XML representation of the object that is produced by the <see cref="M:System.Xml.Serialization.IXmlSerializable.WriteXml(System.Xml.XmlWriter)"/> method and consumed by the <see cref="M:System.Xml.Serialization.IXmlSerializable.ReadXml(System.Xml.XmlReader)"/> method.
        /// </returns>
        public XmlSchema GetSchema()
        {
            return new XmlSchema();
        }

        /// <summary>
        /// Generates an object from its XML representation.
        /// </summary>
        /// <param name="reader">The <see cref="T:System.Xml.XmlReader"/> stream from which the object is deserialized. </param>
        public void ReadXml(XmlReader reader)
        {
            var doc = new XmlDocument();
            doc.Load(reader);
            if (doc.GetElementsByTagName("FocusedBorder").Count > 0)
                FocusedBorder = GetColor(doc.GetElementsByTagName("FocusedBorder")[0].InnerText);
            if (doc.GetElementsByTagName("DisabledMask").Count > 0)
                DisabledMask = GetColor(doc.GetElementsByTagName("DisabledMask")[0].InnerText);
            if (doc.GetElementsByTagName("ArrowHoverColor").Count > 0)
                ArrowHoverColor = GetColor(doc.GetElementsByTagName("ArrowHoverColor")[0].InnerText);
            if (doc.GetElementsByTagName("ControlBackColor").Count > 0)
                ControlBackColor = GetColor(doc.GetElementsByTagName("ControlBackColor")[0].InnerText);
            if (doc.GetElementsByTagName("CaptionTextColor").Count > 0)
                CaptionTextColor = GetColor(doc.GetElementsByTagName("CaptionTextColor")[0].InnerText);
            if (doc.GetElementsByTagName("HoverColor").Count > 0)
                HoverColor = GetColor(doc.GetElementsByTagName("HoverColor")[0].InnerText);
            if (doc.GetElementsByTagName("ControlBorderColor").Count > 0)
                ControlBorderColor = GetColor(doc.GetElementsByTagName("ControlBorderColor")[0].InnerText);
            if (doc.GetElementsByTagName("DateDaySaperatorColor").Count > 0)
                DateDaySaperatorColor = GetColor(doc.GetElementsByTagName("DateDaySaperatorColor")[0].InnerText);
            if (doc.GetElementsByTagName("DayMarker").Count > 0)
                DayMarker = GetColor(doc.GetElementsByTagName("DayMarker")[0].InnerText);
            if (doc.GetElementsByTagName("ArrowColor").Count > 0)
                ArrowColor = GetColor(doc.GetElementsByTagName("ArrowColor")[0].InnerText);
            if (doc.GetElementsByTagName("TodayBorderColor").Count > 0)
                TodayBorderColor = GetColor(doc.GetElementsByTagName("TodayBorderColor")[0].InnerText);
            if (doc.GetElementsByTagName("ActiveTextColor").Count > 0)
                ActiveTextColor = GetColor(doc.GetElementsByTagName("ActiveTextColor")[0].InnerText);
            if (doc.GetElementsByTagName("TodayColor").Count > 0)
                TodayColor = GetColor(doc.GetElementsByTagName("TodayColor")[0].InnerText);
            if (doc.GetElementsByTagName("InactiveTextColor").Count > 0)
                InactiveTextColor = GetColor(doc.GetElementsByTagName("InactiveTextColor")[0].InnerText);
            if (doc.GetElementsByTagName("SelectedDateTextColor").Count > 0)
                SelectedDateTextColor = GetColor(doc.GetElementsByTagName("SelectedDateTextColor")[0].InnerText);
            if (doc.GetElementsByTagName("Radius").Count > 0)
                Radius = Convert.ToInt32(doc.GetElementsByTagName("Radius")[0].InnerText);
            if (doc.GetElementsByTagName("SelectedDateAppearance").Count > 0)
            {
                var xml = "<BorderAppearance>" + doc.GetElementsByTagName("SelectedDateAppearance")[0].InnerXml +
                          "</BorderAppearance>";
                SelectedDateAppearance.ReadXml(new XmlTextReader(xml, XmlNodeType.Document, null));
            }
            if (doc.GetElementsByTagName("ButtonBackColor").Count > 0)
            {
                var xml = "<ColorPair>" + doc.GetElementsByTagName("ButtonBackColor")[0].InnerXml + "</ColorPair>";
                ButtonBackColor.ReadXml(new XmlTextReader(xml, XmlNodeType.Document, null));
            }
            if (doc.GetElementsByTagName("SelectedBackColor").Count > 0)
            {
                var xml = "<ColorPair>" + doc.GetElementsByTagName("SelectedBackColor")[0].InnerXml + "</ColorPair>";
                SelectedBackColor.ReadXml(new XmlTextReader(xml, XmlNodeType.Document, null));
            }
            if (doc.GetElementsByTagName("CaptionBackColor").Count > 0)
            {
                var xml = "<ColorPair>" + doc.GetElementsByTagName("CaptionBackColor")[0].InnerXml + "</ColorPair>";
                CaptionBackColor.ReadXml(new XmlTextReader(xml, XmlNodeType.Document, null));
            }
        }

        /// <summary>
        /// Converts an object into its XML representation.
        /// </summary>
        /// <param name="writer">The <see cref="T:System.Xml.XmlWriter"/> stream to which the object is serialized. </param>
        public void WriteXml(XmlWriter writer)
        {
            writer.WriteElementString("FocusedBorder", GetString(FocusedBorder));
            writer.WriteElementString("DisabledMask", GetString(DisabledMask));
            writer.WriteElementString("ArrowHoverColor", GetString(ArrowHoverColor));
            writer.WriteElementString("ControlBackColor", GetString(ControlBackColor));
            writer.WriteStartElement("SelectedDateAppearance");
            SelectedDateAppearance.WriteXml(writer);
            writer.WriteEndElement();
            writer.WriteElementString("TodayBorderColor", GetString(TodayBorderColor));
            writer.WriteElementString("ActiveTextColor", GetString(ActiveTextColor));
            writer.WriteElementString("TodayColor", GetString(TodayColor));
            writer.WriteElementString("InactiveTextColor", GetString(InactiveTextColor));
            writer.WriteElementString("SelectedDateTextColor", GetString(SelectedDateTextColor));
            writer.WriteStartElement("ButtonBackColor");
            ButtonBackColor.WriteXml(writer);
            writer.WriteEndElement();
            writer.WriteElementString("DayMarker", GetString(DayMarker));
            writer.WriteStartElement("SelectedBackColor");
            SelectedBackColor.WriteXml(writer);
            writer.WriteEndElement();
            writer.WriteElementString("ArrowColor", GetString(ArrowColor));
            writer.WriteStartElement("CaptionBackColor");
            CaptionBackColor.WriteXml(writer);
            writer.WriteEndElement();
            writer.WriteElementString("CaptionTextColor", GetString(CaptionTextColor));
            writer.WriteElementString("HoverColor", GetString(HoverColor));
            writer.WriteElementString("ControlBorderColor", GetString(ControlBorderColor));
            writer.WriteElementString("DateDaySaperatorColor", GetString(DateDaySaperatorColor));
            writer.WriteElementString("Radius", Radius.ToString());
        }

        private static string GetString(Color c)
        {
            if (c.IsNamedColor || c.IsKnownColor || c.IsSystemColor)
                return c.Name;
            if (c.IsEmpty)
                return string.Empty;
            return c.A + ", " + c.R + ", " + c.G + ", " + c.B;
        }

        private static Color GetColor(string c)
        {
            if (c.IndexOf(',') > 0)
            {
                var parts = c.Split(',');
                return Color.FromArgb(Convert.ToInt32(parts[0].Trim()), Convert.ToInt32(parts[1].Trim()),
                                      Convert.ToInt32(parts[2].Trim()),
                                      Convert.ToInt32(parts[3].Trim()));
            }
            return Color.FromName(c);
        }

        #endregion
    }
}