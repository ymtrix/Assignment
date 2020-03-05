using System;


namespace ABM.EdiFactClient
{
    class Program
    {
        static void Main()
        {
            //EdiFact String
            string strEdiFact = @"UNA: +.? 'UNB+UNOC:3+2021000969+4441963198+180525:1225+3VAL2MJV6EH9IX+KMSV7HMD+CUSDECU-IE++1++1'UNH + EDIFACT + CUSDEC:D: 96B: UN: 145050'BGM+ZEM:::EX+09SEE7JPUV5HC06IC6+Z'LOC + 17 + IT044100'LOC+18+SOL'LOC + 35 + SE'LOC+36+TZ'LOC + 116 + SE003033'DTM+9:20090527:102'DTM + 268:20090626:102'DTM+182:20090527:102'";
            
            //Parsing EdiFact string if it contains Loc along with segment values, function will return an array of all loc segments in EdiFact string.
            var result = EdiFact.ParseString(strEdiFact);

            //Iterating each loc segment return by the EdiFact parse method and displaying on the console all segments value
            foreach (var locSegments in result)
                Console.WriteLine(String.Format("Segment: {0}-{1}", locSegments[0]?.Trim(), locSegments[1]?.Trim()));

            Console.ReadKey();
        }
    }
}
