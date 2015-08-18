namespace CloudCore.Configuration.ConfigFile.Location
{
    public interface ILocationConfig
    {
        decimal Latitude { get; }
        decimal Longitude { get; }
        bool LocationAware { get; }
        int RadiusInMeters { get; }
    }

    public class LocationConfig : ILocationConfig
    {
        private decimal _latitude = 0;
        public virtual decimal Latitude
        {
            get
            {
                return _latitude;
            }

            protected set
            {
                _latitude = value;
            }
        }

        private decimal _longitude = 0;
        public virtual decimal Longitude
        {
            get
            {
                return _longitude;
            }

            protected set
            {
                _longitude = value;
            }
        }

        private bool _locationAware = false;
        public virtual bool LocationAware
        {
            get
            {
                return _locationAware;
            }

            protected set
            {
                _locationAware = value;
            }
        }

        private int _radiusInMeters = 0;

        public virtual int RadiusInMeters
        {
            get
            {
                return _radiusInMeters;
            }

            protected set
            {
                _radiusInMeters = value;
            }
        }
    }
}
