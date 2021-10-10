using System;
using System.Collections.Generic;
using static TibiaDataApiCore.Domain.BaseApiData;
using static TibiaDataApiCore.Domain.HighscoresData;
using static TibiaDataApiCore.Domain.HighscoresData.Highscores;

namespace TibiaDataApiCore.Domain {
    public record HighscoresData(Highscores highscores, Information information) 
        : BaseApiData(highscores, information) {

        public record Highscores(Filter filters, IReadOnlyList<Character> data): Data {

            public record Filter(string world, string category, string vocation);
            public record Character(string name, short rank, string vocation, string world, UInt64 points, short level);

        }
    }
}
