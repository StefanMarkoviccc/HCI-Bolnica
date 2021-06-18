using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCIBolnica.Model
{
    public class Recipe : Entity
    {
        private Medicine medicine;
        private string quantityOfTherapy;
        private DateTime beginningOfTherapy;
        private DateTime endOfTherapy;
        private double takingMedicineInHours;
        private string patientId;
        private string medicineStrength;



        public Recipe()
        {

        }

        public Recipe(String quantityOfTherapy, DateTime beginningOfTherapy, DateTime endOfTherapy, double takingMedicineInHours, Medicine medicine, string patientId, string medicineStrength)
        {
            this.quantityOfTherapy = quantityOfTherapy;
            this.beginningOfTherapy = beginningOfTherapy;
            this.endOfTherapy = endOfTherapy;
            this.takingMedicineInHours = takingMedicineInHours;
            this.medicine = medicine;
            this.patientId = patientId;
            this.medicineStrength = medicineStrength;
        }

        public override void InitExportList()
        {
            
        }

        public override string Validate(string columName)
        {
            return "";
        }
        public Medicine Medicine
        {
            get { return medicine; }
            set
            {
                medicine = value;
                OnPropertyChanged(nameof(Medicine));
            }
        }

        public string QuantityOfTherapy
        {
            get { return quantityOfTherapy; }
            set
            {
                quantityOfTherapy = value;
                OnPropertyChanged(nameof(QuantityOfTherapy));
            }
        }

        public DateTime BeginningOfTherapy
        {
            get { return beginningOfTherapy; }
            set
            {
                beginningOfTherapy = value;
                OnPropertyChanged(nameof(BeginningOfTherapy));
            }
        }
        public DateTime EndOfTherapy
        {
            get { return endOfTherapy; }
            set
            {
                endOfTherapy = value;
                OnPropertyChanged(nameof(EndOfTherapy));
            }
        }
        public double TakingMedicineInHours
        {
            get { return takingMedicineInHours; }
            set
            {
                takingMedicineInHours = value;
                OnPropertyChanged(nameof(TakingMedicineInHours));
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

        public string MedicineStrength
        {
            get { return medicineStrength; }
            set
            {
                medicineStrength = value;
                OnPropertyChanged(nameof(MedicineStrength));
            }
        }
    }
}
