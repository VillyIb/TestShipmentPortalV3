using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestShipmentPortal.Constants
{
    public class IncoTermsAttribute : Attribute
    {
        public String Description { get; set; }

        public bool UseByGtx { get; set; }
    }


    public enum GtxIncoTerms
    {
        // see: http://en.wikipedia.org/wiki/Incoterms

        // ReSharper disable InconsistentNaming

        [IncoTerms(Description = "Delivered At Place", UseByGtx = true)]
        DAP = 0, // "0" (text zero) is saved in [ship_Shipments].[ship_DDU] - implicit False for DDP

        [IncoTerms(Description = "Delivered Duty Paid", UseByGtx = true)]
        DDP = 1,  // "1" (text one) is saved in [ship_Shipments].[ship_DDU] - implicit True for DDP

        // --- unsupported definitions
        // Database does not support the following codes
        // Database storage should be reviewed in order to accomodate new values.
        // Ideally the 3-letter code should be saved.

        [IncoTerms(Description = "EX-Works", UseByGtx = false)]
        EXW,

        [IncoTerms(Description = "Free On Board", UseByGtx = false)]
        FOB,

        [IncoTerms(Description = "Free Carrier", UseByGtx = false)]
        FCA,

        [IncoTerms(Description = "Free Alongside Ship", UseByGtx = false)]
        FAS,

        [IncoTerms(Description = "Cost and Freight", UseByGtx = false)]
        CFR,

        [IncoTerms(Description = "Cost, Insurance and Freight", UseByGtx = false)]
        CIF,

        [IncoTerms(Description = "Carriage Paid To", UseByGtx = false)]
        CPT,

        [IncoTerms(Description = "Carriage and Insurance Paid To", UseByGtx = false)]
        CIP,

        [IncoTerms(Description = "Delivered At Terminal", UseByGtx = false)]
        DAT,

        // ReSharper restore InconsistentNaming
    }
}
