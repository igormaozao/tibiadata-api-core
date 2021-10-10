using System.Collections.Generic;
using static TibiaDataApiCore.Domain.BaseApiData;
using static TibiaDataApiCore.Domain.WorldsData;
using static TibiaDataApiCore.Domain.WorldsData.Worlds;

namespace TibiaDataApiCore.Domain {
    public record WorldsData(Worlds worlds, Information information) : BaseApiData(worlds, information) {

        public record Worlds(int online, IReadOnlyList<WorldInfo> allworlds) : Data() {
            public record WorldInfo(string name, int online, string location, string worldtype, string additional);
        };
    }
}
