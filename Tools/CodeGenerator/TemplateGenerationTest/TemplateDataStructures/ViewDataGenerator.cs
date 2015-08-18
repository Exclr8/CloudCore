using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TemplateGenerationTest.TemplateGenerationModels;

namespace TestGenerationTest.TemplateGenerationModels
{
    public static class ViewDataGenerator
    {
        private const string DefaultNamespace = "TemplateGenerationTest";

        public static IEnumerable<PropertyItem> GetPropertyItems()
        {
            return new List<PropertyItem>
            {
                new PropertyItem { PropertyName = "InputColumn1", PropertyType = typeof(string), DisplayName = "Input Column 1" },
                new PropertyItem { PropertyName = "InputColumn2", PropertyType = typeof(string), DisplayName = "Input Column 2" },
                new PropertyItem { PropertyName = "InputColumn3", PropertyType = typeof(string), DisplayName = "Input Column 12" }
            };
        }

        public static SearchTemplateData GetSearchViewData()
        {
            return new SearchTemplateData
            {
                DisplayColumns = new List<DisplayColumn> {

                new DisplayColumn { DisplayProperty = "DisplayColumn1", Action = "Remove", ValueProperty="Id", IsIdentifier = true, ColumnName = "Display Column 1 " },
                new DisplayColumn { DisplayProperty = "DisplayColumn2", ColumnName = "Display Column 2" },
                new DisplayColumn { DisplayProperty = "DisplayColumn3", ColumnName = "Display Column 3" },
                new DisplayColumn { DisplayProperty = "DisplayColumn4", ColumnName = "Display Column 4" },
                
               },
                ModelProperties = GetPropertyItems(),
                GridDataSourceName = "DataSource",
                GridTitle = "The title",
                InputColumns = new List<InputColumn> {
                    new InputColumn { InputProperty = "InputColumn1"},
                    new InputColumn { InputProperty = "InputColumn2" },
                    new InputColumn { InputProperty = "InputColumn3" },
               },
                Namespace = DefaultNamespace,
                ContextName = "Search",
                PageTitle = "The Title",
                DataContextNamespace = "CloudCore.Data",
                DataContextName = "CloudCoreDB",
                SearchQuery = @"from a in db.Cloudcore_User 
                                select new { a.UserId, a.Email }"
            };
        }

        public static CreateTemplateData GetCreateViewData()
        {
            return new CreateTemplateData
            {
                CreateButtonText = "Create Button",
                Namespace = DefaultNamespace,
                ContextName = "Create",
                ModelProperties = GetPropertyItems(),
                PageTitle = "Create Test"
            };
        }

        public static ModifyTemplateData GetModifyViewData()
        {
            return new ModifyTemplateData
            {
                ModifyButtonText = "Create Button",
                Namespace = DefaultNamespace,
                ContextName = "Modify",
                ModelProperties = GetPropertyItems(),
                PageTitle = "Modify Test"
            };
        }

        public static DeleteTemplateData GetDeleteViewData()
        {
            return new DeleteTemplateData
            {
                DeleteConfirmMessage = "Are you sure you want to delete this item ? ",
                PageTitle = "Delete Item ",
                Namespace = DefaultNamespace,
                ContextName = "Delete",
                KeyFieldPropertyName = "TestId",
                ModelProperties = GetPropertyItems()
            };
        }

        public static DetailsTemplateData GetDetailViewData()
        {
            return new DetailsTemplateData
            {
                Namespace = DefaultNamespace,
                ContextName = "Details",
                ModelProperties = GetPropertyItems(),
                PageTitle = "Modify Test"
            };
        }

        public static LookupTemplateData GetLookupViewData()
        {
            return new LookupTemplateData
            {
                DisplayColumns = new List<DisplayColumn> {

                new DisplayColumn { DisplayProperty = "DisplayColumn1", Action = "Remove", ValueProperty="Id", IsIdentifier = true, ColumnName = "Display Column 1 " },
                new DisplayColumn { DisplayProperty = "DisplayColumn2", ColumnName = "Display Column 2" },
                new DisplayColumn { DisplayProperty = "DisplayColumn3", ColumnName = "Display Column 3" },
                new DisplayColumn { DisplayProperty = "DisplayColumn4", ColumnName = "Display Column 4" },
                
               },
                ModelProperties = GetPropertyItems(),
                GridDataSourceName = "DataSource",
                GridTitle = "The title",
                InputColumns = new List<InputColumn> {
                    new InputColumn { InputProperty = "InputColumn1"},
                    new InputColumn { InputProperty = "InputColumn2" },
                    new InputColumn { InputProperty = "InputColumn3" },
               },
                Namespace = DefaultNamespace,
                ContextName = "Lookup",
                PageTitle = "The Title",
                DataContextNamespace = "CloudCore.Data",
                DataContextName = "CloudCoreDB",
                SearchQuery = @"from a in db.Cloudcore_User 
                                select new { a.UserId, a.Email }"
            };
        }


    public static ListViewTemplateData GetListViewData()
        {
            return new ListViewTemplateData
            {
                DisplayColumns = new List<DisplayColumn> {

                new DisplayColumn { DisplayProperty = "DisplayColumn1", Action = "Remove", ValueProperty="Id", IsIdentifier = true, ColumnName = "Display Column 1 " },
                new DisplayColumn { DisplayProperty = "DisplayColumn2", ColumnName = "Display Column 2" },
                new DisplayColumn { DisplayProperty = "DisplayColumn3", ColumnName = "Display Column 3" },
                new DisplayColumn { DisplayProperty = "DisplayColumn4", ColumnName = "Display Column 4" },
                
               },
                ModelProperties = GetPropertyItems(),
                GridDataSourceName = "DataSource",
                GridTitle = "The title",
                Namespace = DefaultNamespace,
                ContextName = "ListView",
                PageTitle = "The Title",
                DataContextNamespace = "CloudCore.Data",
                DataContextName = "CloudCoreDB",
                SearchQuery = @"from a in db.Cloudcore_User 
                                select new { a.UserId, a.Email }"
            };
        }
    }
}