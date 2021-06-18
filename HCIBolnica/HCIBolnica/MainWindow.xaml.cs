using HCIBolnica.Dialogues.View;
using HCIBolnica.Dialogues.ViewModel;
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

namespace HCIBolnica
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel(this, passwordBox);

        }
        private void PasswordBox_Password(object sender, RoutedEventArgs e)
        {
            var passwordBox = sender as PasswordBox;
            if ((passwordBox != null))
            {
                ((DataContext as MainWindowViewModel)).Password = passwordBox.Password;
            }
        }
    }
}
