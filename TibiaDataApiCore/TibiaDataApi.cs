using System;
using System.Net.Http;
using System.Threading.Tasks;
using TibiaDataApiCore.Constants;
using TibiaDataApiCore.Domain;
using TibiaDataApiCore.Extensions;

namespace TibiaDataApiCore {
    public class TibiaDataApi {

        String TibiaDataUrl { get; set; } = "https://api.tibiadata.com";
        String TibiaDataApiVersion { get; set; } = "v2"; //TODO: Change to some kind of Enum/Constant

        String TibiaDataFullUrl => $"{TibiaDataUrl}/{TibiaDataApiVersion}";

        HttpClient httpClient = new HttpClient();

        public TibiaDataApi() { }
        public TibiaDataApi(String tibiaDataUrl) {
            TibiaDataUrl = tibiaDataUrl;
        }
        public TibiaDataApi(String tibiaDataUrl, String tibiaDataApiVersion) {
            TibiaDataUrl = tibiaDataUrl;
            TibiaDataApiVersion = tibiaDataApiVersion;
        }

        public async Task<HighscoresData> GetHighscore(
            string world, 
            HighscoresCategoryEnum category = HighscoresCategoryEnum.Experience,
            HighscoreVocationEnum vocation = HighscoreVocationEnum.All) {
            
            string HS_FULL_URL = $"{TibiaDataFullUrl}/highscores/{world}/{category.GetDescription()}/{vocation.GetDescription()}.json";

            string data = await httpClient.GetStringAsync(HS_FULL_URL);

            return data.Deserialize<HighscoresData>();
        }

        public async Task<WorldsData> GetWorlds() {
            string WORLDS_FULL_URL = $"{TibiaDataFullUrl}/worlds.json";
            string data = await httpClient.GetStringAsync(WORLDS_FULL_URL);
            return data.Deserialize<WorldsData>();
        }

        public async Task<WorldInformationData> GetWorld(string worldName) {
            string WORLD_FULL_URL = $"{TibiaDataFullUrl}/world/{worldName}.json";
            string data = await httpClient.GetStringAsync(WORLD_FULL_URL);
            return data.Deserialize<WorldInformationData>();
        }

        public async Task<CharactersData> GetCharacter(string characterName) {
            string CHARACTERS_FULL_URL = $"{TibiaDataFullUrl}/characters/{characterName}.json";
            string data = await httpClient.GetStringAsync(CHARACTERS_FULL_URL);
            return data.Deserialize<CharactersData>();
        }

        public async Task<GuildsData> GetGuilds(string worldName) {
            string GUILDS_FULL_URL = $"{TibiaDataFullUrl}/guilds/{worldName}.json";
            string data = await httpClient.GetStringAsync(GUILDS_FULL_URL);
            return data.Deserialize<GuildsData>();
        }

        public async Task<GuildInformationData> GetGuild(string guildName) {
            string GUILD_FULL_URL = $"{TibiaDataFullUrl}/guild/{guildName}.json";
            string data = await httpClient.GetStringAsync(GUILD_FULL_URL);
            return data.Deserialize<GuildInformationData>();
        }

        public async Task<HousesData> GetHouses(
            string worldName,
            HousesCityEnum city = HousesCityEnum.AbDendriel,
            HousesTypeEnum type = HousesTypeEnum.Houses) {

            string HOUSES_FULL_URL = $"{TibiaDataFullUrl}/houses/{worldName}/{city.GetDescription()}/{type.GetDescription()}.json";
            string data = await httpClient.GetStringAsync(HOUSES_FULL_URL);
            return data.Deserialize<HousesData>();
        }

        public async Task<HouseInformationData> GetHouse(string worldName, int houseId) {
            string HOUSE_FULL_URL = $"{TibiaDataFullUrl}/house/{worldName}/{houseId}.json";
            string data = await httpClient.GetStringAsync(HOUSE_FULL_URL);
            return data.Deserialize<HouseInformationData>();
        }

        public async Task<NewsData> GetLatestNews() {
            string NEWS_FULL_URL = $"{TibiaDataFullUrl}/latestnews.json";
            string data = await httpClient.GetStringAsync(NEWS_FULL_URL);
            return data.Deserialize<NewsData>();
        }

        public async Task<NewsData> GetLatestNewsTickers() {
            string NEWS_FULL_URL = $"{TibiaDataFullUrl}/newstickers.json";
            string data = await httpClient.GetStringAsync(NEWS_FULL_URL);
            return data.Deserialize<NewsData>();
        }

        public async Task<NewsInformationData> GetNews(int newsId) {
            string NEWS_FULL_URL = $"{TibiaDataFullUrl}/news/{newsId}.json";
            string data = await httpClient.GetStringAsync(NEWS_FULL_URL);
            return data.Deserialize<NewsInformationData>();
        }
    }
}
