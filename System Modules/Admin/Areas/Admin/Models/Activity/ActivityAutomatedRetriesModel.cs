using System.ComponentModel.DataAnnotations;
using CloudCore.Admin.Classes.FormObjects;
using CloudCore.Domain.Workflow;

using CloudCore.Data;

namespace CloudCore.Admin.Models
{
    public class ActivityAutomatedRetriesModel : ActivityForm
    {
        #region Properties

        [Required(ErrorMessage = "Please enter Maximum Retries.")]
        [Range(0, 50, ErrorMessage = "Maximum retries out of range. Allowed values: from 0 to 50")]
        [Display(Name = "Maximum Retries")]
        public int MaxRetries { get; set; }

        [Required(ErrorMessage = "Please enter Retry Delay In Seconds.")]
        [Range(0, 3600, ErrorMessage = "Retry Delay In Seconds out of range. Allowed values: from 0 to 3600")]
        [Display(Name = "Retry Delay In Seconds")]
        public int RetryDelayInSeconds { get; set; }

        #endregion

        #region Methods

        public void GetRetryInformation()
        {
            MaxRetries = ActiveActivityDetails.MaximumRetries;
            RetryDelayInSeconds = ActiveActivityDetails.RetryDelayInSeconds;
        }

        public void SaveRetryInformation()
        {

            CloudCoreDB.Context.Cloudcore_ActivityRetryUpdate(ActivityId, MaxRetries, RetryDelayInSeconds);
            ActiveActivityDetails.ForceRefresh();
        }

        #endregion
    }
}