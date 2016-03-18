using TestShipmentPortal.ShipmentPortalV2;

namespace TestShipmentPortal.Contracts
{
    public interface IBookingResponseV2
    {
        /// <remarks/>
        string RequestId { get; set; }

        /// <remarks/>
        bool Success { get; set; }

        /// <remarks/>
        string StatusText { get; set; }

        /// <remarks/>
        Direction Direction { get; set; }

        /// <remarks/>
        Status[] StatusList { get; set; }

        /// <remarks/>
        string CarrierName { get; set; }

        /// <remarks/>
        string CarrierProduct { get; set; }

        /// <remarks/>
        decimal BilledWeight { get; set; }

        /// <remarks/>
        decimal ShipmentCost { get; set; }

        /// <remarks/>
        decimal RemoteAreaServiceCost { get; set; }

        /// <remarks/>
        decimal OilChargeCost { get; set; }

        /// <remarks/>
        decimal TotalCost { get; set; }

        /// <remarks/>
        string WayBillNumberHead { get; set; }

        /// <remarks/>
        string[] WayBillNumberColliList { get; set; }

        /// <remarks/>
        BinaryImage[] BinaryImageList { get; set; }

        event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
    }
}