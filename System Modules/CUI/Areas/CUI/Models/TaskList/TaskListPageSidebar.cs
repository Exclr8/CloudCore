using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using CloudCore.Web.Core;
using CloudCore.Web.Core.Workflow;
using CloudCore.Core.TaskList;

namespace CloudCore.Web.Areas.CUI.Models.TaskList
{
    public enum TaskListSidebarType
    {
        StandardQueries = 0,
        CustomQueries = 1
    }

    public sealed class TaskListSidebarObject : SidebarObject
    {
        public int ListType { get; set; }

        public bool IsStandardQuery { get; set; }
    }

    public sealed class TaskListPageSidebar : SidebarBase
    {
        public override string SidebarListItemPartialViewName()
        {
            return "TaskList/_TaskListPageSidebarItem";
        }

        private TaskListPageSidebar()
        {
            AddMenuCategory("Standard Queries");
            AddMenuCategory("Custom Queries");
        }

        public static TaskListPageSidebar PopuateTasklistSidebar(UrlHelper urlHelper)
        {
            var taskListSidebar = new TaskListPageSidebar();
            taskListSidebar.AddStandardTaskQueryItems(urlHelper);
            taskListSidebar.AddCustomTaskQueryItems(urlHelper);
            return taskListSidebar;
        }

        private void AddStandardTaskQueryItems(UrlHelper urlHelper)
        {
            var standardQueryList = TaskListQueryList.StandardTaskList;
            for (var i = 0; i < standardQueryList.Length; i++)
            {
                AddTasklistSidebarItem(i, 
                    standardQueryList[i].Title, 
                    urlHelper.Action("GetTasks", "Tasklist", 
                    new 
                    { 
                        listType = i, 
                        activeTab = String.Format("standard_{0}", i), 
                        isStandard = true 
                    }),
                    true,
                    TaskListSidebarType.StandardQueries);
            }
        }

        private void AddCustomTaskQueryItems(UrlHelper urlHelper)
        {
            var customQueryList = TaskListQueryList.CustomQueryList;
            for (var i = 0; i < TaskListQueryList.CustomQueryList.Count(); i++)
            {
                AddTasklistSidebarItem(i,
                    TaskListQueryList.CustomQueryList.ToArray()[i].Title, 
                    urlHelper.Action("GetTasks", "Tasklist", 
                    new 
                    { 
                        listType = i,
                        activeTab = String.Format("custom{0}", i), 
                        isStandard = false 
                    }),
                    false,
                    TaskListSidebarType.CustomQueries);
            }
        }

        private void AddTasklistSidebarItem(int listType, string title, string url, bool isStandardQuery, TaskListSidebarType taskListSidebarType)
        {
            var taskListSideBar = new TaskListSidebarObject
            {
                Title = title,
                Link = url,
                ListType = listType,
                IsStandardQuery = isStandardQuery
            };

            AddSidebarMenuItem((int)taskListSidebarType, taskListSideBar);
        }
    }
}