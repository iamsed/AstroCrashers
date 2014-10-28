using UnityEngine;
using System.Collections;

public class AstroBehaviour : MonoBehaviour {

	public void Tween(IEnumerator coroutine, float secondsDelay)
	{
		StartCoroutine(_tween(coroutine, secondsDelay));
	}

	private IEnumerator _tween(IEnumerator coroutine, float secondsDelay)
	{
		yield return new WaitForSeconds(secondsDelay);
		StartCoroutine(coroutine);
	}
}
