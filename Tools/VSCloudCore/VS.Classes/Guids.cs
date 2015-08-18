// Guids.cs
// MUST match guids.h
using System;

namespace CloudCore.VSExtension
{
    static class GuidList
    {
        public const string CSharpString = "FAE04EC0-301F-11D3-BF4B-00C04F79EFBC";

        public const string guidVSCloudCorePkgString = "cd733063-7383-4175-a38b-283e39e02fcc";
        
        public const string guidVSCloudCoreCmdSetString = "01707136-f235-4e21-8268-451183d3433e";
        
        public const string guidWebModuleString = "696e1aa7-2107-4bbe-a1d1-ee1993e870d2";
        public const string guidWebModuleFactoryString = "56709072-e3d2-452b-b2db-0ae5600fc001";

        public const string guidProcessModuleString = "4A66091C-1BB9-4C5C-9C5D-49348088ADEC";
        public const string guidProcessModuleFactoryString = "5d6a7b84-d146-40e6-84d8-d08e9bd78560";
        public const string guidProcessModule_PP_String = "1E2800FE-37C5-4FD3-BC2E-969342EE08AF";
        public const string guidProcessModule_PV_String = "3A0C0D50-90E0-491E-9982-4E84243F9F4B";

        public const string guidCloudCoreSiteString = "5BA442A2-0B80-4B66-A8CA-AEF8861C8019";
        public const string guidCloudCoreSiteFactoryString = "D790A903-EF92-46E7-811A-47AF5FA5E3E9";
        public const string guidCloudCoreSite_PP_ACSString = "59AB1C8A-845A-4BD5-B395-5D90D0C47241";
        public const string guidCloudCoreSite_PV_ACSString = "B7EAACF5-45E9-422B-A755-2AA3AAE6C161";

        
        public static readonly Guid guidVSCloudCoreCmdSet = new Guid(guidVSCloudCoreCmdSetString);
    };
}