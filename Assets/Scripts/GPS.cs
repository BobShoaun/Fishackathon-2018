using System;
using System.Collections;
using UnityEngine;
using Location;

public static class GPS {

    private static float latitude;
    private static float longitude;

	public static GeoCoordinate result;

    // Use this for initialization
	public static void Initialize () {
        // check if user has location service enabled
        if (!Input.location.isEnabledByUser)
        {
            Console.WriteLine("ERROR: Location service is disabled.");
        }
        Debug.Log(Application.platform);
    }

    public static IEnumerator getLocation()
    {
        // turn on location services
        Input.location.Start();

        // Wait for service to initialize
        int waitTime = 20;
        while (Input.location.status == LocationServiceStatus.Initializing && waitTime > 0)
        {
            yield return new WaitForSeconds(1);
            waitTime--;
        }

        // timeout when service didn't initialize in 20 seconds
        if (waitTime < 1)
        {
            Console.WriteLine("Timeout");
            yield break;
        }

        // Connection failed
        if (Input.location.status == LocationServiceStatus.Failed)
        {
            Console.WriteLine("Unable to determine device location.");
            yield break;
        }
        else
        {
            latitude = Input.location.lastData.latitude;
			longitude = Input.location.lastData.longitude;
        }

		result.setLongitude (longitude);
		result.setLatitude (latitude);

        Input.location.Stop();
    }

}
