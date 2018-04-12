using System.Collections.Generic;

namespace MiroBozik.StringParser
{
    public static class StringExtensions
    {
        public static IDictionary<string, string> Parse(this string str, string template)
        {
            var tmpl = new Template(template);
            tmpl.Compile();
            return tmpl.Parse(str);
        }
    }
}