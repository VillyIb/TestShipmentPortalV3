
using TestShipmentPortal.ShipmentPortalV2;

namespace TestShipmentPortal.Contracts
{
    public interface IBookingRequestV2 : IBookingRequest
    {

        /// <remarks/>
        ServiceV2[] Services { get; set; }

        /// <remarks/>
        Address AddressReturn { get; set; }

    }
}