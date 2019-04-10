using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataRepository : IDataRepository
    {
        public void FixEfProviderServicesProblem()
        {
            //The Entity Framework provider type 'System.Data.Entity.SqlServer.SqlProviderServices, EntityFramework.SqlServer'
            //for the 'System.Data.SqlClient' ADO.NET provider could not be loaded. 
            //Make sure the provider assembly is available to the running application. 
            //See http://go.microsoft.com/fwlink/?LinkId=260882 for more information.

            var instance = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }
        public IEnumerable<Variable> GetAll()
        {
            var context = new MyDbContext();
            var aaa = context.Variables;
            return aaa;
            //var query = context.Set<Variable>();
            //return query;
        }
        public void Update(int id, Variable variable)
        {
            using (var context = new MyDbContext())
            {
                var entity = context.Set<Variable>().Find(id);
                if (entity == null)
                {
                    return;
                }

                context.Entry(entity).CurrentValues.SetValues(variable);
                context.SaveChanges();
            }  
        }

        public void Delete(int id)
        {
            using (var context = new MyDbContext())
            {
                var entity = context.Set<Variable>().Find(id);
                if (entity == null)
                {
                    return;
                }

                context.Set<Variable>().Remove(entity);
                context.SaveChanges();
            }
        }
        public virtual void Add(params Variable[] items)
        {
            using (var context = new MyDbContext())
            {
                foreach (var item in items)
                {
                    context.Set<Variable>().Add(item);
                    context.SaveChanges();
                }
            }
        }
    }
    public interface IDataRepositoryFuture<T> where T : class
    {
        void Add(params T[] items);
        IEnumerable<T> GetAll();
        IQueryable<T> GetAllNonMaterialized();
        T GetById();
        void Delete(int id);
        void Delete(params T[] items);
        //void Delete(Expression<Func<T, bool>> predicate);
        void Update(params T[] items);
        void Update(string id, params T[] items);
        void Update(object[] id, params T[] items);

    }
}
