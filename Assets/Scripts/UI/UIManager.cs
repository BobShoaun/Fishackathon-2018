using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

public class UIManager : MonoBehaviour {

	public GameObject[] pages;
	public List<MovingObject> movingObject;
	public TMP_Dropdown countryDropdown;
	public CountryDatabase countryDatabase;

	List<string> countryNames = new List<string>();

	void Start () {
		
		foreach (var country in countryDatabase.countries) {
			countryNames.Add (country.name);
		}

		PopulateList ();

		foreach (MovingObject o in movingObject) {
			if (o.buttonTriggers == null)
				continue;
			foreach(Button but in o.buttonTriggers){
				but.onClick.AddListener (() => Move (o));
				but.onClick.AddListener (o.callback.Invoke);
			}

		}
	}

	public void SwitchPage (int index) {
		foreach (var page in pages)
			page.SetActive (false);
		pages [index].SetActive (true);
	}

	void Move (MovingObject obj) {
		Vector2 finalOffset = new Vector2( obj.offset.x * (obj.objectToMove.GetComponent<RectTransform> ().rect.width * GetComponent<Canvas> ().scaleFactor),
			obj.offset.y *(obj.objectToMove.GetComponent<RectTransform> ().rect.height * GetComponent<Canvas> ().scaleFactor) );

		StartCoroutine (MoveAnimation(obj.objectToMove.GetComponent<RectTransform>(), finalOffset, obj.offsetTime));
	}

	IEnumerator MoveAnimation(RectTransform transform, Vector2 offset, float offsetTime){
		float percent = 0;
		Vector2 startingPos = transform.position;

		while(percent < 1.0f){
			percent += Time.deltaTime / offsetTime;
			transform.position = Vector2.Lerp (startingPos, startingPos + offset, percent);
			yield return null;
		}
	}

	public void DisplayPage(GameObject objectToShow){
		objectToShow.SetActive (true);
	}

	public void PopulateList(){
		countryDropdown.AddOptions (countryNames);
	}

}

[System.Serializable]
public class UnityEventBool : UnityEvent<bool> {
	
}
