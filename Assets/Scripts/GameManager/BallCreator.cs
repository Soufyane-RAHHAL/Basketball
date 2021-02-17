using UnityEngine;
using System.Collections;

public class BallCreator : MonoBehaviour {
	[SerializeField]
	private GameObject ball;
	[SerializeField]
	private Sprite[] ballImages;
	private float height ;
	private float width ;
	private float minX ;
	private float maxX ;
	private float MinY ;
	private float maxY ;

	// Use this for initialization
	void Awake(){
		height = Camera.main.orthographicSize ;
		width = height * Screen.width / Screen.height;
		minX = -width/7;
		 maxX = width - width / 10;
		MinY = -height+ height/ 10;
		maxY = height / 4;
	}

	public void CreatBall(int index ){
		GameObject gameBall = Instantiate (ball,new Vector3(Random.Range(minX,maxX),Random.Range(MinY,maxY),0),Quaternion.identity)as GameObject;
		gameBall.GetComponent<SpriteRenderer>().sprite= ballImages[index];
	
	}
}
