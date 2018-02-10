using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Block : MonoBehaviour {

	public event System.Action<Block> OnBlockClick;
	public Vector2 offset;
	public float offsetTime = .1f;
	public GameObject objectToMove;
	public Button buttonTrigger;

	void Start(){
		if(objectToMove == null)
			objectToMove = this.gameObject;
		
		buttonTrigger.onClick.AddListener (OnClick);
	}

	public void OnClick(){
		//Debug.Log ("click");
		if (OnBlockClick != null) {
			OnBlockClick (this);
		}
	}

}
