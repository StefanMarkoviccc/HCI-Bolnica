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
    public class PrescribingTherapyViewModel : ViewModelBase
    {
        public PrescribingTherapyWindow prescribingTherapyWindow;
        private RelayCommand cancelCommand;
        private RelayCommand okCommand;
        private Medicine selectedItem = new Medicine();
        private List<ComboData<Medicine>> medicines;
        private MedicineRepository medicineRepository = new MedicineRepository();
        private Patient selectedPatient = new Patient();
        private Recipe selectedRecipe = new Recipe();
        public PrescribingTherapyViewModel(PrescribingTherapyWindow prescribingTherapyWindow, Patient selectedPatient) 
        {
            this.prescribingTherapyWindow = prescribingTherapyWindow;
            LoadMedicine();
            this.selectedPatient = selectedPatient;
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

        public Recipe SelectedRecipe
        {
            get { return selectedRecipe; }
            set
            {
                selectedRecipe = value;
                OnPropertyChanged(nameof(SelectedRecipe));
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

        public Patient SelectedPatient
        {
            get{ return selectedPatient; }
            set
            {
                selectedPatient = value;
                OnPropertyChanged(nameof(SelectedPatient));
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

        public void LoadMedicine()
        {
            List<ComboData<Medicine>> result = new List<ComboData<Medicine>>();

            foreach(Medicine medicine in medicineRepository.GetAll())
            {
                result.Add(new ComboData<Medicine>() { Name = medicine.MedicineName, Value = medicine });
            }

            Medicines = result;
        }

        public void CancelCommandExecute() 
        {
            prescribingTherapyWindow.Close();
        }

        public bool CanCancelCommandExecute() { return true; }

        public void OkCommandExecute() 
        {
            HCIContext.Instance.Recipes.Add(SelectedRecipe);
            HCIContext.Instance.Save();
            prescribingTherapyWindow.Close();
            MessageBox.Show("Uspesno ste prepisali terapiju!", "Prepisivanje terapije!");
        }

        public bool CanOkCommandExecute() { return true; }
    }
}
