using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;

using TestShipmentPortal.AppCode;
using TestShipmentPortal.BookingPortalV3;

namespace TestShipmentPortal
{
    public partial class Form1 : Form
    {
        private ShipmentPortalBi BusinessContext { get; set; }


        private V3dRequest Request { get; set; }


        private void PopulateFields()
        {
            XuAccount.Text = Request.AccountId.ToString(CultureInfo.InvariantCulture);
            XuCustomsCurrency.Text = Request.CustomsCurrencyCode;
            XuCustomsValue.Text = Request.CustomsValue.ToString(CultureInfo.InvariantCulture);
            XuDescription.Text = Request.Description;
            //XuDirection.Text = Request.Direction.ToString("G");
            XuIncoterm.Text = Request.Incoterm.ToString("G");
            XuOperationCode.Text = Request.OperationCode.ToString("G");
            XuPassword.Text = Request.Password;


            {
                // Insurance
                XuInsuranceCurrency.Text = Request.InsuranceCurrencyCode;
                XuInsuranceValue.Text = Request.InsuranceValue.ToString("#.00");
            }

            // Pickup.
            if (Request.AddressPickup != null)
            {
                XuPcAttention.Text = Request.AddressPickup.Attention;
                XuPcCountryCode.Text = Request.AddressPickup.CountryCode;
                XuPcEmail.Text = Request.AddressPickup.Email;
                XuPcName.Text = Request.AddressPickup.Name;
                XuPcPhone.Text = Request.AddressPickup.Phone;
                XuPcRef.Text = Request.AddressPickup.Reference;
                XuPcStreet1.Text = Request.AddressPickup.Street1;
                XuPcStreet2.Text = Request.AddressPickup.Street2;
                XuPcZip.Text = Request.AddressPickup.ZipCode;
                XuPcCity.Text = Request.AddressPickup.City;
            }

            // Receiver
            if (Request.AddressReceiver != null)
            {
                XuRcAttention.Text = Request.AddressReceiver.Attention;
                XuRcCountryCode.Text = Request.AddressReceiver.CountryCode;
                XuRcEmail.Text = Request.AddressReceiver.Email;
                XuRcName.Text = Request.AddressReceiver.Name;
                XuRcPhone.Text = Request.AddressReceiver.Phone;
                XuRcRef.Text = Request.AddressReceiver.Reference;
                XuRcStreet1.Text = Request.AddressReceiver.Street1;
                XuRcStreet2.Text = Request.AddressReceiver.Street2;
                XuRcZip.Text = Request.AddressReceiver.ZipCode;
                XuRcCity.Text = Request.AddressReceiver.City;
            }

            // Return Address
            if (Request.AddressReturn != null)
            {
                XuRaAttention.Text = Request.AddressReturn.Attention;
                XuRaCountryCode.Text = Request.AddressReturn.CountryCode;
                XuRaEmail.Text = Request.AddressReturn.Email;
                XuRaName.Text = Request.AddressReturn.Name;
                XuRaPhone.Text = Request.AddressReturn.Phone;
                XuRaRef.Text = Request.AddressReturn.Reference;
                XuRaStreet1.Text = Request.AddressReturn.Street1;
                XuRaStreet2.Text = Request.AddressReturn.Street2;
                XuRaZip.Text = Request.AddressReturn.ZipCode;
                XuRaCity.Text = Request.AddressReturn.City;
            }

            XuSalesProdId.Text = Request.SalesproductId.ToString(CultureInfo.InvariantCulture);
            var useDate = Math.Max(DateTime.Today.Ticks, Request.ShippingDate.Ticks);
            XuShipDate.Text = (new DateTime(useDate)).ToString("yyyy-MM-dd");
            XuShipmentType.Text = Request.ShipmentType.ToString("G");

            // Sender
            if (Request.AddressSender != null)
            {
                XuSnAttention.Text = Request.AddressSender.Attention;
                XuSnCountryCode.Text = Request.AddressSender.CountryCode;
                XuSnEmail.Text = Request.AddressSender.Email;
                XuSnName.Text = Request.AddressSender.Name;
                XuSnPhone.Text = Request.AddressSender.Phone;
                XuSnRef.Text = Request.AddressSender.Reference;
                XuSnStreet1.Text = Request.AddressSender.Street1;
                XuSnStreet2.Text = Request.AddressSender.Street2;
                XuSnZip.Text = Request.AddressSender.ZipCode;
                XuSnCity.Text = Request.AddressSender.City;
            }

            XuUsername.Text = Request.Username;
            XuWaybillEncoding.Text = Request.ImageEncoding.ToString("G");
            XuWaybillFormat.Text = Request.WaybillImageFormat.ToString("G");

            XuColliCount.Text = Request.ParcelList.Length.ToString(CultureInfo.InvariantCulture);

            XuDropPointEmail.Text = Request.DeliveryNotificationEmail;
            XuDropPointSms.Text = Request.DeliveryNotificationSms;
            XuDropPointId.Text = Request.DropPoint;

            XuNotifyReceiver.Checked = Request.NotifyReceiver;
            XuPickupHandling.SelectedItem = Request.PickupHandling.ToString("G");
            XuPickupDelivery.SelectedItem = Request.PickupDelivery.ToString("G");

            XuPickupReadyHh.Text = Request.PickupFrom.Hour.ToString("00");
            XuPickupReadyMm.Text = Request.PickupFrom.Minute.ToString("00");

            XuPickupCloseHh.Text = Request.PickupUntil.Hour.ToString("00");
            XuPickupCloseMm.Text = Request.PickupUntil.Minute.ToString("00");

            // Service
            {
                XuServiceCode.DataSource = Enum.GetNames(typeof(V3cServiceCode));
                XuServiceCount.Text = Request.AdditionalServiceList.Length.ToString();
            }

            UploadDocumentInitGui();
        }


