using System;
using static TibiaDataApiCore.Domain.BaseApiData;

namespace TibiaDataApiCore.Domain {
    public record BaseApiData(BaseData Data, BaseInformation Information) {

        public abstract record BaseData;

        public record BaseInformation(
            short ApiVersion,
            float ExecutionTime,
            DateTime LastUpdated,
            DateTime Timestamp
        );
    }
}
