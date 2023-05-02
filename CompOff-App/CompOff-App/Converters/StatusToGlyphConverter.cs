using CompOff_App.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompOff_App.Converters
{
    public class StatusToGlyphConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            JobStatus status = (JobStatus)value;
            return status switch
            {
                JobStatus.Waiting => "&#xef64;",
                JobStatus.InQueue => "&#xe8b5;",
                JobStatus.Running => "&#xef6f;",
                JobStatus.Cancelled => "&#xe5c9;",
                JobStatus.Done => "&#xe86c;",
                _ => "&#xef64;",
            };
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
