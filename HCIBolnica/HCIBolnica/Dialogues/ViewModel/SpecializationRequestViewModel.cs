using HCI_Bolnica.CompositeComon;
using HCIBolnica.CompositeComon;
using HCIBolnica.Dialogues.Model;
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
    public class SpecializationRequestViewModel : ViewModelBase
    {
        public SpecializationRequestWindow specializationRequestWindow;
        private RelayCommand cancelCommand;
        private RelayCommand okCommand;
        private RequestForSpecialistModel selectedItem = new RequestForSpecialistModel();
        private List<ComboData<Specialization>> specializations = new List<ComboData<Specialization>>();
        private Patient patient = new Patient();
        private HealthCard healthCard = new HealthCard();

        public SpecializationRequestViewModel(SpecializationRequestWindow specializationRequestWindow, Patient patient) 
        {
            this.specializationRequestWindow = specializationRequestWindow;
            this.patient = patient;
            LoadSpecializations();
            LoadHealtCard();
            SelectedItem.JMBG = Patient.JMBG;
            SelectedItem.HealthCardNumber = healthCard.ID;
        }
        public HealthCard HealthCard
        {
            get { return healthCard; }
            set
            {
                healthCard = value;
                OnPropertyChanged(nameof(HealthCard));
            }
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
        public RequestForSpecialistModel SelectedItem
        {
            get { return selectedItem; }
            set
            {
                selectedItem = value;
                OnPropertyChanged(nameof(SelectedItem));
            }
        }

        public List<ComboData<Specialization>> Specializations
        {
            get { return specializations; }
            set
            {
                specializations = value;
                OnPropertyChanged(nameof(Specialization));
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
        public void LoadHealtCard()
        {
            foreach (HealthCard h in HCIContext.Instance.HealthCards)
            {
                if (h.FirstName == Patient.FirstName)
                {
                    healthCard = h;
                }
            }
        }
        public void CancelCommandExecute() { }

        public bool CanCancelCommandExecute() { return true; }

        public void OkCommandExecute() 
        {
            HCIContext.Instance.RequestForSpecialists.Add(selectedItem);
            HCIContext.Instance.Save();
            specializationRequestWindow.Close();
            MessageBox.Show("Uspesno ste izadli uput!", "Izdavanje uputa!");
        }

        public bool CanOkCommandExecute() 
        {
            if (string.IsNullOrWhiteSpace(SelectedItem.ID) || string.IsNullOrWhiteSpace(SelectedItem.HealthCardNumber) || string.IsNullOrWhiteSpace(SelectedItem.JMBG) || string.IsNullOrWhiteSpace(SelectedItem.ReasonForSpecialist))
            {
                return false;
            }

            return true;
        }
    }
}
