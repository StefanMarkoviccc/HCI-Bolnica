using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCIBolnica.Model
{
    public class ResidentalAddress : Entity
    {
        private string street;
        private string houseNumber;
        public ResidentalAddress(string street, string houseNumber)
        {
            this.street = street;
            this.houseNumber = houseNumber;
        }
        public ResidentalAddress() { }

        public override string Validate(string columName)
        {
            return "";
        }

        public override void InitExportList()
        {
        }

        public string Street
        {
            get { return street; }
            set
            {
                street = value;
                OnPropertyChanged(nameof(Street));
            }
        }

        public string HouseNumber
        {
            get { return houseNumber; }
            set
            {
                houseNumber = value;
                OnPropertyChanged(nameof(HouseNumber));
            }
        }
    }
}
