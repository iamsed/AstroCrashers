using UnityEngine;
using System.Collections;

public class WarpScreen : MonoBehaviour {
	bool isWrappingX = false;
	bool isWrappingY = false;
	Renderer[] renderers;
	// Use this for initialization
	void Start () {
		renderers = GetComponentsInChildren<Renderer>();
	}
	
	// Update is called once per frame
	void Update () {
		WrapScreen ();	
	}

	bool CheckRenderers()
	{
		foreach(var renderer in renderers)
		{
			// If at least one render is visible, return true
			if(renderer.isVisible)
			{
				return true;
			}
		}
		
		// Otherwise, the object is invisible
		return false;
	}

	void WrapScreen()
	{
		var isVisible = CheckRenderers();
		
		if(isVisible)
		{
			isWrappingX = false;
			isWrappingY = false;
			return;
		}
		
		if(isWrappingX && isWrappingY) {
			return;
		}


		var cam = Camera.main;

		var WRAP = cam.ViewportToWorldPoint (new Vector3 (1.0f, 1.0f));
		
		var viewportPosition = cam.WorldToViewportPoint(transform.position);
		var newPosition = transform.position;
		
		if (!isWrappingX && viewportPosition.x > 1)
		{
			newPosition.x -= WRAP.x * 2.0f;
			
			isWrappingX = true;
		}

		if(!isWrappingX && viewportPosition.x < 0)
		{
			newPosition.x += WRAP.x * 2.0f;
			
			isWrappingX = true;
		}


		
		if (!isWrappingY && viewportPosition.y > 1)
		{
			newPosition.y -= WRAP.y * 2.0f;
			
			isWrappingY = true;
		}

		if (!isWrappingY && viewportPosition.y < 0) 
		{
			newPosition.y += WRAP.y * 2.0f;
			
			isWrappingY = true;

		}
		
		transform.position = newPosition;
	}
}
