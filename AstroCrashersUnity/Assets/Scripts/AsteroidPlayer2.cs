using UnityEngine;
using System.Collections;

public class AsteroidPlayer2 : AsteroidPlayer {
	

	void Update () 
	{
		
		float markerXAxis = Input.GetAxis("RightStickHorizontal2");
		float markerYAxis = Input.GetAxis ("RightStickVertical2");
		
		TeleportMarker.transform.position += new Vector3 (markerXAxis, markerYAxis, 0.0f);
		
		
		float rotation = Input.GetAxis("Horizontal2");
		float acceleration = 0.0f; // = Input.GetAxis("Vertical");
		

		
		float LTRT = Input.GetAxis ("LTRT2");
		
		if (LTRT > 0.0f) 
		{
			Debug.Log("R2 (RT), przyspiesza");
			acceleration = 1.0f * LTRT;
		}

		_cooldown -= Time.deltaTime;
		if (LTRT < 0.0f) 
		{
			if(_cooldown < 0.0f) FireBeam();
			Debug.Log("L2 (LT), pif paf");
			
		}

		if (Input.GetButton("X2"))
		{
			acceleration = -1.0f;
			
			Debug.Log("p2 X");
		}
		
		if (Input.GetButtonDown("L1 2"))
		{
			Teleport();
			Debug.Log("L1 2, teleport");
		}
		
		UpdateMovement(rotation, acceleration);
		
		
		
		//Input.GetAxis(
	}

	void OnGUI()
	{
		GUI.color = Color.cyan;
		GUI.Box (new Rect (0, 0, 200, 80), p1Points.ToString ());
	}

	int p1Points = 0;
	void OnCollisionEnter2D(Collision2D collision)
	{


		p1Points++;
		Debug.Log ("Bum bum");
	}
}
