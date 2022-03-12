using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRHWLibrary
{
    public static class ArgParser
    {
        public static Dictionary<string, string> ParseArgs(string[] args)
        {
            // to keep things simple and focus on the task at hand
            // it is assumed that the arguments are entered correctly
            var keys = from key in args
                       where key.StartsWith('/')
                       select key.TrimStart('/').ToLower();
            var values = from value in args
                         where !value.StartsWith('/')
                         // use "s" to indicate space delimiter
                         select value.ToLower() == "s" ? " " : value.ToLower();

            return keys.Zip(values, (key, value) =>
                new KeyValuePair<string, string>(key, value))
                .ToDictionary(x => x.Key, x => x.Value); ;
        }
    }
}
