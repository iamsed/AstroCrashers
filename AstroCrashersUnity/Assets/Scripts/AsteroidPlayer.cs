using UnityEngine;
using System.Collections;

public class AsteroidPlayer : AstroBehaviour {

	public float accelerationForce = 10f;
	public float rotationForce = 3f;
	public float teleportDistance = 5.0f;
	public GameObject TeleportMarker;
	
	public float shootCooldown = 0.1f;
	
	public float markerSpeed = 5.0f;
	
	public float maxSpeed = 10.0f;
	
	public LaserBeam beamPrefab;

	protected float _cooldown;
	protected float _rotation;

	protected void FireBeam()
	{
		var beam = GameObject.Instantiate (beamPrefab) as LaserBeam;
		beam.transform.position = transform.position + transform.right * 1.5f;
		beam.transform.rotation = transform.rotation;
		beam.Fire ();
		_cooldown = shootCooldown;
	}

	protected void Teleport()
	{
		var tempPos = TeleportMarker.transform.position;
		TeleportMarker.transform.position = transform.position;
		transform.position = tempPos;

		//forward flash
		//transform.position += transform.right * teleportDistance;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	protected void UpdateMovement (float rotation, float acceleration) {
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
	}
}
