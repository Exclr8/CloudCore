using System;
using System.Web;
using System.Web.SessionState;
using CloudCore.Core;
using CloudCore.Domain;
using CloudCore.Data;
using System.Linq;

namespace CloudCore.Web.Core.Security.Authentication
{
    public class SessionInfo
    {
        private const string CcActivetab = "cc_tabidx";
        private const string CcStdqueryidx = "cc_sqidx";
        private const string CcWlisttype = "cc_wltype";
        private const string CcUserhasnotifications = "cc_uhnotif";
        private const string CcNotificationlastupdate = "cc_notiflu";
        private const string CcTaskListActiveTab = "cc_tasklistacctivetab";
        
        public static HttpSessionState Session { get { return HttpContext.Current.Session; } }

        public static int ActiveTab
        {
            set { SetItemValue(CcActivetab, value); }
            get { return GetItemValue(CcActivetab); }
        }

        public static int StandardQueryIndex
        {
            set { SetItemValue(CcStdqueryidx, value); }
            get { return GetItemValue(CcStdqueryidx, 1); }
        }

        public static int WorklistTypeIndex
        {
            set { SetItemValue(CcWlisttype, value); }
            get { return GetItemValue(CcWlisttype); }
        }

        public static bool HasNotifications
        {
            set
            {
                SetItemValue(CcUserhasnotifications, value ? 1 : 0);
                LastNotifyUpdate = DateTime.Now;
            }
            get
            {
                var userId = CloudCoreIdentity.UserId;
                var lastUpdate = LastNotifyUpdate;
                if (lastUpdate <= DateTime.Now.AddMinutes(-5))
                {
                    var hasCount = CloudCoreDB.Context.Cloudcore_VwUserNotification.Where(un => un.UserId == userId && un.HasRead == false).Any();
                    SetItemValue(CcUserhasnotifications, hasCount ? 1 : 0);
                    return hasCount;
                }
               
                return GetItemValue(CcUserhasnotifications) == 1;
            }
        }

        public static DateTime LastNotifyUpdate
        {
            set { SetItemValue(CcNotificationlastupdate, value); }
            get { return GetItemValue(CcNotificationlastupdate, DateTime.Now.AddDays(-1)); }
        }

        public static string TaskListActiveTab
        {
            get { return GetItemValue(CcTaskListActiveTab, "standard_0"); }
            set { SetItemValue(CcTaskListActiveTab, value); }
        }

        private static int GetItemValue(string keyName, int defaultValue = 0)
        {
            var aValue = (int?)Session[keyName];
            if (!aValue.HasValue)
            {
                aValue = defaultValue;
                Session.Add(keyName, aValue.Value);
            }
            return aValue.Value;
        }

        private static void SetItemValue(string keyName, int value)
        {
            Session[keyName] = value;
        }

        private static DateTime GetItemValue(string keyName, DateTime defaultValue)
        {
            var aValue = (DateTime?)Session[keyName];
            if (!aValue.HasValue)
            {
                aValue = defaultValue;
                Session.Add(keyName, aValue.Value);
            }
            return aValue.Value;
        }

        private static void SetItemValue(string keyName, DateTime value)
        {
            Session[keyName] = value;
        }

        private static string GetItemValue(string key, string defaultValue)
        {
            var value = (string)Session[key];
            if (value == null)
            {
                value = defaultValue;
                Session.Add(key, value);
            }
            return value;
        }

        private static void SetItemValue(string key, string value)
        {
            Session[key] = value;
        } 
    }
}
