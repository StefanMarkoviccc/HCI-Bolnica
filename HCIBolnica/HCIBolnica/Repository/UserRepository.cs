using HCIBolnica.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCIBolnica.Repository
{
    public class UserRepository : Repository<User>
    {
        public override IEnumerable<Entity> Search(string term = "")
        {
            List<Entity> result = new List<Entity>();

            foreach (Entity entity in HCIContext.Instance.Users)
            {
                if (((User)entity).ID.Contains(term))
                {
                    result.Add(entity);
                }
            }
            return result;
        }
    }
}
