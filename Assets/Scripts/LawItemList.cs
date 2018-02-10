using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LawItemList : MonoBehaviour {

	public CountryDatabase countryDatabase;
	public Transform parent;
	public GameObject lawItemPrefab;

	public void UpdateList (int country) {
		foreach (Transform transform in parent) {
			DestroyImmediate (transform.gameObject);
		}
		foreach (Law law in countryDatabase.countries [country].laws) {
			Instantiate (lawItemPrefab, parent).GetComponent<LawItem> ().Law = law;
		}
	}

}
