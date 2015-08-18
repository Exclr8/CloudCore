using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Architect.CustomCode
{
    public static class Guids
    {
        public const int cmdidNewCommandID = 0x201;
        public const int cmdidExportCommandID = 0x202;
        public const int cmdidImportCommandID = 0x203;

        public const string guidFileMenuCmdSetString = "294A7B97-9247-41EC-81E5-3F97A5C8E70B";
        public static readonly Guid guidFileMenuCmdSet = new Guid(guidFileMenuCmdSetString);

        public const string guidExportCmdSetString = "B3A85A38-AB94-4D48-B66A-83D2C0A367A7";
        public static readonly Guid guidExportCmdSet = new Guid(guidFileMenuCmdSetString);

        public const string guidImportCmdSetString = "779FC622-CD68-48A8-AEA6-878C0E7EA043";
        public static readonly Guid guidImportCmdSet = new Guid(guidFileMenuCmdSetString);

        public const string guidShowControllerSourceCmdSetString = "EF92F3C6-017F-493A-AD03-110773120FEC";
        public static readonly Guid guidShowControllerSourceCmdSet = new Guid(guidFileMenuCmdSetString);
        public static readonly int cmdShowControllerSourceId = 0x830;
    }
}
