using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FishLawSystem : MonoBehaviour {

	public CoordsToLawDatabase database;

	public Vector2 currentCoordinates;
	[SerializeField]
	private int updateRate = 5;

	public string Longitude { get; set; }
	public string Lattitude { get; set; }

	public TextMeshProUGUI lawText;

	private void Start () {
		database = GetComponent<CoordsToLawDatabase> ();
	}

	public void SourceDatabaseFromCoords () {
		float longitude = float.Parse (Longitude);
		float lattitude = float.Parse (Lattitude);
		Vector2 coords = new Vector2 (longitude, lattitude);

		string lawString = "The Law in this coords are ";


		foreach (Law law in database [coords])
			lawString += law;

		lawText.text = lawString;
	}


	private IEnumerator SourceGPSLocation () {
		while (true) {
			yield return new WaitForSeconds (updateRate);
			// source GPS for current coords, set curretn coords to current location
		}
	}

}
