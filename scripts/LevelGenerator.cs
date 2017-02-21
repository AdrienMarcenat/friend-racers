using UnityEngine;
using System.Collections;
using SimpleJSON;
using System.IO;
using System.Collections.Generic;

public class LevelGenerator : MonoBehaviour 
{
	private static LevelGenerator instance; // Singleton
	public string fileName;

	private string levelConfig;
	public GameObject obstacle;
	public GameObject coin;

	void Awake() 
	{
		if (instance == null) 
		{
			DontDestroyOnLoad (gameObject);
			instance = this;
		} 
		else if (instance != this)
			Destroy (gameObject);
	}

	// Use this for initialization
	void Start () 
	{
		levelConfig = readJSON ();
		generate ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private string readJSON()
	{
		StreamReader sr = new StreamReader (Application.dataPath + "/friend-racers/config/" + fileName);
		string content = sr.ReadToEnd ();
		sr.Close ();

		return content;
	}

	private void generate()
	{
		JSONNode json = JSON.Parse (levelConfig);

		string tile = json ["tiles"][0]["tile"].Value;
		string[] tileSplit = tile.Split (' ');
		ArrayList lines = new ArrayList();

		for (int i = 0; i < tileSplit.Length; i++) {
			string line = tileSplit [i];
			if (line != "")
				lines.Add(line);
		}

		for (int i = 1; i <= lines.Count; i++) 
		{
			string line = lines [lines.Count - i] as string;
			for (int j = 0; j < line.Length; j++) 
			{
				GameObject newObject = null;
				if (line [j] == 'O') 
				{
					newObject = Instantiate (obstacle);
				}
				if (line [j] == 'C') 
				{
					newObject = Instantiate (coin);
				}
				if(newObject != null)
					newObject.transform.position = new Vector3 (j, i, 0);
			}
		}
	}
}