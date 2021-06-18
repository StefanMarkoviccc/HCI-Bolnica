using HCI_Bolnica.CompositeComon;
using HCIBolnica.CompositeComon;
using HCIBolnica.Model;
using HCIBolnica.Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCIBolnica.Dialogues.ViewModel
{
    public class PatientHistoryViewModel : ViewModelBase
    {
        private ObservableCollection<Anamneza> anamnezes  = new ObservableCollection<Anamneza>();
        private RelayCommand cancelCommand;
        private AnamnezaRepository anamnezaRepository = new AnamnezaRepository();
        
        public PatientHistoryViewModel(Patient patient)
        {
            Anamnezes = new ObservableCollection<Anamneza>(anamnezaRepository.FindPatientHistory(patient));
        }

        public ObservableCollection<Anamneza> Anamnezes
        {
            get { return anamnezes; }
            set
            {
                anamnezes = value;
                OnPropertyChanged(nameof(Anamnezes));
            }
        }

        public RelayCommand CancelCommand
        {
            get { return cancelCommand ?? (cancelCommand = new RelayCommand(param => CancelCommandExecute(), param => CanCancelCommandExecute())); }
        }

        public void CancelCommandExecute()
        { 
        
        }

        public bool CanCancelCommandExecute()
        {
            return true;
        }

    }
}
