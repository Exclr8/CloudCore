using System.Text.RegularExpressions;
using FrameworkOne.CloudCoreCodeGenerator.CodeGenerators.Data;
using Microsoft.CSharp;

namespace FrameworkOne.CloudCoreCodeGenerator.CodeGenerators.Helpers
{

    internal partial class TransformCodeHelpers
    {
        internal static string TransformTemplates<DataType>(dynamic generator) where DataType : IData
        {
            var data = ((DataType)WizardDataStore.Data);

            generator.Data = data;

            var result = generator.TransformText();

            System.IO.File.WriteAllText((data as BaseData).FullFilePath, result);

            return result;
        }

        public static string AppendFileExtension(string fileName, string extension)
        {
            return fileName.EndsWith(extension) ? fileName : fileName + extension;
        }

        public static string CleanClassName(string className)
        {
            Regex regex = new Regex(@"[^\p{Ll}\p{Lu}\p{Lt}\p{Lo}\p{Nd}\p{Nl}\p{Mn}\p{Mc}\p{Cf}\p{Pc}\p{Lm}]");
            string ret = regex.Replace(className, "");
            
            //The identifier must start with a character or a "_"
            if (!char.IsLetter(ret, 0) && !CSharpCodeProvider.CreateProvider("C#").IsValidIdentifier(ret))
                ret = string.Concat("_", ret);
            
            return ret;
        }

        public static bool ValidateClass(string className)
        {
            Regex regex = new Regex(@"[^\p{Ll}\p{Lu}\p{Lt}\p{Lo}\p{Nd}\p{Nl}\p{Mn}\p{Mc}\p{Cf}\p{Pc}\p{Lm}]");
            return regex.IsMatch(className);
        }

        public static bool ValidateNamespace(string nameSpace)
        {
            Regex regex = new Regex(@"(@?[a-z_A-Z]\w+(?:\.@?[a-z_A-Z]\w+)*");
            return regex.IsMatch(nameSpace);
        }
    }
}
