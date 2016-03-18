using TestShipmentPortal.Constants;

namespace TestShipmentPortal.Contracts
{
    public interface IColli
    {
        /// <summary>
        /// Dry Ice Weight in g.
        /// </summary>
        [DataValidationDecimal(MinValue = "0.0m", MaxValue = "99,999.9m")] // TODO verify
        decimal DryIceWeight { get; set; }

        /// <summary>
        /// Height in mm.
        /// </summary>
        [DataValidationDecimal(MinValue = "1.0m", MaxValue = "9,999.9m")] // TODO verify
        decimal Height { get; set; }

        /// <summary>
        /// Length in mm.
        /// </summary>
        [DataValidationDecimal(MinValue = "1.0m", MaxValue = "9,999.9m")] // TODO verify
        decimal Length { get; set; }

        ///// <summary>
        ///// Colli WayBill number.
        ///// </summary>
        //[DataValidationText(AllowEmpty = false, MaxLength = 55)]
        //String WayBillNumber { get; set; }

        /// <summary>
        /// Weight in g.
        /// </summary>
        [DataValidationDecimal(MinValue = "1.0m", MaxValue = "99,999.9m")] // TODO verify
        decimal Weight { get; set; }

        /// <summary>
        /// Width in mm.
        /// </summary>
        [DataValidationDecimal(MinValue = "1.0m", MaxValue = "9,999.9m")] // TODO verify
        decimal Width { get; set; }
    }
}
