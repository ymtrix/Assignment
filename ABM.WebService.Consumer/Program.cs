using System;
using System.Xml;

namespace ABM.WebService.Consumer
{
    class Program
    {
        static void Main()
        {
            try
            {
                //Creating Web service instance
                ABM.WebService.WSProxy.XmlPayloadServiceClient xmlPayloadServiceClient = new ABM.WebService.WSProxy.XmlPayloadServiceClient();

                XmlDocument xmlDocument = new XmlDocument();
                //Loading Xml from file stored in bin, by default Payloa.xml property set to alwaycopy to app folder.
                xmlDocument.Load(@"Payload.xml");

                //If xml loaded, return zero if everything is correct.
                Console.WriteLine(String.Format("XML Paylod is Correct :{0}", xmlPayloadServiceClient.GetStatusCodeOfXMLPayload(xmlDocument.DocumentElement)));

                //Expected output is -1 because command value is not DEFAULT
                xmlDocument.SelectSingleNode("//Declaration").Attributes.GetNamedItem("Command").InnerText = "ABC";
                Console.WriteLine(String.Format("Declaration :{0}", xmlPayloadServiceClient.GetStatusCodeOfXMLPayload(xmlDocument.DocumentElement)));

                //Expected Output is -2 is because SiteID value is not DUB
                xmlDocument.SelectSingleNode("//SiteID").InnerText = "XYZ";
                Console.WriteLine(String.Format("SiteID :{0}", xmlPayloadServiceClient.GetStatusCodeOfXMLPayload(xmlDocument.DocumentElement)));

                Console.ReadKey();
            }
            catch (Exception exp)
            {
                //File not loaded
                Console.WriteLine(String.Format("XML File either not loaded or incorrect. Error Info:{0}",exp.Message));
            }
         
        }
    }
}
