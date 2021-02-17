using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour {
	private Animator mainAnim,ballAnim;
	void Awake(){
		mainAnim = GameObject.Find ("Main Menu Buttons Holder").GetComponent<Animator>();
		ballAnim = GameObject.Find ("Select Balls Holder").GetComponent<Animator>();
	}
	public void PlayGame(){
		SceneManager.LoadScene ("GamePlay");
	}
	public void SelectBall(){
		mainAnim.Play ("FadeOut 0");
		ballAnim.Play ("FadeIn");
	}
	public void BackToMenu(){
		mainAnim.Play ("FadeIn");
		ballAnim.Play ("FadeOut");
	}
}
