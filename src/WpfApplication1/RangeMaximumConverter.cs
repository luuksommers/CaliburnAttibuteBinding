using System.ComponentModel.DataAnnotations;

namespace WpfApplication1
{
    public sealed class RangeMaximumConverter : AttributeConverter<RangeAttribute>
    {
        public override object GetValueFromAttribute(RangeAttribute attribute)
        {
            return attribute.Maximum;
        }
    }
}
