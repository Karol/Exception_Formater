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
            if (!string.IsNullOrWhiteSpace(text))
            {

                string formated = text.Replace("--->", System.Environment.NewLine + "--->");
                formated = formated.Replace("     w ", System.Environment.NewLine+ "     w " );
                formated = formated.Replace("     at ", System.Environment.NewLine + "     at ");
                formated = formated.Replace(" at ", System.Environment.NewLine + " at ");
                formated = formated.Replace("  --- E", System.Environment.NewLine + "  --- E");
                
                if (tbxFormated != null && !string.IsNullOrWhiteSpace(formated))
                {
                    tbxFormated.Text = formated;
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
    }
}
