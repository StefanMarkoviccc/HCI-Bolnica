using HCIBolnica.Core;
using HCIBolnica.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HCIBolnica.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        public void Add(Entity entity)
        {
            HCIContext.Instance.Get(typeof(TEntity)).Add(entity);
        }

        public Entity Get(string id)
        {
            return HCIContext.Instance.Get(typeof(TEntity)).Where(x => x.ID == id).FirstOrDefault();
        }

        public IEnumerable<Entity> GetAll()
        {
            return HCIContext.Instance.Get(typeof(TEntity));
        }

        public void Remove(Entity entity)
        {
            Entity entityToRemove = Get(entity.ID);
            HCIContext.Instance.Get(typeof(TEntity)).Remove(entityToRemove);
        }

        public void Save()
        {
            HCIContext.Instance.Save();
        }

        public virtual IEnumerable<Entity> Search(string term = "")
        {
            throw new NotImplementedException();
        }
    }
   
}
