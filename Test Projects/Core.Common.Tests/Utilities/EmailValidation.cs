using System.Collections.Generic;
using System.Text.RegularExpressions;
using CloudCore.Core.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CloudCore.Core.Tests.Utilities
{
    /// <summary>
    /// Follows RFC3696 http://tools.ietf.org/html/rfc3696
    /// </summary>
    [TestClass]
    public class EmailValidation
    {
        Dictionary<string, bool> emailsToTest;

        public EmailValidation()
        {
            emailsToTest = new Dictionary<string, bool>
            {
                { @"NotAnEmail", false },
                { @"@NotAnEmail", false },
                { @"""test\\blah""@example.com", true },
                { @"""test\blah""@example.com", false },
                { "\"test\\\rblah\"@example.com", true },
                { "\"test\rblah\"@example.com", false },
                { @"""test\""blah""@example.com", true },
                { @"""test""blah""@example.com", false },
                { @"customer/department@example.com", true },
                { @"$A12345@example.com", true },
                { @"!def!xyz%abc@example.com", true },
                { @"_Yosemite.Sam@example.com", true },
                { @"~@example.com", true },
                { @".wooly@example.com", false },
                { @"wo..oly@example.com", false },
                { @"pootietang.@example.com", false },
                { @".@example.com", false },
                { @"""Austin@Powers""@example.com", true },
                { @"Ima.Fool@example.com", true },
                { @"""Ima.Fool""@example.com", true },
                { @"""Ima Fool""@example.com", true },
                { @"Ima Fool@example.com", false },
                { @"whk@frameworkone.co.za", true }
            };
        }
        
        [TestMethod]
        public void TestEmailRegularExpression()
        {
            string pattern = RegularExpressionPatterns.ValidEmailAddress;

            var regex = new Regex(pattern, RegexOptions.IgnoreCase);

            foreach (var emailComparison in emailsToTest)
            {
                Assert.AreEqual(emailComparison.Value, regex.IsMatch(emailComparison.Key)
                , "Problem with '" + emailComparison.Key + "'. Expected "
                + emailComparison.Value + " but was not that.");
            }  
        }
    }


}
