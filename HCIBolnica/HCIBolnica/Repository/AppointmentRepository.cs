using HCIBolnica.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCIBolnica.Repository
{
    public class AppointmentRepository : Repository<Appointment>
    {
        public override IEnumerable<Entity> Search(string term = "")
        {
            List<Entity> result = new List<Entity>();

            foreach (Entity entity in HCIContext.Instance.Appointments)
            {
                if (((Appointment)entity).ID.Contains(term))
                {
                    result.Add(entity);
                }
            }
            return result;
        }
    public List<Appointment> SearchAppointment(DateTime dateOfAppointment)
    {
        List<Appointment> result = new List<Appointment>();

        foreach (Entity entity in HCIContext.Instance.Appointments)
        {
            Appointment appointment = entity as Appointment;

            DateTime date = appointment.DateOfAppointment;

            if (date == dateOfAppointment)
            {
                result.Add(appointment);
            }

        }

        return result;
    }
    }
}
