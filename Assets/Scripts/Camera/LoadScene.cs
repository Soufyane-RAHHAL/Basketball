using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class LoadScene : MonoBehaviour {
	public float TimeDelay=1f;
	// Use this for initialization
	void Start () {
		Invoke ("StopTheGame",TimeDelay);
		Invoke ("LoadSceneMainMenu",TimeDelay);

	}
	
	void StopTheGame(){
		Time.timeScale = 0f;
	}
	void LoadSceneMainMenu(){
		SceneManager.LoadScene ("MainMenu");
		Time.timeScale = 1f;
	}
}
