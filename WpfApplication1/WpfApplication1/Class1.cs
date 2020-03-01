using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
namespace WpfApplication1
{
    public static class calcit
    {


        private static Stack revers2 = new Stack();             // < revers To postfix string 

        public static void CleanAll()
        {
            revers2.Clear();
        }

        static public string postfix(string infix)
        {
            //Stack revers = new Stack();                   // < revers To postfix string 
            string together = string.Empty;                // < get to gether the items
            Console.Write("Enter Your Sentence >> ");
            string Infix = infix;                        // < Get Infix Sentence
            Stack Postfix = new Stack();                // < Converted Postfix Sentenc Save Here
            Stack Operator = new Stack();              // < For Operator Like: () ^ * / + -
            int counter1 = 0;                         // < This Counter Is Taking The Last Opearand That Is In The Num
            string num = "";                         // <  Get All Char Of Numbers To Gether 

            foreach (var item in Infix)
            {

                counter1++; // < This Counter Is Taking The Last Opearand That Is In The Num
                if (char.IsDigit(item) == true)
                {
                    /// 0 < 1 < 2 < 3 < 4 < 5 < 6 < 7 < 8 < 9 <
                    num += item;
                }
                else if (char.IsDigit(item) == false)
                {
                    /// () ^ * / + -
                    Postfix.Push(num);
                    num = "";
                    if (item == '%' || item == '(' || item == ')' || item == '^' || item == '*' || item == '/' || item == '+' || item == '-')
                    {
                        switch (item)
                        {
                            case '*':
                            case '/':
                            case '%':
                                if (Operator.Count == 0)
                                {
                                    Operator.Push(item);
                                }
                                else if (Operator.Peek().ToString() == "%" || Operator.Peek().ToString() == "/" || Operator.Peek().ToString() == "*" || Operator.Peek().ToString() == "^")
                                {
                                    Postfix.Push(Operator.Pop());
                                    Operator.Push(item);
                                }
                                else if (Operator.Peek().ToString() == "+" || Operator.Peek().ToString() == "-" || Operator.Peek().ToString() == "(")
                                {
                                    Operator.Push(item);
                                }
                                break;

                            case '+':
                            case '-':
                                if (Operator.Count == 0)
                                {
                                    Operator.Push(item);
                                }
                                else if (Operator.Peek().ToString() == "%" || Operator.Peek().ToString() == "+" || Operator.Peek().ToString() == "-" || Operator.Peek().ToString() == "*" || Operator.Peek().ToString() == "/" || Operator.Peek().ToString() == "^")
                                {
                                    Postfix.Push(Operator.Pop());
                                    if (Operator.Count == 0)
                                    {
                                        Operator.Push(item);
                                    }
                                    else if (Operator.Peek().ToString() == "%" || Operator.Peek().ToString() == "+" || Operator.Peek().ToString() == "-" || Operator.Peek().ToString() == "*" || Operator.Peek().ToString() == "/" || Operator.Peek().ToString() == "^")
                                    {
                                        Postfix.Push(Operator.Pop());
                                        if (Operator.Count == 0)
                                        {
                                            Operator.Push(item);
                                        }
                                        else if (Operator.Peek().ToString() == "%" || Operator.Peek().ToString() == "+" || Operator.Peek().ToString() == "-" || Operator.Peek().ToString() == "*" || Operator.Peek().ToString() == "/" || Operator.Peek().ToString() == "^")
                                        {
                                            Postfix.Push(Operator.Pop());
                                            Operator.Push(item);
                                        }
                                        else
                                        {
                                            Operator.Push(item);
                                        }
                                    }
                                    else
                                    {
                                        Operator.Push(item);
                                    }
                                }
                                else if (Operator.Peek().ToString() == "(")
                                {
                                    Operator.Push(item);
                                }

                                break;

                            case '^':
                                if (Operator.Count <= 0)
                                {
                                    Operator.Push(item);
                                }
                                else if (Operator.Peek().ToString() == "^")
                                {
                                    Postfix.Push(Operator.Pop());
                                    Operator.Push(item);
                                }
                                else if (Operator.Peek().ToString() == "(" || Operator.Peek().ToString() == "*" || Operator.Peek().ToString() == "/" || Operator.Peek().ToString() == "+" || Operator.Peek().ToString() == "-")
                                {
                                    Operator.Push(item);
                                }
                                break;

                            case '(':
                                Operator.Push(item);
                                break;

                            case ')':

                                if (Operator.Peek().ToString() != "(")
                                {
                                    while (Operator.Peek().ToString() != "(")
                                    {
                                        Postfix.Push(Operator.Pop());
                                    }
                                    Operator.Pop();
                                }

                                break;

                        }
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Who Make You To Enter This Fucking Word > {0}", item);
                    }
                }
                if (counter1 == Infix.Length) // < Chek The Last Operand
                {
                    Postfix.Push(num);
                }
            }

            for (int i = 0; i < Operator.Count + 1; i++)
            {
                Postfix.Push(Operator.Pop());
            }

            // here is the postfix \/

            foreach (var item in Postfix)
            {
                revers2.Push(item);
            }
            foreach (var item in revers2)
            {
                together += item;
            }

            return together;
        }

        // evalue

        public static double countit(string postfix)
        {
            Stack<double> temp = new Stack<double>();

            foreach (var item in revers2)
            {
                if ("^*/+-%".Contains(item.ToString()))
                {
                    double temp1;
                    double temp2;

                    switch (item.ToString())
                    {
                        case ("*"):
                            temp.Push(temp.Pop() * temp.Pop());
                            break;
                        case "-":
                            temp1 = temp.Pop();
                            temp2 = temp.Pop();
                            temp.Push(temp2 - temp1);
                            break;
                        case "+":
                            temp.Push(temp.Pop() + temp.Pop());
                            break;
                        case "/":
                            temp1 = temp.Pop();
                            temp2 = temp.Pop();
                            temp.Push(temp2 / temp1);
                            break;
                        case "%":
                            temp1 = temp.Pop();
                            temp2 = temp.Pop();
                            temp.Push(temp2 % temp1);
                            break;
                        case "^":
                            temp1 = temp.Pop();
                            temp2 = temp.Pop();
                            temp.Push(Math.Pow(temp2, temp1));
                            break;
                    }
                }
                else
                {
                    temp.Push(Convert.ToInt32(item));
                }
            }

            return temp.Pop();

        }

    }
}
