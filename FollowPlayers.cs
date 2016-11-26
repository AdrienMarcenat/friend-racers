using UnityEngine;
using System.Collections;

public class FollowPlayers : MonoBehaviour 
{
	Transform players;

	// Use this for initialization
	void Start () 
	{
		players = GameObject.FindGameObjectWithTag ("Player").transform;
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.position = new Vector3 (transform.position.x, players.position.y, transform.position.z);
	}
}
