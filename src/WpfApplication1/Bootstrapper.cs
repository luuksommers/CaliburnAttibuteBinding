using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using Xceed.Wpf.Toolkit;

namespace WpfApplication1
{
    public class MyBootstrapper : Bootstrapper<ShellViewModel> 
    {
        private static readonly IValueConverter RangeAttributeMaximum = new RangeMaximumConverter();
        private static readonly IValueConverter RangeMinimumConverter = new RangeMinimumConverter();

        protected override void Configure()
        {
            base.Configure();

            ConventionManager.AddElementConvention<DecimalUpDown>(DecimalUpDown.ValueProperty, "Value", "ValueChanged").ApplyBinding =
                (viewModelType, path, property, element, convention) =>
                {
                    if (!ConventionManager.SetBindingWithoutBindingOrValueOverwrite(viewModelType, path, property, element, convention, DecimalUpDown.ValueProperty))
                        return false;

                    if (ConventionManager.HasBinding(element, DecimalUpDown.MaximumProperty)) 
                        return true;

                    var binding = new Binding(path) { Mode = BindingMode.OneTime, Converter = RangeAttributeMaximum, ConverterParameter = property };
                    BindingOperations.SetBinding(element, DecimalUpDown.MaximumProperty, binding);

                    if (ConventionManager.HasBinding(element, DecimalUpDown.MinimumProperty))
                        return true;

                    binding = new Binding(path) { Mode = BindingMode.OneTime, Converter = RangeMinimumConverter, ConverterParameter = property };
                    BindingOperations.SetBinding(element, DecimalUpDown.MinimumProperty, binding);

                    return true;
                };
        }
    }
}
