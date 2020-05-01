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
        public static string GotIt;

        public static string Lines(string path, string SearchSentenc)
        {
            GotIt = "!";

            string[] line = File.ReadAllLines(path);

            GotIt = Array.Find(line, element => element.StartsWith(SearchSentenc, StringComparison.Ordinal));
           
            return GotIt;
        }
    }
}
