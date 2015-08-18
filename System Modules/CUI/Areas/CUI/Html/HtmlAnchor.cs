using System;

namespace CloudCore.Web.Html
{
    public static class StringExtensions
    {
        public static int LastIndexOfAny(this string stringBeingSearched, int startIndex = 0, params string[] stringsToFind)
        {
            int index = -1;

            foreach (string stringToFind in stringsToFind)
            {
                var index2 = stringBeingSearched.IndexOf(stringToFind, startIndex + index + 1, StringComparison.Ordinal);

                if (index2 > index)
                    index = index2;
            }

            return index;
        }

        public static int IndexOfAny(this string stringBeingSearched, int startIndex = 0, params string[] stringsToFind)
        {
            int index = -1;

            foreach (string stringToFind in stringsToFind)
            {
                index = stringBeingSearched.IndexOf(stringToFind, startIndex, StringComparison.Ordinal);

                if (index >= 0)
                {
                    break;
                }
            }
            return index;
        }

        public static string HtmlLinkifyString(this string textToLinkify)
        {
            var str = textToLinkify;

            if (!textToLinkify.ToLower().Contains("<a "))
            {
                str = string.Empty;

                var strIndex = 0;

                var index = textToLinkify.ToLower().IndexOfAny(0, "http://", "https://", "www.");
                if (index >= 0)
                {
                    var found = true;

                    while (found)
                    {
                        str += textToLinkify.Substring(strIndex, index) + "<a href=\"{0}\" target=\"_parent\">{0}</a>";

                        var linkEnd = textToLinkify.IndexOfAny(index, ")", " ", "\n", "\r", "\t", "\0") - 1;

                        linkEnd = linkEnd < 0 ? textToLinkify.Length - 1 : linkEnd;

                        if (linkEnd < 0)
                            linkEnd = textToLinkify.Length - 1;

                        var link = textToLinkify.Substring(index, (linkEnd - index) + 1);

                        str = string.Format(str, link, link);
                        index = textToLinkify.IndexOfAny(index + 1, "http://", "https://", "www.");

                        if (index >= 0)
                            str += textToLinkify.Substring(linkEnd, index);
                        else
                        {
                            found = false;

                            if (linkEnd < textToLinkify.Length - 1)
                                str += textToLinkify.Substring(linkEnd + 1);
                        }

                        strIndex = index + 1;
                    }
                }

                if (str.Length == 0)
                {
                    str += textToLinkify;
                }
            }
            else
            {
                if (!textToLinkify.Contains("target="))
                {
                    str = textToLinkify.Substring(0, textToLinkify.IndexOf("<a ", StringComparison.Ordinal) + 3) + "target=\"_parent\" " + textToLinkify.Substring(3);
                }
            }

            return str;
        }
    }
}