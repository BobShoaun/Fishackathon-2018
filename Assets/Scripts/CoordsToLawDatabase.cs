using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Newtonsoft.Json;
using System.IO;

public class CoordsToLawDatabase : MonoBehaviour {

	public Law[] Laws;

	public IEnumerable<Law> this [Vector2 coords] {
		get { 
			return Laws.Where (law => law.coordinates.Contains (coords));
		}
	}

	private void Start () {
		//WriteJsonDatabase ();
		ReadJsonDatabase ();
	}

	private void WriteJsonDatabase () {
		Laws = new Law[] {
			new Law (new Vector2 [] { 
				new Vector2 (121, 300), 
				new Vector2 (300, 400), 
				new Vector2 (400, 323)}, "You cannot fish with a net here!"),
			new Law (new Vector2 [] { 
				new Vector2 (121, 300), 
				new Vector2 (222, 333), 
				new Vector2 (111, 222)}, "DO NOT FISH HERE ITS ILLEGAL"),
			new Law (new Vector2 [] { 
				new Vector2 (555, 444), 
				new Vector2 (398, 120), 
				new Vector2 (900, 1090)}, "YOU CAN FISH ANYTHING U WANT")
		};
		string json = JsonConvert.SerializeObject (Laws, Formatting.Indented);

		File.WriteAllText (Path.Combine (Application.streamingAssetsPath, "Law Database.json"), json);

	}


	private void ReadJsonDatabase () {
		string json = File.ReadAllText (Path.Combine (Application.streamingAssetsPath, "Law Database.json"));
		Laws = JsonConvert.DeserializeObject<Law[]> (json);

	}


}

public class Law {

	public Vector2 [] coordinates;
	public string statement;
	public string punishment;

	public Law (Vector2[] coords, string statement) {
		coordinates = coords;
		this.statement = statement;
	}

	public override string ToString ()
	{
		string lawString = statement;
		if (punishment != null)
			lawString += " \nPunishment: "+ punishment;
		return lawString;
	}

}
