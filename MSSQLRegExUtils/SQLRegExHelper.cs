using Microsoft.SqlServer.Server;
using System.Data.SqlTypes;
using System.Text.RegularExpressions;

namespace MSSQLRegExUtils
{
    public class SQLRegExHelper
    {
        [SqlFunction]
        public static bool Match(string inputValue, string regexPattern)
        {
            if (string.IsNullOrEmpty(inputValue) || string.IsNullOrEmpty(regexPattern))
                return false;

            Regex r1 = new Regex(regexPattern.TrimEnd(null));
            return r1.Match(inputValue.TrimEnd(null)).Success;
        }

        [SqlFunction]
        public static SqlString Replace(string inputValue, string regexPattern, string replacePattern)
        {
            var result = string.Empty;

            if (!string.IsNullOrEmpty(inputValue) || !string.IsNullOrEmpty(regexPattern) || !string.IsNullOrEmpty(replacePattern))
            {
                result = Regex.Replace(inputValue, regexPattern, replacePattern);
            }

            return new SqlString(result);

        }
    }
}
