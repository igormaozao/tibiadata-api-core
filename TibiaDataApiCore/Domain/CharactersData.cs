using System.Collections.Generic;
using TibiaDataApiCore.Domain.Commons;
using static TibiaDataApiCore.Domain.BaseApiData;
using static TibiaDataApiCore.Domain.CharactersData;
using static TibiaDataApiCore.Domain.CharactersData.Character;
using static TibiaDataApiCore.Domain.CharactersData.Character.CharacterData;
using static TibiaDataApiCore.Domain.CharactersData.Character.CharacterDeath;

namespace TibiaDataApiCore.Domain {
    public record CharactersData(Character Characters, BaseInformation Information): BaseApiData(Characters, Information) {

        public record Character(
            CharacterData Data, 
            IReadOnlyCollection<CharacterAchivements> Achievements, 
            IReadOnlyCollection<CharacterDeath> Deaths,
            CharacterAccountInformation AccountInformation,
            IReadOnlyCollection<CharacterOtherCharacters> OtherCharacters) : BaseData() {

            public record CharacterData(string Name, string Title, string Sex, string Vocation, short Level, short AchivementPoints, string World, string Residence, 
                string MarriedTo, IReadOnlyCollection<CharacterHouse> Houses, CharacterGuild Guild, IReadOnlyCollection<TimeZoneDate> LastLogin, string Comment, string AccountStatus, string Status) {

                public record CharacterHouse(string Name, string Town, string Paid, string World, int Houseid);

                public record CharacterGuild(string Name, string Rank);

            }

            public record CharacterAchivements(short Stars, string Name);

            public record CharacterDeath(TimeZoneDate Date, short Level, string Reason, IReadOnlyCollection<CharacterDeathInvolved> Involved) {

                public record CharacterDeathInvolved(string Name);
            }

            public record CharacterAccountInformation(string LoyaltyTitle, TimeZoneDate Created);

            public record CharacterOtherCharacters(string Name, string World, string Status);

            
        }
    }
}
