using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections;
using System.IO;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Txtcommand.Focus();

            DoCMD.IsChecked = Properties.Settings.Default.BoolDoCcmd;
            DoCalc.IsChecked = Properties.Settings.Default.BoolDocalc;
        }
        // CMD // KeyDown
        private void Txtcommand_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.RightCtrl)
            {
                if (LblSolve.Text.ToString().Length >= 1)
                {
                    Txtcommand.Focus();
                    string[] TMP = new string[2];
                    TMP = LblSolve.Text.ToString().Split(',');
                    Txtcommand.Text = TMP[0];
                    Txtcommand.SelectAll();
                }
            }
            // I Dont Like && So I Write Like This \/
            if (DoCMD.IsChecked == true)
            {
                if (e.Key == Key.Enter)
                {
                    if (Txtcommand.Text.Length >= 1)
                    {
                        if (char.IsLetter(Txtcommand.Text[0]))
                        {
                            File.AppendAllText("hisory.list.csv", "\n" + Txtcommand.Text);
                            System.Diagnostics.Process.Start("CMD.exe", "/k" + Txtcommand.Text);
                        }
                    }
                }
            }


        }
        // Calculator // TXT cHANGED
        private void Txtcommand_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Txtcommand.Text.Length >= 2)
            {
                if (char.IsDigit(Txtcommand.Text[0]) || Txtcommand.Text[0] == '(')
                {
                    if (DoCalc.IsChecked == true)
                    {
                        LblSolve.Visibility = Visibility.Visible;
                        LblSolve.Text = "?";
                        WinF.Height = 150;
                        LblSolve.FontSize = 26;
                        try
                        {
                            string tmp = calcit.postfix(Txtcommand.Text);
                            LblSolve.Text = calcit.countit(tmp).ToString();
                            calcit.CleanAll();
                        }
                        catch
                        {
                            calcit.CleanAll();
                            // nothig need <?>
                        }
                    }
                }
                else if (char.IsLetter(Txtcommand.Text[0]))
                {
                    if (DoCMD.IsChecked == true)
                    {
                        LblSolve.Visibility = Visibility.Visible;
                        WinF.Height = 190;
                        LblSolve.FontSize = 20;
                        LblSolve.Text = CsvReader.Lines("Command.List.csv", Txtcommand.Text);

                        try
                        {
                            if (LblSolve.Text.ToString() == string.Empty)
                            {
                                LblSolve.Text = CsvReader.Lines("hisory.list.csv", Txtcommand.Text);
                            }
                        }
                        catch
                        {
                            LblSolve.Text = CsvReader.Lines("hisory.list.csv", Txtcommand.Text);
                        }
                    }
                    if (Txtcommand.Text.Contains("bin>")) // Convert To Binary
                    {
                        try
                        {
                            string tmp = Txtcommand.Text.Remove(0, 4);
                            LblSolve.Text = ToBinary.Num2Bin(Convert.ToInt32(tmp));
                        }
                        catch (Exception ex)
                        {
                            // MessageBox.Show(ex.Message);
                        }
                    }
                    else if (Txtcommand.Text.Contains("hex>")) // Convert To Hex
                    {
                        try
                        {
                            string tmp = Txtcommand.Text.Remove(0, 4);
                            LblSolve.Text = ToHex.Num2Hex(Convert.ToInt32(tmp));
                        }
                        catch
                        {
                        }
                    }
                }
            }
            else
            {
                LblSolve.Text = string.Empty;
                LblSolve.Visibility = Visibility.Hidden;
                WinF.Height = 97;
            }




        }

        private void WinF_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void WinF_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        // bool Vmanpag = true;
        private void BtnSetting_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("Help.html");
        }
        bool WTDP = true;
        private void Btndolist_Click(object sender, RoutedEventArgs e)
        {
            if (WTDP == true)
            {
                PageWhatDo.Visibility = Visibility.Visible;
                WTDP = false;
            }
            else
            {
                PageWhatDo.Visibility = Visibility.Hidden;
                WTDP = true;
            }
        }

        private void DoCMD_Click(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.BoolDoCcmd = DoCMD.IsChecked.Value;
            Properties.Settings.Default.Save();
        }

        private void DoCalc_Click(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.BoolDocalc = DoCalc.IsChecked.Value;
            Properties.Settings.Default.Save();
        }
    }
}

