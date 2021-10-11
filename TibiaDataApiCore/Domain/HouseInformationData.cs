using TibiaDataApiCore.Domain.Commons;
using static TibiaDataApiCore.Domain.BaseApiData;
using static TibiaDataApiCore.Domain.HouseInformationData;
using static TibiaDataApiCore.Domain.HouseInformationData.HouseData;

namespace TibiaDataApiCore.Domain {
    public record HouseInformationData(HouseData House, BaseInformation Information): BaseApiData(House, Information) {

        public record HouseData(
            int Houseid,
            string World,
            string Name,
            string Type,
            short Beds,
            short Size,
            int Rent,
            string Img,
            HouseStatus Status
        ) : BaseData {

            public record HouseStatus(
                bool Occupied,
                bool Auction,
                string OwnerNow,
                string OwnerNew,
                bool CurrentBid,
                string AuctionEnd,
                TimeZoneDate PaidUntil,
                bool TransferAccept,
                int? TransferBid,
                string Original
            );
        }
    }
}
