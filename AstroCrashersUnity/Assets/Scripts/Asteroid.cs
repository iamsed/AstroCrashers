using UnityEngine;
using System.Collections;

public class Asteroid : MonoBehaviour {


	public float RotationSpeed;
	public float FlightSpeed;

	// Use this for initialization
	void Start () {
		rigidbody2D.AddTorque(RotationSpeed);
		
		
	}
	
	// Update is called once per frame


	bool notfirst = false;
	void Update () {
		if (notfirst)
						return;

		notfirst = true;
		rigidbody2D.AddForce(transform.right * FlightSpeed);
		
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		kill ();
		Debug.Log ("Bum bum");
	}
	
	private void kill()
	{

		GameObject.Destroy (this.gameObject);
		
	}
}
