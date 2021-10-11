using TibiaDataApiCore.Domain.Commons;
using static TibiaDataApiCore.Domain.BaseApiData;
using static TibiaDataApiCore.Domain.NewsInformationData;

namespace TibiaDataApiCore.Domain {
    public record NewsInformationData(News news, Information information) {

        public record News(
            int id,
            string title,
            string content,
            TimeZoneDate date
        );
    }
}
