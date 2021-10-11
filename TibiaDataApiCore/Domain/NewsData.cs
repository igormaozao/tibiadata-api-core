using System.Collections.Generic;
using TibiaDataApiCore.Domain.Commons;
using static TibiaDataApiCore.Domain.BaseApiData;
using static TibiaDataApiCore.Domain.NewsData;
using static TibiaDataApiCore.Domain.NewsData.NewsList;

namespace TibiaDataApiCore.Domain {
    public record NewsData(NewsList newslist, Information information): BaseApiData(newslist, information) {

        public record NewsList(string type, IReadOnlyCollection<News> data): Data {

            public record News(
                int id,
                string type,
                string news,
                string apiurl,
                string tibiaurl,
                TimeZoneDate date
            );
        }
    }
}
