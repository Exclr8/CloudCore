using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using CloudCore.Domain;

using CloudCore.Data;

namespace CloudCore.Admin.Models
{
    public class SystemValueCreateModel : SystemValueCategoryContext
    {
        [Display(Name = "Name")]
        [Required]
        [StringLength(50, ErrorMessage="A Maximum of 50 Characters is allowed for System Value Name.")]
        public string ValueName { get; set; }

        [Display(Name = "Value Data")]
        [Required]
        [StringLength(8000, ErrorMessage = "A Maximum of 8000 Characters is allowed for System Value Name.")]
        public string ValueData { get; set; }

        [Display(Name = "Description")]
        [Required]
        [StringLength(8000, ErrorMessage = "A Maximum of 8000 Characters is allowed for System Description.")]
        public string ValueDescription { get; set; }


        public void AddSystemValue()
        {
            try
            {
                CloudCoreDB db = new CloudCoreDB();
                int? systemval = 0;
                db.Cloudcore_SystemValueCreate(this.CategoryId, this.ValueName, this.ValueData, this.ValueDescription, ref systemval);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
    }
}