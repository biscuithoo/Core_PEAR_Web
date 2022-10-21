using NTU_FYP_PEAR_CORE_20.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NTU_FYP_PEAR_CORE_20.Repository
{
    public interface IBaseListRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseList
    {
        List<TEntity> GetNotDeleted();
        TEntity GetOneNotDeleted(int id);
        bool CheckExist(string value);
        TEntity Create(TEntity entity, string value);
    }
}
