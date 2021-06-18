using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCIBolnica.Model
{
    public class PatientHistory : Entity
    {
        private Patient patient;
        private Anamneza anamneza;

        public PatientHistory()
        {

        }

        public PatientHistory(Patient patient,Anamneza anamneza)
        {
            this.patient = patient;
            this.anamneza = anamneza;
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
