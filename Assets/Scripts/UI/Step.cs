using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.Events;

[System.Serializable]
public class Step {

	public GameObject text;
	public int order;
	public UnityEvent callbacks;

}
