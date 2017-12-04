using System;
using System.ComponentModel;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using CalanderControl.Design.Enums;
using CalanderControl.Design.Generics;

namespace CalanderControl.Design.Layout
{
    [Serializable]
    [TypeConverter(typeof (GenericConverter<CornerShape>))]
    public class CornerShape : ICloneable, IXmlSerializable
    {
        private CornerType bottomLeft;
        private CornerType bottomRight;
        private CornerType topLeft;
        private CornerType topRight;

        public CornerShape()
        {
            topLeft = CornerType.Round;
            topRight = CornerType.Round;
            bottomLeft = CornerType.Round;
            bottomRight = CornerType.Round;
        }

        public CornerShape(CornerType type)
        {
            topLeft = type;
            topRight = type;
            bottomLeft = type;
            bottomRight = type;
        }

        public CornerType BottomLeft
        {
            get { return bottomLeft; }
            set
            {
                if (bottomLeft != value)
                {
                    bottomLeft = value;
                    OnBorderCornerChanged(new GenericEventArgs<AppearanceAction>(AppearanceAction.Recreate));
                }
            }
        }

        public CornerType BottomRight
        {
            get { return bottomRight; }
            set
            {
                if (bottomRight != value)
                {
                    bottomRight = value;
                    OnBorderCornerChanged(new GenericEventArgs<AppearanceAction>(AppearanceAction.Recreate));
                }
            }
        }

        [Browsable(false)]
        public bool IsAllSquared
        {
            get
            {
                return ((((topLeft == CornerType.Square) && (topRight == CornerType.Square)) &&
                         (bottomLeft == CornerType.Square)) && (bottomRight == CornerType.Square));
            }
        }

        public CornerType TopLeft
        {
            get { return topLeft; }
            set
            {
                if (topLeft != value)
                {
                    topLeft = value;
                    OnBorderCornerChanged(new GenericEventArgs<AppearanceAction>(AppearanceAction.Recreate));
                }
            }
        }

        public CornerType TopRight
        {
            get { return topRight; }
            set
            {
                if (topRight != value)
                {
                    topRight = value;
                    OnBorderCornerChanged(new GenericEventArgs<AppearanceAction>(AppearanceAction.Recreate));
                }
            }
        }

        #region ICloneable Members

        public virtual object Clone()
        {
            var shape = new CornerShape();
            shape.TopLeft = topLeft;
            shape.TopRight = topRight;
            shape.BottomLeft = bottomLeft;
            shape.BottomRight = bottomRight;
            return shape;
        }

        #endregion

        #region Should serialize implementation

        public bool ShouldSerializeBottomLeft()
        {
            return bottomLeft != CornerType.Round;
        }

        public bool ShouldSerializeBottomRight()
        {
            return bottomRight != CornerType.Round;
        }

        public bool ShouldSerializeTopLeft()
        {
            return topLeft != CornerType.Round;
        }

        public bool ShouldSerializeTopRight()
        {
            return topRight != CornerType.Round;
        }

        #endregion

        #region Reset implementation

        public void ResetBottomLeft()
        {
            bottomLeft = CornerType.Round;
        }

        public void ResetBottomRight()
        {
            bottomRight = CornerType.Round;
        }

        public void ResetTopLeft()
        {
            topLeft = CornerType.Round;
        }

        public void ResetTopRight()
        {
            topRight = CornerType.Round;
        }

        #endregion

        public event GenericEventHandler<AppearanceAction> BorderCornerChanged;

        public virtual bool DefaultChanged()
        {
            return ((topLeft != CornerType.Round) ||
                    ((topRight != CornerType.Round) ||
                     ((bottomLeft != CornerType.Round) || (bottomRight != CornerType.Round))));
        }

        protected virtual void OnBorderCornerChanged(GenericEventArgs<AppearanceAction> e)
        {
            if (BorderCornerChanged != null)
            {
                BorderCornerChanged(this, e);
            }
        }

        ///<summary>
        ///Determines whether the specified <see cref="T:System.Object"></see> is equal to the current <see cref="T:System.Object"></see>.
        ///</summary>
        ///
        ///<returns>
        ///true if the specified <see cref="T:System.Object"></see> is equal to the current <see cref="T:System.Object"></see>; otherwise, false.
        ///</returns>
        ///
        ///<param name="obj">The <see cref="T:System.Object"></see> to compare with the current <see cref="T:System.Object"></see>. </param><filterpriority>2</filterpriority>
        public override bool Equals(object obj)
        {
            var shape = obj as CornerShape;
            if (shape != null)
            {
                return shape.bottomLeft == bottomLeft && shape.bottomRight == bottomRight && shape.topLeft == topLeft &&
                       shape.topRight == topRight;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }

        public void Assign(CornerShape shape)
        {
            TopLeft = shape.topLeft;
            TopRight = shape.topRight;
            BottomLeft = shape.bottomLeft;
            BottomRight = shape.bottomRight;
        }

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
            if (doc.GetElementsByTagName("BottomLeft").Count > 0)
                BottomLeft =
                    (CornerType) Enum.Parse(typeof (CornerType), doc.GetElementsByTagName("BottomLeft")[0].InnerText);
            if (doc.GetElementsByTagName("BottomRight").Count > 0)
                BottomRight =
                    (CornerType) Enum.Parse(typeof (CornerType), doc.GetElementsByTagName("BottomRight")[0].InnerText);
            if (doc.GetElementsByTagName("TopLeft").Count > 0)
                TopLeft = (CornerType) Enum.Parse(typeof (CornerType), doc.GetElementsByTagName("TopLeft")[0].InnerText);
            if (doc.GetElementsByTagName("TopRight").Count > 0)
                TopRight =
                    (CornerType) Enum.Parse(typeof (CornerType), doc.GetElementsByTagName("TopRight")[0].InnerText);
        }

        /// <summary>
        /// Converts an object into its XML representation.
        /// </summary>
        /// <param name="writer">The <see cref="T:System.Xml.XmlWriter"/> stream to which the object is serialized. </param>
        public void WriteXml(XmlWriter writer)
        {
            writer.WriteElementString("BottomLeft", BottomLeft.ToString());
            writer.WriteElementString("BottomRight", BottomRight.ToString());
            writer.WriteElementString("TopLeft", TopLeft.ToString());
            writer.WriteElementString("TopRight", TopRight.ToString());
        }

        #endregion
    }
}