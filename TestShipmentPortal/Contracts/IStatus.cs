namespace TestShipmentPortal.Contracts
{
    public interface IStatus
    {
        /// <remarks/>
        string FieldName { get; set; }

        /// <remarks/>
        string Severity { get; set; }

        /// <remarks/>
        string Text { get; set; }

        /// <remarks/>
        string Code { get; set; }

        event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
    }
}