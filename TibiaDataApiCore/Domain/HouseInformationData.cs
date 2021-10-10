using TibiaDataApiCore.Domain.Commons;
using static TibiaDataApiCore.Domain.BaseApiData;
using static TibiaDataApiCore.Domain.HouseInformationData;
using static TibiaDataApiCore.Domain.HouseInformationData.HouseData;

namespace TibiaDataApiCore.Domain {
    public record HouseInformationData(HouseData house, Information information): BaseApiData(house, information) {

        public record HouseData(
            int houseid,
            string world,
            string name,
            string type,
            short beds,
            short size,
            int rent,
            string img,
            HouseStatus status
        ) : Data {

            public record HouseStatus(
                bool occupied,
                bool auction,
                string ownerNow,
                string ownerNew,
                bool currentBid,
                string auctionEnd,
                TimeZoneDate paidUntil,
                bool transferAccept,
                int? transferBid,
                string original
            );
        }
    }
}
