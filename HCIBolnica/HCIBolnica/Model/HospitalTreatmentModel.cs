using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCIBolnica.Model
{
    public class HospitalTreatmentModel : Entity
    {
        private Patient patient;
        private string healthCardNumber;
        private string diagnosis;

        public HospitalTreatmentModel()
        {

        }

        public HospitalTreatmentModel(Patient patient, string healthCardNumber, string diagnosis)
        {
            this.patient = patient;
            this.healthCardNumber = healthCardNumber;
            this.diagnosis = diagnosis;
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

        public string HealthCardNumber
        {
            get { return healthCardNumber; }
            set
            {
                healthCardNumber = value;
                OnPropertyChanged(nameof(HealthCardNumber));
            }
        }

        public string Diagosis
        {
            get { return diagnosis; }
            set
            {
                diagnosis = value;
                OnPropertyChanged(nameof(Diagosis));
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
