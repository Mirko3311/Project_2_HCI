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
using System.Windows.Shapes;

namespace DrugiProjektniZadatakHCI
{
    /// <summary>
    /// Interaction logic for WCustomWindow.xaml
    /// </summary>
    public partial class WCustomWindow : Window
    {
        public string UserInput { get; private set; }

        public WCustomWindow()
        {
            InitializeComponent();
        }

        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            UserInput = UserInputTextBox.Text;
            DialogResult = true; // Zatvara prozor i signalizira da je unos uspešan
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false; // Zatvara prozor bez snimanja
        }
    }
}
