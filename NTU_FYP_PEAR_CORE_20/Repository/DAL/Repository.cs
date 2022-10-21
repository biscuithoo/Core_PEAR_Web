using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using NTU_FYP_PEAR_CORE_20.Data;
using System.Linq;

namespace NTU_FYP_PEAR_CORE_20.Repository
{
    /* 
     * Methods to access ApplicationDbContext.DbSet (_context.Models)
     */
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly ApplicationDbContext _context;
        protected readonly DbSet<TEntity> DbSet;
        public Repository(ApplicationDbContext db)
        {
            _context = db;
            DbSet = db.Set<TEntity>();
        }

        // Add Entity to DbSet (_context.Models.Add()), start tracking
        public void Add(TEntity entity)
        {
            DbSet.Add(entity);
        }

        // Reference to the DbSet (_context.Models), can do .Where .All etc.
        public IQueryable<TEntity> GetAll()
        {
            return DbSet;
        }

        // Reference to single item in DbSet, can do .Where .All etc.
        public TEntity GetById(int id)
        {
            return DbSet.Find(id);
        }

        // Save to Database
        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        // Update Entity in DbSet
        public void Update(TEntity entity)
        {
            DbSet.Update(entity);
        }
        public string Serialise(TEntity entity)
        {
            return JsonConvert.SerializeObject(entity, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                //PreserveReferencesHandling = PreserveReferencesHandling.Objects
            });
        }
        public TEntity Deserialise(string entity)
        {
            return JsonConvert.DeserializeObject<TEntity>(entity);
        }
    }
}
