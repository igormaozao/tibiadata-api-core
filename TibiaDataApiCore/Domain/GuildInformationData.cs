using System.Collections.Generic;
using static TibiaDataApiCore.Domain.BaseApiData;
using static TibiaDataApiCore.Domain.GuildInformationData;
using static TibiaDataApiCore.Domain.GuildInformationData.GuildInformation;
using static TibiaDataApiCore.Domain.GuildInformationData.GuildInformation.GuildData;
using static TibiaDataApiCore.Domain.GuildInformationData.GuildInformation.GuildMembersData;

namespace TibiaDataApiCore.Domain {
    public record GuildInformationData(GuildInformation guild, Information information): BaseApiData(guild, information) {

        public record GuildInformation(GuildData data, IReadOnlyCollection<GuildMembersData> members) : Data {

            public record GuildData(
                string name, 
                string description, 
                GuildHallData guildhall,
                bool application,
                bool war,
                short onlineStatus,
                short offlineStatus,
                bool disbanded,
                short totalmembers,
                short totalinvited,
                string world,
                string founded,
                bool active,
                string homepage,
                string guildlogo) {
                
                public record GuildHallData(string name, string town, string paid, string world, int houseid);
            }

            public record GuildMembersData(string rankTitle, IReadOnlyCollection<GuildCharacterData> characters) {

                public record GuildCharacterData(string name, string nick, short level, string vocation, string joined, string status);
            }
        }
    }
}
