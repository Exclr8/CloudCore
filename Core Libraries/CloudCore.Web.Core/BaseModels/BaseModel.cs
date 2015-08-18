using CloudCore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudCore.Web.Core.BaseModels
{
    public class BaseModel
    {
        private CloudCoreDB cloudcoredbcontext = CloudCoreDB.Context;

        protected CloudCoreDB CoreDataContext
        {
            get
            {
                return cloudcoredbcontext;
            }
        } 
    }
}
