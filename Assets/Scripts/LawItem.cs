using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LawItem : MonoBehaviour {

	TextMeshProUGUI titleText;
	TextMeshProUGUI descriptionText;
	TextMeshProUGUI punishmentTitleText;
	TextMeshProUGUI punishmentDescriptionText;

	public Law Law {
		set { 
			titleText.text = value.title;
			descriptionText.text = value.description;
			punishmentTitleText.text = value.punishmentTitle;
			punishmentDescriptionText.text = value.punishmentDescription;

		}
	}

}
