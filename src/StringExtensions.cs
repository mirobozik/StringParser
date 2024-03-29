﻿using System.Collections.Generic;

namespace StringParser
{
    public static class StringExtensions
    {
        public static IDictionary<string, string> Parse(this string str, string template)
        {
            var tmpl = new Template(template);
            tmpl.Compile();
            return tmpl.Parse(str);
        }

        public static bool IsMatch(this string str, string template)
        {
            var tmpl = new Template(template);
            tmpl.Compile();
            return tmpl.IsMatch(str);
        }
    }
}