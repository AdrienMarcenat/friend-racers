using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour 
{
	private Rigidbody2D body  ; // The two players share the same body, that's the point of the game
	private Vector2 movePoints; // Represent the current number of movements the players are allowed to do 
	private int movePointsMaxR; // The maximum number of movements the right player can do, can be changed by items
	private int movePointsMaxL; // The maximum number of movements the left player can do, can be changed by items
	private int linePlayerR   ; // The line where the right player is
	private int linePlayerL   ; // The line where the left player is

	public float velocity    ; // The velocity of the shared body, depends on the chosen diffilcuty and items
	public int movePointsInit; // The initial number of movements granted to the players
	public int numberOfLine  ; /* The number of lines in the level is numberOfLine*2 + 1.
								  The line 0 is in the middle (so lines can have a negative number) */

	// Use this for initialization
	void Start () 
	{
		body = GetComponent<Rigidbody2D> ();
		body.velocity = new Vector3 (0.0f, velocity, 0.0f);
		movePoints = new Vector2 (movePointsInit, movePointsInit);
		movePointsMaxR = movePointsInit;
		movePointsMaxL = movePointsInit;
		linePlayerL = -1;
		linePlayerR = 1;
	}
	
	// Update is called once per frame
	void Update () 
	{
		bool rightPlayerR = Input.GetButtonDown ("right") && movePoints.x > 0 && linePlayerR < numberOfLine ;
		bool leftPlayerR  = Input.GetButtonDown ("left" ) && movePoints.x > 0 && linePlayerL > -numberOfLine;
		bool rightPlayerL = Input.GetButtonDown (  "D"  ) && movePoints.y > 0 && linePlayerR < numberOfLine ;
		bool leftPlayerL  = Input.GetButtonDown (  "Q"  ) && movePoints.y > 0 && linePlayerL > -numberOfLine;

		if (rightPlayerR || leftPlayerR) 
		{
			movePoints.x = Mathf.Clamp (movePoints.x - 1, 0, movePointsMaxR);
			movePoints.y = Mathf.Clamp (movePoints.y + 1, 0, movePointsMaxL);
		} 
		else if (rightPlayerL || leftPlayerL) 
		{
			movePoints.y = Mathf.Clamp (movePoints.y - 1, 0, movePointsMaxL);
			movePoints.x = Mathf.Clamp (movePoints.x + 1, 0, movePointsMaxR);
		}
			
		if (rightPlayerR || rightPlayerL) 
		{
			linePlayerL += 1;
			linePlayerR += 1;
			transform.position = new Vector3 (transform.position.x + 1.0f, transform.position.y, transform.position.z);
		}
		else if (leftPlayerR || leftPlayerL) 
		{
			linePlayerL -= 1;
			linePlayerR -= 1;
			transform.position = new Vector3 (transform.position.x - 1.0f, transform.position.y, transform.position.z);
		}
	}

	void FixedUpdate()
	{
		
	}
}
