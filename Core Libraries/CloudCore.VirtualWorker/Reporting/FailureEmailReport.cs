using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using CloudCore.Configuration.ConfigFile;
using CloudCore.Core.Logging;
using CloudCore.Core.Utilities;
using CloudCore.Data;
using CloudCore.Logging;
using Frameworkone.ThirdParty.PostageApp;

namespace CloudCore.VirtualWorker.Reporting
{
    public class ScheduledTaskFailureEmailReport
    {
        private readonly PostageAppClient email;
        private readonly string failureMessage;

        public ScheduledTaskFailureEmailReport(int scheduledTaskId, string failureMessage)
        {
            this.failureMessage = failureMessage;
            email = new PostageAppClient()
            { TemplateName = "staskfailurenotify" };

            var dbContext = CloudCoreDB.Context;

            var result = from sch in dbContext.Cloudcore_ScheduledTask
                         join schg in dbContext.Cloudcore_ScheduledTaskGroup
                             on sch.ScheduledTaskGroupId equals schg.ScheduledTaskGroupId
                         join user in dbContext.Cloudcore_User
                             on schg.ManagerUserId equals user.UserId
                         where sch.ScheduledTaskId == scheduledTaskId
                         select new { GroupManagerEmail = user.Email, ScheduledTaskManagerEmail = sch.NotifyEmail, sch.ScheduledTaskName, user.Fullname };

            var userDetail = result.First();

            email.GlobalVariables.Add(new KeyValuePair<string, string>("user", userDetail.Fullname));
            email.GlobalVariables.Add(new KeyValuePair<string, string>("taskname", userDetail.ScheduledTaskName));
            email.GlobalVariables.Add(new KeyValuePair<string, string>("datetime", DateTime.Now.ToString("HH:mm:ss dd/MM/yyyy")));
            email.GlobalVariables.Add(new KeyValuePair<string, string>("message", failureMessage));

            if (Regex.IsMatch(userDetail.GroupManagerEmail, RegularExpressionPatterns.ValidEmailAddress))
            {
                if (email.Recipients.All(r => r.RecipientEmail != userDetail.GroupManagerEmail))
                    email.Recipients.Add(new EmailRecipient
                    {
                        RecipientEmail = userDetail.GroupManagerEmail,
                        MailVariables = new Dictionary<string, string> { { "user", userDetail.Fullname } }
                    });
            }
            else
                Logger.Warn("No User Manager is defined or the User has no Email address.", LogCategories.ScheduledTaskMonitor);

            if (Regex.IsMatch(string.IsNullOrEmpty(userDetail.ScheduledTaskManagerEmail) ? string.Empty : userDetail.ScheduledTaskManagerEmail,
                RegularExpressionPatterns.ValidEmailAddress))
            {
                if (email.Recipients.All(r => r.RecipientEmail != userDetail.ScheduledTaskManagerEmail))
                    email.Recipients.Add(new EmailRecipient
                    {
                        RecipientEmail = userDetail.ScheduledTaskManagerEmail,
                        MailVariables = new Dictionary<string, string> { { "user", userDetail.Fullname } }
                    });
            }
            else
                Logger.Warn("No Email address is defined for the scheduled task.", LogCategories.ScheduledTaskMonitor);
        }

        public void Send()
        {
            if (email.Recipients.Count > 0)
            {
                try
                {
                    email.Send();
                }
                catch (Exception ex)
                {
                    Logger.Error(
                        string.Format(@"Scheduled Task Failure Report sending was unsuccessful. Original report: {0}", failureMessage)
                                    + @" -- Cause for report send failure: ", ex, ignoreVerbosityConfig: true);
                }
            }
        }
    }
}
