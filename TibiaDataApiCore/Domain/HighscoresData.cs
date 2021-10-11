using System.Collections.Generic;
using static TibiaDataApiCore.Domain.BaseApiData;
using static TibiaDataApiCore.Domain.HighscoresData;
using static TibiaDataApiCore.Domain.HighscoresData.HighscoresList;

namespace TibiaDataApiCore.Domain {
    public record HighscoresData(HighscoresList Highscores, BaseInformation Information) 
        : BaseApiData(Highscores, Information) {

        public record HighscoresList(Filter Filters, IReadOnlyList<Character> Data): BaseData {

            public record Filter(string World, string Category, string Vocation);
            public record Character(string Name, short Rank, string Vocation, string World, ulong Points, short Level);

        }
    }
}
