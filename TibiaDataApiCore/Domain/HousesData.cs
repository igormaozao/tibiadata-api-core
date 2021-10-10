using System.Collections.Generic;
using static TibiaDataApiCore.Domain.BaseApiData;
using static TibiaDataApiCore.Domain.HousesData;
using static TibiaDataApiCore.Domain.HousesData.Houses;

namespace TibiaDataApiCore.Domain {
    public record HousesData(Houses houses, Information information): BaseApiData(houses, information) {

        public record Houses(
            string town,
            string world,
            string type,
            IReadOnlyCollection<House> houses): Data {

            public record House(
                int houseid, 
                string name, 
                short size,
                int rent,
                string status);
        }
    }
}
