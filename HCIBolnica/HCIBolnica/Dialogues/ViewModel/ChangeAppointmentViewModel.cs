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

namespace HCIBolnica.Dialogues.ViewModel
{
    public class ChangeAppointmentViewModel : ViewModelBase
    {
        ChangeAppointment changeAppointment;
        private RelayCommand cancelCommand;
        private RelayCommand okCommand;
        private List<ComboData<Patient>> patients;
        private List<ComboData<TypeOfAppointment>> typeOfAppointments;
        private List<ComboData<Room>> rooms;
        private List<ComboData<string>> times;
        private Appointment selectedItem;
        private DateTime dateOfAppointment = DateTime.Now;
        private PatientRepository repository = new PatientRepository();
        private RoomRepository roomRepository = new RoomRepository();
        private DoctorAppointmentViewModel doctorAppointmentViewModel;

        public ChangeAppointmentViewModel(ChangeAppointment changeAppointment, Appointment appointement,DoctorAppointmentViewModel doctorAppointmentViewModel) 
        {
            this.changeAppointment = changeAppointment;
            this.doctorAppointmentViewModel = doctorAppointmentViewModel;
            selectedItem = appointement;
            LoadPatients();
            LoadTypeOfAppointemnts();
            LoadRooms();
            LoadTimeOfAppointment();
            LoadDateOfAppointment();
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

        public DateTime DateOfAppointment
        {
            get { return dateOfAppointment; }
            set
            {
                dateOfAppointment = value;
                OnPropertyChanged(nameof(DateOfAppointment));
            }
        }

        public List<ComboData<string>> Times
        {
            get { return times; }
            set
            {
                times = value;
                OnPropertyChanged(nameof(Times));
            }
        }

        public List<ComboData<TypeOfAppointment>> TypeOfAppointments
        {
            get { return typeOfAppointments; }
            set
            {
                typeOfAppointments = value;
                OnPropertyChanged(nameof(TypeOfAppointments));
            }
        }

        public List<ComboData<Patient>> Patients
        {
            get { return patients; }
            set
            {
                patients = value;
                OnPropertyChanged(nameof(Patients));
            }
        }

        public List<ComboData<Room>> Rooms
        {
            get { return rooms; }
            set
            {
                rooms = value;
                OnPropertyChanged(nameof(Rooms));
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
            HCIContext.Instance.Save();
            changeAppointment.Close();
            doctorAppointmentViewModel.Inic();
        }

        public void LoadPatients()
        {
            List<ComboData<Patient>> result = new List<ComboData<Patient>>();


            foreach (Patient patient in repository.GetAll())
            {
                result.Add(new ComboData<Patient>() { Name = patient.FirstName + " " + patient.LastName, Value = patient });
            }

            Patients = result;
        }

        public void LoadRooms()
        {
            List<ComboData<Room>> result = new List<ComboData<Room>>();

            foreach (Room room in roomRepository.GetAll())
            {
                result.Add(new ComboData<Room>() { Name = room.ID, Value = room});
            }
            Rooms = result;
        }

        public void LoadDateOfAppointment()
        {

        }

        public void LoadTypeOfAppointemnts()
        {
            List<ComboData<TypeOfAppointment>> result = new List<ComboData<TypeOfAppointment>>();

            result.Add(new ComboData<TypeOfAppointment>() { Name = "Operacija", Value = TypeOfAppointment.Operation });
            result.Add(new ComboData<TypeOfAppointment>() { Name = "Pregled", Value = TypeOfAppointment.Examination });

            TypeOfAppointments = result;
        }

        public void LoadTimeOfAppointment()
        {
            List<ComboData<string>> result = new List<ComboData<string>>();

            result.Add(new ComboData<string>() { Name = "08:00", Value = "08:00" });
            result.Add(new ComboData<string>() { Name = "08:30", Value = "08:30" });
            result.Add(new ComboData<string>() { Name = "09:00", Value = "09:00" });
            result.Add(new ComboData<string>() { Name = "09:30", Value = "09:30" });
            result.Add(new ComboData<string>() { Name = "10:00", Value = "10:00" });
            result.Add(new ComboData<string>() { Name = "10:30", Value = "10:30" });
            result.Add(new ComboData<string>() { Name = "11:00", Value = "11:00" });
            result.Add(new ComboData<string>() { Name = "11:30", Value = "11:30" });
            result.Add(new ComboData<string>() { Name = "12:00", Value = "12:00" });
            result.Add(new ComboData<string>() { Name = "12:30", Value = "12:30" });
            result.Add(new ComboData<string>() { Name = "13:00", Value = "13:00" });

            Times = result;
        }

        public bool CanOkCommandExecute()
        {
            if (string.IsNullOrWhiteSpace(SelectedItem.ID))
            {
                return false;
            }

            return true;
        }

    }
}
