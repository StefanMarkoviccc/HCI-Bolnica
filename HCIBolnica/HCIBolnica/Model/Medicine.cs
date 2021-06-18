using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCIBolnica.Model
{
    public class Medicine : Entity
    {
        private string medicineId;
        private string medicineName;
        private string quantityOfMedicine;
        private string drugIngredients;
        private string medicineStrength;
        private string periodOfTakingTheDrug;
        private DateTime startOfTherapy;
        private DateTime endOfTherapy;

        public Medicine() { }

        public Medicine(String medicineId, String medicineName)
        {
            this.medicineId = medicineId;
            this.medicineName = medicineName;
        }


        public Medicine(string medicineId, string medicineName, string quantityOfMedicine, string drugIngredients, string medicineStrength, string periodOfTakingTheDrug, DateTime startOfTherapy, DateTime endOfTherapy)
        {
            this.medicineId = medicineId;
            this.medicineName = medicineName;
            this.quantityOfMedicine = quantityOfMedicine;
            this.drugIngredients = drugIngredients;
            this.medicineStrength = medicineStrength;
            this.periodOfTakingTheDrug = periodOfTakingTheDrug;
            this.startOfTherapy = startOfTherapy;
            this.endOfTherapy = endOfTherapy;
        }

        public Medicine(string medicineId, string medicineName, string quantityOfMedicine, string medicineStrength, string periodOfTakingTheDrug, DateTime startOfTherapy, DateTime endOfTherapy)
        {
            this.medicineId = medicineId;
            this.medicineName = medicineName;
            this.quantityOfMedicine = quantityOfMedicine;
            this.medicineStrength = medicineStrength;
            this.periodOfTakingTheDrug = periodOfTakingTheDrug;
            this.startOfTherapy = startOfTherapy;
            this.endOfTherapy = endOfTherapy;
        }

        public override string Validate(string columName)
        {
            return "";
        }

        public override void InitExportList()
        {
        }

        public DateTime StartOfTherapy
        {
            get { return startOfTherapy; }
            set
            {
                startOfTherapy = value;
                OnPropertyChanged(nameof(StartOfTherapy));
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

        public string PeriodOfTakingTheDrug
        {
            get { return periodOfTakingTheDrug; }
            set
            {
                periodOfTakingTheDrug = value;
                OnPropertyChanged(nameof(PeriodOfTakingTheDrug));
            }
        }

        public string MedicineId
        {
            get { return medicineId; }
            set
            {
                medicineId = value;
                OnPropertyChanged(nameof(MedicineId));
            }
        }

        public string MedicineName
        {
            get { return medicineName; }
            set
            {
                medicineName = value;
                OnPropertyChanged(nameof(MedicineName));
            }
        }

        public string QuantityOfMedicine
        {
            get { return quantityOfMedicine; }
            set
            {
                quantityOfMedicine = value;
                OnPropertyChanged(nameof(QuantityOfMedicine));
            }
        }

        public string DrugIngredients
        {
            get { return drugIngredients; }
            set
            {
                drugIngredients = value;
                OnPropertyChanged(nameof(DrugIngredients));
            }
        }

        public string MedicineStregnth
        {
            get { return medicineStrength; }
            set
            {
                medicineStrength = value;
                OnPropertyChanged(nameof(MedicineStregnth));
            }
        }

        public override string ToString()
        {
            return medicineName;
        }
    }
}
