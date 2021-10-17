using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Persistance
{
    public interface IRepository<T> where T : class
    {
        public IEnumerable<T> Get();
        public Task<T> Get(int id);
        public Task Insert(T entity);

        public int GetCount();

        public Task Delete(int id);

        public void Update(T entity);
    }
}
