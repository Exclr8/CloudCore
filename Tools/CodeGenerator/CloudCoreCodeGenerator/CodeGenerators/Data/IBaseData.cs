using System;

namespace FrameworkOne.CloudCoreCodeGenerator.CodeGenerators.Data
{
    public interface IData {}

    public interface IBaseData : IData
    {
        string Title { get; set; }
        string FileLocation { get; set; }
        string FileName { get; set; }

        void ResetAllData();
    }
}
