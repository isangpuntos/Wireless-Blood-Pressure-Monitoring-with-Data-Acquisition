using System;
using System.ComponentModel;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using CalanderControl.Design.Enums;
using CalanderControl.Design.Generics;

namespace CalanderControl.Design.Layout
{
    [Serializable]
    [TypeConverter(typeof (GenericConverter<BorderAppearance>))]
    public class BorderAppearance : ICloneable, IDisposable, IXmlSerializable
    {
        private DashStyle borderLineStyle = DashStyle.Solid;
        private ToolStripStatusLabelBorderSides borderVisibility = ToolStripStatusLabelBorderSides.All;
        private CornerShape cornerShape;

        public BorderAppearance()
        {
            cornerShape = new CornerShape();
        }

        [TypeConverter(typeof (GenericConverter<CornerShape>))]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public CornerShape CornerShape
        {
            get { return cornerShape; }
        }

        public DashStyle BorderLineStyle
        {
            get { return borderLineStyle; }
            set
            {
                if (borderLineStyle != value)
                {
                    borderLineStyle = value;
                    OnAppearanceChanged(new GenericEventArgs<AppearanceAction>(AppearanceAction.Recreate));
                }
            }
        }

        public ToolStripStatusLabelBorderSides BorderVisibility
        {
            get { return borderVisibility; }
            set
            {
                if (borderVisibility != value)
                {
                    borderVisibility = value;
                    OnAppearanceChanged(new GenericEventArgs<AppearanceAction>(AppearanceAction.Recreate));
                }
            }
        }

        #region ICloneable Members

        public virtual object Clone()
        {
            var borderAppearance = new BorderAppearance();
            borderAppearance.CornerShape.Assign((CornerShape) cornerShape.Clone());
            borderAppearance.BorderLineStyle = borderLineStyle;
            borderAppearance.BorderVisibility = borderVisibility;
            return borderAppearance;
        }

        #endregion

        #region IDisposable Members

        public virtual void Dispose()
        {
            if (cornerShape != null)
            {
                cornerShape.BorderCornerChanged -= OnBorderCornerChanged;
            }
        }

        #endregion

        public event GenericEventHandler<AppearanceAction> AppearanceChanged;

        public virtual bool DefaultChanged()
        {
            return borderLineStyle != DashStyle.Solid || borderVisibility != ToolStripStatusLabelBorderSides.All ||
                   CornerShape.DefaultChanged();
        }

        protected void OnBorderCornerChanged(object sender, GenericEventArgs<AppearanceAction> e)
        {
            OnAppearanceChanged(e);
        }

        protected virtual void OnAppearanceChanged(GenericEventArgs<AppearanceAction> e)
        {
            if (AppearanceChanged != null)
            {
                AppearanceChanged(this, e);
            }
        }

        public virtual void Reset()
        {
            cornerShape = new CornerShape();
            borderLineStyle = DashStyle.Solid;
            borderVisibility = ToolStripStatusLabelBorderSides.All;
        }

        internal void Assign(BorderAppearance borderAppearance)
        {
            CornerShape.Assign((CornerShape) borderAppearance.cornerShape.Clone());
            BorderLineStyle = borderAppearance.borderLineStyle;
            BorderVisibility = borderAppearance.borderVisibility;
        }

        #region Should serialize implementation used by designer

        public bool ShouldSerializeCornerShape()
        {
            return cornerShape.DefaultChanged();
        }

        public bool ShouldSerializeBorderLineStyle()
        {
            return borderLineStyle != DashStyle.Solid;
        }

        public bool ShouldSerializeBorderVisibility()
        {
            return borderVisibility != ToolStripStatusLabelBorderSides.All;
        }

        #endregion

        #region Reset implementation used by designer

        public void ResetCornerShape()
        {
            cornerShape = new CornerShape();
        }

        public void ResetBorderLineStyle()
        {
            borderLineStyle = DashStyle.Solid;
        }

        public void ResetBorderVisibility()
        {
            borderVisibility = ToolStripStatusLabelBorderSides.All;
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
            if (doc.GetElementsByTagName("BorderLineStyle").Count > 0)
                BorderLineStyle =
                    (DashStyle) Enum.Parse(typeof (DashStyle), doc.GetElementsByTagName("BorderLineStyle")[0].InnerText);
            if (doc.GetElementsByTagName("BorderVisibility").Count > 0)
                BorderVisibility =
                    (ToolStripStatusLabelBorderSides)
                    Enum.Parse(typeof (ToolStripStatusLabelBorderSides),
                               doc.GetElementsByTagName("BorderVisibility")[0].InnerText);
            if (doc.GetElementsByTagName("CornerShape").Count > 0)
            {
                string xml = "<CornerShape>" + doc.GetElementsByTagName("CornerShape")[0].InnerXml + "</CornerShape>";
                CornerShape.ReadXml(new XmlTextReader(xml, XmlNodeType.Document, null));
            }
        }

        /// <summary>
        /// Converts an object into its XML representation.
        /// </summary>
        /// <param name="writer">The <see cref="T:System.Xml.XmlWriter"/> stream to which the object is serialized. </param>
        public void WriteXml(XmlWriter writer)
        {
            writer.WriteElementString("BorderLineStyle", BorderLineStyle.ToString());
            writer.WriteElementString("BorderVisibility", BorderVisibility.ToString());
            writer.WriteStartElement("CornerShape");
            CornerShape.WriteXml(writer);
            writer.WriteEndElement();
        }

        #endregion
    }
}