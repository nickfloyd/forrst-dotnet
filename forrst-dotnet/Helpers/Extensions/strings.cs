using System.Text;
using System.Text.RegularExpressions;
namespace System {
    public static class StringExtensions {

        public static string UrlEncode(this string s) {
            return System.Web.HttpUtility.UrlEncode(s);
        }

        public static string UrlDecode(this string s) {
            return System.Web.HttpUtility.UrlDecode(s);
        }

    }
}

