using HCI_Bolnica.CompositeComon;
using HCIBolnica.CompositeComon;
using HCIBolnica.Dialogues.View;
using HCIBolnica.Model;
using HCIBolnica.Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HCIBolnica.Dialogues.ViewModel
{
    public class DoctorAppointmentViewModel : ViewModelBase
    {
        DoctorAppointmentPage doctorAppointmentPage;
        private RelayCommand makeAnAppointmentCommand;
        private RelayCommand editAppointmentCommand;
        private RelayCommand cancelAppointmentCommand;
        private DateTime dateOfAppointment = DateTime.Now;
        private RelayCommand goBackCommand;
        ObservableCollection<Entity> doctorAppointments = new ObservableCollection<Entity>();
        private Appointment selectedItem;
        private RelayCommand searchCommand;

        public DoctorAppointmentViewModel()
        {
        }

        public DoctorAppointmentViewModel(DoctorAppointmentPage doctorAppointmentPage)
        {
            this.doctorAppointmentPage = doctorAppointmentPage;
            Inic();
        }
        public RelayCommand SearchCommand
        {
            get { return searchCommand ?? (searchCommand = new RelayCommand(param => SearchCommandExecute(), param => CanSearchCommandExecute())); }
        }
        public DateTime DateOfAppointment
        {
            get { return dateOfAppointment; }
            set
            {
                dateOfAppointment = value;
                OnPropertyChanged(nameof(DateOfAppointment));
            }
        }
        public Appointment SelectedItem
        {
            get { return selectedItem; }
            set
            {
                selectedItem = value;
                OnPropertyChanged(nameof(SelectedItem));
            }
        }


        public ObservableCollection<Entity> DoctorAppointments
        {
            get { return doctorAppointments; }
            set
            {
                doctorAppointments = value;
                OnPropertyChanged(nameof(DoctorAppointments));
            }
        }

        public void Inic()
        {
            DoctorAppointments = new ObservableCollection<Entity>(HCIContext.Instance.Appointments);
        }

        public RelayCommand EditAppointmentCommand 
        {
            get { return editAppointmentCommand ?? (editAppointmentCommand = new RelayCommand(param => EditCommandExecute(), param => CanEditCommandExecute())); }
        }

        public RelayCommand MakeAnAppointmentCommand
        {
            get { return makeAnAppointmentCommand ?? (makeAnAppointmentCommand = new RelayCommand(param => MakeAppointmentCommandExecute(), param => CanMakeAppointmentCommandExecute())); }
        }

        public RelayCommand CancelCommand
        {
            get { return cancelAppointmentCommand ?? (cancelAppointmentCommand = new RelayCommand(param => CancelCommandExecute(), param => CanCancelCommandExecute())); }
        }

        public RelayCommand GoBackCommand 
        {
            get { return goBackCommand ?? (goBackCommand = new RelayCommand(param => GoBackCommandExecute(), param => CanGoBackCoomandExecute()));}
        }
        public void SearchCommandExecute()
        {
            AppointmentRepository appointemntRepository = new AppointmentRepository();
            DoctorAppointments = new ObservableCollection<Entity>(appointemntRepository.SearchAppointment(dateOfAppointment));
        }
        public bool CanSearchCommandExecute()
        {
            return true;
        }
        public void CancelCommandExecute() 
        {
            MessageBoxResult messageResult = MessageBox.Show("Da li ste sigurni da zelite da otkazete termin?", "Brisanje termina", MessageBoxButton.YesNo);
            if(messageResult != MessageBoxResult.Yes)
            {
                return;
            }

            foreach(Appointment appointment in HCIContext.Instance.Appointments)
            {
                if (appointment.ID == SelectedItem.ID)
                {
                    SelectedItem = appointment;
                }
            }
            HCIContext.Instance.Appointments.Remove(SelectedItem);
            HCIContext.Instance.Save();
            Inic();
        }

        public bool CanCancelCommandExecute() 
        {
            return SelectedItem != null;
        }

        public void EditCommandExecute() 
        {
            ChangeAppointment changeAppointment = new ChangeAppointment(selectedItem,this);
            changeAppointment.ShowDialog();
            HCIContext.Instance.Save();
        }

        public bool CanEditCommandExecute() { return SelectedItem != null; }

        public void MakeAppointmentCommandExecute() 
        {
            SchedulingAppointmentWindow schedulingAppointmentWindow = new SchedulingAppointmentWindow(this);
            schedulingAppointmentWindow.ShowDialog();
            HCIContext.Instance.Save();
        }

        public bool CanMakeAppointmentCommandExecute() { return true; }

        public void GoBackCommandExecute() { }

        public bool CanGoBackCoomandExecute() { return true; }
    }
}
