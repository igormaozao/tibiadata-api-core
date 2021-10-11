using System.Threading.Tasks;
using TibiaDataApiCore;
using TibiaDataApiCore.Constants;
using TibiaDataApiCore.Extensions;
using Xunit;

namespace TibiaDataApiCoreTest {
    public class TibiaDataApiIntegrationTests {

        private readonly TibiaDataApi tibiaDataApi = new TibiaDataApi();

        [Fact]
        public async Task Should_Call_Live_Highscore_Correctly() {
            var worldFilter = "Impera";
            var vocationFilter = HighscoreVocationEnum.None;
            var hsData = await tibiaDataApi.GetHighscore(worldFilter, vocation: vocationFilter);

            Assert.NotNull(hsData);
			Assert.NotNull(hsData.Highscores);

            Assert.Equal(worldFilter, hsData.Highscores.Filters.World);
            Assert.Equal(vocationFilter.GetDescription(), hsData.Highscores.Filters.Vocation);

            Assert.True(hsData.Highscores.Data.Count > 0);

            Assert.Equal((short)2, hsData.Information.ApiVersion);
		}

        [Fact]
        public async Task Should_Call_Live_Worlds_Data_Correctly() {
            var data = await tibiaDataApi.GetWorlds();

            Assert.NotNull(data);
            Assert.NotNull(data.Information);
            Assert.NotNull(data.Worlds);
            Assert.NotNull(data.Worlds.Allworlds);

            Assert.True(data.Worlds.Allworlds.Count > 0);
        }

        [Fact]
        public async Task Should_Call_Live_World_Information_Data_Correctly() {
            var worldName = "Impera";
            var data = await tibiaDataApi.GetWorld(worldName);

            Assert.NotNull(data);
            Assert.NotNull(data.Information);
            Assert.NotNull(data.World);
            Assert.NotNull(data.World.WorldInformation);
            Assert.NotNull(data.World.PlayersOnline);

            Assert.True(data.World.PlayersOnline.Count > 0);
        }

        [Fact]
        public async Task Should_Call_Live_Character_Data_Correctly() {
            var charName = "Rogi Suvan";
            var data = await tibiaDataApi.GetCharacter(charName);

            Assert.NotNull(data);
            Assert.NotNull(data.Information);
            Assert.NotNull(data.Characters);

            Assert.Equal(charName, data.Characters.Data.Name);
            Assert.Equal("Thais", data.Characters.Data.Residence);
            Assert.Equal("Relembra", data.Characters.Data.World);

            Assert.Contains(data.Characters.OtherCharacters, c => c.Name == "Rogi Returns");
        }

        [Fact]
        public async Task Should_Call_Live_Guilds_Data_Correctly() {
            var worldName = "Antica";
            var data = await tibiaDataApi.GetGuilds(worldName);

            Assert.NotNull(data);
            Assert.NotNull(data.Information);
            Assert.NotNull(data.Guilds);
            Assert.NotNull(data.Guilds.World);
            Assert.NotNull(data.Guilds.Active);

            Assert.Equal(worldName, data.Guilds.World);

            Assert.True(data.Guilds.Active.Count > 0);
        }

        [Fact]
        public async Task Should_Call_Live_Specific_Guild_Data_Correctly() {
            var guildName = "Red Rose";
            var guildWorld = "Antica";
            var redRoseFoundDate = "2002-02-18";

            var data = await tibiaDataApi.GetGuild(guildName);

            Assert.NotNull(data);
            Assert.NotNull(data.Information);
            Assert.NotNull(data.Guild);
            Assert.NotNull(data.Guild.Data);

            Assert.Equal(guildName, data.Guild.Data.Name);
            Assert.Equal(guildWorld, data.Guild.Data.World);
            Assert.Equal(redRoseFoundDate, data.Guild.Data.Founded);

            Assert.True(data.Guild.Members.Count > 0);
        }

        [Fact]
        public async Task Should_Call_Live_Houses_Data_Correctly() {
            var worldName = "Antica";
            var city = HousesCityEnum.Venore;
            var houseType = HousesTypeEnum.Houses;

            var data = await tibiaDataApi.GetHouses(worldName, city, houseType);

            Assert.NotNull(data);
            Assert.NotNull(data.Information);
            Assert.NotNull(data.Houses);

            Assert.Equal(worldName, data.Houses.World);
            Assert.Equal(city.GetDescription(), data.Houses.Town);
            Assert.Equal(houseType.GetDescription(), data.Houses.Type);

            Assert.True(data.Houses.Houses.Count > 0);
        }

        [Fact]
        public async Task Should_Call_Live_House_Information_Data_Correctly() {
            var worldName = "Antica";
            var houseType = "guildhall";
            var houseId = 35037;

            var data = await tibiaDataApi.GetHouse(worldName, houseId);

            Assert.NotNull(data);
            Assert.NotNull(data.Information);
            Assert.NotNull(data.House);
            Assert.NotNull(data.House.Status);

            Assert.Equal(worldName, data.House.World);
            Assert.Equal(houseType, data.House.Type);
            Assert.Equal(houseId, data.House.Houseid);
        }

        [Fact]
        public async Task Should_Call_Live_Latest_News_Data_Correctly() {

            var data = await tibiaDataApi.GetLatestNews();

            Assert.NotNull(data);
            Assert.NotNull(data.Information);
            Assert.NotNull(data.Newslist);

            Assert.Equal("latestnews", data.Newslist.Type);
        }

        [Fact]
        public async Task Should_Call_Live_Latest_News_Tickers_Data_Correctly() {

            var data = await tibiaDataApi.GetLatestNewsTickers();

            Assert.NotNull(data);
            Assert.NotNull(data.Information);
            Assert.NotNull(data.Newslist);

            Assert.Equal("newstickers", data.Newslist.Type);
        }

        [Fact]
        public async Task Should_Call_Live_News_Information_Data_Correctly() {
            var newsId = 3560;

            var data = await tibiaDataApi.GetNews(newsId);

            Assert.NotNull(data);
            Assert.NotNull(data.Information);
            Assert.NotNull(data.News);

            Assert.Equal(newsId, data.News.Id);
        }

        [Fact]
        public async Task Should_Call_Live_News_Information_Data_With_Wrong_Id() {
            var newsId = 999999;

            var data = await tibiaDataApi.GetNews(newsId);

            Assert.NotNull(data);
            Assert.NotNull(data.Information);
            Assert.NotNull(data.News);

            Assert.Equal(0, data.News.Id);
            Assert.Null(data.News.Title);
            Assert.Null(data.News.Content);
            Assert.Null(data.News.Date);
        }
    }
}
