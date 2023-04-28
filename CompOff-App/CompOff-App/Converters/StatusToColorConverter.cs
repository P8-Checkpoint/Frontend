using CompOff_App.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompOff_App.Converters
{
    public class StatusToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            JobStatus status = (JobStatus)value;
            switch (status)
            {
                case JobStatus.Waiting:
                    return Color.FromRgba("#FAD116");
                case JobStatus.InQueue:
                    return Color.FromRgba("#4BB4DE");
                case JobStatus.Running:
                    return Color.FromRgba("#345DA7");
                case JobStatus.Cancelled:
                    return Color.FromRgba("#FF0000");
                case JobStatus.Done:
                    return Color.FromRgba("#00DE00");
                default:
                    return Color.FromRgba("#F1EAE6");
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
