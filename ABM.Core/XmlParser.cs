using System;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

namespace ABM
{
    /// <summary>
    /// Xml parser class provides functionality to get Reference text xml tag value.
    /// Parse xml document as payload
    /// return different status codes if xml do not match with defined business rules. 
    /// All method of the class are static, to avoid creating of an object of this class.
    /// </summary>
    public class XmlParser
    {
        //private constructor to block instance creation of XmlParser class
        private XmlParser()
        { }

        /// <summary>
        ///method searches given reference codes in xml document and returns Reference Text value for each given code
        /// </summary>
        /// <param name="refcodes">An array of search criteria elements</param>
        /// <param name="xmlDoc">Xml document as an element to be processed</param>
        /// <returns>An array of string with all reference codes found for specified criteria</returns>
        public static string[] GetRefText(string[] refcodes, XmlElement xmlDoc)
        {
            try
            {
                //Parsing xml document passed as input parameter
                XDocument xdoc = XDocument.Parse(xmlDoc.InnerXml);

                //Using linq query to get Reference Text values for given reference codes, if values are found it will return an array with results otherwise empty array it will return.
                //In modern techniques linq is more efficient than creating a logic for this search criteria.
                return xdoc?.Descendants(AppConstant.ReferenceTag)?.Where(x => refcodes?.Contains(x.Attribute(AppConstant.RefCodeTag)?.Value) == true)?.Descendants(AppConstant.RefTextTag)?.Select(refText => refText.Value)?.ToArray();
            }
            catch (Exception)
            {
                return new string[] { };
            }

        }

        /// <summary>
        ///Method checks xml payload correct or not. if all values match to business rules then returns 0
        ///If command value is not equals to DEFUALT then return -1
        ///If SiteID value is not equals to DUB then return -2
        /// </summary>
        /// <param name="xmlDoc">takes xml document as input parameter to check the xml payload</param>
        /// <returns>following values return 0-Correct xml, -1 Command <> DEFAULT and SiteID <> DUB</returns>
        public static short ParseWebApiXML(XmlElement xmlDoc)
        {
            //initializing code variable with 0, if entire xml is correct it will return zero
            short code = 0;

            //Parsing Xml passed as parameter 
            XDocument xdoc = XDocument.Parse(xmlDoc.InnerXml);
               
            //if Command attribute is not equals to DEFAULT then return -1.
            if (xdoc?.Descendants(AppConstant.DeclarationTag)?.Count(x => x.Attribute(AppConstant.CommandTag)?.Value != AppConstant.DefaultTag) > 0)
                code = - 1;

            //If SiteID value is not equals to DUB return -2
            if (xdoc?.Descendants(AppConstant.SiteIDTag)?.Count(x => x.Value != AppConstant.DubTag) > 0)
                code = - 2;
           
            return code;
        }

    }
}
