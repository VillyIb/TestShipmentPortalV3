using System;
using System.IO;
using System.Xml.Serialization;

using TestShipmentPortal.BookingPortalV3;

namespace TestShipmentPortal.AppCode
{
    public class ShipmentPortalBi
    {
        private UserInput2 zUserInput;
        public UserInput2 UserInput2
        {
            get { return zUserInput ?? (zUserInput = new UserInput2()); }
        }

        public V3dRequest Request { get; set; }

        public V3dResponse Response { get; set; }


        public void TestException()
        {
            var wsClient = new V3BookingSoapClient("V3BookingSoap12");

            wsClient.Exception(0);

        }

        public bool Execute()
        {
            var wsClient = new V3BookingSoapClient("V3BookingSoap12");


            wsClient.Ping();

            Response = wsClient.Booking("vij", "Turnip592", Request);
            //var bookingResponseV1 = wsClient.Booking("admin", "Turnip592", bookingRequestLive);
            //var bookingResponseV1 = wsClient.Booking("CRWebServiceUser", "Cr20150522", bookingRequestLive);


            return Response.Success;
        }

        public void SettingsSave()
        {
            String serialized;
            var serializer = new XmlSerializer(Request.GetType());
            using (var sw = new StringWriter())
            {
                serializer.Serialize(sw, Request);
                serialized = sw.ToString();
            }

            UserInput2.RequestV2 = serialized;

            UserInput2.Save();
        }

        public void SettingsLoad()
        {
            var t1 = UserInput2.RequestV2;

            if (String.IsNullOrWhiteSpace(t1))
            {
                Request = new V3dRequest();
            }
            else
            {
                var serializer = new XmlSerializer(typeof(V3dRequest));

                using (var sr = new StringReader(t1))
                {
                    var t2 = serializer.Deserialize(sr);
                    Request = t2 as V3dRequest;
                }
            }
        }
    }
}
