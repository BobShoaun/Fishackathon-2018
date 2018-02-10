using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour {

	int firstTime;

	// Use this for initialization
	void Start () {
		firstTime = PlayerPrefs.GetInt ("isFirstTime");

		if (firstTime == 0)
			StartTutorial ();
		else
			PlayerPrefs.SetInt ("isFirstTime", 1);

	}

	void StartTutorial(){


	}

	// Update is called once per frame
	void Update () {
		
	}
}
