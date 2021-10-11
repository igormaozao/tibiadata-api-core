using System.Collections.Generic;
using static TibiaDataApiCore.Domain.BaseApiData;
using static TibiaDataApiCore.Domain.WorldsData;
using static TibiaDataApiCore.Domain.WorldsData.WorldsListData;

namespace TibiaDataApiCore.Domain {
    public record WorldsData(WorldsListData Worlds, BaseInformation Information) : BaseApiData(Worlds, Information) {

        public record WorldsListData(int Online, IReadOnlyList<WorldInfo> Allworlds) : BaseData() {
            public record WorldInfo(string Name, int Online, string Location, string Worldtype, string Additional);
        };
    }
}
