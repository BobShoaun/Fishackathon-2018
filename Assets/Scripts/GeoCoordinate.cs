using Newtonsoft.Json;

namespace Location
{
    public struct GeoCoordinate
    {
		[JsonProperty ("x")]
        public double latitude;
		[JsonProperty ("y")]
		public double longitude;

        public GeoCoordinate(double latitude, double longtitude) {
            this.latitude = latitude;
            this.longitude = longtitude;
        }

        public double getLatitude()
        {
            return latitude;
        }

        public double getLongitude()
        {
            return longitude;
        }

        public void setLatitude(double latitude)
        {
            // TODO: Restrictions for value
            this.latitude = latitude;
        }

        public void setLongitude(double longtitude)
        {
            // TODO: Restrictions for value
            this.longitude = longtitude;
        }

		public override string ToString () {
			return string.Format ("({0}, {1})", longitude, latitude);
		}

    }
}
