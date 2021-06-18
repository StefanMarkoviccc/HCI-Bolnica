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
    public class RequestForSpecializationViewModel : ViewModelBase
    {
        private RequestForSpecialization requestForSpecialization;
        private RelayCommand cancelCommand;
        private RelayCommand okCommand;
        private RequestForSpecializationModel selectedItem = new RequestForSpecializationModel();
        private List<ComboData<Doctor>> doctors;
        private List<ComboData<Specialization>> specializations;
        DoctorRepository doctorRepository = new DoctorRepository();

        public RequestForSpecializationViewModel(RequestForSpecialization requestForSpecialization) 
        {
            this.requestForSpecialization = requestForSpecialization;
            LoadDoctor();
            LoadSpecializations();
        }

        public List<ComboData<Specialization>> Specializations
        {
            get { return specializations; }
            set
            {
                specializations = value;
                OnPropertyChanged(nameof(Specializations));
            }
        }

        public RequestForSpecializationModel SelectedItem
        {
            get { return selectedItem; }
            set
            {
                selectedItem = value;
                OnPropertyChanged(nameof(SelectedItem));
            }
        }

        public List<ComboData<Doctor>> Doctors
        {
            get { return doctors; }
            set
            {
                doctors = value;
                OnPropertyChanged(nameof(Doctors));
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

        public void LoadDoctor()
        {
            List<ComboData<Doctor>> result = new List<ComboData<Doctor>>();

            foreach (Doctor doctor in doctorRepository.GetAll())
            {
                result.Add(new ComboData<Doctor>() { Name = doctor.FirstName + " " + doctor.LastName, Value = doctor });
            }
            Doctors = result;
        }

        public void LoadSpecializations()
        {
            List<ComboData<Specialization>> result = new List<ComboData<Specialization>>();

            result.Add(new ComboData<Specialization>() { Name = "Kardiolog", Value = Specialization.Cardiologist });
            result.Add(new ComboData<Specialization>() { Name = "Zubar", Value = Specialization.Dentist });
            result.Add(new ComboData<Specialization>() { Name = "Dermatolog", Value = Specialization.Dermatologist });
            result.Add(new ComboData<Specialization>() { Name = "Neurohirurg", Value = Specialization.Neurosurgeon });
            result.Add(new ComboData<Specialization>() { Name = "Pediatar", Value = Specialization.Pediatrician });
            result.Add(new ComboData<Specialization>() { Name = "Hirurg", Value = Specialization.Surgeon });
            result.Add(new ComboData<Specialization>() { Name = "Opsta praksa", Value = Specialization.GeneralPractice });

            Specializations = result;
        }

        public void CancelCommandExecute() { }

        public bool CanCancelCommandExecute() { return true; }

        public void OkCommandExecute() 
        {
            HCIContext.Instance.RequestsForSpecializations.Add(selectedItem);
            HCIContext.Instance.Save();
            MessageBox.Show("Uspesno ste podneti zahtev za specijalziaciju!", "Zahtev za specijalizaciju!");
        }

        public bool CanOkCommandExecute() { return true; }
    }
}