        private void ReadFields()
        {
            {
                uint t1;
                Request.AccountId = uint.TryParse(XuAccount.Text, out t1) ? t1 : 0;
            }
            Request.CustomsCurrencyCode = XuCustomsCurrency.Text;
            {
                decimal t1;
                Request.CustomsValue = decimal.TryParse(XuCustomsValue.Text, out t1) ? t1 : 0m;
            }
            Request.Description = XuDescription.Text;
            //{
            //    Direction t1;
            //    Request.Direction = Enum.TryParse(XuDirection.Text, out t1) ? t1 : Direction.Export;
            //}
            {
                V3cIncoTerms t1;
                Request.Incoterm = Enum.TryParse(XuIncoterm.Text, out t1) ? t1 : V3cIncoTerms.DAP;
            }
            {
                V3cOperationCode t1;
                Request.OperationCode = Enum.TryParse(XuOperationCode.Text, out t1) ? t1 : V3cOperationCode.Test;
            }
            Request.Password = XuPassword.Text;

            Request.S01PayingAccountNumber = String.Empty;
            Request.S02PayingAccountNumber = String.Empty;
            Request.WayBillReturnEmail = String.Empty;

            {
                // Insurance
                XuInsuranceCurrency.Text = String.IsNullOrWhiteSpace(XuInsuranceCurrency.Text) ? "DKK" : XuInsuranceCurrency.Text;
                if (XuInsuranceCurrency.Text.Length != 3)
                {
                    XuInsuranceCurrency.Text = @"Specify 3 characters";
                }
                Request.InsuranceCurrencyCode = XuInsuranceCurrency.Text;
                decimal t1;
                Request.InsuranceValue = decimal.TryParse(XuInsuranceValue.Text, out t1) ? t1 : 0m;
            }


            // Pickup.
            {
                Request.AddressPickup = String.IsNullOrWhiteSpace(XuPcName.Text) ? null : new V3dAddress
                {
                    Attention = XuPcAttention.Text,
                    CountryCode = XuPcCountryCode.Text,
                    Email = XuPcEmail.Text,
                    Name = XuPcName.Text,
                    Phone = XuPcPhone.Text,
                    Reference = XuPcRef.Text,
                    Street1 = XuPcStreet1.Text,
                    Street2 = XuPcStreet2.Text,
                    ZipCode = XuPcZip.Text,
                    City = XuPcCity.Text,
                };
            }
            // Receiver
            Request.AddressReceiver = new V3dAddress
                {
                    Attention = XuRcAttention.Text,
                    CountryCode = XuRcCountryCode.Text,
                    Email = XuRcEmail.Text,
                    Name = XuRcName.Text,
                    Phone = XuRcPhone.Text,
                    Reference = XuRcRef.Text,
                    Street1 = XuRcStreet1.Text,
                    Street2 = XuRcStreet2.Text,
                    ZipCode = XuRcZip.Text,
                    City = XuRcCity.Text,
                };

            // Return Address
            Request.AddressReturn = String.IsNullOrWhiteSpace(XuRaCity.Text) ? null : new V3dAddress
            {
                Attention = XuRaAttention.Text,
                CountryCode = XuRaCountryCode.Text,
                Email = XuRaEmail.Text,
                Name = XuRaName.Text,
                Phone = XuRaPhone.Text,
                Reference = XuRaRef.Text,
                Street1 = XuRaStreet1.Text,
                Street2 = XuRaStreet2.Text,
                ZipCode = XuRaZip.Text,
                City = XuRaCity.Text,
            };

            {
                uint t1;
                Request.SalesproductId = uint.TryParse(XuSalesProdId.Text, out t1) ? t1 : 0;
            }

            {
                DateTime t1;
                Request.ShippingDate = DateTime.TryParse(XuShipDate.Text, out t1) ? t1 : DateTime.Now.Date;
            }

            {
                V3cShipmentType t1;
                Request.ShipmentType = Enum.TryParse(XuShipmentType.Text, out t1) ? t1 : V3cShipmentType.NonDocument;
                XuShipmentType.Text = Request.ShipmentType.ToString("G");
            }

            // Sender
            Request.AddressSender = new V3dAddress
                {
                    Attention = XuSnAttention.Text,
                    CountryCode = XuSnCountryCode.Text,
                    Email = XuSnEmail.Text,
                    Name = XuSnName.Text,
                    Phone = XuSnPhone.Text,
                    Reference = XuSnRef.Text,
                    Street1 = XuSnStreet1.Text,
                    Street2 = XuSnStreet2.Text,
                    ZipCode = XuSnZip.Text,
                    City = XuSnCity.Text,
                };
            Request.Username = XuUsername.Text;

            {
                V3cImageEncoding t1;
                Request.ImageEncoding = Enum.TryParse(XuWaybillEncoding.Text, out t1) ? t1 : V3cImageEncoding.PDF;
            }
            {
                V3cWaybillImageFormat t1;
                Request.WaybillImageFormat = Enum.TryParse(XuWaybillFormat.Text, out t1) ? t1 : V3cWaybillImageFormat.A4;
            }

            {
                Request.DeliveryNotificationEmail = XuDropPointEmail.Text;
                Request.DeliveryNotificationSms = XuDropPointSms.Text;
                Request.DropPoint = XuDropPointId.Text;
            }

            {
                V3cPickupDelivery pd;

                Request.PickupDelivery = Enum.TryParse(XuPickupDelivery.SelectedItem.ToString(), out pd) ? pd : V3cPickupDelivery.Undefined;

                int hour;
                int min;

                if (!(int.TryParse(XuPickupReadyHh.Text, out hour))) { throw new ArgumentException("Pickup ready Hour"); }
                if (!(int.TryParse(XuPickupReadyMm.Text, out min))) { throw new ArgumentException("Pickup ready Minute"); }
                Request.PickupFrom = Request.ShippingDate.Date.AddHours(hour).AddMinutes(min);

                if (!(int.TryParse(XuPickupCloseHh.Text, out hour))) { throw new ArgumentException("Pickup close Hour"); }
                if (!(int.TryParse(XuPickupCloseMm.Text, out min))) { throw new ArgumentException("Pickup close Minute"); }
                Request.PickupUntil = Request.ShippingDate.Date.AddHours(hour).AddMinutes(min);

                V3cPickupHandling ph;
                Request.PickupHandling = Enum.TryParse(XuPickupHandling.SelectedItem.ToString(), out ph) ? ph : V3cPickupHandling.Unconditional;

                Request.NotifyReceiver = XuNotifyReceiver.Checked;

            }

            {
                V3cWaybillImageFormat t1;
                Request.WaybillImageFormat = Enum.TryParse(XuWsWaybillImageFormat.Text, out t1)
                    ? t1
                    : V3cWaybillImageFormat.A4;
            }

        }


