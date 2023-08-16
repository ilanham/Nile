using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Nile
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

        //private void toMultiButton_Click(object sender, RoutedEventArgs e)
        //{
        //    string input = inputTextBox.Text;
        //    outputTextBox.Text = input.Replace(",", "\r\n");
        //}

        public static class Nile
        {
            public static int CountStringOccurrences(string text, string pattern)
            {
                int count = 0;
                int i = 0;
                while ((i = text.IndexOf(pattern, i)) != -1)
                {
                    i += pattern.Length;
                    count++;
                }
                return count;
            }
        }

        protected static string TrimSpecialCharacters(string input)
        {
            input = input.Replace(@"'", "");
            input = input.Replace("(", "");
            input = input.Replace(")", "");

            return input;
        }

        private void inputTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string input = inputTextBox.Text.TrimEnd();

            if (Nile.CountStringOccurrences(input, ",") >= 1)
            {
                input = TrimSpecialCharacters(input);
                outputTextBox.Text = input.Replace(",", "\r\n");
            }

            else if (Nile.CountStringOccurrences(input, "\r\n") >= 1)
            {
                input = TrimSpecialCharacters(input);
                input = input.Replace("\r\n", ",");

                if (addQuotesCheckBox.IsChecked == true)
                {       
                    input = input.Replace(",", @"','");
                    input = @"'" + input + @"'";
                }

                if (addParensCheckBox.IsChecked == true)
                {
                    input = "(" + input + ")";
                }

                outputTextBox.Text = input;
            }
        }
    }
}
