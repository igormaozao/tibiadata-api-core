using System.Collections.Generic;
using TibiaDataApiCore.Domain.Commons;
using static TibiaDataApiCore.Domain.BaseApiData;
using static TibiaDataApiCore.Domain.CharactersData;
using static TibiaDataApiCore.Domain.CharactersData.Character;
using static TibiaDataApiCore.Domain.CharactersData.Character.CharacterData;
using static TibiaDataApiCore.Domain.CharactersData.Character.CharacterDeath;

namespace TibiaDataApiCore.Domain {
    public record CharactersData(Character characters, Information information): BaseApiData(characters, information) {

        public record Character(
            CharacterData data, 
            IReadOnlyCollection<CharacterAchivements> achievements, 
            IReadOnlyCollection<CharacterDeath> deaths,
            CharacterAccountInformation accountInformation,
            IReadOnlyCollection<CharacterOtherCharacters> otherCharacters) : Data() {

            public record CharacterData(string name, string title, string sex, string vocation, short level, short achivementPoints, string world, string residence, 
                string marriedTo, IReadOnlyCollection<CharacterHouse> houses, CharacterGuild guild, IReadOnlyCollection<TimeZoneDate> lastLogin, string comment, string accountStatus, string status) {

                public record CharacterHouse(string name, string town, string paid, string world, int houseid);

                public record CharacterGuild(string name, string rank);

            }

            public record CharacterAchivements(short stars, string name);

            public record CharacterDeath(TimeZoneDate date, short level, string reason, IReadOnlyCollection<CharacterDeathInvolved> involved) {

                public record CharacterDeathInvolved(string name);
            }

            public record CharacterAccountInformation(string loyaltyTitle, TimeZoneDate created);

            public record CharacterOtherCharacters(string name, string world, string status);

            
        }
    }
}
