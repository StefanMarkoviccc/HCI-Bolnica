using HCIBolnica.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCIBolnica.Repository
{
    class PatientRepository : Repository<Patient>
    {
        public override IEnumerable<Entity> Search(string term = "")
        {
            List<Entity> result = new List<Entity>();

            foreach (Entity entity in HCIContext.Instance.Patients)
            {
                if (((Patient)entity).FirstName.Contains(term) || (((Patient)entity).LastName.Contains(term)))
                {
                    result.Add(entity);
                }
            }
            return result;
        }
        public IEnumerable<Entity> SearchDinamic(string term = "")
        {
            List<Entity> result = new List<Entity>();
            foreach (Entity entity in HCIContext.Instance.Appointments)
            {
                if (((Appointment)entity).ID.Contains(term) || ((Appointment)entity).Patient.FirstName.Contains(term) || ((Appointment)entity).Patient.LastName.Contains(term))
                {
                    result.Add(entity);
                }
            }
            return result;
        }
    }

}
