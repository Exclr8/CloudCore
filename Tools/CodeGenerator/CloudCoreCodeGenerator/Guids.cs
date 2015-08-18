// Guids.cs
// MUST match guids.h
using System;

namespace FrameworkOne.CloudCoreCodeGenerator
{
    static class GuidList
    {
        public const string guidCloudCoreCodeGeneratorPkgString = "f67c3050-7b9f-4494-b53c-0615bbcec9c4";
        public const string guidCloudCoreCodeGeneratorCmdSetString = "986fec74-2a3c-44a0-8b52-29dd677e0eac";

        public static readonly Guid guidCloudCoreCodeGeneratorCmdSet = new Guid(guidCloudCoreCodeGeneratorCmdSetString);
    };
}