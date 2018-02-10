using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LawItem : MonoBehaviour {

	public TextMeshProUGUI titleText;
	public Text descriptionText;
	public Text punishmentTitleText;
	public Text punishmentDescriptionText;

	public Law Law {
		set { 
			titleText.text = value.title;
			descriptionText.text = value.description;
			punishmentTitleText.text = value.punishmentTitle;
			punishmentDescriptionText.text = value.punishmentDescription;

		}
	}

}
