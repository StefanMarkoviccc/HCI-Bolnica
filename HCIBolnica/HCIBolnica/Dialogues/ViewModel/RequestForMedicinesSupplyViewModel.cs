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
    public class RequestForMedicinesSupplyViewModel : ViewModelBase
    {
        public RequestsForMedicinesSupply requestsForMedicinesSupply;
        private RelayCommand cancelCommand;
        private RelayCommand okCommand;
        RequestForMedicinesSupplyModel selectedItem = new RequestForMedicinesSupplyModel();
        DoctorRepository doctorRepository = new DoctorRepository();
        MedicineRepository medicineRepository = new MedicineRepository();
        private List<ComboData<Doctor>> doctors;
        private List<ComboData<Medicine>> medicines;


        public RequestForMedicinesSupplyViewModel(RequestsForMedicinesSupply requestsForMedicinesSupply) 
        {
            this.requestsForMedicinesSupply = requestsForMedicinesSupply;
            LoadDoctors();
            LoadMedicines();
        }
        public RequestForMedicinesSupplyModel SelectedItem
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

        public List<ComboData<Medicine>> Medicines
        {
            get { return medicines; }
            set
            {
                medicines = value;
                OnPropertyChanged(nameof(Medicines));
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

        public void LoadDoctors()
        {
            List<ComboData<Doctor>> result = new List<ComboData<Doctor>>();

            foreach (Doctor doctor in doctorRepository.GetAll())
            {
                result.Add(new ComboData<Doctor>() { Name = doctor.FirstName + " " + doctor.LastName, Value = doctor });
            }
            Doctors = result;
        }

        public void LoadMedicines()
        {
            List<ComboData<Medicine>> result = new List<ComboData<Medicine>>();

            foreach (Medicine medicine in medicineRepository.GetAll())
            {
                result.Add(new ComboData<Medicine>() { Name = medicine.MedicineName, Value = medicine });
            }
            Medicines = result;
        }

        public void CancelCommandExecute() { }

        public bool CanCancelCommandExecute() { return true; }

        public void OkCommandExecute() 
        {
            HCIContext.Instance.MedicinesSupply.Add(selectedItem);
            HCIContext.Instance.Save();
            MessageBox.Show("Uspesno ste podneti zahtev za dobavljanje lekova!", "Zahtev za dobavljanje lekova!");
        }

        public bool CanOkCommandExecute() { return true; }
    }
}
