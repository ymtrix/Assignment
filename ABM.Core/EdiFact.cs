
using System.Text.RegularExpressions;
using System.Linq;

namespace ABM
{
    /// <summary>
    /// This class contains is responsible to perform operations on EdiFact strings.
    /// Class contains only static method to parse EdiFact string.
    /// </summary>
    public class EdiFact
    {
       //Private constructor to block instance creating of this class
        private EdiFact()
        {}

        /// <summary>
        /// Method takes EdiFact string, tries to search loc segments, if segments are found then return an array of all loc segments
        /// if no segment found then return empty array
        /// </summary>
        /// <param name="EdiFactText">input EdiFact string</param>
        /// <returns>an array of loc segments</returns>
        public static string[][] ParseString(string EdiFactText)
        {
            //using regular expression to search loc segments into EdiFact string. Regular expression is defined in AppConstant class
            //If expression match then returns all loc ssegments with loc values as a array
            var locArrary = Regex.Matches(EdiFactText, AppConstant.RegularExpPattern);

            //filtering loc from the matched segments and return an array with segments.
            return locArrary?.Cast<Match>().Select(locSegment =>  locSegment?.Value.Split(new string[] { AppConstant.PlusSign }, System.StringSplitOptions.RemoveEmptyEntries)?.Skip(1).ToArray() ).ToArray();
        }
    }
}

