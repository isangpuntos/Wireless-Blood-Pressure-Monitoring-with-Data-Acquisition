using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Drawing.Design;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using System.Xml;
using System.Xml.Serialization;
using CalanderControl.Design.Attributes;
using CalanderControl.Design.Editors;
using CalanderControl.Design.Generics;
using CalanderControl.Design.Layout;
using FontConverter=CalanderControl.Design.Editors.FontConverter;
using FontEditor=CalanderControl.Design.Editors.FontEditor;

namespace CalanderControl.Design.Designer
{
    internal class MonthCalanderDesigner : ParentControlDesigner
    {
        public override DesignerActionListCollection ActionLists
        {
            get
            {
                var list = new DesignerActionListCollection {new MonthCalanderDesignerActionList(Component)};
                return list;
            }
        }

        #region Nested type: MonthCalanderDesignerActionList

        internal class MonthCalanderDesignerActionList : DesignerActionList
        {
            public MonthCalanderDesignerActionList(IComponent component) : base(component)
            {
            }

            private MonthCalander Calander
            {
                get { return (MonthCalander) Component; }
            }

            public override bool AutoShow
            {
                get { return true; }
                set { base.AutoShow = true; }
            }

            [TypeConverter(typeof (GenericConverter<MonthCalanderAppearance>))]
            [Editor(typeof (MonthCalanderAppearanceEditor), typeof (UITypeEditor))]
            [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
            public MonthCalanderAppearance Appearance
            {
                get { return Calander.Appearance; }
            }

            public bool UseTheme
            {
                get { return Calander.ThemeProperty.UseTheme; }
                set
                {
                    Calander.ThemeProperty.UseTheme = value;
                    Calander.SetThemeDefaults();
                }
            }

            public bool DrawFocused
            {
                get { return Calander.DrawFocused; }
                set
                {
                    if (Calander.DrawFocused != value)
                    {
                        Calander.DrawFocused = value;
                        Calander.SetThemeDefaults();
                    }
                }
            }

            public bool HotAppearance
            {
                get { return Calander.HotAppearance; }
                set
                {
                    if (Calander.HotAppearance != value)
                    {
                        Calander.HotAppearance = value;
                        Calander.SetThemeDefaults();
                    }
                }
            }

            [Editor(typeof (RangeEditor), typeof (UITypeEditor))]
            [MinMax(0, 100)]
            public int BackGroundImageAlpha
            {
                get { return Calander.BackGroundImageAlpha; }
                set
                {
                    if (Calander.BackGroundImageAlpha != value)
                    {
                        Calander.BackGroundImageAlpha = value;
                        Calander.SetThemeDefaults();
                    }
                }
            }

            public Image BackGroundImage
            {
                get { return Calander.BackgroundImage; }
                set
                {
                    if (Calander.BackgroundImage != value)
                    {
                        Calander.BackgroundImage = value;
                        Calander.SetThemeDefaults();
                    }
                }
            }

            public ImageLayout BackgroundImageLayout
            {
                get { return Calander.BackgroundImageLayout; }
                set
                {
                    if (Calander.BackgroundImageLayout != value)
                    {
                        Calander.BackgroundImageLayout = value;
                        Calander.SetThemeDefaults();
                    }
                }
            }

            [TypeConverter(typeof (FontConverter)), Editor(typeof (FontEditor), typeof (UITypeEditor))]
            public string NumberFont
            {
                get { return Calander.NumberFont; }
                set
                {
                    Calander.NumberFont = value;
                    Calander.SetThemeDefaults();
                }
            }

            [TypeConverter(typeof (FontConverter)), Editor(typeof (FontEditor), typeof (UITypeEditor))]
            public string CaptionFont
            {
                get { return Calander.CaptionFont; }
                set
                {
                    Calander.CaptionFont = value;
                    Calander.SetThemeDefaults();
                }
            }

            public ColorScheme ColorScheme
            {
                get { return Calander.ThemeProperty.ColorScheme; }
                set
                {
                    Calander.ThemeProperty.ColorScheme = value;
                    Calander.SetThemeDefaults();
                }
            }

            internal void ApplyTemplate()
            {
                object currentValue = Calander.Appearance;
                var editor = new MonthCalanderAppearanceEditor.AppearanceEditor((MonthCalanderAppearance) currentValue);
                editor.ShowDialog();
                Calander.Appearance.Assign(editor.Value);
                Calander.SetThemeDefaults();
            }

            internal void Reset()
            {
                Calander.Appearance.Reset();
                Calander.SetThemeDefaults();
                Calander.Invalidate();
            }

            internal void SaveStyle()
            {
                using (var dlg = new SaveFileDialog())
                {
                    dlg.Filter = "XML File (*.xml)|*.xml";
                    if (dlg.ShowDialog() != DialogResult.OK)
                        return;
                    using (XmlWriter writer = new XmlTextWriter(dlg.FileName, Encoding.UTF8))
                    {
                        var serializer = new XmlSerializer(typeof (MonthCalanderAppearance));
                        serializer.Serialize(writer, Calander.Appearance);
                        writer.Flush();
                        writer.Close();
                    }
                }
            }

            internal void LoadStyle()
            {
                using (var dlg = new OpenFileDialog())
                {
                    dlg.Filter = "XML File (*.xml)|*.xml";
                    if (dlg.ShowDialog() != DialogResult.OK)
                        return;
                    using (var fs = new FileStream(dlg.FileName, FileMode.Open))
                    {
                        var serializer = new XmlSerializer(typeof (MonthCalanderAppearance));
                        var app = (MonthCalanderAppearance) serializer.Deserialize(fs);
                        Calander.Appearance.Assign(app);
                    }
                }
                Calander.SetThemeDefaults();
                Calander.Invalidate();
            }

            public override DesignerActionItemCollection GetSortedActionItems()
            {
                var collection = new DesignerActionItemCollection
                                     {
                                         new DesignerActionPropertyItem("Appearance", "Appearance", "Appearance"),
                                         new DesignerActionPropertyItem("ColorScheme", "ColorScheme", "Appearance"),
                                         new DesignerActionPropertyItem("UseTheme", "UseTheme", "Appearance"),
                                         new DesignerActionPropertyItem("HotAppearance", "HotAppearance", "Appearance"),
                                         new DesignerActionPropertyItem("DrawFocused", "DrawFocused", "Appearance"),
                                         new DesignerActionPropertyItem("BackGroundImage", "BackGroundImage",
                                                                        "Appearance"),
                                         new DesignerActionPropertyItem("BackgroundImageLayout", "BackgroundImageLayout",
                                                                        "Appearance"),
                                         new DesignerActionPropertyItem("BackGroundImageAlpha", "BackGroundImageAlpha",
                                                                        "Appearance"),
                                         new DesignerActionPropertyItem("CaptionFont", "CaptionFont", "Appearance"),
                                         new DesignerActionPropertyItem("NumberFont", "NumberFont", "Appearance"),
                                         new DesignerActionMethodItem(this, "ApplyTemplate", "Apply Template",
                                                                      "Appearance", true),
                                         new DesignerActionMethodItem(this, "Reset", "Reset Appearance",
                                                                      "Appearance", true),
                                         new DesignerActionMethodItem(this, "SaveStyle", "Save Theme",
                                                                      "Appearance", true),
                                         new DesignerActionMethodItem(this, "LoadStyle", "Load Theme",
                                                                      "Appearance", true)
                                     };
                return collection;
            }
        }

        #endregion
    }
}