using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ManageMenuUI : MonoBehaviour {

	public Canvas MainMenuCanvas;
	public Canvas TutorialCanvas;
	public Canvas CreditsCanvas;


	// Use this for initialization
	void Start () {
		TutorialCanvas.enabled = false;
		CreditsCanvas.enabled = false;
		MainMenuCanvas.enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void StartGame()
	{
		SceneManager.LoadScene ("TutorialLevel");
	}

	public void ToTutorialCanvas()
	{
		MainMenuCanvas.enabled = false;
		CreditsCanvas.enabled = false;
		TutorialCanvas.enabled = true; 
	}
	public void ToMainMenuCanvas()
	{
		MainMenuCanvas.enabled = true;
		CreditsCanvas.enabled = false;
		TutorialCanvas.enabled = false; 
	}
	public void ToCreditsCanvas()
	{
		MainMenuCanvas.enabled = false;
		CreditsCanvas.enabled = true;
		TutorialCanvas.enabled = false; 
	}

	public void QuitGame()
	{
		Application.Quit();
	}
}
