using System.Collections.Generic;

namespace DAL
{
    public interface IDataRepository
    {
        void Add(params Variable[] items);
        void Delete(int id);
        void FixEfProviderServicesProblem();
        IEnumerable<Variable> GetAll();
        void Update(int id, Variable variable);
    }
}