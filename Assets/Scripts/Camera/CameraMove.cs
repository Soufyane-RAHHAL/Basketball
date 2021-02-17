using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour {

	private  float offsetY;
	private float height , width;
	// Use this for initialization
	void Start () {
		height = Camera.main.orthographicSize * 2f;
		width = height * Screen.width / Screen.height;
		offsetY = width/4;

	}

	// Update is called once per frame
	void Update () {
//		if (PlayerScipt.instance != null) {
//
//				MoveThecamera ();
//
//		}
	}
	void MoveThecamera(){
		Vector3 temp = transform.position;
//		temp.x =PlayerScipt.instance.GetpostionX()+offsetY;
		transform.position = temp;
	}
}
