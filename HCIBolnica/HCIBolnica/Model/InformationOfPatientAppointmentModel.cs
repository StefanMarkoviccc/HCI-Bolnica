using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCIBolnica.Model
{
    public class InformationOfPatientAppointmentModel : Entity
    {
        private string anamneza;
        private string diagnosis;
        private string therapy;
        private string control;

        public string Anamneza
        {
            get { return anamneza; }
            set
            {
                anamneza = value;
                OnPropertyChanged(nameof(Anamneza));
            }
        }
        public string Diagnosis
        {
            get { return diagnosis; }
            set
            {
                diagnosis = value;
                OnPropertyChanged(nameof(Diagnosis));
            }
        }
        public string Therapy
        {
            get { return therapy; }
            set
            {
                therapy = value;
                OnPropertyChanged(nameof(Therapy));
            }
        }
        public string Control
        {
            get { return control; }
            set
            {
                control = value;
                OnPropertyChanged(nameof(Control));
            }
        }

        public override void InitExportList()
        {
           
        }

        public override string Validate(string columName)
        {
            return "";
        }
    }
}
