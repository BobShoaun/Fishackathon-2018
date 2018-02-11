using System;
using System.Collections.Generic;

namespace Location
{
    public static class GeoCoordinateDistanceExtensions
    {
        public static int getNearestCoordinate(GeoCoordinate currentCoordinate,
            List<GeoCoordinate> listOfCoordinates)
        {
            double shortestDistance = distanceInKmBetweenCoordinates(currentCoordinate,
                listOfCoordinates[0]);

            GeoCoordinate nearestCoordinate = listOfCoordinates[0];

            int indexOfNearestCoordinate = 0;

            for (int i = 0; i < listOfCoordinates.Count; i++)
            {
                double distance = distanceInKmBetweenCoordinates(currentCoordinate,
                    listOfCoordinates[i]);

                if (distance < shortestDistance)
                {
                    shortestDistance = distance;
                    nearestCoordinate = listOfCoordinates[i];
                    indexOfNearestCoordinate = i;
                }
            }
            return indexOfNearestCoordinate;
        }

        private static double distanceInKmBetweenCoordinates(
            GeoCoordinate gc1, GeoCoordinate gc2)
        {
            const double earthRadius = 6371.0;

            double lat1 = gc1.getLatitude();
            double lon1 = gc1.getLongitude();
            double lat2 = gc2.getLatitude();
            double lon2 = gc2.getLongitude();

            double latDistance = degreeToRadians(lat2 - lat1);
            double lonDistance = degreeToRadians(lon2 - lon1);

            lat1 = degreeToRadians(lat1);
            lat2 = degreeToRadians(lat2);

            double a = Math.Pow(Math.Sin(latDistance / 2), 2) +
                Math.Pow(Math.Sin(lonDistance / 2), 2) * Math.Cos(lat1) * Math.Cos(lat2);

            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

            return earthRadius * c;
        }

        private static double degreeToRadians(double degrees)
        {
            return degrees * Math.PI / 180;
        }
    }
}
