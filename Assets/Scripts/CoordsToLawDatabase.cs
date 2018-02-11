using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Newtonsoft.Json;
using System.IO;
using Location;

public class Law {

	public string description; // do not fish here
	//public string punishmentTitle; // PUNSHDS102 OF FEDA
	public string punishmentDescription; // u got 

	public Law () {
	}
//
//	public override string ToString () {
//		//string lawString = title;
//		if (punishmentTitle != null)
//			lawString += " \nPunishment: "+ punishmentTitle;
//		return lawString;
//	}

}

public class Country {

	public string name;
	public GeoCoordinate[] coordinates;
	public Law[] laws;

	public Country () {
	}

}
