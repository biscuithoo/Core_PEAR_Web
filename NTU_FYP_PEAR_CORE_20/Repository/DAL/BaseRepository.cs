using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using NTU_FYP_PEAR_CORE_20.Data;
using System.Linq;
using System.Threading.Tasks;

namespace NTU_FYP_PEAR_CORE_20.Repository
{
    public class BaseRepository<TEntity> : Repository<TEntity>, IBaseRepository<TEntity> where TEntity : Models.Base
    {
        public BaseRepository(ApplicationDbContext context) : base(context) { }

        public void MarkDelete(int id)
        {
            GetById(id).isDeleted = true;
        }
    }
}
