using System;
using System.Xml;

namespace ABM.RefText.Client
{
    class Program
    {
        static void Main()
        {
            //Creating an xmlDocument element instance
            XmlDocument xmlDocument = new XmlDocument();
            //Loading ReferenceText xml file data from bin folder, by default Reference.xml file property set to alway copy file to app directory
            xmlDocument.Load(@"ReferenceText.xml");

            //passing MWB,TRV,CAR values to read their RefText Tag value, if these tag are available then method will return an array with Ref text for these 3 tags.
            var result = XmlParser.GetRefText(new string[] { "MWB", "TRV", "CAR" }, xmlDocument.DocumentElement);

            //Iterating each result and displaying RefText value on console.
            foreach (var refTextItem in result)
                Console.WriteLine(String.Format("RefText :{0}", refTextItem));

            Console.ReadKey();

        }
    }
}
