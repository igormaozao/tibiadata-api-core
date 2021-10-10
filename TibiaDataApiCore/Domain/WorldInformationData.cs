using System.Collections.Generic;
using TibiaDataApiCore.Domain.Commons;
using static TibiaDataApiCore.Domain.BaseApiData;
using static TibiaDataApiCore.Domain.WorldInformationData;
using static TibiaDataApiCore.Domain.WorldInformationData.World;
using static TibiaDataApiCore.Domain.WorldInformationData.World.WorldInformation;

namespace TibiaDataApiCore.Domain {
    public record WorldInformationData(World world, Information information) : BaseApiData(world, information) {

        public record World(WorldInformation worldInformation, IReadOnlyCollection<PlayersOnline> playersOnline): Data() {
            
            public record WorldInformation(string name, int playersOnline, OnlineRecord onlineRecord, string creationDate, string location, string pvpType, IReadOnlyCollection<string> worldQuestTitles, string battleyeStatus) {
                
                public record OnlineRecord(int players, TimeZoneDate date);
            }

            public record PlayersOnline(string name, short level, string vocation);
        }
    }
}
