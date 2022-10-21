using NTU_FYP_PEAR_CORE_20.Data;
using NTU_FYP_PEAR_CORE_20.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NTU_FYP_PEAR_CORE_20.Repository
{
    public interface IBaseRepository<TEntity> : IRepository<TEntity> where TEntity : Models.Base
    {
        void MarkDelete(int id);
    }
}
