using System.Linq;
using System.Threading.Tasks;
using TibiaDataApiCore;
using Xunit;

namespace TibiaDataApiCoreTest {
    public class TibiaDataApiIntegrationTests {

        private readonly TibiaDataApi tibiaDataApi = new TibiaDataApi();

        [Fact]
        public async Task Should_Call_Live_Highscore_Correctly() {
            var worldFilter = "Impera";
            var vocationFilter = "none";
            var hsData = await tibiaDataApi.GetHighscore(worldFilter, vocation: vocationFilter);

            Assert.NotNull(hsData);
			Assert.NotNull(hsData.highscores);

            Assert.Equal(worldFilter, hsData.highscores.filters.world);
            Assert.Equal(vocationFilter, hsData.highscores.filters.vocation);

            Assert.True(hsData.highscores.data.Count > 0);

            Assert.Equal((short)2, hsData.information.ApiVersion);
		}

        [Fact]
        public async Task Should_Call_Live_Worlds_Data_Correctly() {
            var data = await tibiaDataApi.GetWorlds();

            Assert.NotNull(data);
            Assert.NotNull(data.information);
            Assert.NotNull(data.worlds);
            Assert.NotNull(data.worlds.allworlds);

            Assert.True(data.worlds.allworlds.Count > 0);
        }

        [Fact]
        public async Task Should_Call_Live_World_Information_Data_Correctly() {
            var worldName = "Impera";
            var data = await tibiaDataApi.GetWorld(worldName);

            Assert.NotNull(data);
            Assert.NotNull(data.information);
            Assert.NotNull(data.world);
            Assert.NotNull(data.world.worldInformation);
            Assert.NotNull(data.world.playersOnline);

            Assert.True(data.world.playersOnline.Count > 0);
        }

        [Fact]
        public async Task Should_Call_Live_Character_Data_Correctly() {
            var charName = "Rogi Suvan";
            var data = await tibiaDataApi.GetCharacter(charName);

            Assert.NotNull(data);
            Assert.NotNull(data.information);
            Assert.NotNull(data.characters);

            Assert.Equal(charName, data.characters.data.name);
            Assert.Equal("Thais", data.characters.data.residence);
            Assert.Equal("Relembra", data.characters.data.world);

            Assert.Contains(data.characters.otherCharacters, c => c.name == "Rogi Returns");
        }

        [Fact]
        public async Task Should_Call_Live_Guilds_Data_Correctly() {
            var worldName = "Antica";
            var data = await tibiaDataApi.GetGuilds(worldName);

            Assert.NotNull(data);
            Assert.NotNull(data.information);
            Assert.NotNull(data.guilds);
            Assert.NotNull(data.guilds.world);
            Assert.NotNull(data.guilds.active);

            Assert.Equal(worldName, data.guilds.world);

            Assert.True(data.guilds.active.Count > 0);
        }

        [Fact]
        public async Task Should_Call_Live_Specific_Guild_Data_Correctly() {
            var guildName = "Red Rose";
            var guildWorld = "Antica";
            var redRoseFoundDate = "2002-02-18";

            var data = await tibiaDataApi.GetGuild(guildName);

            Assert.NotNull(data);
            Assert.NotNull(data.information);
            Assert.NotNull(data.guild);
            Assert.NotNull(data.guild.data);

            Assert.Equal(guildName, data.guild.data.name);
            Assert.Equal(guildWorld, data.guild.data.world);
            Assert.Equal(redRoseFoundDate, data.guild.data.founded);

            Assert.True(data.guild.members.Count > 0);
        }

        [Fact]
        public async Task Should_Call_Live_Houses_Data_Correctly() {
            var worldName = "Antica";
            var city = "Venore";
            var houseType = "houses";

            var data = await tibiaDataApi.GetHouses(worldName, city, houseType);

            Assert.NotNull(data);
            Assert.NotNull(data.information);
            Assert.NotNull(data.houses);

            Assert.Equal(worldName, data.houses.world);
            Assert.Equal(city, data.houses.town);

            Assert.True(data.houses.houses.Count > 0);
        }

        [Fact]
        public async Task Should_Call_Live_House_Information_Data_Correctly() {
            var worldName = "Antica";
            var houseType = "guildhall";
            var houseId = 35037;

            var data = await tibiaDataApi.GetHouse(worldName, houseId);

            Assert.NotNull(data);
            Assert.NotNull(data.information);
            Assert.NotNull(data.house);
            Assert.NotNull(data.house.status);

            Assert.Equal(worldName, data.house.world);
            Assert.Equal(houseType, data.house.type);
            Assert.Equal(houseId, data.house.houseid);
        }

        [Fact]
        public async Task Should_Call_Live_Latest_News_Data_Correctly() {

            var data = await tibiaDataApi.GetLatestNews();

            Assert.NotNull(data);
            Assert.NotNull(data.information);
            Assert.NotNull(data.newslist);

            Assert.Equal("latestnews", data.newslist.type);
        }

        [Fact]
        public async Task Should_Call_Live_Latest_News_Tickers_Data_Correctly() {

            var data = await tibiaDataApi.GetLatestNewsTickers();

            Assert.NotNull(data);
            Assert.NotNull(data.information);
            Assert.NotNull(data.newslist);

            Assert.Equal("newstickers", data.newslist.type);
        }

        [Fact]
        public async Task Should_Call_Live_News_Information_Data_Correctly() {
            var newsId = 3560;

            var data = await tibiaDataApi.GetNews(newsId);

            Assert.NotNull(data);
            Assert.NotNull(data.information);
            Assert.NotNull(data.news);

            Assert.Equal(newsId, data.news.id);
        }

        [Fact]
        public async Task Should_Call_Live_News_Information_Data_With_Wrong_Id() {
            var newsId = 999999;

            var data = await tibiaDataApi.GetNews(newsId);

            Assert.NotNull(data);
            Assert.NotNull(data.information);
            Assert.NotNull(data.news);

            Assert.Equal(0, data.news.id);
            Assert.Null(data.news.title);
            Assert.Null(data.news.content);
            Assert.Null(data.news.date);
        }
    }
}
