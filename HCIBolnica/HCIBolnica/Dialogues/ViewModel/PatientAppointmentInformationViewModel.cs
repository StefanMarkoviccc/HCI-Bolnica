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

namespace HCIBolnica.Dialogues.ViewModel
{
    public class PatientAppointmentInformationViewModel : ViewModelBase
    {
        public PatientAppointmentInformationWindow patientAppointmentInformationWindow;
        private RelayCommand cancelCommand;
        private RelayCommand okCommand;
        private InformationOfPatientAppointmentModel selectedItem = new InformationOfPatientAppointmentModel();

        public PatientAppointmentInformationViewModel(PatientAppointmentInformationWindow patientAppointmentInformationWindow) 
        {
            this.patientAppointmentInformationWindow = patientAppointmentInformationWindow;
        }
        public InformationOfPatientAppointmentModel SelectedItem
        {
            get { return selectedItem; }
            set
            {
                selectedItem = value;
                OnPropertyChanged(nameof(SelectedItem));
            }
        }
        public RelayCommand CancelCommand
        {
            get { return cancelCommand ?? (cancelCommand = new RelayCommand(param => CancelCommandExecute(), param => CanCancelCommandExecute())); }
        }

        public RelayCommand OkCommand
        {
            get { return okCommand ?? (okCommand = new RelayCommand(param => OkCommandExecute(), param => CanOkCommandExecute())); }
        }

        public void CancelCommandExecute() { }

        public bool CanCancelCommandExecute() { return true; }

        public void OkCommandExecute()
        {
            HCIContext.Instance.InformationOfPatientAppontment.Add(selectedItem);
            HCIContext.Instance.Save();
            patientAppointmentInformationWindow.Close();
            MessageBox.Show("Uspesno ste popunili informacije o pregledu!", "Informacije o pregledu pacijenta!");
        }

        public bool CanOkCommandExecute() { return true; }
    }
}
