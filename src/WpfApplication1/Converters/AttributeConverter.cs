using System;
using System.Reflection;
using System.Windows.Data;

namespace WpfApplication1.Converters
{
    public abstract class AttributeConverter<T> : IValueConverter
        where T : Attribute
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var property = parameter as PropertyInfo;

            if (property == null)
                return new ArgumentNullException("parameter").ToString();

            if (!property.IsDefined(typeof(T), true))
                return new ArgumentOutOfRangeException("parameter", parameter,
                    "Property \"" + property.Name + "\" has no associated " + typeof(T).Name + " attribute.").ToString();

            return GetValueFromAttribute((T)property.GetCustomAttributes(typeof(T), true)[0]);
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException();
        }

        public abstract object GetValueFromAttribute(T attribute);
    }
}