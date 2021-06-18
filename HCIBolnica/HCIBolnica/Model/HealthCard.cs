using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCIBolnica.Model
{
    public class HealthCard : Entity
    {
        //private string hospitalName;
        private string receptionDepartment;
        private string firstName;
        private string lastName;
        private string parentName;
        private DateTime dateOfBirth;
        private Gender gender;
        private string phone;
        private string healthCardNumber;
        private MerrageStatus merriageStatus;
        private Patient patient;
        private Anamneza anamneza;
        private ResidentalAddress residentalAddress;
        public List<Recipe> recipes{ get; set; }

        public HealthCard()
        {
            anamneza = new Anamneza();
            recipes = new List<Recipe>();
        }
        public HealthCard(string receptionDepartment, string firstName, string lastName, string parentName, DateTime dateOfBirth, Gender gender, string phone, string heltCardNumber, MerrageStatus merriageStatus, Anamneza anamneza)
        {
           this.receptionDepartment = receptionDepartment;
           this.firstName = firstName;
           this.lastName = lastName;
           this.parentName = parentName;
           this.dateOfBirth = dateOfBirth;
           this.gender = gender;
           this.phone = phone;
           this.healthCardNumber = heltCardNumber;
           this.merriageStatus = merriageStatus;
            this.anamneza = anamneza;
            recipes = new List<Recipe>();
        }

        public override string Validate(string columName)
        {
            return "";
        }

        public override void InitExportList()
        {
        }

        public string ReceptionDepartment 
        {
            get { return receptionDepartment; }
            set
            {
                receptionDepartment = value;
                OnPropertyChanged(nameof(ReceptionDepartment));
            }
        }
        public string FirstName
        {
            get { return firstName; }
            set
            {
                firstName = value;
                OnPropertyChanged(nameof(FirstName));
            }
        }

        public string LastName
        {
            get { return lastName; }
            set
            {
                lastName = value;
                OnPropertyChanged(nameof(LastName));
            }
        }
        public string ParentName
        {
            get { return parentName; }
            set
            {
                parentName = value;
                OnPropertyChanged(nameof(ParentName));
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

        public Gender Gender
        {
            get { return gender; }
            set
            {
                gender = value;
                OnPropertyChanged(nameof(Gender));
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

        public string HealthCardNumber
        {
            get { return healthCardNumber; }
            set
            {
                healthCardNumber = value;
                OnPropertyChanged(nameof(HealthCardNumber));
            }
        }

        public MerrageStatus MerrageStatus
        {
            get { return merriageStatus; }
            set
            {
                merriageStatus = value;
                OnPropertyChanged(nameof(MerrageStatus));
            }
        }

        public Patient Patient
        {
            get { return patient; }
            set
            {
                patient = value;
                OnPropertyChanged(nameof(Patient));
            }
        }

        public Anamneza Anamneza
        {
            get { return anamneza; }
            set
            {
                anamneza = value;
                OnPropertyChanged(nameof(Anamneza));
            }
        }

        public ResidentalAddress ResidentalAddress
        {
            get { return residentalAddress; }
            set
            {
                residentalAddress = value;
                OnPropertyChanged(nameof(ResidentalAddress));
            }
        }


    }
}