        public Form1()
        {
            InitializeComponent();
            BusinessContext = new ShipmentPortalBi();
            Request = new V3dRequest
            {
                ParcelList = new List<V3dParcel>().ToArray(),
                AdditionalServiceList = new List<V3dService>().ToArray()
            };
        }


        private void XuConfigLoad_Click(object sender, EventArgs e)
        {

            BusinessContext.SettingsLoad();
            // ReSharper disable once UnusedVariable
            object t1 = BusinessContext.Request;


            Request = BusinessContext.Request ?? new V3dRequest();
            Request.ParcelList = new List<V3dParcel>().ToArray();
            Request.AdditionalServiceList = new List<V3dService>().ToArray();
            Request.UploadDocumentList = new V3dUploadDocument[0];
            //Request.AdditionalServiceList.Clear();
            PopulateFields();
            XuSubmit.Enabled = false;
        }


        private void XuConfigSave_Click(object sender, EventArgs e)
        {
            //BusinessContext.SettingsSave();
            ReadFields();

            foreach (var ud in Request.UploadDocumentList)
            {
                ud.ImageBase64 = null;
            }

            BusinessContext.Request = Request;
            BusinessContext.SettingsSave();
        }


        public static string ToXmlString(object value)
        {
            String result;
            var serializer = new XmlSerializer(value.GetType());
            using (var sw = new StringWriter())
            {
                serializer.Serialize(sw, value);
                result = sw.ToString();
            }
            return result;
        }


