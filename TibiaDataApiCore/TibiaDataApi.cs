using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using TibiaDataApiCore.Domain;
using TibiaDataApiCore.Extensions;
using static TibiaDataApiCore.Domain.HighscoresData;

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

        public async Task<HighscoresData> GetHighscore(string world, string category = "experience", string vocation = "all") {
            
            string HS_FULL_URL = $"{TibiaDataFullUrl}/highscores/{world}/{category}/{vocation}.json";

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
    }
}
