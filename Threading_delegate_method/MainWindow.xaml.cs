using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;
using System.Threading;

namespace Threading_delegate_method
{
    public partial class MainWindow : Window
    {
        delegate void FormatNumber(double number);

        public MainWindow()
        {
            InitializeComponent();
        }

        private void FormatNumberAsCurrency(double number)
        {
            MessageBox.Show(string.Format("Answer is " + " A Currency: {0:C}", number));
        }
        private void FormatNumberWithCommas(double number)
        {
            MessageBox.Show(string.Format("Answer is " + " With Commas: {0:N}", number));
        }
        private void FormatNumberWithTwoPlaces(double number)
        {
            MessageBox.Show(string.Format("Answer is " + " With 3 places: {0:.###}", number));
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(textBox.Text, out double number))
            {
                FormatNumber format = null;
                if (comboBox.SelectedIndex == 0)
                    format = FormatNumberAsCurrency;
                else if (comboBox.SelectedIndex == 1)
                    format = FormatNumberWithCommas;
                else if (comboBox.SelectedIndex == 2)
                    format = FormatNumberWithTwoPlaces;
                if (format != null)
                    format(number);
            }
            else
            {
                MessageBox.Show("Please enter a valid number.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
