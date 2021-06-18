using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCIBolnica.Model
{
    public class Patient : Person
    {
        private HealthCard healthCard;
        public System.Collections.ArrayList termin;

        private string patientId;
        private string anamneza;
        private string residentalAddress;
        private Gender gender;
        private string phone;
        private DateTime dateOfBirth;

        public Patient(string patientId)
        {
            this.patientId = patientId;
        }
        public Patient()
        {
        }

        public string ResidentalAddress
        {
            get { return residentalAddress; }
            set
            {
                residentalAddress = value;
                OnPropertyChanged(nameof(ResidentalAddress));
            }
        }
        public HealthCard HealthCard
        {
            get { return healthCard; }
            set
            {
                healthCard = value;
                OnPropertyChanged(nameof(HealthCard));
            }
        }

        public string PatientId
        {
            get { return patientId; }
            set
            {
                patientId = value;
                OnPropertyChanged(nameof(PatientId));
            }
        }

        public string Anamneza
        {
            get { return anamneza; }
            set
            {
                anamneza = value;
                OnPropertyChanged(nameof(Anamneza));
            }
        }

        public Gender Gender
        {
            get { return gender; }
            set
            {
                gender = value;
                OnPropertyChanged(nameof(gender));
            }
        }

        public string Phone
        {
            get { return phone; }
            set
            {
                phone = value;
                OnPropertyChanged(nameof(Phone));
            }
        }

        public DateTime DateOfBirth
        {
            get { return dateOfBirth; }
            set
            {
                dateOfBirth = value;
                OnPropertyChanged(nameof(DateOfBirth));
            }
        }
        public override string ToString()
        {
            return FirstName + " " + LastName;
            
        }
    }
}
