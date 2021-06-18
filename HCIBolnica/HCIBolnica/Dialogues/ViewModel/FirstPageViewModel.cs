using HCI_Bolnica.CompositeComon;
using HCIBolnica.CompositeComon;
using HCIBolnica.Dialogues.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCIBolnica.Dialogues.ViewModel
{
    public class FirstPageViewModel : ViewModelBase
    {
        FirstPage firstPage ;
        private RelayCommand wizardCommand;
        public FirstPageViewModel(FirstPage firstPage1)
        {
            this.firstPage = firstPage1;
        }
        public RelayCommand WizardCommand
        {
            get { return wizardCommand ?? (wizardCommand = new RelayCommand(param => WizardCommandExecute(), param => CanWizardCommandExecute())); }
        }
        public void WizardCommandExecute()
        {
            WizardWindow wizardWindow = new WizardWindow();
            wizardWindow.ShowDialog();
        }
        public bool CanWizardCommandExecute()
        { return true; }
    }
}
