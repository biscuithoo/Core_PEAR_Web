using System.Linq;

namespace NTU_FYP_PEAR_CORE_20.Repository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> GetAll();
        TEntity GetById(int id);
        void Add(TEntity entity);
        void Update(TEntity entity);
        int SaveChanges();
        string Serialise(TEntity entity);
        TEntity Deserialise(string entity);
    }
}
