using System;
using System.Collections;
using UnityEngine;

public class GPS {

    private static GPS gps;

    private double latitude;
    private double longitude;

    public Vector2 result;

    private GPS() {  }

    public static GPS getInstance()
    {
        if(gps == null)
        {
            gps = new GPS();
        }
        return gps;
    }
    
    // Use this for initialization
    void Start () {
        // check if user has location service enabled
        if (!Input.location.isEnabledByUser)
        {
            Console.WriteLine("ERROR: Location service is disabled.");
        }
        Debug.Log(Application.platform);
    }

    public IEnumerator getLocation()
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

        result.x = (float)latitude;
        result.y = (float)longitude;

        Input.location.Stop();
    }

    // Update is called once per frame
    void Update () {
		
	}
}
