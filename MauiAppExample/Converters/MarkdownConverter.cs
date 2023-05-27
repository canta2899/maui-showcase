using System;
using System.Globalization;

namespace MauiAppExample.Converters;

public class MarkdownConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is not string) return null;

        var converted = Markdig.Markdown.ToHtml((string)value);

        return converted;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        // no convert back operation required
        throw new NotImplementedException();
    }
}

