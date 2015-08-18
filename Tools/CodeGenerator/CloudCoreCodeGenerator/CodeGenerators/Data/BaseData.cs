using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameworkOne.CloudCoreCodeGenerator.CodeGenerators.Data
{
    public abstract class BaseData : IBaseData
    {
        public string Title { get; set; }
        public string FileLocation { get; set; }
        public string FileName { get; set; }

        public string FullFilePath
        {
            get
            {
                var addSlash = !(FileLocation.Last() == '\\');
                return string.Format("{0}{1}{2}", FileLocation, (addSlash ? "\\" : string.Empty), FileName);
            }
        }

        public abstract void ResetAllData();
    }
}
