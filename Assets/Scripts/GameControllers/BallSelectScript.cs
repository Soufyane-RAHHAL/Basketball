using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class BallSelectScript : MonoBehaviour {
	private List<Button> buttons =new List<Button>();
	// Use this for initialization
	void Awake () {
		GetButtonsAndAddListner ();
	}
	
	// Update is called once per frame
	void GetButtonsAndAddListner (){
		GameObject[] btns = GameObject.FindGameObjectsWithTag ("MainBall");

		for (int i = 0; i < btns.Length; i++) {
			buttons.Add (btns[i].GetComponent<Button>());
			buttons [i].onClick.AddListener (()=> SelecABall ());
		}
	}
	public void SelecABall (){
		int index = int.Parse (UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
		if (GameManger.instance != null)
			GameManger.instance.SetBallIndex (index);
	}
}
