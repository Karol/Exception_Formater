using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace Format_Exception
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            tbxFormated.IsReadOnly = true;
        }

        private void ExeptionFormating(string text)
        {
            string[] separators = new string[] { "--->", "     w ", " at ", "  --- E", "--- K", "Server stack trace" };
            if (!string.IsNullOrWhiteSpace(text))
            {
                foreach (var separator in separators)
                {
                    text = text.Replace(separator, System.Environment.NewLine + separator);
                }
                
                if (tbxFormated != null && !string.IsNullOrWhiteSpace(text))
                {
                    tbxFormated.Text = text;
                }
            }
        }

        private void TbxErrorString_TextInput(object sender, TextCompositionEventArgs e)
        {
            ExeptionFormating(tbxErrorString.Text);
        }

        private void TbxErrorString_TextChanged(object sender, TextChangedEventArgs e)
        {
            ExeptionFormating(tbxErrorString.Text);
        }

        private void TbxErrorString_GotFocus(object sender, RoutedEventArgs e)
        {
            if (tbxErrorString.Text.Equals("past error string"))
            {
                tbxErrorString.Text = string.Empty;
            }
        }

        private void CheckBoxWrap_Checked(object sender, RoutedEventArgs e)
        {
            tbxFormated.TextWrapping = TextWrapping.Wrap;
        }

        private void CheckBoxWrap_Unchecked(object sender, RoutedEventArgs e)
        {
            tbxFormated.TextWrapping = TextWrapping.NoWrap;
        }

        private void TbxErrorString_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (!tbxErrorString.Text.Equals("past error string"))
            {
                tbxErrorString.SelectAll();
            }
        }

        private void SelectText(object sender, RoutedEventArgs e)
        {
            TextBox tb = (sender as TextBox);
            if (tb != null && !tb.Text.Equals("past error string") )
            {
                tb.SelectAll();
            }
        }

        private void SelectivelyIgnoreMouseButton(object sender, MouseButtonEventArgs e)
        {
            TextBox tb = (sender as TextBox);
            if (tb != null && !tb.Text.Equals("past error string"))
            {
                if (!tb.IsKeyboardFocusWithin)
                {
                    e.Handled = true;
                    tb.Focus();
                }
            }
        }
    }
}
