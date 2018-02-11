using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LawItemList : MonoBehaviour {

	public CountryDatabase countryDatabase;
	public Transform parent;
	public GameObject lawItemPrefab;
	public TMP_Dropdown countryDropdown;
	List<string> countryNames = new List<string>();

	private void Start () {
		countryDatabase.databaseReady += OnDatabaseReady;
	
	}

	private void OnDatabaseReady () {
		foreach (var country in countryDatabase.countries) {
			countryNames.Add (country.name);
		}

		PopulateList ();
	}


	public void PopulateList(){
		countryDropdown.AddOptions (countryNames);
		countryDropdown.value = 0;
		countryDropdown.onValueChanged.Invoke (0);
	}

	public void UpdateList (int country) {
		StartCoroutine (UpdateListCoroutine (country));
	}

	private IEnumerator UpdateListCoroutine (int country) {
		foreach (Transform transform in parent) {
			Destroy (transform.gameObject);
		}
		yield return null;
		foreach (Law law in countryDatabase.countries [country].laws) {
			Instantiate (lawItemPrefab, parent).GetComponent<LawItem> ().Law = law;
		}
	}

}
