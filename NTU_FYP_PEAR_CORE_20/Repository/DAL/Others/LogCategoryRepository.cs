using NTU_FYP_PEAR_CORE_20.Data;
using NTU_FYP_PEAR_CORE_20.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NTU_FYP_PEAR_CORE_20.Repository.Others
{
    public class LogCategoryRepository : Repository<LogCategory>
    {
        public LogCategoryRepository(ApplicationDbContext context) : base(context) { }

        public int GetLogCatByName(string logCat)
        {
            return GetAll().Where(x => x.logCategoryName == logCat).FirstOrDefault().logCategoryID;
        }
    }
}
