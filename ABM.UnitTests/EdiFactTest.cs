
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ABM.Tests
{
    /// <summary>
    /// EdiFact Test class contains test methods to test EdiFact in ABM.Core library dll
    /// Method Naming convention <METHOD NAME,BEHAVIOR,EXPECTED RESULT>
    /// </summary>
    [TestClass]
    public class EdiFactTest
    {
        /// <summary>
        /// Method tests empty string 
        /// Expected output is zero length array
        /// </summary>
        [TestMethod]
        public void PraseString_EmptyString_ReturnZeroLenghtObject()
        {
           var result  = EdiFact.ParseString("");
            Assert.IsTrue(result?.Length == 0);
        }

        /// <summary>
        /// Method tests EdiFact string 
        /// Expected output is an array with loc segments
        /// </summary>
        [TestMethod]
        public void PraseString_EditFactString_ReturnLocArray()
        {
            var result = EdiFact.ParseString(@"UNA: +.? 'UNB+UNOC:3+2021000969+4441963198+180525:1225+3VAL2MJV6EH9IX+KMSV7HMD+CUSDECU-IE++1++1'UNH + EDIFACT + CUSDEC:D: 96B: UN: 145050'BGM+ZEM:::EX+09SEE7JPUV5HC06IC6+Z'LOC + 17 + IT044100'LOC+18+SOL'LOC + 35 + SE'LOC+36+TZ'LOC + 116 + SE003033'DTM+9:20090527:102'DTM + 268:20090626:102'DTM+182:20090527:102'");
            Assert.IsTrue(result?.Length > 0);
        }

        /// <summary>
        /// Method Tests EdiFact string with carriage return characters
        /// Expected output is an array with loc segments
        /// </summary>
        [TestMethod]
        public void PraseString_EditFactStringWithCarriageReturn_ReturnLocArray()
        {
            var result = EdiFact.ParseString(@"UNA:+.? '
                                UNB + UNOC:3 + 2021000969 + 4441963198 + 180525:1225 + 3VAL2MJV6EH9IX + KMSV7HMD + CUSDECU - IE++1++1'
                                UNH + EDIFACT + CUSDEC:D: 96B: UN: 145050'
                                BGM + ZEM:::EX + 09SEE7JPUV5HC06IC6 + Z'
                                LOC + 17 + IT044100'
                                LOC + 18 + SOL'
                                LOC + 35 + SE'
                                LOC + 36 + TZ'
                                LOC + 116 + SE003033'
                                DTM + 9:20090527:102'
                                DTM + 268:20090626:102'
                                DTM + 182:20090527:102'");
            Assert.IsTrue(result?.Length > 0);
        }

        /// <summary>
        /// Method tests EdiFact string without loc values
        /// Expected output is an empty array
        /// </summary>
        [TestMethod]
        public void PraseString_EditFactStringWithoutLOC_ReturnZeroObject()
        {
            var result = EdiFact.ParseString(@"UNA:+.? '
                                UNB + UNOC:3 + 2021000969 + 4441963198 + 180525:1225 + 3VAL2MJV6EH9IX + KMSV7HMD + CUSDECU - IE++1++1'
                                UNH + EDIFACT + CUSDEC:D: 96B: UN: 145050'
                                BGM + ZEM:::EX + 09SEE7JPUV5HC06IC6 + Z'
                                DTM + 9:20090527:102'
                                DTM + 268:20090626:102'
                                DTM + 182:20090527:102'");
            Assert.IsTrue(result?.Length == 0);
        }
    }
}
