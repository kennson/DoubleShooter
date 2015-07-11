using UnityEngine;
using System.Collections;

public class DestroyEnemy2Bullet : MonoBehaviour {

	public GameObject explosion;

	private GameController gameController;

	void Start() 
	{
		GameObject gameControllerObject = GameObject .FindWithTag ("GameController");
			
		if (gameControllerObject != null) {
				gameController = gameControllerObject .GetComponent <GameController > ();	                                                                 
			}
		}

	void OnTriggerEnter(Collider other) 
	{
		if (other.tag == "Player") 
		{
			gameController .GameOver();	
			Instantiate (explosion, transform .position, transform .rotation);
			Destroy(other.gameObject);
			Destroy(gameObject);
		}
	}
}
