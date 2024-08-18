namespace CodingTracker.Library
{
    internal static class Validations
    {
        internal static bool DateTimeValidations(DateTime startTime, DateTime endTime) => startTime < endTime && endTime > startTime;
    }
}
