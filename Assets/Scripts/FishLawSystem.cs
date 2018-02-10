using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FishLawSystem : MonoBehaviour {

	public Vector2 currentCoordinates;
	[SerializeField]
	private int updateRate = 5;

	public string Longitude { get; set; }
	public string Lattitude { get; set; }

	public TextMeshProUGUI lawText;

	CountryDatabase countryDatabase;

	private void Start () {
		countryDatabase = GetComponent<CountryDatabase> ();
	}

	public void SourceDatabaseFromCoords () {
		float longitude = float.Parse (Longitude);
		float lattitude = float.Parse (Lattitude);
		Vector2 coords = new Vector2 (longitude, lattitude);

		string lawString = "The Laws in this coords are: \n";

		foreach (Law law in countryDatabase [coords].laws) {
			lawString += law;
			lawString += "\n";
		}

		lawText.text = lawString;
	}

	private void GetNearestCoordsTo (Vector2 coords) {
		
	}

	private IEnumerator SourceGPSLocation () {
		while (true) {
			yield return new WaitForSeconds (updateRate);
			// source GPS for current coords, set curretn coords to current location
		}
	}

	public void Search () {
		
	}

}
