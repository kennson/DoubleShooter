using UnityEngine;
using System.Collections;

public class DestroyEnemy1 : MonoBehaviour {

	public int scoreValue;
	public GameObject explosion;

	private GameController gameController;

	void Start() 
	{
		GameObject gameControllerObject = GameObject .FindWithTag ("GameController");
		if (gameControllerObject != null) {
			gameController = gameControllerObject .GetComponent <GameController >();	                                                                 
		}
	}

	void OnTriggerEnter(Collider other) 
	{
		if (other.tag == "Boundary")
		{
			return;
		}

		if (other.tag == "PlayerBullet") {
			DestroyObjects();
			gameController .AddScore (scoreValue);
			Destroy(other.gameObject);
		}

		if (other.tag == "Player") 
		{
			DestroyObjects();
			gameController .GameOver();	
			Destroy(other.gameObject);
		}
	}

	void DestroyObjects()
	{
		Instantiate (explosion, transform .position, transform .rotation);
		Destroy(gameObject);
	}
}
