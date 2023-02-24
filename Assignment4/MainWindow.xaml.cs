//Tyler Nelson
//CSCI 3005
//11/03/2022
//Assignment 4
//Binary Calculator with GUI

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
using System.Text.RegularExpressions;

namespace Assignment4
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

        public string ConvertToBinary(int n)
        {
            string binary = Convert.ToString(n, 2);

            return binary;
        }

        public int ConvertFromBinary(string n)
        {
            int deci = Convert.ToInt32(n, 2);
            return deci;
        }

        public string ConvertToOctal(int n)
        {
            string octal = Convert.ToString(n, 8);
            return octal;
        }

        public string ConvertToHex(int n)
        {
            string hex = Convert.ToString(n, 16);
            return hex;
        }


        void PrintAnswers(int num1, int num2, int result, string operation)
        {
            BinTextBox.Text = $"{ConvertToBinary(num1)} {operation} {ConvertToBinary(num2)} = {ConvertToBinary(result)}";
            DecimalTextBox.Text = $"{num1} {operation} {num2} = {result}";
            OctalTextBox.Text = $"{ConvertToOctal(num1)} {operation} {ConvertToOctal(num2)} = {ConvertToOctal(result)}";
            HexTextBox.Text = $"{ConvertToHex(num1)} {operation} {ConvertToHex(num2)} = {ConvertToHex(result)}";
        }


        private void Operation_Click(object sender, RoutedEventArgs e)
        {
            int zeroError = 0;
            int emptyError = 0;
            int emptyError2 = 0;
            if (Number1TextBox.Text.Length == 0)
            {
                emptyError++;
            }
            if (Number2TextBox.Text.Length == 0)
            {
                emptyError2++;
            }
            //This did not work

            /*int regexError1 = 0;
            int regexError2 = 0;
            string pattern = @"[0-1]*";
            Regex regex = new Regex(pattern);
            var match1 = Regex.Match(Number1TextBox.Text, pattern);
            if (!Regex.IsMatch(Number1TextBox.Text, pattern))
            {
                regexError1=1;
            }
            var match2 = Regex.Match(Number2TextBox.Text, pattern);
            if (!Regex.IsMatch(Number2TextBox.Text, pattern))
            {
                regexError2=1;
            }
            */
            try
            {
                string num1 = Number1TextBox.Text;
                string num2 = Number2TextBox.Text;
                int num1Decimal = ConvertFromBinary(num1);
                int num2Decimal = ConvertFromBinary(num2);
                if (ReferenceEquals(sender, AdditionButton))
                {
                    int sum = num1Decimal + num2Decimal;
                    PrintAnswers(num1Decimal, num2Decimal, sum, "+");
                }
                if (ReferenceEquals(sender, SubtractionButton))
                {
                    int difference = num1Decimal - num2Decimal;
                    PrintAnswers(num1Decimal, num2Decimal, difference, "-");
                }
                if (ReferenceEquals(sender, MultiplicationButton))
                {
                    int product = num1Decimal * num2Decimal;
                    PrintAnswers(num1Decimal, num2Decimal, product, "*");
                }
                if (ReferenceEquals(sender, DivisionButton))
                {
                    if (num2 == "0")
                    {
                        zeroError = 1;
                    }
                    int quotient = num1Decimal / num2Decimal;
                    PrintAnswers(num1Decimal, num2Decimal, quotient, "/");
                }
                if (ReferenceEquals(sender, BitWiseOrButton))
                {
                    int bitwiseOr = num1Decimal | num2Decimal;
                    PrintAnswers(num1Decimal, num2Decimal, bitwiseOr, "|");
                }
                if (ReferenceEquals(sender, BitWiseAndButton))
                {
                    int bitwiseAnd = num1Decimal & num2Decimal;
                    PrintAnswers(num1Decimal, num2Decimal, bitwiseAnd, "&");
                }
                if (ReferenceEquals(sender, BitWiseXorButton))
                {
                    int bitwiseXor = num1Decimal ^ num2Decimal;
                    PrintAnswers(num1Decimal, num2Decimal, bitwiseXor, "^");
                }
            }
            catch (Exception)
            {
                string message = "";
                if(emptyError == 1)
                {
                    message += "Number 1 is empty";
                }
                else if (emptyError2 == 1)
                {
                    if(message.Length > 0)
                    {
                        message += "\n";
                    }
                    message += "Number 2 is empty";
                }
                else if (zeroError == 1)
                {
                    message += "Cannot divide by zero";
                }
                else
                {
                    message += "Invalid entry";
                }

                MessageBoxResult result = MessageBox.Show(message);

            }
            if (ReferenceEquals(sender, ClearButton))
            {
                Number1TextBox.Text = "";
                Number2TextBox.Text = "";
                BinTextBox.Text = "";
                DecimalTextBox.Text = "";
                OctalTextBox.Text = "";
                HexTextBox.Text = "";
            }
        }



        private void BitWiseNotButton_Click(object sender, RoutedEventArgs e)
        {
            string num1 = Number1TextBox.Text;
            int num1Decimal = ConvertFromBinary(num1);
            int bitwiseNot = ~num1Decimal;
            BinTextBox.Text = $"~ {num1} = {ConvertToBinary(num1Decimal)}";
            DecimalTextBox.Text = $"~ {num1Decimal} = {bitwiseNot}";
            OctalTextBox.Text = $"~ {ConvertToOctal(num1Decimal)} = {ConvertToOctal(bitwiseNot)}";
            HexTextBox.Text = $"~ {ConvertToHex(num1Decimal)} = {ConvertToHex(bitwiseNot)}";

        }

        private void ClearTwoButton_Click(object sender, RoutedEventArgs e)
        {
            Number2TextBox.Text = "";
        }

        private void ClearOneButton_Click(object sender, RoutedEventArgs e)
        {
            Number1TextBox.Text = "";
        }
    }
}

    

