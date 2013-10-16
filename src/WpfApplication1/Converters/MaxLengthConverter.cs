using System.ComponentModel.DataAnnotations;

namespace WpfApplication1.Converters
{
    public sealed class MaxLengthConverter : AttributeConverter<StringLengthAttribute>
    {
        public override object GetValueFromAttribute(StringLengthAttribute attribute)
        {
            return attribute.MaximumLength;
        }
    }
}