
using TestShipmentPortal.ShipmentPortalV2;

namespace TestShipmentPortal.Contracts
{
    public interface IBookingRequest
    {
        /// <remarks/>
        OperationCode OperationCode { get; set; }

        /// <remarks/>
        string Username { get; set; }

        /// <remarks/>
        string Password { get; set; }

        /// <remarks/>
        uint AccountId { get; set; }

        /// <remarks/>
        ShipmentType ShipmentType { get; set; }

        /// <remarks/>
        GtxIncoTerms Incoterm { get; set; }

        /// <remarks/>
        uint SalesproductId { get; set; }

        /// <remarks/>
        System.DateTime ShippingDate { get; set; }

        /// <remarks/>
        string Description { get; set; }

        /// <remarks/>
        BookingColliV2[] CollieList { get; set; }

        /// <remarks/>
        ExportType ExportType { get; set; }

        /// <remarks/>
        ImageEncoding ImageEncoding { get; set; }

        /// <remarks/>
        WaybillImageFormat WaybillImageFormat { get; set; }

        /// <remarks/>
        WaybillReturnCode WaybillReturnCode { get; set; }

        /// <remarks/>
        string WayBillReturnEmail { get; set; }

        /// <remarks/>
        decimal CustomsValue { get; set; }

        /// <remarks/>
        string CustomsCurrencyCode { get; set; }

        /// <remarks/>
        decimal InsuranceValue { get; set; }

        /// <remarks/>
        string InsuranceCurrencyCode { get; set; }

        /// <remarks/>
        bool InsuredByCarrier { get; set; }

        /// <remarks/>
        bool S01ReceiverPays { get; set; }

        /// <remarks/>
        string S01PayingAccountNumber { get; set; }

        /// <remarks/>
        bool S02ReceiverPays { get; set; }

        /// <remarks/>
        string S02PayingAccountNumber { get; set; }

        /// <remarks/>
        DangerousGoodsAccessibilityType DangerousGoodsAccessibilityType { get; set; }

        /// <remarks/>
        bool NotifyReceiver { get; set; }

        /// <remarks/>
        Address AddressPickup { get; set; }

        /// <remarks/>
        Address AddressReceiver { get; set; }

        /// <remarks/>
        Address AddressSender { get; set; }

        /// <remarks/>
        PickupHandling PickupHandling { get; set; }

        /// <remarks/>
        PickupDelivery PickupDelivery { get; set; }

        /// <remarks/>
        System.DateTime PickupFrom { get; set; }

        /// <remarks/>
        System.DateTime PickupUntil { get; set; }

        /// <remarks/>
        string DropPoint { get; set; }

        /// <remarks/>
        string DeliveryNotificationSms { get; set; }

        /// <remarks/>
        string DeliveryNotificationEmail { get; set; }

        event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
    }
}