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

namespace ExperimentWithControls
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

        private void NumberTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox numberTextBox = sender as TextBox;
            string inputText = numberTextBox.Text;

            bool isNumeric = IsTextNumberic(inputText);
            if (!isNumeric)
            {
                SetNumberTextBlock(string.Empty);
                return;
            }

            SetNumberTextBlock(inputText);
        }

        private void NumberTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsTextNumberic(e.Text);
        }
        private bool IsTextNumberic(string text)
        {
            return int.TryParse(text, out _);
        }

        private void SetNumberTextBlock(string text)
        {
            if (number == null) return;

            if (string.IsNullOrEmpty(text))
            {
                number.Text = "No number entered.";
                return;
            }
            number.Text = text;
        }
    }
}
