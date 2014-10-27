using UnityEngine;
using System.Collections;

public class LaserBeam : MonoBehaviour {
	public float Lifespan = 5.0f;
	float _lifespan;
	public float FireForce = 50.0f;
	// Use this for initialization
	void Start () {
	
	}

	bool fired = false;
	public void Fire()
	{
		_lifespan = Lifespan;
		fired = true;
		rigidbody2D.AddForce (transform.right * FireForce);
	}
	
	// Update is called once per frame
	void Update () {
		if (!fired)
						return;

		_lifespan -= Time.deltaTime;

		if (_lifespan < 0.0f) { kill ();
				}
		
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
