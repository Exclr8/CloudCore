using System;
using System.Web.Mvc;
using CloudCore.Web.Core.Notifications;
using CloudCore.Web.Core.Security;


namespace CloudCore.Web.Core.BaseControllers
{


    /// <summary>
    /// MUST NOT be inherited by your controllers directly.
    /// Provides base notification message popup functionality.
    /// Does not include any layout information and doesn't do any authorisation and authentication.
    /// </summary>
    [RedirectToHttps]
    public abstract class CoreController : Controller
    {
     

   

        public void ShowErrorMessage(string messageText, string title = "")
        {
            NotificationBaloonMessage.Create(TempData, NotificationBaloonType.Error, messageText, title);
        }

        public void ShowSuccessMessage(string messageText, string title = "")
        {
            NotificationBaloonMessage.Create(TempData, NotificationBaloonType.Success, messageText, title);
        }

        public void ShowMessage(string messageText, string title = "")
        {
            NotificationBaloonMessage.Create(TempData, NotificationBaloonType.Message, messageText, title);
        }

        public bool ValidateAndExecute(Action actionToExecute, string successMessage)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    actionToExecute();
                    ShowSuccessMessage(successMessage);
                    return true;
                }

                throw new AggregateException(Common.GetErrorListFromModelState(ModelState));
            }
            catch (Exception error)
            {
                ShowErrorMessage(error.Message);
            }

            return false;
        }
    }
}
