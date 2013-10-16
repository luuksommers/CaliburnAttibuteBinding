using Caliburn.Micro;
using System.ComponentModel.DataAnnotations;

namespace WpfApplication1
{
    public class ShellViewModel : PropertyChangedBase
    {
        decimal decimalValue;

        public ShellViewModel()
        {
            DecimalValue = 5;
        }

        [Range(0,10)]
        public decimal DecimalValue
        {
            get { return decimalValue; }
            set
            {
                decimalValue = value;
                NotifyOfPropertyChange(() => DecimalValue);
            }
        }
    }
}
