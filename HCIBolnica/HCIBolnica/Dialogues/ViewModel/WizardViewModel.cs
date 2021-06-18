using HCI_Bolnica.CompositeComon;
using HCIBolnica.CompositeComon;
using HCIBolnica.Dialogues.View;
using HCIBolnica.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCIBolnica.Dialogues.ViewModel
{
    public class WizardViewModel : ViewModelBase
    {
        private WizardWindow window;
        private RelayCommand nextCommand;
        private RelayCommand cancelCommand;
        private string selectedText;
        private WizardSteps wizardSteps;
        private string image = string.Empty;

        public WizardViewModel(WizardWindow wizardWindow)
        {
            window = wizardWindow;
            wizardSteps = WizardSteps.Step1;
            SelectedText = "Ukoliko zelite da zakazete termin potrebno je da kliknete na dugme TERMINI LEKARA!";
             Image = @"C:\Users\Markoviccc\OneDrive\Desktop\HCI NOVI\HCIBolnica\HCIBolnica\Pictures\step1.png";
        }
        public string Image
        {
            get { return image; }
            set
            {
                image = value;
                OnPropertyChanged(nameof(Image));
            }
        }
        public string SelectedText
        {
            get { return selectedText; }
            set
            {
                selectedText = value;
                OnPropertyChanged(nameof(SelectedText));
            }
        }
        public RelayCommand NextCommand
        {
            get { return nextCommand ?? (nextCommand = new RelayCommand(param => NextCommandExecute(), param => CanNextCommandExecute())); }
        }
        public RelayCommand CancelCommand
        {
            get { return cancelCommand ?? (cancelCommand = new RelayCommand(param => CancelCommandExecute(), param => CanCancelCommandExecute())); }
        }
        public void NextCommandExecute()
        {
            if (wizardSteps == WizardSteps.Step1)
            {
                SelectedText = "Zatim je potrebno da kliknete na dugme ZAKAZI TERMIN!";
                  Image = @"C:\Users\Markoviccc\OneDrive\Desktop\HCI NOVI\HCIBolnica\HCIBolnica\Pictures\step2.png";
                wizardSteps = WizardSteps.Step2;
            }
            else if (wizardSteps == WizardSteps.Step2)
            {
                SelectedText = "Nakon što Vam se prikaže prozor za zakazivanje termina, potrebno je da unesete trazene podatke(1) i pritisnete na dugme POTVRDI(2)";
                Image = @"C:\Users\Markoviccc\OneDrive\Desktop\HCI NOVI\HCIBolnica\HCIBolnica\Pictures\step3.png";
                wizardSteps = WizardSteps.Step3;
            }
            else if (wizardSteps == WizardSteps.Step3)
            {
                SelectedText = "Zakazan termin ce Vam se prikazati u tabeli termina!";
                Image = @"C:\Users\Markoviccc\OneDrive\Desktop\HCI NOVI\HCIBolnica\HCIBolnica\Pictures\step4.png";
                wizardSteps = WizardSteps.Step4;
            }
            else
            {
                window.Close();
            }


        }
        public bool CanNextCommandExecute() { return true; }
        public void CancelCommandExecute()
        {
            window.Close();
        }
        public bool CanCancelCommandExecute() { return true; }
    }
}

