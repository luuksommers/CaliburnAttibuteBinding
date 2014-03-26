using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Data;
using Caliburn.Micro;
using WpfApplication1.Converters;
using Xceed.Wpf.Toolkit;

namespace WpfApplication1
{
    public class MyBootstrapper : Bootstrapper<ShellViewModel>
    {
        private static readonly IValueConverter RangeMaximumConverter = new RangeMaximumConverter();
        private static readonly IValueConverter RangeMinimumConverter = new RangeMinimumConverter();
        private static readonly IValueConverter MaxLengthConverter = new MaxLengthConverter();

        protected override void Configure()
        {
            base.Configure();

            ConventionManager.AddElementConvention<DecimalUpDown>(DecimalUpDown.ValueProperty, "Value", "ValueChanged").ApplyBinding =
                (viewModelType, path, property, element, convention) =>
                {
                    if (!ConventionManager.SetBindingWithoutBindingOrValueOverwrite(viewModelType, path, property, element, convention, DecimalUpDown.ValueProperty))
                        return false;

                    if (property.GetCustomAttributes(typeof(RangeAttribute), true).Any())
                    {
                        if (!ConventionManager.HasBinding(element, DecimalUpDown.MaximumProperty))
                        {
                            var binding = new Binding(path) { Mode = BindingMode.OneTime, Converter = RangeMaximumConverter, ConverterParameter = property };
                            BindingOperations.SetBinding(element, DecimalUpDown.MaximumProperty, binding);
                        }

                        if (!ConventionManager.HasBinding(element, DecimalUpDown.MinimumProperty))
                        {
                            var binding = new Binding(path) { Mode = BindingMode.OneTime, Converter = RangeMinimumConverter, ConverterParameter = property };
                            BindingOperations.SetBinding(element, DecimalUpDown.MinimumProperty, binding);
                        }
                    }

                    return true;
                };

            var originalBinding = ConventionManager.GetElementConvention(typeof(TextBox)).ApplyBinding;
            ConventionManager.GetElementConvention(typeof(TextBox)).ApplyBinding =
                (viewModelType, path, property, element, convention) =>
                {
                    if (!originalBinding(viewModelType, path, property, element, convention))
                        return false;

                    if (property.GetCustomAttributes(typeof(StringLengthAttribute), true).Any())
                    {
                        if (!ConventionManager.HasBinding(element, TextBox.MaxLengthProperty))
                        {
                            var binding = new Binding(path) { Mode = BindingMode.OneTime, Converter = MaxLengthConverter, ConverterParameter = property };
                            BindingOperations.SetBinding(element, TextBox.MaxLengthProperty, binding);
                        }
                    }
                    return true;
                };
        }
    }
}
