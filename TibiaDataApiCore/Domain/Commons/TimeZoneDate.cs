using System;

namespace TibiaDataApiCore.Domain.Commons {
    public record TimeZoneDate(DateTime date, short timezoneType, string timezone);
}
