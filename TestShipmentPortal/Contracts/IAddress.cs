using System;

namespace TestShipmentPortal.Contracts
{
    public interface IAddress
    {
        String Name { get; set; }
        String Attention { get; set; }
        String Street1 { get; set; }
        String Street2 { get; set; }
        String ZipCode { get; set; }
        String City { get; set; }
        String StateCode { get; set; }
        String CountryCode { get; set; }
        String Phone { get; set; }
        String Email { get; set; }
        String Reference { get; set; }
    }
}