using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour {
	
	public List<MovingObject> movingObject;
	public TMP_Dropdown countryDropdown;
	public CountryDatabase countryDatabase;

	public event System.Action<bool> MenuRunning;
	List<string> countryNames = new List<string>();

	void Start(){
		foreach (var country in countryDatabase.countries) {
			countryNames.Add (country.name);
		}

		PopulateList ();

		foreach (MovingObject o in movingObject) {
			o.OnBlockClick += Move;

			if (o.buttonTriggers == null)
				continue;
			foreach(Button but in o.buttonTriggers){
				but.onClick.AddListener (o.OnClick);
			}

		}
	}

	void Move(MovingObject obj){
		Vector2 finalOffset = new Vector2( obj.offset.x * (obj.objectToMove.GetComponent<RectTransform> ().rect.width * GetComponent<Canvas> ().scaleFactor),
			obj.offset.y *(obj.objectToMove.GetComponent<RectTransform> ().rect.height * GetComponent<Canvas> ().scaleFactor) );

		//MenuRunning (true);
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
		//MenuRunning (false);
	}

	public void DisplayPage(GameObject objectToShow){
		objectToShow.SetActive (true);
	}

	public void PopulateList(){
		countryDropdown.AddOptions (countryNames);
	}

}
