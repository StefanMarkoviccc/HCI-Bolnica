using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCIBolnica.Model
{
    public class Person : Entity
    {
        private User user;
        private string firstName;
        private string lastName;
        private string jmbg;
        private string email;
        private string fullName;
        private ResidentalAddress residentialAddress;

        public Person(string firstName, string lastName, string jmbg, string email, ResidentalAddress residentialAddress)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.jmbg = jmbg;
            this.email = email;
            this.residentialAddress = residentialAddress;
        }
        public Person()
        {

        }
        public Person(string firstName, string lastName, string jmbg, string email, ResidentalAddress residentialAddress, User user)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.jmbg = jmbg;
            this.email = email;
            this.residentialAddress = residentialAddress;
            this.user = user;
        }
        public Person(string firstName, string lastName)
        {
            this.firstName = firstName;
            this.lastName = lastName;
        }

        public override string Validate(string columName)
        {
            return "";
        }

        public override void InitExportList()
        {
            
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

        public string JMBG
        {
            get { return jmbg; }
            set
            {
                jmbg = value;
                OnPropertyChanged(nameof(JMBG));
            }
        }

        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                OnPropertyChanged(nameof(Email));
            }
        }

        public ResidentalAddress ResidentialAddress
        {
            get { return residentialAddress; }
            set
            {
                residentialAddress = value;
                OnPropertyChanged(nameof(ResidentialAddress));
            }
        }
        public User User
        {
            get { return user; }
            set
            {
                user = value;
                OnPropertyChanged(nameof(User));
            }
        }
        public string FullName
        {
            get { return fullName; }
            set
            {
                fullName = value;
                OnPropertyChanged(nameof(FullName));
            }
        }

        

    }
}
