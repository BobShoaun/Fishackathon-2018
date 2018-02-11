using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TutorialManager : MonoBehaviour {

	int firstTime;
	EventSystem eventSys;
	public List<Step> steps;
	bool tutEnabled = false;

	// Use this for initialization
	void Start () {
		eventSys = FindObjectOfType<EventSystem> ();

		firstTime = PlayerPrefs.GetInt ("isFirstTime");

		if (firstTime == 0)
			tutEnabled = true;
		else
			PlayerPrefs.SetInt ("isFirstTime", 1);

	}

	void StartTutorial(){
		if (currentIndex == 0) {
			eventSys.enabled = false;
			NextStep ();
		}

		if (Input.GetButtonDown("Fire1"))
			NextStep ();
	}

	int currentIndex = 0;
	void NextStep(){
		if (currentIndex >= steps.Count) { 
			tutEnabled = false;
			eventSys.enabled = true;

			foreach (Step s in steps)
				s.text.SetActive (false);

			return;
		}else if (currentIndex >= 1)
			steps [currentIndex - 1].text.SetActive (false);

		steps [currentIndex].text.SetActive (true);
		steps [currentIndex].callbacks.Invoke ();
		currentIndex++;

	}

	// Update is called once per frame
	void Update () {
		if (tutEnabled)
			StartTutorial ();
	}
}
