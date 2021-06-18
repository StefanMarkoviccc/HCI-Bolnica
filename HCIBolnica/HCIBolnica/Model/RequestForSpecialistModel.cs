using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCIBolnica.Model
{
    public class RequestForSpecialistModel : Entity
    {
        private Specialization specialization;
        private string healthCardNumber;
        private string jmbg;
        private string reasonForSpecialist;

        public RequestForSpecialistModel()
        {

        }

        public RequestForSpecialistModel(Specialization specialization, string healthCardNumber, string jmbg, string reasonForSpecialist)
        {
            this.specialization = specialization;
            this.healthCardNumber = healthCardNumber;
            this.jmbg = jmbg;
            this.reasonForSpecialist = reasonForSpecialist;
        }

        public Specialization Specialization
        {
            get { return specialization; }
            set 
            {
                specialization = value;
                OnPropertyChanged(nameof(Doctor));
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

        public string JMBG
        {
            get { return jmbg; }
            set
            {
                jmbg = value;
                OnPropertyChanged(nameof(JMBG));
            }
        }

        public string ReasonForSpecialist
        {
            get { return reasonForSpecialist; }
            set
            {
                reasonForSpecialist = value;
                OnPropertyChanged(nameof(ReasonForSpecialist));
            }
        }

        public override void InitExportList()
        {
            throw new NotImplementedException();
        }

        public override string Validate(string columName)
        {
            return "";
        }
    }

}
