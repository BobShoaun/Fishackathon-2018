using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Newtonsoft.Json;
using System.IO;
using Location;

public class CountryDatabase : MonoBehaviour {

	public Country[] countries;

	public List<Country> countryList = new List<Country> ();
	public List<GeoCoordinate> coordsList = new List<GeoCoordinate> ();

	private void AssignLists () {
		
		foreach (Country country in countries)
			foreach (GeoCoordinate coords in country.coordinates) {
				countryList.Add (country);
				coordsList.Add (coords);
			}
			
	}

	public Country this [string name] {
		get { 
			return countries.First (country => country.name == name);
		}
	}

	public Country this [GeoCoordinate coords] {
		get { 
			return countries.First (country => country.coordinates.Contains (coords));
		}
	}


	private void Awake () {
		//WriteJsonDatabase ();
		ReadJsonDatabase ();
		AssignLists ();
		StartCoroutine (Write ());
	}

	private IEnumerator Write () {
		yield return new WaitForSeconds (10);
		WriteJsonDatabase ();
	}


	private void WriteJsonDatabase () {

//		countries = new Country[] {
//			new Country { 
//				name = "Malaysia",
//				coordinates = new Vector2[] {
//					new Vector2 (111, 222),
//					new Vector2 (222, 333)
//				},
//				laws = new Law[] {
//					new Law {
//						title = "LAW OF LMAO",
//						description = "DO NOT FISH HERE!",
//						punishmentTitle = "DEATH SENTENCE",
//						punishmentDescription = "Die"
//					},
//					new Law {
//						title = "FISHING LAW 300",
//						description = "",
//						punishmentTitle = "DEATH SENTENCE",
//						punishmentDescription = "Die"
//					}
//				}
//			},
//			new Country { 
//				name = "Indonesia",
//				coordinates = new Vector2[] {
//					new Vector2 (444, 555),
//					new Vector2 (999, 1000)
//				},
//				laws = new Law[] {
//					new Law {
//						title = "LAW OF INDO",
//						description = "DO NOT PEE IN THE SEA!",
//						punishmentTitle = "CUT",
//						punishmentDescription = "cut"
//					}
//				}
//			},
//		};
		string json = JsonConvert.SerializeObject (countries, Formatting.Indented);
		File.WriteAllText (Path.Combine (Application.streamingAssetsPath, "Database2.json"), json);
	}


	private void ReadJsonDatabase () {
		string json = File.ReadAllText (Path.Combine (Application.streamingAssetsPath, "Database.json"));
		countries = JsonConvert.DeserializeObject<Country[]> (json);
	}

}