using System.Collections.Generic;
using static TibiaDataApiCore.Domain.BaseApiData;
using static TibiaDataApiCore.Domain.GuildInformationData;
using static TibiaDataApiCore.Domain.GuildInformationData.GuildInformation;
using static TibiaDataApiCore.Domain.GuildInformationData.GuildInformation.GuildData;
using static TibiaDataApiCore.Domain.GuildInformationData.GuildInformation.GuildMembersData;

namespace TibiaDataApiCore.Domain {
    public record GuildInformationData(GuildInformation Guild, BaseInformation Information): BaseApiData(Guild, Information) {

        public record GuildInformation(GuildData Data, IReadOnlyCollection<GuildMembersData> Members) : BaseData {

            public record GuildData(
                string Name, 
                string Description, 
                GuildHallData Guildhall,
                bool Application,
                bool War,
                short OnlineStatus,
                short OfflineStatus,
                bool Disbanded,
                short Totalmembers,
                short Totalinvited,
                string World,
                string Founded,
                bool Active,
                string Homepage,
                string Guildlogo) {
                
                public record GuildHallData(string Name, string Town, string Paid, string World, int Houseid);
            }

            public record GuildMembersData(string RankTitle, IReadOnlyCollection<GuildCharacterData> Characters) {

                public record GuildCharacterData(string Name, string Nick, short Level, string Vocation, string Joined, string Status);
            }
        }
    }
}
