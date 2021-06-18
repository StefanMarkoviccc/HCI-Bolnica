using HCIBolnica.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCIBolnica.Repository
{
    public class RequestForSpecializationRepository : Repository<RequestForSpecializationModel>
    {
        public override IEnumerable<Entity> Search(string term = "")
        {
            List<Entity> result = new List<Entity>();

            foreach (Entity entity in HCIContext.Instance.SpentInventorys)
            {
                if (((SpentInventory)entity).ID.Contains(term))
                {
                    result.Add(entity);
                }
            }
            return result;
        }
    }
}
