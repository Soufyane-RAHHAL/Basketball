using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GamePlayController : MonoBehaviour {
	private int seconds=90;
	[HideInInspector]
	public int Gaols;
	[SerializeField]
	private Text timeText,GoalsText,YourScoreText,heightScoreText;
	[SerializeField]
	private GameObject panel,player;

	public void GoToMainMenu(){
		SceneManager.LoadScene ("MainMenu");
	}
	void Start(){
		StartCoroutine (time());
	}
	void Update(){
		if (seconds > 0) {
			timeText.text = "Time : " + seconds;
			GoalsText.text = "Goals : " + Gaols;
		}
	}
	IEnumerator time(){
		yield return new WaitForSeconds (1);
		if (seconds > 0) {
			seconds--;
		}else
		if (seconds <= 0) {
				YourScoreText.text = "Your Score : " + Gaols;
				heightScoreText.text="Height Score : ";
				panel.SetActive (true);
			
				player.SetActive (false);
			}
				
		StartCoroutine (time());
	}
	public void restartButtonFunction(){
		SceneManager.LoadScene ("GamePlay");
	}
	public void HomeButtonFunction(){
		SceneManager.LoadScene ("MainMenu");
	}
}
