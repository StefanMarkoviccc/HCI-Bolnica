using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCIBolnica.Model
{
    public class RequestForMedicinesSupplyModel : Entity
    {
        private Doctor doctor;
        private Medicine medicine;
        private string reason;

        public RequestForMedicinesSupplyModel()
        {

        }

        public RequestForMedicinesSupplyModel(Doctor doctor,Medicine medicine, string reason)
        {
            this.doctor = doctor;
            this.medicine = medicine;
            this.reason = reason;
        }

        public Doctor Doctor
        {
            get { return doctor; }
            set
            {
                doctor = value;
                OnPropertyChanged(nameof(Doctor));
            }
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

        public string Reason
        {
            get { return reason; }
            set
            {
                reason = value;
                OnPropertyChanged(nameof(Reason));
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
