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
                if (TimeSpan.TryParse(value, out var parsedDuration))
                    Duration = parsedDuration;
                else
                    Duration = TimeSpan.Zero;
            }
        }

    }
}
