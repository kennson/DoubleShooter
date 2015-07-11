using UnityEngine;
using System.Collections;

public class StartController : MonoBehaviour {

	public void StartGame()
	{
		Application.LoadLevel("DoubleShooter");
	}
	
	public void QuitGame()
	{
		Application .Quit();
	}
}
