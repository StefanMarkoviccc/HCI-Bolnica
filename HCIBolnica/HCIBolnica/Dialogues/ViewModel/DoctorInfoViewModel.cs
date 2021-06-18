using HCI_Bolnica.CompositeComon;
using HCIBolnica.CompositeComon;
using HCIBolnica.Dialogues.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCIBolnica.Dialogues.ViewModel
{
    public class DoctorInfoViewModel : ViewModelBase
    {
        public DoctorInfoPage doctorInfoPage;
        private RelayCommand goBackCommand;

        public DoctorInfoViewModel(DoctorInfoPage doctorInfoPage) 
        {
            this.doctorInfoPage = doctorInfoPage;

        }

        public RelayCommand GoBackCommand
        {
            get { return goBackCommand ?? (goBackCommand = new RelayCommand(param => GoBackCommandExecute(), param => CanGoBackCoomandExecute())); }
        }
        public void GoBackCommandExecute() { }

        public bool CanGoBackCoomandExecute() { return true; }
    }
}
