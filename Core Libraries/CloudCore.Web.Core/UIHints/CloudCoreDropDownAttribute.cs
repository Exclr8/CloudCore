using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Web.Mvc;
using CloudCore.Web.Core.Razor.Extensions;

namespace CloudCore.Web.Core.UIHints
{
    // TODO: Create sufficient XML documentation for class and class members so developers can understand what it's for and how to use it.
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true, Inherited = false)]
    public class CloudCoreDropDownAttribute : UIHintAttribute
    {
        private readonly Type _dataClassType;
        private readonly string _methodName;
        private readonly string _textPropertyName;
        private readonly string _valuePropertyName;
        private readonly object[] _methodArguments;
        
        /// <summary>
        /// Causes the model property to use the CloudCoreDropDown control to render the editor field on the web page form when using an editor (template).
        /// </summary>
        /// <param name="dataClassType">The specified class/type will be used to retrieve the text and value field names, as well as the method that will return the list of items that the drop-down control must contain.</param>
        /// <param name="dataTextPropertyName">The name of the class property that contains the data value for the drop down field</param>
        /// <param name="dataValuePropertyName">The name of the class property that contains the text for the drop down field</param>
        /// <param name="classDataMethodName">The name of the method that will return the list of items that the drop-down control must contain. The method must be a static method and should be of type IEnumerable T where T is the same type as the dataClassType argument.</param>
        /// <param name="methodArguments">Any arguments that the drop down list data method requires. If no arguments are required you can specify null here.</param>
        public CloudCoreDropDownAttribute(Type dataClassType, string dataTextPropertyName, string dataValuePropertyName, string classDataMethodName, params object[] methodArguments)
            : base("CloudCoreDropDown")
        {
            _dataClassType = dataClassType;
            _methodName = classDataMethodName;
            _methodArguments = methodArguments;
            _textPropertyName = dataTextPropertyName;
            _valuePropertyName = dataValuePropertyName;
        }

        internal IEnumerable<SelectListItem> GetMethodResult()
        {
            if (_dataClassType == null)
                throw new NoNullAllowedException("Class data type cannot be null. (DropDown attribute)");

            var serviceInstance = Activator.CreateInstance(_dataClassType);
            var methodInfo = _dataClassType.GetMethod(_methodName);
            var retVal = methodInfo.Invoke(serviceInstance, _methodArguments) as IEnumerable<dynamic>;
                
            return retVal.ToSelectListItems(_textPropertyName, _valuePropertyName);
        }
    }
}