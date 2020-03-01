using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace WpfApplication1
{
    static public class CsvReader
    {
        public static string Lines(string path, string SearchSentenc)
        {
            string GotIt = string.Empty;

            string[] line = File.ReadAllLines(path);

            return Array.Find(line, element => element.StartsWith(SearchSentenc, StringComparison.Ordinal));
        }
    }
}
