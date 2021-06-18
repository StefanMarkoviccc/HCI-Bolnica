using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCIBolnica.Model
{
    public class Appointment : Entity
    {
        private string time;
        private double durationOfTheAppointment;
        private DateTime dateOfAppointment = DateTime.Now;
        private TypeOfAppointment typeOfAppointment;
        private string appointmentId;
        private Doctor doctor;
        private Patient patient;
        private bool isUrgent;
        private Room room;
 
        public Appointment(string appointmentId, TypeOfAppointment typeOfAppointment, String time, double durationOfTheAppointment, DateTime dateOfAppointment, Patient patient, Doctor doctor)
        {
            this.appointmentId = appointmentId;
            this.typeOfAppointment = typeOfAppointment;
            this.time = time;
            this.durationOfTheAppointment = durationOfTheAppointment;
            this.dateOfAppointment = dateOfAppointment;
            this.patient = patient;
            this.doctor = doctor;
        }                                        
        public Appointment(String appointmentId, TypeOfAppointment typeOfAppointment, String time, double durationOfTheAppointment, DateTime dateOfAppointment, Patient patient, Doctor doctor, bool urgent = false)

        {
            this.appointmentId = appointmentId;
            this.typeOfAppointment = typeOfAppointment;
            this.time = time;
            this.durationOfTheAppointment = durationOfTheAppointment;
            this.dateOfAppointment = dateOfAppointment;
            this.patient = patient;
            this.doctor = doctor;
            isUrgent = urgent;
        }
        

        public Appointment() { }

        public override string Validate(string columName)
        {
            return "";
        }

        public override void InitExportList()
        {

        }

        public string Time
        {
            get { return time; }
            set
            {
                time = value;
                OnPropertyChanged(nameof(Time));
            }
        }

        public double DurationOfTheAppointment
        {
            get { return durationOfTheAppointment; }
            set
            {
                durationOfTheAppointment = value;
                OnPropertyChanged(nameof(DurationOfTheAppointment));
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

        public TypeOfAppointment TypeOfAppointment
        {
            get { return typeOfAppointment; }
            set
            {
                typeOfAppointment = value;
                OnPropertyChanged(nameof(TypeOfAppointment));
            }
        }

        public string AppointmentId
        {
            get { return appointmentId; }
            set
            {
                appointmentId = value;
                OnPropertyChanged(nameof(AppointmentId));
            }
        }

        public Doctor Doctor
        {
            get { return doctor; }
            set
            {
                doctor = value;
                OnPropertyChanged(nameof(doctor));
            }
        }

        public Patient Patient
        {
            get { return patient; }
            set
            {
                patient = value;
                OnPropertyChanged(nameof(patient));
            }
        }

        public bool IsUrgent
        {
            get { return isUrgent; }
            set
            {
                isUrgent = value;
                OnPropertyChanged(nameof(isUrgent));
            }
        } 

        public Room Room
        {
            get { return room; }
            set
            {
                room = value;
                OnPropertyChanged(nameof(Room));
            }
        }
    }
}
