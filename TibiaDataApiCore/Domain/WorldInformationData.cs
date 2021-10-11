using System.Collections.Generic;
using TibiaDataApiCore.Domain.Commons;
using static TibiaDataApiCore.Domain.BaseApiData;
using static TibiaDataApiCore.Domain.WorldInformationData;
using static TibiaDataApiCore.Domain.WorldInformationData.WorldData;
using static TibiaDataApiCore.Domain.WorldInformationData.WorldData.WorldInfoData;

namespace TibiaDataApiCore.Domain {
    public record WorldInformationData(WorldData World, BaseInformation Information) : BaseApiData(World, Information) {

        public record WorldData(WorldInfoData WorldInformation, IReadOnlyCollection<PlayersOnlineData> PlayersOnline): BaseData() {
            
            public record WorldInfoData(string Name, int PlayersOnline, OnlineRecordData OnlineRecord, string CreationDate, string Location, string PvpType, IReadOnlyCollection<string> WorldQuestTitles, string BattleyeStatus) {
                
                public record OnlineRecordData(int players, TimeZoneDate date);
            }

            public record PlayersOnlineData(string Name, short Level, string Vocation);
        }
    }
}
