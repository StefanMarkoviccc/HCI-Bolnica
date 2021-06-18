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
    public class RequestForDaysOffViewModel : ViewModelBase
    {
        public RequestForDaysOff requestForDaysOff;
        private RelayCommand cancelCommand;
        private RelayCommand okCommand;
        RequestToManager selectedItem = new RequestToManager();
        private List<ComboData<Doctor>> doctors;
        DoctorRepository doctorRepository = new DoctorRepository();

        public RequestForDaysOffViewModel(RequestForDaysOff requestForDaysOff) 
        {
            this.requestForDaysOff = requestForDaysOff;
            LoadDoctor();
        }

        public RequestToManager SelectedItem
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

        public void CancelCommandExecute() { }

        public bool CanCancelCommandExecute() { return true; }

        public void OkCommandExecute() 
        {
            HCIContext.Instance.RequestToManager.Add(selectedItem);
            HCIContext.Instance.Save();
            MessageBox.Show("Uspesno ste podneti zahtev za slobodne dane!", "Zahtev za slobodne dane!");

        }

        public bool CanOkCommandExecute() { return true; }
    }
}
