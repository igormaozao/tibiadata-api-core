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
    }
}
