using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestShipmentPortal.Constants
{
    /// <summary>
    /// Summary description for DataValidationAttribute
    /// </summary>
    public class DataValidationAttribute : Attribute
    {

    }

    public class DataValidationTextAttribute : DataValidationAttribute
    {
        public int MaxLength { get; set; }

        public int MinLength { get; set; }

        public bool AllowEmpty { get; set; }
    }

    public class DataValidationIntAttribute : DataValidationAttribute
    {
        public int MaxValue { get; set; }

        public int MinValue { get; set; }
    }

    public class DataValidationDecimalAttribute : DataValidationAttribute
    {
        /// <summary>
        /// Attribute does not permit decimal, please specify like "99,999.99m" in string.
        /// </summary>
        public String MaxValue { get; set; }

        /// <summary>
        /// Attribute does not permit decimal, please specify like "99,999.99m" in string.
        /// </summary>
        public String MinValue { get; set; }
    }

    public class DataValidationDateAttribute : DataValidationAttribute
    {
        public DateTime MaxValue { get; set; }

        public DateTime MinValue { get; set; }

    }

    public class DataValidateionDateOffsettAttribute : DataValidationAttribute
    {
        public int MaxOffsettForward { get; set; }
        public int MaxoffsettReverse { get; set; }
    }

    public class DataValidationListAttribute : DataValidationAttribute
    {
        public int MinCount { get; set; }
        public int MaxCount { get; set; }
    }

    public class DataValidationEmailAttribute : DataValidationAttribute
    {
        public bool AllowEmpty { get; set; }
        public bool AllowMultiple { get; set; }
        public bool CheckSyntax { get; set; }
    }
}
