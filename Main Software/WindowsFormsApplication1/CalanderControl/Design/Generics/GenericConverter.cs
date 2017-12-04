using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Globalization;
using System.Reflection;

namespace CalanderControl.Design.Generics
{
    public class GenericConverter<T> : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return ((sourceType == typeof (string)) || base.CanConvertFrom(context, sourceType));
        }

        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            return ((destinationType == typeof (InstanceDescriptor)) || base.CanConvertTo(context, destinationType));
        }

        public override bool GetPropertiesSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        public override bool GetCreateInstanceSupported(ITypeDescriptorContext context)
        {
            if (context.PropertyDescriptor != null)
                return !context.PropertyDescriptor.IsReadOnly;
            return true;
        }

        public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value,
                                                                   Attribute[] attributes)
        {
            return TypeDescriptor.GetProperties(typeof (T), attributes);
        }

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            var text = value as string;
            if (text == null)
            {
                return base.ConvertFrom(context, culture, value);
            }
            string text2 = text.Trim();

            if (context == null)
            {
                return null;
            }
            if (text2.Length == 0)
            {
                return null;
            }
            if (culture == null)
            {
                culture = CultureInfo.CurrentCulture;
            }
            char ch = culture.TextInfo.ListSeparator[0];
            string[] textArray = text2.Split(new[] {ch});
            PropertyInfo[] properties = typeof (T).GetProperties();
            object instance = Assembly.GetAssembly(typeof (T)).CreateInstance(typeof (T).ToString());
            ConstructorInfo constructor = typeof (T).GetConstructor(new Type[0]);
            int current = 0;
            if (constructor != null)
            {
                for (int i = 0; i < properties.Length; i++)
                {
                    if (!properties[i].CanWrite)
                    {
                        continue;
                    }
                    string s = TypeDescriptor.GetConverter(properties[i].PropertyType).ConvertToString(context, culture,
                                                                                                       properties[i].
                                                                                                           GetValue(
                                                                                                           instance,
                                                                                                           null));
                    int count = s.Split(new[] {ch}).Length;
                    string tmpString = string.Empty;
                    for (int j = 0; j < count; j++)
                    {
                        tmpString += textArray[current + j] + ch;
                    }
                    current += count;
                    string[] parts = tmpString.Trim(new[] {ch}).Split(new[] {"="}, StringSplitOptions.None);
                    if (TypeDescriptor.GetConverter(properties[i].PropertyType).CanConvertFrom(typeof (string)))
                    {
                        if (parts.Length == 2)
                        {
                            object val =
                                TypeDescriptor.GetConverter(properties[i].PropertyType).ConvertFromString(
                                    parts[1].Trim(new[] {'[', ']'}));
                            properties[i].SetValue(instance, val, new object[0]);
                        }
                        else
                        {
                            string strings = tmpString.Replace(parts[0], string.Empty).Trim('=');
                            object val =
                                TypeDescriptor.GetConverter(properties[i].PropertyType).ConvertFromString(context,
                                                                                                          culture,
                                                                                                          strings);
                            properties[i].SetValue(instance, val, new object[0]);
                        }
                    }
                    else
                    {
                        object val = properties[i].GetValue(context.PropertyDescriptor.GetValue(context.Instance), null);
                        properties[i].SetValue(instance, val, new object[0]);
                    }
                }
            }
            return instance;
        }

        public override object CreateInstance(ITypeDescriptorContext context, IDictionary propertyValues)
        {
            if (propertyValues == null)
            {
                throw new ArgumentNullException("propertyValues");
            }
            object instance = Assembly.GetAssembly(typeof (T)).CreateInstance(typeof (T).ToString());
            PropertyInfo[] properties = typeof (T).GetProperties();
            for (int i = 0; i < properties.Length; i++)
            {
                if (!properties[i].CanWrite)
                {
                    continue;
                }
                if (propertyValues[properties[i].Name] == null)
                {
                    continue;
                }
                properties[i].SetValue(instance, propertyValues[properties[i].Name], new object[0]);
            }
            return instance;
        }

        //public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        //{
        //    if (destinationType == null)
        //    {
        //        throw new ArgumentNullException("destinationType");
        //    }
        //    if (value is T)
        //    {
        //        return value.ToString();
        //    }
        //    return base.ConvertTo(context, culture, value, destinationType);
        //}

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value,
                                         Type destinationType)
        {
            if (destinationType == null)
            {
                throw new ArgumentNullException("destinationType");
            }
            if (value is GenericCollection<T>)
            {
                return base.ConvertTo(context, culture, value, destinationType);
            }
            if (value is T)
            {
                if (destinationType == typeof (string))
                {
                    var tVal = (T) value;
                    if (culture == null)
                    {
                        culture = CultureInfo.CurrentCulture;
                    }
                    PropertyInfo[] properties = tVal.GetType().GetProperties();
                    string separator = culture.TextInfo.ListSeparator[0].ToString();
                    var textArray = new string[properties.Length];
                    for (int i = 0; i < properties.Length; i++)
                    {
                        if (properties[i].CanWrite)
                        {
                            textArray[i] = properties[i].Name + "=[" +
                                           TypeDescriptor.GetConverter(properties[i].PropertyType).ConvertToString(
                                               context, culture, properties[i].GetValue(value, null)) + "]";
                        }
                    }
                    string retVal = string.Empty;
                    for (int i = 0; i < textArray.Length; i++)
                    {
                        if (textArray[i] != null)
                        {
                            retVal += textArray[i] + separator;
                        }
                    }
                    return retVal.TrimEnd(new[] {separator[0]});
                }
                if (destinationType == typeof (InstanceDescriptor))
                {
                    return new InstanceDescriptor(typeof (T).GetConstructor(new Type[0]), null, false);
                }
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }
    }
}