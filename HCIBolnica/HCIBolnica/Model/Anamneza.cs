using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCIBolnica.Model
{
    public class Anamneza : Entity
    {
        public string simptoms;
        public string doctorReport;
        private string anamnezaID;
        private Patient patient;
        private DateTime dateOfPreviousAppointment;


        public Anamneza()
        {
            simptoms = "";
            doctorReport = "";
        }
        public Anamneza(string simptomi, string izvestajLekara)
        {
            simptoms = simptoms == null ? "" : simptoms;
            doctorReport = doctorReport == null ? "" : doctorReport;
        }

        public override string Validate(string columName)
        {
            return "";
        }

        public override void InitExportList()
        {
        }

        public string Simptoms
        {
            get { return simptoms; }
            set
            {
                simptoms = value;
                OnPropertyChanged(nameof(Simptoms));
            }
        }

        public string DoctorReport
        {
            get { return doctorReport; }
            set {
                doctorReport = value;
                OnPropertyChanged(nameof(DoctorReport));
            }
        }

        public string AnamnezaID
        {
            get { return anamnezaID; }
            set
            {
                anamnezaID = value;
                OnPropertyChanged(nameof(AnamnezaID));
            }
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

        public DateTime DateOfPreviousAppointment
        {
            get { return dateOfPreviousAppointment; }
            set { dateOfPreviousAppointment = value;
                OnPropertyChanged(nameof(DateOfPreviousAppointment));
            }
        }
    }
}
