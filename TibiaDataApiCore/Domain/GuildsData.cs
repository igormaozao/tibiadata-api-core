using System.Collections.Generic;
using static TibiaDataApiCore.Domain.BaseApiData;
using static TibiaDataApiCore.Domain.GuildsData;
using static TibiaDataApiCore.Domain.GuildsData.GuildsList;

namespace TibiaDataApiCore.Domain {
    public record GuildsData(GuildsList Guilds, BaseInformation Information): BaseApiData(Guilds, Information) {

        public record GuildsList(string World, IReadOnlyCollection<Guild> Active, IReadOnlyCollection<Guild> Formation): BaseData() {

            public record Guild(string Name, string Desc, string Guildlogo);
        }
    }
}
