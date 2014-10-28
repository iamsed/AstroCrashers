using UnityEngine;
using System.Collections;

public class AsteroidPlayer1 : AsteroidPlayer {





	void Update () 
	{
		
		float markerXAxis = Input.GetAxis("RightStickHorizontal1");
		float markerYAxis = Input.GetAxis ("RightStickVertical1");

		TeleportMarker.transform.position += new Vector3 (markerXAxis, markerYAxis, 0.0f);

		float rotation = Input.GetAxis("Horizontal1");
		float acceleration = 0.0f; // = Input.GetAxis("Vertical");

		if(Input.GetKey(KeyCode.D))
		{
			rotation = 1.0f;
		}

		if(Input.GetKey(KeyCode.A))
		{
			rotation = -1.0f;
		}

		if (Input.GetKeyDown (KeyCode.Joystick1Button6))
		{
			Debug.Log("L2");
		}

		float LTRT = Input.GetAxis ("LTRT1");

		if(Input.GetKey(KeyCode.W)) LTRT = 1.0f;
		if(Input.GetKey(KeyCode.Space)) LTRT = -1.0f;

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

		if (Input.GetButton("X1") || Input.GetKey(KeyCode.S))
		{
			acceleration = -1.0f;
			
			Debug.Log("p1 X");
		}

		if (Input.GetButtonDown("L1 1") || Input.GetKeyDown(KeyCode.E))
		{
			Teleport();

			
			Debug.Log("L1 1, teleport");
		}



		UpdateMovement(rotation, acceleration);

		

		//Input.GetAxis(
	}

	void OnGUI()
	{
		GUI.color = Color.red;
		GUI.Box (new Rect (Screen.width - 200, 0, 200, 80), p1Points.ToString ());
	}
	
	int p1Points = 0;

	public void OnCollisionEnter2D(Collision2D collision)
	{
		p1Points++;
	}

}
