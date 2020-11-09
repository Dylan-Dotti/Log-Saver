using Newtonsoft.Json;
using System;

namespace TimeUtilities
{
    public struct DateTimeRange
    {
        [JsonProperty("LowerDateTime", Order = 1, Required = Required.Always)]
        public DateTime LowerDateTime { get; private set; }

        [JsonProperty("UpperDateTime", Order = 2, Required = Required.Always)]
        public DateTime UpperDateTime { get; private set; }

        [JsonIgnore]
        public DateTimeKind Kind => LowerDateTime.Kind;

        public DateTimeRange(DateTime time1, DateTime time2)
        {
            if (time1.Kind != time2.Kind)
            {
                throw new ArgumentException(
                    "DateTimeKind values of both times must be equal." +
                    $"Kind 1: {time1.Kind}, Kind 2: {time2.Kind}.");
            }
            LowerDateTime = time1 <= time2 ? time1 : time2;
            UpperDateTime = time1 < time2 ? time2 : time1;
        }

        public DateTimeRange ToUtc()
        {
            return new DateTimeRange(TimeZoneInfo.ConvertTimeToUtc(LowerDateTime),
                TimeZoneInfo.ConvertTimeToUtc(UpperDateTime));
        }

        public DateTimeRange ToLocal()
        {
            return new DateTimeRange(LowerDateTime.ToLocalTime(), UpperDateTime.ToLocalTime());
        }

        public override string ToString()
        {
            return $"TimeRange:({LowerDateTime}, {UpperDateTime})";
        }

        public (DateTime lowerBound, DateTime upperBound) ToTuple()
        {
            return (LowerDateTime, UpperDateTime);
        }
    }
}
