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

namespace HCIBolnica.Dialogues.ViewModel
{
    public class HealthCardViewModel : ViewModelBase
    {

        public HealthCardPage healthCardPage;
        private RelayCommand previousAppointmentsCommand;
        private RelayCommand cancelCommand;
        private PatientRepository patientRepository = new PatientRepository();
        private List<ComboData<Patient>> patients;
        List<ComboData<Gender>> genders = new List<ComboData<Gender>>();
        Patient selectedItem = null;
        private Patient patient;


        public HealthCardViewModel(HealthCardPage healthCardPage,Patient patient)
        {
            this.healthCardPage = healthCardPage;
            LoadPatients();
            LoadGenders();

            this.Patient = patient;
            SelectedItem = patient;
        }

        public Patient Patient
        {
            get { return patient; }
            set
            {
                patient = value;
                OnPropertyChanged(nameof(Patient));
            }
        }
        public RelayCommand PreviousAppointmentsCommand
        {
            get { return previousAppointmentsCommand ?? (previousAppointmentsCommand = new RelayCommand(param => PreviousAppointmentsCommandExecute(), param => CanPreviousAppointmentsCommandExecute())); }
        }

        public RelayCommand CancelCommand
        {
            get { return cancelCommand ?? (cancelCommand = new RelayCommand(param => CancelCommandExecute(), param => CanCancelCommandExecute())); }
        }

        public Patient SelectedItem
        {
            get { return selectedItem; }
            set
            {
                selectedItem = value;
                OnPropertyChanged(nameof(SelectedItem));
            }
        }

        public List<ComboData<Gender>> Genders
        {
            get { return genders; }
            set
            {
                genders = value;
                OnPropertyChanged(nameof(Genders));
            }
        }

        public void LoadGenders()
        {
            List<ComboData<Gender>> result = new List<ComboData<Gender>>();

            result.Add(new ComboData<Gender>() { Name = "Muski", Value = Gender.Male });
            result.Add(new ComboData<Gender>() { Name = "Zenski", Value = Gender.Female });

            Genders = result;
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

        public void LoadPatients()
        {
            List<ComboData<Patient>> result = new List<ComboData<Patient>>();


            foreach (Patient patient in patientRepository.GetAll())
            {
                result.Add(new ComboData<Patient>() { Name = patient.FirstName + " " + patient.LastName, Value = patient });
            }

            Patients = result;
        }


        public void PreviousAppointmentsCommandExecute() 
        {
            PatientHistoryWindow patientHistoryWindow = new PatientHistoryWindow(SelectedItem);
            patientHistoryWindow.ShowDialog();
        }

        public bool CanPreviousAppointmentsCommandExecute()
        {
            return true;
        }

        public void CancelCommandExecute()
        {
            FirstPage firstPage = new FirstPage();
            HospitalMainWindow.Instance.MainFrame.Content = firstPage;
        }

        public bool CanCancelCommandExecute()
        {
            return true;
        }
    }
}
