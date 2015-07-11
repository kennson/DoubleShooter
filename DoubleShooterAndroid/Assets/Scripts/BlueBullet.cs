using UnityEngine;
using System.Collections;

public class BlueBullet : MonoBehaviour {

	public float speed;
	
	void Start () 
	{
		rigidbody .velocity = transform .up * speed;
	}
}
