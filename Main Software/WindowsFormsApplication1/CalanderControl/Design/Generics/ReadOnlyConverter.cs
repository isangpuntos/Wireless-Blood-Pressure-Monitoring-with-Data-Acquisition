using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace CalanderControl.Design.Generics
{
    public class ReadOnlyConverter : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return false;
        }

        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            return false;
        }

        public override bool GetCreateInstanceSupported(ITypeDescriptorContext context)
        {
            return false;
        }

        public override bool GetPropertiesSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value,
                                                                   Attribute[] attributes)
        {
            var init = TypeDescriptor.GetProperties(value.GetType(), attributes);
            var pds = new PropertyDescriptor[init.Count];
            for (var i = 0; i < init.Count; i++)
            {
                if (!init[i].IsBrowsable)
                    continue;
                var attrs = new List<Attribute>();
                for (var j = 0; j < attributes.Length; j++)
                {
                    attrs.Add(attributes[j]);
                }
                attrs.Add(new ReadOnlyAttribute(true));
                if (init[i].Converter == null || !init[i].Converter.GetType().Assembly.GlobalAssemblyCache)
                {
                    attrs.Add(new TypeConverterAttribute(typeof (ReadOnlyConverter)));
                }
                attrs.Add(new DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Hidden));
                pds[i] = new PD(init[i].ComponentType, init[i].Name, init[i].PropertyType, attrs.ToArray());
            }
            return new PropertyDescriptorCollection(pds);
        }

        #region Nested type: PD

        private class PD : SimplePropertyDescriptor
        {
            public PD(Type componentType, string name, Type propertyType, Attribute[] attributes)
                : base(componentType, name, propertyType, attributes)
            {
            }

            #region Overrides of PropertyDescriptor

            /// <summary>
            /// When overridden in a derived class, gets the current value of the property on a component.
            /// </summary>
            /// <returns>
            /// The value of a property for a given component.
            /// </returns>
            /// <param name="component">The component with the property for which to retrieve the value. </param>
            public override object GetValue(object component)
            {
                return component.GetType().GetProperty(Name).GetValue(component, null);
            }

            /// <summary>
            /// When overridden in a derived class, sets the value of the component to a different value.
            /// </summary>
            /// <param name="component">The component with the property value that is to be set. </param><param name="value">The new value. </param>
            public override void SetValue(object component, object value)
            {
            }

            #endregion
        }

        #endregion
    }
}