        //private void AddReturnAddress()
        //{
        //    Request.ReturnAddress = new Address
        //    {
        //        Attention = "RAA",
        //        City = "RAC",
        //        CountryCode = "DK",
        //        Email = "vij@gtx.nu",
        //        Name = "Villy",
        //        Phone = "21174505",
        //        Reference = "RAR",
        //        StateCode = "",
        //        Street1 = "Stavnsholt Gydevej",
        //        Street2 = "70",
        //        ZipCode = "3460"
        //    };
        //}

        //private void AddServices()
        //{

        //    Request.Services =
        //        (
        //            new[]
        //            {
        //                new WsServiceV2
        //                {
        //                    Name = V3cServiceCode.FlexDeposit,
        //                    Parameters = new[] {"Stilles ved bagdør"}
        //                }
        //            }
        //        );
        //}


        private void XuSubmit_Click(object sender, EventArgs e)
        {
            XuSubmit.Enabled = false;

            ReadFields();

            #region UploadDocument

            var uploadDocumentSave = new List<V3dUploadDocument>();
            foreach (var ud in Request.UploadDocumentList)
            {
                uploadDocumentSave.Add(
                    new V3dUploadDocument
                    {
                        Filename = ud.Filename,
                        ImageBase64 = null,
                        ImageEncoding = ud.ImageEncoding,
                        ImageType = ud.ImageType,
                    }
                );
            }

            DocumentUploadRead();

            foreach (var ud in Request.UploadDocumentList)
            {
                // Strip off path.
                ud.Filename = new FileInfo(ud.Filename).Name;
            }
            #endregion

            //AddReturnAddress();

            //AddServices();


            BusinessContext.Request = Request;

            if (!(BusinessContext.Execute())) // -------------> extern call --------> response
            {
                // Failure

                Clipboard.SetText(ToXmlString(BusinessContext.Response));

                var msg = new StringBuilder();
                msg.Append(String.IsNullOrWhiteSpace(BusinessContext.Response.StatusText) ? "" : String.Format("{0}", BusinessContext.Response.StatusText));

                if (BusinessContext.Response.StatusList != null)
                {
                    foreach (var current in BusinessContext.Response.StatusList)
                    {
                        msg.AppendFormat("{0}", msg.Length > 0 ? "\r\n" : "");
                        msg.Append(String.IsNullOrWhiteSpace(current.Code) ? "" : String.Format("Code: {0}, ", current.Code));
                        msg.Append(String.IsNullOrWhiteSpace(current.FieldName) ? "" : String.Format("Field: {0}, ", current.FieldName));
                        msg.Append(String.IsNullOrWhiteSpace(current.Code) ? "" : String.Format("Severity: {0}, ", current.Severity));
                        msg.Append(String.IsNullOrWhiteSpace(current.Code) ? "" : String.Format("Description: {0}", current.Text));
                    }
                }

                MessageBox.Show(msg.ToString());
            }
            else
            {
                // Success

                try
                {
                    if (BusinessContext.Response.BinaryImageList != null && BusinessContext.Response.BinaryImageList.Any())
                    {
                        var current = BusinessContext.Response.BinaryImageList[0];
                        var t1 = current.ImageBase64;
                        byte[] bytes = Convert.FromBase64String(t1);

                        const string path = @"C:\Users\Administrator\Downloads";
                        var name = String.Format("WayBill {0}.pdf", BusinessContext.Response.WayBillNumberHead);

                        var fullpath = Path.Combine(path, name);
                        var file = new FileInfo(fullpath);

                        using (var fs = file.OpenWrite())
                        {
                            foreach (var b in bytes)
                            {
                                fs.WriteByte(b);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show(@"No image returned");
                    }

                }
                // ReSharper disable once RedundantCatchClause
                // ReSharper disable once UnusedVariable
                catch (Exception ex)
                {
                    throw;
                }

                Clipboard.SetText(ToXmlString(BusinessContext.Response));
                MessageBox.Show(@"OK\r\n" + ToXmlString(BusinessContext.Response));
            }

            Request.UploadDocumentList = uploadDocumentSave.ToArray();

            XuSubmit.Enabled = true;
        }


        private decimal ReadDecimalField(TextBox textBoxControl)
        {
            decimal t1;
            if (!(decimal.TryParse(textBoxControl.Text, out t1)))
            {
                var msg = String.Format("Unable to parse decimal falue from field {0}", textBoxControl.Name);
                var saved = textBoxControl.BackColor;
                textBoxControl.BackColor = Color.Red;
                MessageBox.Show(msg);
                textBoxControl.BackColor = saved;
            }
            return t1;
        }


        private void XuColliAdd_Click(object sender, EventArgs e)
        {
            var parcel = new V3dParcel
                {
                    DryIceWeight = ReadDecimalField(XuCollDryIce),
                    Height = ReadDecimalField(XuColliHeight),
                    Length = ReadDecimalField(XuColliLength),
                    Weight = ReadDecimalField(XuCollWeight),
                    Width = ReadDecimalField(XuColliWidth),
                };


            var t1 = (new List<V3dParcel>(Request.ParcelList) { parcel }).ToArray();
            Request.ParcelList = t1;

            XuColliCount.Text = Request.ParcelList.Count().ToString(CultureInfo.InvariantCulture);

            XuSubmit.Enabled = Request.ParcelList.Any();

        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }


        private void label33_Click(object sender, EventArgs e)
        {

        }


        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }


        private void label43_Click(object sender, EventArgs e)
        {

        }


        private void XuClose_Click(object sender, EventArgs e)
        {
            Close();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            var additionalServiceList = Enum.GetNames(typeof(V3cServiceCode));
            XuAdditionalService.DataSource = additionalServiceList;

            UploadDocumentInitGui();
        }


        private void XuServiceAdd_Click(object sender, EventArgs e)
        {
            V3cServiceCode t1;
            if (Enum.TryParse(XuServiceCode.SelectedValue.ToString(), out t1) && !(String.IsNullOrWhiteSpace(XuServiceText1.Text)))
            {
                var t2 = new V3dService
                {
                    ServiceCode = t1,
                    ParameterList = new List<string> { XuServiceText1.Text }.ToArray(),
                };
                var t3 = Request.AdditionalServiceList.ToList();
                t3.Add(t2);
                Request.AdditionalServiceList = t3.ToArray();
            }

            XuServiceCount.Text = Request.AdditionalServiceList.Count().ToString();
        }


        private void XuTestException_Click(object sender, EventArgs e)
        {
            BusinessContext.TestException();
        }


        private void XuASAdd_Click(object sender, EventArgs e)
        {
            if (Request.AdditionalServiceList == null) { Request.AdditionalServiceList = new List<V3dService>().ToArray(); }

            V3cServiceCode t1;

            var t2 = Request.AdditionalServiceList.ToList();

            t2.Add(new V3dService
                {
                    ParameterList = new List<string> { XuAdditionalServiceText.Text }.ToArray(),
                    ServiceCode = Enum.TryParse(XuAdditionalService.SelectedIndex.ToString(), out t1) ? t1 : V3cServiceCode.SUNDEF
                }
            );

            Request.AdditionalServiceList = t2.ToArray();

            XuASCount.Text = Request.AdditionalServiceList.Count().ToString();
        }

        #region Upload Document

        private void UploadDocumentInitGui()
        {
            {
                var t1 = Enum.GetNames(typeof(V3cUploadDocumentEncoding));
                XuUploadDocumentEncoding.DataSource = t1;
                XuUploadDocumentEncoding.SelectedIndex = 1;
            }
            {
                var t1 = Enum.GetNames(typeof(V3cUploadDocumentType));
                XuUploadDocumentPurpose.DataSource = t1;
                XuUploadDocumentPurpose.SelectedIndex = 1;
            }

            XuUploadDocumentFilename.Text = "";

            Request.UploadDocumentList = new V3dUploadDocument[0];
            XuUploadDocumentCount.Text = Request.UploadDocumentList.Length.ToString();

        }

        private void XuUploadDocumentAdd_Click(object sender, EventArgs e)
        {
            var uploadDocument = new V3dUploadDocument();

            {
                V3cUploadDocumentEncoding t1;
                uploadDocument.ImageEncoding = Enum.TryParse(XuUploadDocumentEncoding.SelectedIndex.ToString(), out t1) ? t1 : V3cUploadDocumentEncoding.Undefined;
            }

            {
                V3cUploadDocumentType t1;
                uploadDocument.ImageType = Enum.TryParse(XuUploadDocumentPurpose.SelectedIndex.ToString(), out t1) ? t1 : V3cUploadDocumentType.Undefined;
            }

            uploadDocument.Filename = XuUploadDocumentFilename.Text;


            var t2 = (Request.UploadDocumentList ?? new V3dUploadDocument[1]).ToList();
            t2.Add(uploadDocument);
            Request.UploadDocumentList = t2.ToArray();

            XuUploadDocumentCount.Text = Request.UploadDocumentList.Length.ToString();

        }

        private void DocumentUploadRead()
        {
            foreach (var ud in Request.UploadDocumentList)
            {
                var bytes = File.ReadAllBytes(ud.Filename);
                var b64 = Convert.ToBase64String(bytes);
                ud.ImageBase64 = b64;
            }
        }


        private void XuUploadDocumentBrowse_Click(object sender, EventArgs e)
        {
            openFileDialog1.AddExtension = true;
            openFileDialog1.CheckFileExists = true;
            openFileDialog1.DefaultExt = XuUploadDocumentEncoding.SelectedIndex.ToString();
            openFileDialog1.Multiselect = false;
            openFileDialog1.ShowDialog();
            XuUploadDocumentFilename.Text = openFileDialog1.FileName;
        }

        #endregion

    }
}
