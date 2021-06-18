using HCIBolnica.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCIBolnica.Repository
{
    public class AnamnezaRepository : Repository<Anamneza>
    {
        private Patient patient;
        private Anamneza anamneza;

        public List<Anamneza> SearchByDate(DateTime start, DateTime end) 
        {
            List<Anamneza> result = new List<Anamneza>();

            foreach (Anamneza entity in HCIContext.Instance.Anamnezas)
            {
                if (entity.DateOfPreviousAppointment >= start && entity.DateOfPreviousAppointment <= end)
                {
                    result.Add(entity);
                }
            }
            return result;
        }

        public override IEnumerable<Entity> Search(string term = "")
        {
            List<Entity> result = new List<Entity>();

            foreach (Entity entity in HCIContext.Instance.Anamnezas)
            {
                if (((Anamneza)entity).ID.Contains(term))
                {
                    result.Add(entity);
                }
            }
            return result;
        }

        public List<Anamneza> FindPatientHistory(Patient patient)
        {
            List<Anamneza> result = new List<Anamneza>();

            foreach (Anamneza anamneza in HCIContext.Instance.Anamnezas)
            {
               if (patient.ID == anamneza.Patient.ID)
               {
                    result.Add(anamneza);
               }
            }

            return result;
        }
    }
}
