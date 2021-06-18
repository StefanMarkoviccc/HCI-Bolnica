using HCIBolnica.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCIBolnica.Repository
{
    public class PersonRepository : Repository<Person>
    {
        public override IEnumerable<Entity> Search(string term = "")
        {
            List<Entity> result = new List<Entity>();

            foreach (Entity entity in HCIContext.Instance.People)
            {
                if (((Person)entity).ID.Contains(term))
                {
                    result.Add(entity);
                }
            }
            return result;
        }
    }
}
