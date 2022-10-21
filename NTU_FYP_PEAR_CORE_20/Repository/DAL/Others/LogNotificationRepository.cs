using NTU_FYP_PEAR_CORE_20.Data;
using NTU_FYP_PEAR_CORE_20.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NTU_FYP_PEAR_CORE_20.Repository
{
    public class LogNotificationRepository : Repository<LogNotification>
    {
        public LogNotificationRepository(ApplicationDbContext context) : base(context) { }

        public LogNotification Create(int logID, string intendedUserType, string intendedUserID, string step, bool readStatus, string message)
        {
            LogNotification entity = new LogNotification();
            entity.logID = logID;
            entity.intendedUserType = intendedUserType;
            entity.intendedUserID = intendedUserID;
            entity.step = step;
            entity.readStatus = readStatus;
            entity.message = message;
            return entity;
        }
        public LogNotification CreateAdd(int logID, string intendedUserType, string intendedUserID, string step, bool readStatus, string message)
        {
            LogNotification entity = Create(logID, intendedUserType, intendedUserID, step, readStatus, message);
            Add(entity);
            return entity;
        }
        public List<LogNotification> FindAllByLog(int logID)
        {
            return DbSet.Where(x => x.logID == logID).ToList();
        }
        public LogNotification FindByLog(int logID)
        {
            LogNotification notification = FindAllByLog(logID).LastOrDefault();
            return notification;
        }
        public List<LogNotification> FindByUser(string userID)
        {
            return GetAll().Where(x => x.intendedUserID == userID).ToList();
        }
        public List<LogNotification> GetRead(string userID)
        {
            return FindByUser(userID).Where(x => x.readStatus == true).ToList();
        }
        public List<LogNotification> GetUnread(string userID)
        {
            return FindByUser(userID).Where(x => x.readStatus == false).ToList();
        }
        public string GetUnreadCount(string userID)
        {
            var oneWeekAgo = DateTime.Now.Date.AddDays(-7);
            List<LogNotification> unreadNotifications = GetUnread(userID).Where(x => x.createdDateTime > oneWeekAgo).ToList();
            return unreadNotifications.Count().ToString();
        }
        public LogNotification UpdateNotification(int logNotificationID, bool readStatus)
        {
            LogNotification entity = GetById(logNotificationID);
            entity.readStatus = readStatus;
            entity.updatedDateTime = DateTime.Now;
            Update(entity);
            SaveChanges();
            return entity;
        }
    }
}
