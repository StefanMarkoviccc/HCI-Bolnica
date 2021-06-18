using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCIBolnica.Model
{
    public class Complain : Entity
    {
        private string complaniId;
        private string complainText;
        private string medicationId;

        public Complain() { }

        public Complain(String complaniId, String medicationId, String complainText)
        {
            this.complaniId = complaniId;
            this.complainText = complainText;
            this.medicationId = medicationId;
        }

        public Complain(String medicationId, String complainText)
        {
            this.complainText = complainText;
            this.medicationId = medicationId;
        }

        public override string Validate(string columName)
        {
            return "";
        }

        public override void InitExportList()
        {
        }

        public string ComplaniId
        {
            get { return complaniId; }
            set
            {
                complaniId = value;
                OnPropertyChanged(nameof(ComplaniId));
            }
        }

        public string ComplainText
        {
            get { return complainText; }
            set
            {
                complainText = value;
                OnPropertyChanged(nameof(ComplainText));
            }
        }

        public string MedicationId
        {
            get { return medicationId; }
            set
            {
                medicationId = value;
                OnPropertyChanged(nameof(MedicationId));
            }
        }
    }
}
