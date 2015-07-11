using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;
using System.Collections;

public class GameController : MonoBehaviour {

	public GameObject[] hazards;
	public Vector3 spawnValues;
	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;
	public Text scoreText;
	public Text gameOverText;
	public GameObject restartButton;
	public static int counterForAds = counterReset;

	private bool gameOver;
	private int score;
	private const int counterReset = 3;


	void Start() {

		gameOver = false;
		gameOverText .text = "";
		restartButton .SetActive (false);
		score = 0;
		UpdateScore ();
		StartCoroutine(SpawnWaves());
	}

	public static void resetCounter() {
		counterForAds = counterReset;
	}

	void Awake() {
		if (Advertisement.isSupported) {
			Advertisement.allowPrecache = true;
			Advertisement.Initialize("37029", false);
		}
	}

	IEnumerator SpawnWaves()
	{
		yield return new WaitForSeconds (startWait);
		while (true) {
			for (int i = 0; i < hazardCount; i++){
				GameObject hazard = hazards [Random .Range (0, hazards .Length )];
				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
				Instantiate (hazard, spawnPosition, Quaternion .identity);
				yield return new WaitForSeconds (spawnWait );
			}
			yield return new WaitForSeconds (waveWait);

			if(gameOver ){
				restartButton .SetActive (true);
				break;
			}
		}
	}

	public void AddScore(int newScoreValue)
	{
		score += newScoreValue;
		UpdateScore ();
	}

	void UpdateScore()
	{
		scoreText.text = "Score: " + score;
	}

	public void GameOver()
	{
		gameOverText.text = "Game Over";
		gameOver = true;
		counterForAds--;
		
		if (counterForAds <= 0) {
			resetCounter();
			Advertisement.Show(null, new ShowOptions {
				pause = true,
				resultCallback = result => {
					
				}
			});
		}
	}

	public void RestartGame()
	{
		Application.LoadLevel("DoubleShooter");
	}

	public void QuitGame()
	{
		Application .Quit();
	}
}
