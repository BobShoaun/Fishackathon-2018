using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using Assets.SimpleAndroidNotifications;

public class UIManager : MonoBehaviour {

	public GameObject[] pages;
	public List<MovingObject> movingObject;

	public CountryDatabase countryDatabase;
	public TextMeshProUGUI titleText;

	void Start () {
		for (int i = 0; i < movingObject.Count; i++) {
			
			if (movingObject [i].buttonTriggers.Count == 0) {
				continue;
			}
			for(int j = 0; j < movingObject[i].buttonTriggers.Count; j++){
				MovingObject obj = movingObject[i];
				movingObject[i].buttonTriggers[j].onClick.AddListener (() => Move (obj));
				movingObject[i].buttonTriggers[j].onClick.AddListener (movingObject[i].callback.Invoke);
			}
		}
	}

	//0 - home
	public void SwitchPage (int index) {
		foreach (var page in pages)
			page.SetActive (false);
		pages [index].SetActive (true);
		titleText.text = pages [index].name;
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

	public void DisplayMenu(bool enable){
		foreach (MovingObject o in movingObject) {
			if((o.objectToMove.name == "MenuBar") && o.offset.x == 1 && enable == true){
				Move (o);
			}else if((o.objectToMove.name == "MenuBar") && o.offset.x == -1 && enable == false){
				Move (o);
			}
		}
	}


	public void DisableTouch(bool state){
		FindObjectOfType<EventSystem> ().enabled = state;
	}

	public void SendPushUp(string title, string message){
		NotificationManager.Send (new System.TimeSpan (0, 0, 0, 0), title, message, Color.red, NotificationIcon.Bell);
	}

}

[System.Serializable]
public class UnityEventBool : UnityEvent<bool> {
	
}
