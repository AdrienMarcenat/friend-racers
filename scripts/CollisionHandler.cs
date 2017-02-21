using UnityEngine;
using System.Collections;

public class CollisionHandler : MonoBehaviour 
{
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		SendMessage ("OnCollision", other.tag);
		if (other.tag == "Coin")
			other.gameObject.SetActive(false);
	}
}
