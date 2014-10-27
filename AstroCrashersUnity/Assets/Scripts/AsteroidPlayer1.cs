using UnityEngine;
using System.Collections;

public class AsteroidPlayer1 : MonoBehaviour {

	public float accelerationForce = 10f;
	public float rotationForce = 3f;
	public float teleportDistance = 5.0f;
	public GameObject TeleportMarker;

	public float shootCooldown = 0.1f;
	float _cooldown;

	public float markerSpeed = 5.0f;

	public float maxSpeed = 10.0f;

	public LaserBeam beamPrefab;
	private float _rotation;

	void FireBeam()
	{
		var beam = GameObject.Instantiate (beamPrefab) as LaserBeam;
		beam.transform.position = transform.position + transform.right * 1.5f;
		beam.transform.rotation = transform.rotation;
		beam.Fire ();
		_cooldown = shootCooldown;
	}

	void Update () 
	{
		
		float markerXAxis = Input.GetAxis("RightStickHorizontal1");
		float markerYAxis = Input.GetAxis ("RightStickVertical1");

		TeleportMarker.transform.position += new Vector3 (markerXAxis, markerYAxis, 0.0f);


		float rotation = Input.GetAxis("Horizontal1");
		float acceleration = 0.0f; // = Input.GetAxis("Vertical");



		if (Input.GetKeyDown (KeyCode.Joystick1Button6))
		{
			Debug.Log("L2");
		}

		float LTRT = Input.GetAxis ("LTRT1");

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

		if (Input.GetButton("X1"))
		{
			acceleration = -1.0f;
			
			Debug.Log("p1 X");
		}

		if (Input.GetButtonDown("L1 1"))
		{
			var tempPos = TeleportMarker.transform.position;
			
			TeleportMarker.transform.position = transform.position;
			
			transform.position = tempPos;
			
			
			//forward flash
			//transform.position += transform.right * teleportDistance;
			
			Debug.Log("L1 1, teleport");
		}




		_rotation -= rotation * rotationForce;
		
		if (_rotation > 360.0f)
			_rotation -= 360.0f;
		
		if (_rotation < -360.0f)
			_rotation += 360.0f; 
		
		rigidbody2D.MoveRotation(_rotation);
		TeleportMarker.rigidbody2D.MoveRotation(_rotation);
		
		//rigidbody2D.AddTorque(-rotation * rotationForce);
		rigidbody2D.AddForce(transform.right * acceleration * accelerationForce);


		if (rigidbody2D.velocity.x > maxSpeed)
		{
			rigidbody2D.velocity = new Vector2(maxSpeed, rigidbody2D.velocity.y);
		}

		if (rigidbody2D.velocity.y > maxSpeed)
		{
			rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, maxSpeed);
		}
		

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
