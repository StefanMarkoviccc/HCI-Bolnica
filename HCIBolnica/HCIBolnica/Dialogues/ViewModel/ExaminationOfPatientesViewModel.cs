using HCI_Bolnica.CompositeComon;
using HCIBolnica.CompositeComon;
using HCIBolnica.Dialogues.Model;
using HCIBolnica.Dialogues.View;
using HCIBolnica.Model;
using HCIBolnica.Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace HCIBolnica.Dialogues.ViewModel
{
    public class ExaminationOfPatientesViewModel : ViewModelBase
    {
        public ExaminationOfPatientes examinationOfPatientes;
        private RelayCommand prescribingTherapyCommand;
        private RelayCommand instructionForSpecialistCommand;
        private RelayCommand stationaryTreatmentCommand;
        private RelayCommand appointmentInfoCommand;
        private RelayCommand patientHeltCardCommand;
        ObservableCollection<Entity> examinationOfPatientTable = new ObservableCollection<Entity>();
        private Appointment selectedItem;
        private string searchTerm = string.Empty;





        public ExaminationOfPatientesViewModel(ExaminationOfPatientes examinationOfPatientes) 
        {
            this.examinationOfPatientes = examinationOfPatientes;
            Inic1();
        }
        public string SearchTerm
        {
            get { return searchTerm; }
            set
            {
                searchTerm = value;
                OnPropertyChanged(nameof(SearchTerm));

                SearchExecute();
            }
        }
        public ObservableCollection<Entity> ExaminationOfPatientTable
        {
            get { return examinationOfPatientTable; }
            set
            {
                examinationOfPatientTable = value;
                OnPropertyChanged(nameof(ExaminationOfPatientTable));
            }
        }
        public Appointment SelectedItem
        {
            get { return selectedItem; }
            set
            {
                selectedItem = value;
                OnPropertyChanged(nameof(SelectedItem));
            }
        }
        
        public void Inic1()
        {
            ExaminationOfPatientTable = new ObservableCollection<Entity>(HCIContext.Instance.Appointments);
        }

        public RelayCommand PrescribingTherapyCommand
        {
            get { return prescribingTherapyCommand ?? (prescribingTherapyCommand = new RelayCommand(param => PrescribingTherapyCommandExecute(), param => CanPrescribingTherapyCommandExecute())); }
        }

        public RelayCommand InstructionForSpecialistCommand
        {
            get { return instructionForSpecialistCommand ?? (instructionForSpecialistCommand = new RelayCommand(param => InstructionForSpecialistCommandExecute(), param => CanInstructionForSpecialistCommandExecute())); }
        }
        public RelayCommand StationaryTreatmentCommand
        {
            get { return stationaryTreatmentCommand ?? (stationaryTreatmentCommand = new RelayCommand(param => StationaryTreatmentCommandExecute(), param => CanStationaryTreatmentCommandExecute())); }
        }

        public RelayCommand AppointmentInfoCommand
        {
            get { return appointmentInfoCommand ?? (appointmentInfoCommand = new RelayCommand(peram => AppointmentInfoCommandExecute(), param => CanAppointmentInfoCommandExecute())); }
        }
        public RelayCommand PatientHeltCardCommand
        {
            get { return patientHeltCardCommand ?? (patientHeltCardCommand = new RelayCommand(peram => PatientHeltCardCommandExecute(), param => CanPatientHeltCardCommandExecute())); }
        }

        public void PrescribingTherapyCommandExecute() 
        {
            PrescribingTherapyWindow prescribingTherapyWindow = new PrescribingTherapyWindow(SelectedItem.Patient);
            prescribingTherapyWindow.ShowDialog();
        }

        public bool CanPrescribingTherapyCommandExecute() { return true; }

        public void InstructionForSpecialistCommandExecute() 
        {
            SpecializationRequestWindow specializationRequestWindow = new SpecializationRequestWindow(selectedItem.Patient);
            specializationRequestWindow.ShowDialog();
        }

        public bool CanInstructionForSpecialistCommandExecute() { return true; }

        public void StationaryTreatmentCommandExecute() 
        {
            HospitalTreatmentWindow hospitalTreatmentWindow = new HospitalTreatmentWindow();
            hospitalTreatmentWindow.ShowDialog();
        }



        public bool CanStationaryTreatmentCommandExecute() { return true; }

        public void AppointmentInfoCommandExecute() 
        {
            PatientAppointmentInformationWindow patientAppointmentInformationWindow = new PatientAppointmentInformationWindow();
            patientAppointmentInformationWindow.ShowDialog();
        }

        public bool CanAppointmentInfoCommandExecute() { return true; }

        public void PatientHeltCardCommandExecute() 
        {
            HealthCardPage healthCardPage = new HealthCardPage(selectedItem.Patient);
            HospitalMainWindow.Instance.MainFrame.Content = healthCardPage;
        }

        public bool CanPatientHeltCardCommandExecute() { return true; }
        public void SearchExecute()
        {
            PatientRepository patientRepository = new PatientRepository();

            ExaminationOfPatientTable = new ObservableCollection<Entity>(patientRepository.SearchDinamic(searchTerm));


        }
    }

}
