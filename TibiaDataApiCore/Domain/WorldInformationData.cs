using System;
using System.Collections.Generic;
using static TibiaDataApiCore.Domain.BaseApiData;
using static TibiaDataApiCore.Domain.WorldInformationData;
using static TibiaDataApiCore.Domain.WorldInformationData.World;
using static TibiaDataApiCore.Domain.WorldInformationData.World.WorldInformation;
using static TibiaDataApiCore.Domain.WorldInformationData.World.WorldInformation.OnlineRecord;

namespace TibiaDataApiCore.Domain {
    public record WorldInformationData(World world, Information information) : BaseApiData(world, information) {

        public record World(WorldInformation worldInformation, IReadOnlyCollection<PlayersOnline> playersOnline): Data() {
            
            public record WorldInformation(string name, int playersOnline, OnlineRecord onlineRecord, string creationDate, string location, string pvpType, IReadOnlyCollection<string> worldQuestTitles, string battleyeStatus) {
                
                public record OnlineRecord(int players, DateInfo date) {
                    
                    public record DateInfo(DateTime date, int timezoneType, string timezone);
                }
            }

            public record PlayersOnline(string name, short level, string vocation);
        }
    }
}
