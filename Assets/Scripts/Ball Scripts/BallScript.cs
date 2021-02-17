using UnityEngine;
using System.Collections;

public class BallScript : MonoBehaviour {
	private int touchedGround = 0;
	private GamePlayController gpController;

	void Awake(){
		gpController = GameObject.Find ("GamePlay Controller").GetComponent<GamePlayController>();
	}
	void OnCollisionEnter2D(Collision2D target){
		if (target.gameObject.tag == "Holder") {
			if (GameManger.instance != null) {
				if (Random.Range (0, 2) > 1) {
					GameManger.instance.PlaySound (3);
				} else {
					GameManger.instance.PlaySound(4);
				}
			}
		}

		if (target.gameObject.tag == "Ram"||target.gameObject.tag == "Table") {
			if (GameManger.instance != null) {
				if (Random.Range (0, 2) > 1) {
					GameManger.instance.PlaySound (2);
				} else {
					GameManger.instance.PlaySound(5);
				}
			}
		}
		if (target.gameObject.tag == "Ground") {
			touchedGround++;
			if (touchedGround <= 3) {
				if (GameManger.instance != null) {
					if (Random.Range (0, 2) > 1) {
						GameManger.instance.PlaySound (3);
					} else {
						GameManger.instance.PlaySound (4);
					}
				}
			}
		}
	}
	void OnTriggerEnter2D(Collider2D target){
		if (target.tag == "Net") {
			if (GameManger.instance != null) {
				GameManger.instance.PlaySound (1);
				gpController.Gaols++;
			}
		}
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
