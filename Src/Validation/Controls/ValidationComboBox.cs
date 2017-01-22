using System.Collections.ObjectModel;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Prism.Windows.Validation;

namespace Validation.Controls
{
    public sealed class ValidationComboBox : ComboBox
    {
        public ValidationComboBox()
        {
            DefaultStyleKey = typeof(ValidationComboBox);
        }

        public static readonly DependencyProperty ValidationErrorProperty = DependencyProperty.Register(
            nameof(ValidationError), typeof(ReadOnlyCollection<string>), typeof(ValidationComboBox), new PropertyMetadata(BindableValidator.EmptyErrorsCollection, OnValidationErrorsChanged));

        public ReadOnlyCollection<string> ValidationError
        {
            get { return (ReadOnlyCollection<string>)GetValue(ValidationErrorProperty); }
            set { SetValue(ValidationErrorProperty, value); }
        }

        private static void OnValidationErrorsChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs args)
        {
            if (args == null || args.NewValue == null)
            {
                return;
            }

            ValidationComboBox currentComboBox = dependencyObject as ValidationComboBox;
            if (currentComboBox != null)
            {
                var propertyErrors = (ReadOnlyCollection<string>)args.NewValue;
                Style comboboxStyle = (propertyErrors != null && propertyErrors.Any())
                ? (Style)Application.Current.Resources["HighlightComboBoxStyle"]
                : (Style)Application.Current.Resources["ValidationComboBoxStyle"];
                currentComboBox.Style = comboboxStyle;
            }
        }
    }
}
