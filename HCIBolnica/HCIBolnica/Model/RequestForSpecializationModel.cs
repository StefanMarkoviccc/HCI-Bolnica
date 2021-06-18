using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCIBolnica.Model
{
    public class RequestForSpecializationModel : Entity
    {
        private Specialization specialization;
        private Doctor doctor;

        public RequestForSpecializationModel()
        {

        }

        public RequestForSpecializationModel(Specialization specialization, Doctor doctor)
        {
            this.specialization = specialization;
            this.doctor = doctor;
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

        public Doctor Doctor
        {
            get { return doctor; }
            set
            {
                doctor = value;
                OnPropertyChanged(nameof(Doctor));
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
