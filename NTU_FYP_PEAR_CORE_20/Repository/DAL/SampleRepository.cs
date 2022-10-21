using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NTU_FYP_PEAR_CORE_20.Repository
{
    /*
     * Sample Repository contains methods that you should Have and Implement everytime 
     * you Create a new Repository for the model
     * Create(), CreateAdd()
     * Other methods you can implement:
     * - Update() quite similar to Create(), CreateAdd().
     * 
     * Add new methods specific to this repository here
     * Reference: https://chathuranga94.medium.com/generic-repository-pattern-for-asp-net-core-9e3e230e20cb
     */
    public class SampleRepository // : Repository<Model>
    {

        /* Create Model Object without adding into database
         * id will be 0
         * Mainly for adding to log (newLogData) which requires approval first before adding into db
         */
        //public Model Create(// model variables)
        //{
        //    Model entity = new Model();
        //    entity.id = xxxx;
        //    entity.stringValue = stringValue == null ? entity.stringValue : stringValue;
        //    return entity;
        //}

        /*
         * Create the Model and Add to it to the context
         * Can be used for items that do no require any approval
         */
        //public Model CreateAdd(// models variables)
        //{
        //    Model entity = Create(// models variables);
        //    Add(entity);
        //    return entity;
        //}
    }
}
