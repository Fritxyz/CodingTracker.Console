using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingTracker.Library.Models
{
    internal class CodingSession
    {
        internal int Id;
        internal DateTime StartTime;
        internal DateTime EndTime;
        internal TimeSpan Duration;

        internal string DurationString
        {
            
            set
            {
                _durationString = value;
                if (TimeSpan.TryParse(value, out var parsedDuration))
                    Duration = parsedDuration;
                else
                    Duration = TimeSpan.Zero;
            }
        }

    }
}
