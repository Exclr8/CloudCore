using System.ComponentModel.DataAnnotations;
using CloudCore.Domain;

using CloudCore.Data;
using System.Data.SqlClient;

namespace CloudCore.Admin.Models
{
    public class SystemValueCategoryCreateModel
    {
        [Display(Name = "Category Name")]
        [Required]
        public string CategoryName { get; set; }

        public int CategoryId { get; set; }

        public void CreateCategory()
        {
            try
            {
                CloudCoreDB db = new CloudCoreDB();
                int? _categoryId = null;
                db.Cloudcore_SystemValueCategoryCreate(CategoryName, ref _categoryId);
                this.CategoryId = _categoryId.Value;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
    }
}