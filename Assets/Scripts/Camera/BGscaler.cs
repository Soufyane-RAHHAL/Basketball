using UnityEngine;
using System.Collections;

public class BGscaler : MonoBehaviour {
	
	public float widthuser, heightuser, xpositionuser, ypositionuser;
	private float widthobj, heightobj, xpositionobj, ypositionobj;
	float height ;
	float width ;
	// Use this for initialization
	void Start () {
		
	}
	void Update(){
		ubdatethefuck ();
	}
	void ubdatethefuck (){
		height = Camera.main.orthographicSize * 2f;
		width = height * Screen.width / Screen.height;

		widthobj=(width*widthuser)/100;
		heightobj=(height*heightuser)/100;
		xpositionobj=(width*xpositionuser)/100;
		ypositionobj=(width*ypositionuser)/100;
		if(widthobj!=0||heightobj!=0)
		transform.localScale = new Vector3 (widthobj, heightobj, 0);
		transform.position = new Vector3 (xpositionobj, ypositionobj, 0);
	}

}
