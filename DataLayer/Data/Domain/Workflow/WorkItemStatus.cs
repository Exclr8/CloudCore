using System;
using System.Collections.Generic;
using System.Linq;

namespace CloudCore.Domain.Workflow
{
    [Serializable]
    public class WorkItemStatus
    {
        public byte Id { get; set; }
        public string Name { get; set; }

        private WorkItemStatus()
        { }

        public static WorkItemStatus Pending
        {
            get
            {
                return new WorkItemStatus
                {
                    Id = 0,
                    Name = "Pending"
                };
            }
        }

        public static WorkItemStatus Running
        {
            get
            {
                return new WorkItemStatus
                {
                    Id = 1,
                    Name = "Running"
                };
            }
        }

        public static WorkItemStatus Retry
        {
            get
            {
                return new WorkItemStatus
                {
                    Id = 42,
                    Name = "Retry"
                };
            }
        }

        public static WorkItemStatus Disabled
        {
            get
            {
                return new WorkItemStatus
                {
                    Id = 100,
                    Name = "Disabled"
                };
            }
        }

        public static WorkItemStatus Failed
        {
            get
            {
                return new WorkItemStatus
                {
                    Id = 101,
                    Name = "Failed"
                };
            }
        }

        public static List<WorkItemStatus> All
        {
            get
            {
                return new List<WorkItemStatus>
                {
                    Pending,
                    Running,
                    Retry,
                    Failed,
                    Disabled
                };
            }
        }

        public static implicit operator WorkItemStatus(int id)
        {
            return All.SingleOrDefault(x => x.Id == id);
        }
    }
}
