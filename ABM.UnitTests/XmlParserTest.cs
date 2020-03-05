
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Xml;

namespace ABM.Tests
{
    /// <summary>
    /// Class contains test methods forjABM.Core library XMLParser class GetRefText method test cases
    /// Payload Xml Web service method test cases
    ///  Method Naming convention <METHOD NAME,BEHAVIOR,EXPECTED RESULT>
    /// </summary>
    [TestClass]
    public class XmlParserTest
    {

        #region RefTest_Unit_Tests

            /// <summary>
            /// Method takes xml file, load xml and send to ABM.core Library GetRefText method along with Ref codes to be search in the xml document.
            /// Expected output is an array with Ref text element values.
            /// </summary>
            [TestMethod]
            public void GetRefText_RefCodes_ReturnRefTextArray()
            {
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(@"XmlSampleFiles/ReferenceText.xml");
                var result = XmlParser.GetRefText(new string[] { "MWB", "TRV", "CAR" },xmlDocument.DocumentElement);
                Assert.IsTrue(result?.Length > 0);
            }

            /// <summary>
            /// Method takes xml file, load xml and send to ABM.core Library GetRefText method along with empty array to be search in the xml document.
            /// Expected output is an empty array.
            /// </summary>
            [TestMethod]
            public void GetRefText_EmptyArray_ReturnEmptyArray()
            {
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(@"XmlSampleFiles/ReferenceText.xml");
                var result = XmlParser.GetRefText(new string[] { }, xmlDocument.DocumentElement);
                Assert.IsTrue(result?.Length == 0);
            }

            /// <summary>
            /// Method passes null file pointer to ABM.core Library GetRefText method along null object instead of an array to be search.
            /// Expected output is an empty array.
            /// </summary>
            [TestMethod]
            public void GetRefText_NullObject_ReturnEmptyArray()
            {
                
                var result = XmlParser.GetRefText(null,null);
                Assert.IsTrue(result?.Length == 0);
            }

            /// <summary>
            /// Method takes xml file, load xml and send to ABM.core Library GetRefText method along with false ref codes to be search in the xml document.
            /// Expected output is an empty array.
            /// </summary>
            [TestMethod]
            public void GetRefText_FalseRefCodes_ReturnEmptyArray()
            {
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(@"XmlSampleFiles/ReferenceText.xml");
                var result = XmlParser.GetRefText(new string[] { "MWB100", "TRV100", "CAR100" }, xmlDocument.DocumentElement);
                Assert.IsTrue(result?.Length == 0);
            }

        #endregion

        #region XML_Payload_Tests

            /// <summary>
            /// Method creates web service instance, load xml document and send loaded xml document to ABM.Core Library GetStatusCodeofXMLPayload method
            /// Expected output is 0, if xml payload is correct
            /// </summary>
            [TestMethod]
            public void GetStatusCodeOfXMLPayload_CorrectPayloadXML_ReturnZero()
            {
           
                ABM.UnitTests.WebService.XmlPayloadServiceClient xmlPayloadServiceClient = new ABM.UnitTests.WebService.XmlPayloadServiceClient();

                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load( @"XmlSampleFiles/Payload.xml");

                int result = xmlPayloadServiceClient.GetStatusCodeOfXMLPayload(xmlDocument.DocumentElement);
                Assert.AreEqual(0, result);
            }

            /// <summary>
            /// Method creates web service instance, load xml document and send loaded xml document to ABM.Core Library GetStatusCodeofXMLPayload method
            /// Access Declaration element of payload using xpath query and change the value of Command attribute to abc
            /// Expected output is -1, because Command not equals to DEFAULT
            /// </summary>
            [TestMethod]
            public void GetStatusCodeOfXMLPayload_DeclarationCommandNotEqualToDefault_ReturnMinusOne()
            {

                ABM.UnitTests.WebService.XmlPayloadServiceClient xmlPayloadServiceClient = new ABM.UnitTests.WebService.XmlPayloadServiceClient();

                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(@"XmlSampleFiles/Payload.xml");
                xmlDocument.SelectSingleNode("//Declaration").Attributes.GetNamedItem("Command").InnerText = "ABC";

                int result = xmlPayloadServiceClient.GetStatusCodeOfXMLPayload(xmlDocument.DocumentElement);
                Assert.AreEqual(-1, result);
            }

            /// <summary>
            /// Method creates web service instance, load xml document and send loaded xml document to ABM.Core Library GetStatusCodeofXMLPayload method
            /// Access Declaration element of payload using xpath query and change the value of Command attribute to DEFAULT
            /// Expected output is 0, because Command equals to DEFAULT
            /// </summary>
            [TestMethod]
            public void GetStatusCodeOfXMLPayload_DeclarationCommandEqualToDefault_ReturnZero()
            {

                ABM.UnitTests.WebService.XmlPayloadServiceClient xmlPayloadServiceClient = new ABM.UnitTests.WebService.XmlPayloadServiceClient();

                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(@"XmlSampleFiles/Payload.xml");
                xmlDocument.SelectSingleNode("//Declaration").Attributes.GetNamedItem("Command").InnerText = "DEFAULT";

                int result = xmlPayloadServiceClient.GetStatusCodeOfXMLPayload(xmlDocument.DocumentElement);
                Assert.AreEqual(0, result);
            }


            /// <summary>
            /// Method creates web service instance, load xml document and send loaded xml document to ABM.Core Library GetStatusCodeofXMLPayload method
            /// Access SiteID element of payload using xpath query and changes the value of SiteID element to ABC
            /// Expected output is -2, because SiteID not equals to DUB
            /// </summary>
            [TestMethod]
            public void GetStatusCodeOfXMLPayload_SiteIDNotEqualDub_ReturnMinusTwo()
            {

                ABM.UnitTests.WebService.XmlPayloadServiceClient xmlPayloadServiceClient = new ABM.UnitTests.WebService.XmlPayloadServiceClient();

                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(@"XmlSampleFiles/Payload.xml");
      
                xmlDocument.SelectSingleNode("//SiteID").InnerText = "ABC";

                int result = xmlPayloadServiceClient.GetStatusCodeOfXMLPayload(xmlDocument.DocumentElement);
                Assert.AreEqual(-2, result);
            }

            /// <summary>
            /// Method creates web service instance, load xml document and send loaded xml document to ABM.Core Library GetStatusCodeofXMLPayload method
            /// Access SiteID element of payload using xpath query and changes the value of SiteID element to DUB
            /// Expected output is 0, because SiteID equals to DUB
            /// </summary>
            [TestMethod]
            public void GetStatusCodeOfXMLPayload_SiteIDEqualDub_ReturnZero()
            {

                ABM.UnitTests.WebService.XmlPayloadServiceClient xmlPayloadServiceClient = new ABM.UnitTests.WebService.XmlPayloadServiceClient();

                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(@"XmlSampleFiles/Payload.xml");
                xmlDocument.SelectSingleNode("//SiteID").InnerText = "DUB";

                int result = xmlPayloadServiceClient.GetStatusCodeOfXMLPayload(xmlDocument.DocumentElement);
                Assert.AreEqual(0, result);
            }
        #endregion

    }
}
