using NTU_FYP_PEAR_CORE_20.Data;
using NTU_FYP_PEAR_CORE_20.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NTU_FYP_PEAR_CORE_20.Repository
{
    public class NotificationHandlerRepository : Repository<NotificationHandler>
    {
        public NotificationHandlerRepository(ApplicationDbContext context) : base(context) { }

        public NotificationHandler Create(int scenario, int maxNoOfSteps, string step, string senderTypeID, string intendedUserType, string responseRequired, string responseOptions, string nextStep, string message)
        {
            NotificationHandler entity = new NotificationHandler();
            entity.scenario = scenario;
            entity.maxNoOfSteps = maxNoOfSteps;
            entity.step = step;
            entity.senderTypeID = senderTypeID;
            entity.intendedUserType = intendedUserType;
            entity.responseRequired = responseRequired;
            entity.responseOptions = responseOptions;
            entity.nextStep = nextStep;
            entity.message = message;
            return entity;
        }
        public NotificationHandler CreateAdd(int scenario, int maxNoOfSteps, string step, string senderTypeID, string intendedUserType, string responseRequired, string responseOptions, string nextStep, string message)
        {
            NotificationHandler entity = Create(scenario, maxNoOfSteps, step, senderTypeID, intendedUserType, responseRequired, responseOptions, nextStep, message);
            Add(entity);
            return entity;
        }
        public NotificationHandler FindByStep(int scenario, string step)
        {
            return DbSet.Where(x => x.scenario == scenario && x.step == step).SingleOrDefault();
        }
    }
}
