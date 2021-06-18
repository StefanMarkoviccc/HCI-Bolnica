using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCIBolnica.Model
{
    public class Doctor : Person
    {
        public System.Collections.ArrayList appointment;
        public System.Collections.ArrayList requestToTheManager;
        private string employeeId;
        private bool busy;
        private Specialization specialization;
        public Doctor()
        {
        }
        public Doctor(string employeeId)
        {
            this.employeeId = employeeId;
        }

        public Doctor(string employeeId, bool busy, Specialization specialization)

        {
            this.employeeId = employeeId;
            this.busy = busy;
            this.specialization = specialization;
        }

        public Doctor(string employeeId, bool busy, Specialization specialization, string firstName, string lastName, string jmbg, string email, ResidentalAddress residentalAddress) : base(firstName, lastName, jmbg, email, residentalAddress)
        {
            this.employeeId = employeeId;
            this.busy = busy;
            this.specialization = specialization;
            FullName = firstName + " " + lastName;
        }
        public Doctor(String employeeId, bool busy, Specialization specialization, string firstName, string fullName, string lastName, string jmbg, string email, ResidentalAddress residentalAddress, User user) : base(firstName, lastName, jmbg, email, residentalAddress, user)
        {
            this.employeeId = employeeId;
            this.busy = busy;
            this.specialization = specialization;
            fullName = firstName + " " + lastName;
        }

        public Doctor(String ime, String prezime) : base(ime, prezime)
        {
            FullName = FirstName + " " + LastName;
        }

        public string EmployeeId
        {
            get { return employeeId; }
            set
            {
                employeeId = value;
                OnPropertyChanged(nameof(EmployeeId));
            }
        }

        public Specialization Specialization
        {
            get { return specialization; }
            set
            {
                specialization = value;
                OnPropertyChanged(nameof(Specialization));
            }
        }

        public override string ToString()
        {
            return FirstName + " " + LastName;
        }
    }
}
