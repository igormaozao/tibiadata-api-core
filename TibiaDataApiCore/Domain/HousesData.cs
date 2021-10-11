using System.Collections.Generic;
using static TibiaDataApiCore.Domain.BaseApiData;
using static TibiaDataApiCore.Domain.HousesData;
using static TibiaDataApiCore.Domain.HousesData.HousesList;

namespace TibiaDataApiCore.Domain {
    public record HousesData(HousesList Houses, BaseInformation Information): BaseApiData(Houses, Information) {

        public record HousesList(
            string Town,
            string World,
            string Type,
            IReadOnlyCollection<House> Houses): BaseData {

            public record House(
                int Houseid, 
                string Name, 
                short Size,
                int Rent,
                string Status);
        }
    }
}
