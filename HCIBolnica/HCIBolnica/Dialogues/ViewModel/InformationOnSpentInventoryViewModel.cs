using HCI_Bolnica.CompositeComon;
using HCIBolnica.CompositeComon;
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
    public class InformationOnSpentInventoryViewModel : ViewModelBase
    {
        public InformationOnSpentInventory informationOnSpentInventory;
        private RelayCommand cancelCommand;
        private RelayCommand okCommand;
        private SpentInventory selectedItem = new SpentInventory();

        public InformationOnSpentInventoryViewModel(InformationOnSpentInventory informationOnSpentInventory) 
        {
            this.informationOnSpentInventory = informationOnSpentInventory;
        }

        public SpentInventory SelectedItem
        {
            get { return selectedItem; }
            set
            {
                selectedItem = value;
                OnPropertyChanged(nameof(SelectedItem));
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

        public void CancelCommandExecute() { }

        public bool CanCancelCommandExecute() { return true; }

        public void OkCommandExecute() 
        {
            HCIContext.Instance.SpentInventorys.Add(selectedItem);
            HCIContext.Instance.Save();
            MessageBox.Show("Uspesno ste uneli informacije o potrosenom inventaru!", "Informacije o potrosenom inventaru");

        }

        public bool CanOkCommandExecute() 
        {
            if (string.IsNullOrWhiteSpace(SelectedItem.ID) || string.IsNullOrWhiteSpace(SelectedItem.InventoryQuantity) || string.IsNullOrWhiteSpace(SelectedItem.InventoryQuantity))
            {
                return false;
            }

            return true;
        }
    }
}
