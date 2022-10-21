using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NTU_FYP_PEAR_CORE_20.Models
/*
 * For Models with these fixed variables
 * Reference: https://docs.microsoft.com/en-us/aspnet/mvc/overview/getting-started/getting-started-with-ef-using-mvc/implementing-inheritance-with-the-entity-framework-in-an-asp-net-mvc-application
 */
{
    interface IBase
    {
        public bool isDeleted { get; set; }
        public DateTime createdDateTime { get; set; }
        public DateTime updatedDateTime { get; set; }
    }
}
