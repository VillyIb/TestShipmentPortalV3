using TestShipmentPortal.ShipmentPortalV2;

namespace TestShipmentPortal.Contracts
{
    public interface IBinaryImage
    {
        /// <remarks/>
        ImageType ImageType { get; set; }

        /// <remarks/>
        ImageEncoding ImageEncoding { get; set; }

        /// <remarks/>
        string ImageBase64 { get; set; }

        event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
    }
}