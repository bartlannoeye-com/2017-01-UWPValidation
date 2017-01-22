using System.Collections.ObjectModel;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Prism.Windows.Validation;

namespace Validation.Controls
{
    public sealed class ValidationTextBox : TextBox
    {
        public ValidationTextBox()
        {
            DefaultStyleKey = typeof(ValidationTextBox);
        }

        public static readonly DependencyProperty ValidationErrorProperty = DependencyProperty.Register(
            nameof(ValidationError), typeof(ReadOnlyCollection<string>), typeof(ValidationTextBox), new PropertyMetadata(BindableValidator.EmptyErrorsCollection, OnValidationErrorsChanged));

        public ReadOnlyCollection<string> ValidationError
        {
            get { return (ReadOnlyCollection<string>)GetValue(ValidationErrorProperty); }
            set { SetValue(ValidationErrorProperty, value); }
        }

        private static void OnValidationErrorsChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs args)
        {
            if (args?.NewValue == null)
            {
                return;
            }

            ValidationTextBox currentTextBox = dependencyObject as ValidationTextBox;
            if (currentTextBox != null)
            {
                var propertyErrors = (ReadOnlyCollection<string>)args.NewValue;
                Style textBoxStyle = (propertyErrors != null && propertyErrors.Any())
                ? (Style)Application.Current.Resources["HighlightTextStyle"]
                : (Style)Application.Current.Resources["ValidationTextBoxStyle"];
                currentTextBox.Style = textBoxStyle;
            }
        }
    }
}
