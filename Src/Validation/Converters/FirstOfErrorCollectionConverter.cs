using System;
using System.Collections.ObjectModel;
using Windows.UI.Xaml.Data;

namespace Validation.Converters
{
    /// <summary>
    /// Gets the first error string out of a collection
    /// </summary>
    public class FirstOfErrorCollectionConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value is ReadOnlyCollection<string>)
            {
                var collection = (ReadOnlyCollection<string>)value;
                return collection.Count > 0 ? collection[0] : string.Empty;
            }

            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
