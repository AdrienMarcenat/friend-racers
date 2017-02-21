using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour 
{
	private int score;
	public Text text;

	// Use this for initialization
	void Start () 
	{
		score = 0;
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	private void OnCollision(string tag)
	{
		if (tag == "Obstacle")
			score = Mathf.Clamp (score - 100, 0, int.MaxValue);
		if (tag == "Coin")
			score += 200;

		text.text = score.ToString();
	}
}
