using UnityEngine;
using System.Collections;

public class Enemy2Bullet : MonoBehaviour {

	public float speed;
	
	void Start () 
	{
		rigidbody .velocity = -transform .up * speed;
	}
}
