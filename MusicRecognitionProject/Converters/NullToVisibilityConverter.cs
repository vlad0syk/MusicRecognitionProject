using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using MusicRecognitionProject.Utils;

namespace MusicRecognitionProject.Converters
{
    class NullToVisibilityConverter : IValueConverter

    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            try
            {
                if (value != null)
                    return Visibility.Visible;

                return Visibility.Collapsed;
            }
            catch (Exception ex)
            {
                Logger.LogInfo(ex);
                return System.Windows.Visibility.Collapsed;
            }
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            return Binding.DoNothing;
        }
    }
}
