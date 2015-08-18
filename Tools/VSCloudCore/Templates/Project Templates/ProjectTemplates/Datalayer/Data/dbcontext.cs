using CloudCore.Configuration.ConfigFile;

namespace  $safeprojectname$
{
    public class $ProductDBName$ : $ProductDBName$base
    {
        public $ProductDBName$() : base(ReadConfig.ConnectionString)
        {
            this.ObjectTrackingEnabled = false;
        }

        public $ProductDBName$(string connectionString) : base(connectionString)
        {
            ObjectTrackingEnabled = false;
        }

        public static $ProductDBName$ Context
        {
            get { return new $ProductDBName$(); }
        }
    }
}