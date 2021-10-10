using System.Collections.Generic;
using static TibiaDataApiCore.Domain.BaseApiData;
using static TibiaDataApiCore.Domain.GuildsData;
using static TibiaDataApiCore.Domain.GuildsData.Guilds;

namespace TibiaDataApiCore.Domain {
    public record GuildsData(Guilds guilds, Information information): BaseApiData(guilds, information) {

        public record Guilds(string world, IReadOnlyCollection<Guild> active, IReadOnlyCollection<Guild> formation): Data() {

            public record Guild(string name, string desc, string guildlogo);
        }
    }
}
