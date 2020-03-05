using System.Xml;

namespace ABM.WebService
{
    /// <summary>
    /// A WebService class handles payload.
    /// </summary>
    public class XmlPayloadService : IXmlPayloadService
    {
        /// <summary>
        /// Web service method that calls ABM.core library method ParseWeebApiXml, takes xml payload as a input parameter.
        /// If payload is correct it will return 0
        /// If Command is not equals to DEFAULT, it will return -1
        /// If SiteID is not equals to DUB, it will return -2
        /// </summary>
        /// <param name="xmlElement"></param>
        /// <returns>Return integer</returns>
        public int GetStatusCodeOfXMLPayload(XmlElement xmlElement)
        {
           //Calling ABM.Core library method and passing xml payload as xmlElement
            return XmlParser.ParseWebApiXML(xmlElement); 
        }
    }
}
