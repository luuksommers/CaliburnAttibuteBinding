using Caliburn.Micro;
using System.ComponentModel.DataAnnotations;

namespace WpfApplication1
{
    public class ShellViewModel : PropertyChangedBase
    {
        private decimal _decimalValue;
        private string _stringValue;

        public ShellViewModel()
        {
            DecimalValue = 5;
            StringValue = "This is a test";
        }

        [Range(0,10)]
        public decimal DecimalValue
        {
            get { return _decimalValue; }
            set
            {
                _decimalValue = value;
                NotifyOfPropertyChange(() => DecimalValue);
            }
        }

        [StringLength(20)]
        public string StringValue
        {
            get { return _stringValue; }
            set
            {
                _stringValue = value;
                NotifyOfPropertyChange(() => StringValue);
            }
        }
    }
}
