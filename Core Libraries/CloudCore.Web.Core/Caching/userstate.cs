using System;
using CloudCore.Web.Core.Security.Authentication;

namespace CloudCore.Web.Core.Caching
{
    [Serializable]
    public class UserState : LiteralCache<UserState>
    {
        public int ActiveTab
        {
            get { return SessionInfo.ActiveTab; }
        }

        public int StandardQueryIndex
        {
            get { return SessionInfo.StandardQueryIndex; }
        }


        public int WorklistTypeIndex
        {
            get { return SessionInfo.WorklistTypeIndex; }
        }

    }
}
