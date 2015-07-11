using UnityEngine;
using System.Collections;

public class Enemy1Control : MonoBehaviour {

	public float speed;
	
	void Start () 
	{
		rigidbody .velocity = -transform .up * speed;
	}
}
