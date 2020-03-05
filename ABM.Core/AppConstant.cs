

namespace ABM
{
    /// <summary>
    /// AppConstant class contains only hard coded values, which will be used in entire other class of current assembly.
    /// </summary>
    public static class AppConstant
    {
        public const string RegularExpPattern = @"\b[LOC]{3}[\s+0-9]{1,}[\sA-Z0-9]{1,}";
        public  const string PlusSign = "+";

        public const string ReferenceTag = "Reference";
        public const string RefCodeTag = "RefCode";
        public const string RefTextTag = "RefText";

        public const string DeclarationTag = "Declaration";
        public const string CommandTag = "Command";
        public const string DefaultTag = "DEFAULT";

        public const string SiteIDTag = "SiteID";
        public const string DubTag = "DUB";
    }
}
