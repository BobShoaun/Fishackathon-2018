using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

[System.Serializable]
public class MovingObject {
	
	public Vector2 offset;
	public float offsetTime = .1f;
	public GameObject objectToMove;
	public List<Button> buttonTriggers;
	public UnityEvent callback;

}
