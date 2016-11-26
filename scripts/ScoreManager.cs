using UnityEngine;
using System.Collections;

public class ScoreManager : MonoBehaviour {

	private int score;

	// Use this for initialization
	void Start () {
		score = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void OnCollision(string tag)
	{
		if (tag == "Obstacle")
			score = Mathf.Clamp (score - 100, 0, int.MaxValue);
		if (tag == "Coin")
			score += 200;

		print (score);
	}
}
