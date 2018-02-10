using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishLawSystem : MonoBehaviour {

	public Vector2 currentCoordinates;
	[SerializeField]
	private int updateRate = 5;

	private void Start () {
		
	}

	private IEnumerator SourceGPSLocation () {
		while (true) {
			yield return new WaitForSeconds (updateRate);
			// source GPS for current coords, set curretn coords to current location
		}
	}

}
