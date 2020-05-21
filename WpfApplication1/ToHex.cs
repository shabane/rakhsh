using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1
{
    class ToHex
    {
        static private string tmp = "";
        static private Stack<string> ToRevers = new Stack<string>();
        public static string Num2Hex(int DecimalNum)
        {
            // 260
            string last = "";
            if (DecimalNum / 16 < 16)
            {
                //tmp += (DecimalNum / 16).ToString();
                //tmp += (DecimalNum % 16).ToString();
                //last = tmp;

                ToRevers.Push((DecimalNum % 16).ToString());
                ToRevers.Push((DecimalNum / 16).ToString());

                foreach (var item in ToRevers)
                {
                    switch (item)
                    {
                        case "10":
                            last += "A";
                            break;
                        case "11":
                            last += "B";
                            break;
                        case "12":
                            last += "C";
                            break;
                        case "13":
                            last += "D";
                            break;
                        case "14":
                            last += "E";
                            break;
                        case "15":
                            last += "F";
                            break;
                    }
                    if (Convert.ToInt32(item) < 10)
                    {
                        last += item;
                    }
                }
            }
            else
            {
                while (DecimalNum / 16 >= 16)
                {
                    ToRevers.Push((DecimalNum % 16).ToString());
                    DecimalNum = DecimalNum / 16;
                }
                if (DecimalNum / 16 < 16)
                {
                    ToRevers.Push((DecimalNum % 16).ToString());
                    ToRevers.Push((DecimalNum / 16).ToString());
                }

                foreach (var item in ToRevers)
                {
                    switch (item)
                    {
                        case "10":
                            last += "A";
                            break;
                        case "11":
                            last += "B";
                            break;
                        case "12":
                            last += "C";
                            break;
                        case "13":
                            last += "D";
                            break;
                        case "14":
                            last += "E";
                            break;
                        case "15":
                            last += "F";
                            break;
                    }
                    if (Convert.ToInt32(item) < 10)
                    {
                        last += item;
                    }
                }
            }

            ToRevers.Clear();
            tmp = string.Empty;
            return last;
        }
    }
}
