using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LawItemList : MonoBehaviour {

	public CountryDatabase countryDatabase;
	public Transform parent;
	public GameObject lawItemPrefab;

	public void UpdateList (string country) {
		foreach (Law law in countryDatabase [country].laws) {
			Instantiate (lawItemPrefab, parent).GetComponent<LawItem> ().Law = law;
		}
	}

}
