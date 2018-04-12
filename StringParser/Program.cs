using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace StringParser
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            string template = "d/{device_id}/c/{recipient_id}";

            string test = "d/mydevice/c/yourdevice";

            var data = Parse(template, test);
        }

        private static IDictionary<string, string> Parse(string template, string value)
        {
            var data = new Dictionary<string, string>();
            var placehoderRegex = new Regex("\\{([a-zA-Z_]+)\\}");
            var matchs = placehoderRegex.Matches(template);
            if (!matchs.Any(m=>m.Success))
            {
                return data;
            }

            var placeholders = matchs
                .Where(m=>m.Success && m.Groups.Count > 0)
                .Select(m => m.Groups[1].Value)
                .ToList()                
                ;
            
            
            var tmpl = template;
            tmpl = Regex.Replace(tmpl, @"[\\\^\$\.\|\?\*\+\(\)]", m => "\\" + m.Value);
            
            string pattern = "^" + Regex.Replace(tmpl, @"\{([a-zA-Z_]+)\}", "(?<$1>[a-zA-Z_]+)") + "$";
            var dataMatches = Regex.Matches(value, pattern);

            var values = dataMatches
                .Select(m => m.Groups[1].Value)
                .ToList()                
                ;

            Enumerable.Range(0, placeholders.Count)
                .ToList()
                .ForEach(i =>
                {                   
                    data.Add(placeholders[i], values[i]);
                });
            
            
            return data;
        }
    }
}
