using TibiaDataApiCore.Domain.Commons;
using static TibiaDataApiCore.Domain.BaseApiData;
using static TibiaDataApiCore.Domain.NewsInformationData;

namespace TibiaDataApiCore.Domain {
    public record NewsInformationData(NewsInfo News, BaseInformation Information) {

        public record NewsInfo(
            int Id,
            string Title,
            string Content,
            TimeZoneDate Date
        );
    }
}
