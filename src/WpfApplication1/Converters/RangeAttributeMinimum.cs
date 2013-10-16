using System.ComponentModel.DataAnnotations;

namespace WpfApplication1.Converters
{
    public sealed class RangeMinimumConverter : AttributeConverter<RangeAttribute>
    {
        public override object GetValueFromAttribute(RangeAttribute attribute)
        {
            return attribute.Minimum;
        }
    }
}