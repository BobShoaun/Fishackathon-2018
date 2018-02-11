using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Location;
using System.Linq;
using UnityEngine.Events;

public class FishLawSystem : MonoBehaviour {


	[SerializeField]
	private int updateRate = 5;

	public LawItem lawItemPrefab;
	public Transform lawItemList;

	public LawItem currentLawItem;
	public TextMeshProUGUI coordinatesText;
	public TextMeshProUGUI currentCountryText;

	public TextMeshProUGUI debugText;

	CountryDatabase countryDatabase;
	private Country previousCountry;

	UIManager uimanager;

	private void Start () {


		uimanager = FindObjectOfType<UIManager> ();
		GPS.Initialize ();
		countryDatabase = GetComponent<CountryDatabase> ();

		countryDatabase.databaseReady += OnDatabaseReady;

	}

	private void OnDatabaseReady () {
		StartCoroutine (SourceGPSLocation ());


//		string debug = "";
//		foreach (var geo in countryDatabase.coordsList) {
//			debug = debug + geo.ToString () + "\n";
//		}
//		debugText.text = debug;
	}

//	public void SourceDatabaseFromCoords () {
//		//float longitude = float.Parse (Longitude);
//		//float lattitude = float.Parse (Lattitude);
//	//	Vector2 coords = new Vector2 (longitude, lattitude);
//
//		string lawString = "The Laws in this coords are: \n";
//
//		foreach (Law law in countryDatabase [coords].laws) {
//			lawString += law;
//			lawString += "\n";
//		}
//
//		//lawText.text = lawString;
//	}


	private IEnumerator SourceGPSLocation () {
		while (true) {
			yield return GPS.getLocation ();
			 //= GPS.result.ToString ();


			int nearest = GeoCoordinateDistanceExtensions.getNearestCoordinate (GPS.result, countryDatabase.coordsList.ToList ());

			coordinatesText.text = countryDatabase.coordsList [nearest].ToString ();

			Country currentCountry = countryDatabase.countryList [nearest];

			if (previousCountry != null && currentCountry != previousCountry) {
				uimanager.SendPushUp ("You have crossed to a new region: " + currentCountry.name, 
					"Check the app for updated fishing rules and regulations");
			}

			previousCountry = currentCountry;

			currentCountryText.text = "About your current Location \n <size=150%>" + currentCountry.name + "</size>";
			// source GPS for current coords, set curretn coords to current location
		
			currentLawItem.Law = currentCountry.laws.FirstOrDefault ();

			foreach (Transform t in lawItemList) {
				Destroy (t.gameObject);
			}

			yield return null;

			foreach (Law law in currentCountry.laws) {
				Instantiate (lawItemPrefab, lawItemList).Law = law;
			}
			yield return new WaitForSeconds (updateRate);
			//currentLawItem.Law = 
		}
	}

	public void Search () {
		
	}

}
