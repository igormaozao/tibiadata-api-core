using System;
using static TibiaDataApiCore.Domain.BaseApiData;

namespace TibiaDataApiCore.Domain {
    public record BaseApiData(Data data, Information information) {

        public abstract record Data;

        public record Information(
            short ApiVersion,
            float ExecutionTime,
            DateTime LastUpdated,
            DateTime Timestamp
        );
    }
}
