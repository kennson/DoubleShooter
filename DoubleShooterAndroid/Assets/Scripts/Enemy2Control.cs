using UnityEngine;
using System.Collections;

public class Enemy2Control : MonoBehaviour {

	public float speed;
	public float fireRate;
	public float nextFire;
	public GameObject shot;
	public Transform shotSpawn;
	
	void Start () 
	{
		rigidbody .velocity = -transform .up * speed;
	}

	void Update()
	{
		if (Time .time > nextFire) {
			nextFire = Time.time + fireRate;
			Instantiate (shot, shotSpawn .position, shotSpawn .rotation);
			audio .Play ();
		}
	}
}
