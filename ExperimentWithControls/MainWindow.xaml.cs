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
            if (!(sender is TextBox numberTextBox)) return;

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

        private void SmallSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            number.Text = smallSlider.Value.ToString("0");
        }

        private void BigSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            number.Text = bigSlider.Value.ToString("000-000-0000");
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            if (!(sender is RadioButton radioButton)) return;

            number.Text = radioButton.Content.ToString();
        }

        private void MyListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!(sender is ListBox listBox) || listBox.SelectedItem == null) return;

            if (!(listBox.SelectedItem is ListBoxItem listBoxItem)) return;

            number.Text = listBoxItem.Content.ToString();
        }

        private void ReadOnlyComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!(sender is ComboBox comboBox) || comboBox.SelectedItem == null) return;
            if (!(comboBox.SelectedItem is ListBoxItem listBoxItem)) return;

            number.Text = listBoxItem.Content.ToString();
        }

        private void EditableComboBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!(sender is ComboBox comboBox)) return;

            number.Text = comboBox.Text;
        }
    }
}
