using UnityEngine;
using System.Collections;

[System.Serializable]
public class BlueBoundary
{
	public float xMin, xMax, yMin, yMax;
}

public class BlueController : MonoBehaviour {

	public float speed;
	public BlueBoundary boundary;
	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;
	public float nextFire;
	public BlueTouch touchPad;

	void Update()
	{
		if (touchPad.CanFire() && Time .time > nextFire) {
			nextFire = Time.time + fireRate ;
			Instantiate (shot, shotSpawn .position ,shotSpawn .rotation );
			audio .Play();
		}
	}

	void FixedUpdate() 
	{
		Vector2 direction = touchPad .GetDirection ();
		Vector3 movement = new Vector3 (direction .x, direction .y, 0.0f);
		rigidbody .velocity = movement * speed;
		rigidbody .position = new Vector3 (
				Mathf .Clamp (rigidbody .position .x, boundary .xMin, boundary .xMax),
				Mathf .Clamp (rigidbody .position .y, boundary .yMin, boundary .yMax),
				0.0f);
	}
}
