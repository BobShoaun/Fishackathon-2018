using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CoordsToLawDatabase : MonoBehaviour {

	public Law[] Laws;

	public IEnumerable<Law> this [Vector2 coords] {
		get { 
			return Laws.Where (law => law.coordinates.Contains (coords));
		}
	}

	private void Start () {
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
	}

}

public class Law {

	public Vector2 [] coordinates;
	public string statement;

	public Law (Vector2[] coords, string statement) {
		coordinates = coords;
		this.statement = statement;
	}

	public override string ToString ()
	{
		return statement;
	}

}
