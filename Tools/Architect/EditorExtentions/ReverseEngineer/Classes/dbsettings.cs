using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Btomic
{
    public static class DBSettings
    {
        public static string MyConnectionString { get; set; }
        public static string Server { get; set; }
        public static string Database { get; set; }
        public static string Integrated { get; set; }
        public static string Username { get; set; }
        public static string Password { get; set; }
    }
}
