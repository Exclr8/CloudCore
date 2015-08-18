using CloudCore.Data;
using CloudCore.Web.Core.BaseModels;

using System.ComponentModel.DataAnnotations;
using System.Data.Linq.SqlClient;
using System.Linq;

namespace CloudCore.Admin.Models
{
    public class UserSearchResultItemModel
    {
        #region Public Properties

        public int UserId { get; set; }

        [Required(ErrorMessage = "Please enter a Login name.")]
        [DataType(DataType.Text)]
        [Display(Name = "Login")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Please enter Initials.")]
        [DataType(DataType.Text)]
        [Display(Name = "Initials")]
        public string Initials { get; set; }

        [Required(ErrorMessage = "Please enter Firstname.")]
        [DataType(DataType.Text)]
        [Display(Name = "Firstname(s)")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter Surname.")]
        [DataType(DataType.Text)]
        [Display(Name = "Surname")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Please enter Full Name.")]
        [DataType(DataType.Text)]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Enter Cell Number.")]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Cell Number")]
        public string CellNumber { get; set; }

        [Required(ErrorMessage = "Enter Email Address.")]
        [DataType(DataType.Text)]
        [Display(Name = "Email")]
        [RegularExpression("^([a-zA-Z0-9_\\-\\.]+)@((\\[[0-9]{1,3}\\.[0-9]{1,3}\\.[0-9]{1,3}\\.)|(([a-zA-Z0-9\\-]+\\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\\]?)$", ErrorMessage = "Not a valid email address")]
        public string Email { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Image")]
        public byte[] Image { get; set; }

        #endregion
    }

    public class UserSearchModel : BaseSearchModel<UserSearchResultItemModel>
    {
        public string Name { get; set; }

        public string NameFilter { get; set; }

        public string Login { get; set; }

        public string LoginFilter { get; set; }

        public string Email { get; set; }

        public string EmailFilter { get; set; }
        
        public override void Search()
        {
            CloudCoreDB database = CloudCoreDB.Context;

            var result = (from user in database.Cloudcore_User
                          where user.UserId > 0
                          select new UserSearchResultItemModel
                          {
                              CellNumber = user.CellNo,
                              Email = user.Email,
                              FirstName = user.Firstnames,
                              FullName = user.Fullname,
                              Initials = user.Initials,
                              Surname = user.Surname,
                              UserId = user.UserId,
                              Login = user.Login
                          });

            if (!string.IsNullOrEmpty(Email))
            {
                result = result.Where(r => SqlMethods.Like(r.Email, string.Format(EmailFilter, Email)));
            }
            if (!string.IsNullOrEmpty(Name))
            {
                result = result.Where(r => SqlMethods.Like(r.FullName, string.Format(NameFilter, Name)) || SqlMethods.Like(r.Login, string.Format(NameFilter, Name)));
            }

            SearchResults = result;
        }
    }
}