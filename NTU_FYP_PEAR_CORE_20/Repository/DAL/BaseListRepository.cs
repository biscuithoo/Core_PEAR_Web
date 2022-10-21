using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using NTU_FYP_PEAR_CORE_20.Data;
using NTU_FYP_PEAR_CORE_20.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace NTU_FYP_PEAR_CORE_20.Repository
{
    public class BaseListRepository<TEntity> : BaseRepository<TEntity>, IBaseListRepository<TEntity> where TEntity : BaseList
    {
        public BaseListRepository(ApplicationDbContext context) : base(context) { }
        public List<TEntity> GetNotDeleted()
        {
            return GetAll().Where(i => i.isDeleted != true).OrderBy(o => o.value).ToList();
        }
        public TEntity GetOneNotDeleted(int id)
        {
            TEntity entity = GetById(id);
            if (entity.isDeleted == true) return null;
            else return entity;
        }
        public bool CheckExist(string value)
        {
            return GetAll().Where(x => x.value == value && x.isDeleted == false).Any();
        }

        // Create(new List_xxx(), "");
        public TEntity Create(TEntity entity, string value)
        {
            entity.value = value;
            return entity;
        }
    }
}
