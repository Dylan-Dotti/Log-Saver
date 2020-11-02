using System;

namespace LogSaverClient
{
    public struct TimeRange
    {
        public DateTime LowerDateTime { get; private set; }
        public DateTime UpperDateTime { get; private set; }

        public TimeRange(DateTime time1, DateTime time2)
        {
            if (time1 <= time2)
            {
                LowerDateTime = time1;
                UpperDateTime = time2;
            }
            else
            {
                LowerDateTime = time2;
                UpperDateTime = time1;
            }
        }

        public TimeRange ToUtc()
        {
            return new TimeRange(TimeZoneInfo.ConvertTimeToUtc(LowerDateTime),
                TimeZoneInfo.ConvertTimeToUtc(UpperDateTime));
        }

        public override string ToString()
        {
            return $"({LowerDateTime}, {UpperDateTime})";
        }

        public (DateTime lowerBound, DateTime upperBound) ToTuple()
        {
            return (LowerDateTime, UpperDateTime);
        }
    }
}
