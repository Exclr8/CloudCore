// Guids.cs
// MUST match guids.h
using System;

namespace FrameworkOne.EditorExtentions
{
    static class GuidList
    {
        public const string GuidEditorExtentionsPkgString = "4bea791f-9f44-4279-89bd-839be05fbb82";
        public const string guidEditorExtentionsCmdSetString = "51e68dd0-ff29-4b61-9b39-e2148c0f701d";

        public static readonly Guid guidEditorExtentionsCmdSet = new Guid(guidEditorExtentionsCmdSetString);
    };
}