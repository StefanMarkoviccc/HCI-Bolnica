using HCI_Bolnica.CompositeComon;
using HCIBolnica.CompositeComon;
using HCIBolnica.Dialogues.View;
using HCIBolnica.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace HCIBolnica.Dialogues.ViewModel
{
    public class HospitalMainWindowViewModel : ViewModelBase
    {
        Frame mainFrame;
        public HospitalMainWindow hospitalMainWindow;
        private RelayCommand doctorInfoCommand;
        private RelayCommand doctorAppointmentCommand;
        private RelayCommand healthCardCommand;
        private RelayCommand patientAppointmentCommand;
        private RelayCommand medicineCheckCommand;
        private RelayCommand stafInfoCommand;
        private RelayCommand specializationRequestCommand;
        private RelayCommand vacationRequestCommand;
        private RelayCommand revisionOfRequestCommand;
        private RelayCommand reportCommand;
        private RelayCommand logoutCommand;

        public HospitalMainWindowViewModel(HospitalMainWindow hospitalMainWindow, Frame frame) 
        {
            this.hospitalMainWindow = hospitalMainWindow;
            mainFrame = frame;
            FirstPage firstPage = new FirstPage();
            mainFrame.Content = firstPage;
        }

        public RelayCommand DoctorInfoCommand 
        {
            get { return doctorInfoCommand ?? (doctorInfoCommand = new RelayCommand(param => DoctorInfoCommandExecute(), param => CanDoctorInfoCommandExecute())); }
        }
        public RelayCommand DoctorAppointmentCommand
        {
            get { return doctorAppointmentCommand ?? (doctorAppointmentCommand = new RelayCommand(param => DoctorAppointmentCommandExecute(), param => CanDoctorAppointmentCommandExecute())); }
        }
        public RelayCommand HealthCardCommand
        {
            get { return healthCardCommand ?? (healthCardCommand = new RelayCommand(param => HealthCardCommandExecute(), param => CanHealthCardCommandExecute())); }
        }
        public RelayCommand PatientAppointmentCommand
        {
            get { return patientAppointmentCommand ?? (patientAppointmentCommand = new RelayCommand(param => PatientAppointmentCommandExecute(), param => CanPatientAppointmentCommandExecute())); }
        }
        public RelayCommand MedicineCheckCommand
        {
            get { return medicineCheckCommand ?? (medicineCheckCommand = new RelayCommand(param => MedicineCheckCommandExecute(), param => CanMedicineCheckCommandExecute())); }
        }
        public RelayCommand StafInfoCommand
        {
            get { return stafInfoCommand ?? (stafInfoCommand = new RelayCommand(param => StafInfoCommandExecute(), param => CanStafInfoCommandExecute())); }
        }
        public RelayCommand SpecializationRequestCommand
        {
            get { return specializationRequestCommand ?? (specializationRequestCommand = new RelayCommand(param => SpecializationRequestCommandExecutes(), param => CanSpecializationRequestCommandExecutes())); }
        }
        public RelayCommand VacationRequestCommand
        {
            get { return vacationRequestCommand ?? (vacationRequestCommand = new RelayCommand(param => VacationRequestCommandExecutes(), param => CanVacationRequestCommandExecutes())); }
        }
        public RelayCommand RevisionOfRequestCommand
        {
            get { return revisionOfRequestCommand ?? (revisionOfRequestCommand = new RelayCommand(param => RevisionOfRequestCommandExecute(), param => CanRevisionOfRequestCommandExecute())); }
        }

        public RelayCommand ReportCommand
        {
            get { return reportCommand ?? (reportCommand = new RelayCommand(param => ReportCommandExecute(), param => CanReportCommandExecute())); }
        }
        public RelayCommand LogoutCommand
        {
            get { return logoutCommand ?? (logoutCommand = new RelayCommand(param => LogoutCommandExecute(), param => CanLogoutCommandExecute())); }
        }
        public void LogoutCommandExecute()
        {
            MainWindow mainWindow = new MainWindow();
            hospitalMainWindow.Close();
            mainWindow.ShowDialog();
        }
        public bool CanLogoutCommandExecute() { return true; }
        public void DoctorInfoCommandExecute() 
        {
            DoctorInfoPage doctorInfoPage = new DoctorInfoPage();
            mainFrame.Content = doctorInfoPage;
        }
        public bool CanDoctorInfoCommandExecute() { return true; }
        public void DoctorAppointmentCommandExecute() 
        {
            DoctorAppointmentPage doctorAppointmentPage = new DoctorAppointmentPage();
            mainFrame.Content = doctorAppointmentPage;
        }
        public bool CanDoctorAppointmentCommandExecute() { return true; }
        public void HealthCardCommandExecute() 
        {
            Patient patient = new Patient();
            HealthCardPage healthCardPage = new HealthCardPage(patient);
            mainFrame.Content = healthCardPage;
        }
        public bool CanHealthCardCommandExecute() { return true; }
        public void PatientAppointmentCommandExecute() 
        {
            ExaminationOfPatientes examinationOfPatientes = new ExaminationOfPatientes();
            mainFrame.Content = examinationOfPatientes;
        }
        public bool CanPatientAppointmentCommandExecute() { return true; }
        public void MedicineCheckCommandExecute()
        {
            MedicineCheckPage medicineCheckPage = new MedicineCheckPage();
            mainFrame.Content = medicineCheckPage;
        }
        public bool CanMedicineCheckCommandExecute() { return true; }
        public void StafInfoCommandExecute() 
        {
            InformationOnSpentInventory informationOnSpentInventory = new InformationOnSpentInventory();
            mainFrame.Content = informationOnSpentInventory;
        }
        public bool CanStafInfoCommandExecute() { return true; }
        public void SpecializationRequestCommandExecutes() 
        {
            RequestForSpecialization requestForSpecialization = new RequestForSpecialization();
            mainFrame.Content = requestForSpecialization;
        }
        public bool CanSpecializationRequestCommandExecutes() { return true; }
        public void VacationRequestCommandExecutes() 
        {
            RequestForDaysOff requestForDaysOff = new RequestForDaysOff();
            mainFrame.Content = requestForDaysOff;
        }
        public bool CanVacationRequestCommandExecutes() { return true; }
        public void RevisionOfRequestCommandExecute() 
        {
            RequestsForMedicinesSupply requestsForMedicinesSupply = new RequestsForMedicinesSupply();
            mainFrame.Content = requestsForMedicinesSupply;
        }
        public bool CanRevisionOfRequestCommandExecute() { return true; }

        public void ReportCommandExecute() 
        {
            PatientHistoryReport patientHistoryReport = new PatientHistoryReport();
            mainFrame.Content = patientHistoryReport;
        }

        public bool CanReportCommandExecute()
        {
            return true;
        }
    }
}