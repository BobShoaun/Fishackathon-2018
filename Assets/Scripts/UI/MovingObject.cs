using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class MovingObject {
	
	public event System.Action<MovingObject> OnBlockClick;
	public Vector2 offset;
	public float offsetTime = .1f;
	public GameObject objectToMove;
	public List<Button> buttonTriggers;

	public void OnClick(){
		//Debug.Log ("click");
		if (OnBlockClick != null) {
			OnBlockClick (this);
		}
	}

}
