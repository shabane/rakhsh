using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1
{
    class ToBinary
    {
        private static Stack<string> bin = new Stack<string>(); // To Reverse The Result
        static public string Num2Bin(int Number)
        {
            string tmp = "";
            while (Number / 2 >= 1)
            {
                bin.Push(Convert.ToString(Number % 2));
                Number = Number / 2;
            }
            bin.Push(Number.ToString());

            foreach (var item in bin)
            {
                tmp += item;
            }
            bin.Clear();
            return tmp;
        }
    }
}

