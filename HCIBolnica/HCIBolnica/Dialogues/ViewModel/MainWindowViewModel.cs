using HCI_Bolnica.CompositeComon;
using HCIBolnica.CompositeComon;
using HCIBolnica.Dialogues.View;
using HCIBolnica.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace HCIBolnica.Dialogues.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        MainWindow mainWindow;
        private string password;
        private RelayCommand firstPageCommand;
        private User selectedItem = new User();
        private PasswordBox passwordBox;
        public MainWindowViewModel(MainWindow mainWindow, PasswordBox passwordBox)
        {
            this.mainWindow = mainWindow;
            this.passwordBox = passwordBox;
        }
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                OnPropertyChanged(nameof(Password));
            }
        }
        public User SelectedItem
        {
            get { return selectedItem; }
            set
            {
                selectedItem = value;
                OnPropertyChanged(nameof(SelectedItem));
            }
        }
        public RelayCommand FirstPageCommand
        {
            get
            {
                return firstPageCommand ?? (firstPageCommand = new RelayCommand(param => FirstPageCommandExecute()));
            }
        }
        public void FirstPageCommandExecute()
        {
            foreach (User user in HCIContext.Instance.Users)
            {
                if (user.UserName == SelectedItem.UserName && user.Password == Password)
                {
                    HospitalMainWindow hospitalMainWindow = new HospitalMainWindow();
                    mainWindow.Close();
                    hospitalMainWindow.Show();
                    return;
                }

            }
            MessageBox.Show("Korisnicko ime ili lozinka nisu dobro uneseni!");
        }
    }
}
