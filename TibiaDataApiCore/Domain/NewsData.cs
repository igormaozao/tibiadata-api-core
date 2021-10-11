using System.Collections.Generic;
using TibiaDataApiCore.Domain.Commons;
using static TibiaDataApiCore.Domain.BaseApiData;
using static TibiaDataApiCore.Domain.NewsData;
using static TibiaDataApiCore.Domain.NewsData.NewsList;

namespace TibiaDataApiCore.Domain {
    public record NewsData(NewsList Newslist, BaseInformation Information): BaseApiData(Newslist, Information) {

        public record NewsList(string Type, IReadOnlyCollection<NewsInfo> Data): BaseData {

            public record NewsInfo(
                int Id,
                string Type,
                string News,
                string Apiurl,
                string Tibiaurl,
                TimeZoneDate Date
            );
        }
    }
}
