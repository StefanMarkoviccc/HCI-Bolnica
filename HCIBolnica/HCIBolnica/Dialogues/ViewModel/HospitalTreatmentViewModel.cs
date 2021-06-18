using HCI_Bolnica.CompositeComon;
using HCIBolnica.CompositeComon;
using HCIBolnica.Dialogues.Model;
using HCIBolnica.Dialogues.View;
using HCIBolnica.Model;
using HCIBolnica.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HCIBolnica.Dialogues.ViewModel
{
    public class HospitalTreatmentViewModel : ViewModelBase
    {
        public HospitalTreatmentWindow hospitalTreatmentWindow;
        private RelayCommand cancelCommand;
        private RelayCommand okCommand;
        private List<ComboData<Patient>> patients = new List<ComboData<Patient>>();
        private HospitalTreatmentModel selectedItem = new HospitalTreatmentModel();
        PatientRepository repository = new PatientRepository();

        public HospitalTreatmentViewModel(HospitalTreatmentWindow hospitalTreatmentWindow) 
        {
            this.hospitalTreatmentWindow = hospitalTreatmentWindow;
            LoadPatients();
        }

        public HospitalTreatmentModel SelectedItem
        {
            get { return selectedItem; }
            set
            {
                selectedItem = value;
                OnPropertyChanged(nameof(SelectedItem));
            }
        }

        public List<ComboData<Patient>> Patients
        {
            get { return patients; }
            set
            {
                patients = value;
                OnPropertyChanged(nameof(Patients));
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

        public void LoadPatients()
        {
            List<ComboData<Patient>> result = new List<ComboData<Patient>>();

            foreach (Patient patient in repository.GetAll())
            {
                result.Add(new ComboData<Patient>() { Name = patient.FirstName + " " + patient.LastName, Value = patient });
            }
            Patients = result;
        }

        public void CancelCommandExecute() { }

        public bool CanCancelCommandExecute() { return true; }

        public void OkCommandExecute()
        {
            HCIContext.Instance.HospitalTreatments.Add(selectedItem);
            HCIContext.Instance.Save();
            hospitalTreatmentWindow.Close();
            MessageBox.Show("Uspesno ste podneli zahtev za stacionarno lecenje!", "Zahtev za stacionarno lecenje!");
        }

        public bool CanOkCommandExecute() { return true; }
    }
}
