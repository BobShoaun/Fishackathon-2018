using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Location;
using System.Linq;

public class FishLawSystem : MonoBehaviour {


	[SerializeField]
	private int updateRate = 5;

	public LawItem lawItemPrefab;
	public Transform lawItemList;

	public LawItem currentLawItem;
	public TextMeshProUGUI coordinatesText;
	public TextMeshProUGUI currentCountryText;

	CountryDatabase countryDatabase;

	private void Start () {
		GPS.Initialize ();
		countryDatabase = GetComponent<CountryDatabase> ();
		StartCoroutine (SourceGPSLocation ());
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

	private void GetNearestCoordsTo (Vector2 coords) {
		
	}

	private IEnumerator SourceGPSLocation () {
		while (true) {
			yield return GPS.getLocation ();
			 //= GPS.result.ToString ();


			int nearest = GeoCoordinateDistanceExtensions.getNearestCoordinate (GPS.result, countryDatabase.coordsList.ToList ());

			coordinatesText.text = countryDatabase.coordsList [nearest].ToString ();

			Country currentCountry = countryDatabase.countryList [nearest];
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
