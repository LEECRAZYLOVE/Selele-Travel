using System;
using System.Globalization;
using System.IO;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace SeleleTravel
{
    /// <summary>
    /// Converts a full path to a specific image type of a drive, folder or file
    /// </summary>
    public class PathToImageBrushConverter : BaseValueConverter<PathToImageBrushConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // path  t the image
            string path = value as string;

            // return nothing if there's no image
            if (path is null) return null;
            string theFullPath = Path.GetFullPath(path);

            try
            {
                // the image
                return new ImageBrush(new BitmapImage(new Uri(theFullPath)));
            }
            catch(Exception ex)
            {
                return null;
            }
            
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
