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
    public class MedicineCheckViewModel : ViewModelBase
    {
        public MedicineCheckPage medicineCheckPage;
        private RelayCommand cancelCommand;
        private RelayCommand okCommand;
        private Medicine selectedItem;
        private List<ComboData<Medicine>> medicines = new List<ComboData<Medicine>>();

        public MedicineCheckViewModel(MedicineCheckPage medicineCheckPage) 
        {
            this.medicineCheckPage = medicineCheckPage;
            LoadMedicines();
        }

        public Medicine SelectedItem
        {
            get { return selectedItem; }
            set
            {
                selectedItem = value;
                OnPropertyChanged(nameof(SelectedItem));
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

        public void LoadMedicines()
        {
            List<ComboData<Medicine>> result = new List<ComboData<Medicine>>();

            foreach(Medicine medicine in HCIContext.Instance.Medicines)
            {
                result.Add(new ComboData<Medicine>() { Name = medicine.MedicineName, Value = medicine });
            }

            Medicines = result;
        }

        public void CancelCommandExecute() { }

        public bool CanCancelCommandExecute() { return true; }

        public void OkCommandExecute() 
        {
            HCIContext.Instance.Save();
            MessageBox.Show("Uspesno ste potvrdili kolicinu leka!", "Provera leka");
        }

        public bool CanOkCommandExecute() { return true; }
    }
}
