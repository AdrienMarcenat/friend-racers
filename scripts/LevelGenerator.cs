using UnityEngine;
using System.Collections;
using SimpleJSON;
using System.IO;

public class LevelGenerator : MonoBehaviour {

	private static LevelGenerator instance; // Singleton
	public string fileName;

	private string levelConfig;

	void Awake() {
		if (instance == null) {
			DontDestroyOnLoad (gameObject);
			instance = this;
		} else if (instance != this)
			Destroy (gameObject);
	}

	// Use this for initialization
	void Start () {
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

		print (json ["test"].Value);
	}
}
