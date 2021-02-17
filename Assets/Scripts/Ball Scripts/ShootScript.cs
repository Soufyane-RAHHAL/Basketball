﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
public class ShootScript : MonoBehaviour {

	public float power = 2.0f;
	public float life =1.0f;
	public float dead_sense = 25f;

	public int dots = 30;

	private Vector2 startPosition;
	private bool shoot = false, aiming=false,hit_ground=false;

	private GameObject Dots;
	private List<GameObject> projectlesPath;
	private Rigidbody2D mybody;
	private Collider2D myCollider;

	// Use this for initialization
	void Awake() {
		mybody = GetComponent<Rigidbody2D>();
		myCollider = GetComponent<Collider2D> ();
	}
	void Start(){
		Dots = GameObject.Find ("dots");
		mybody.isKinematic = true;
		myCollider.enabled = false;
		startPosition = transform.position;
		projectlesPath = Dots.transform.Cast<Transform>().ToList ().ConvertAll(t => t.gameObject);

		for (int i = 0; i < projectlesPath.Count; i++) {
			projectlesPath[i].GetComponent<Renderer>().enabled = false;
		}

	}
	// Update is called once per frame
	void Update () {
		Aim ();
		if (hit_ground) {
			Debug.Log ("djqsh");
			life -= Time.deltaTime;
			Color c = GetComponent<Renderer> ().material.GetColor ("_Color");
			GetComponent<Renderer> ().material.SetColor ("_Color",new Color(c.r,c.g,c.g,life));
		
			if (life < 0) {
				if (GameManger.instance != null) {
					GameManger.instance.CreateBall ();
				}
				DestroyObject(gameObject);
			}
		}
	
	}
	void Aim(){
		if (shoot)
			return;

		if (Input.GetAxis ("Fire1") == 1) {
			if (!aiming) {
				aiming = true;
				startPosition = Input.mousePosition;
				CalculatePath ();
				ShowPath ();
			} else {
				CalculatePath ();
			}
		}else if(aiming && !shoot){
			if (inDeadZone (Input.mousePosition) || inReleaseZone (Input.mousePosition)) {
				aiming = false;
				HidePath ();
				return;
			}
			mybody.isKinematic = false;
			myCollider.enabled = true;
			shoot = true;
			aiming = false;
			mybody.AddForce (GetForce (Input.mousePosition));
			HidePath ();
		}
	}
	Vector2 GetForce(Vector2 mouse){
		return (new Vector2(startPosition.x,startPosition.y)-new Vector2(mouse.x,mouse.y))*power;
	}
	bool inDeadZone(Vector2 mouse){
		if (Mathf.Abs (startPosition.x - mouse.x) <= dead_sense && Mathf.Abs (startPosition.y - mouse.y) <= dead_sense) {
			return true;
		} else {
			return false;
		}
	}
	bool inReleaseZone(Vector2 mouse){
		if (mouse.x <= 70) {
			return true;
		} else {
			return false;
		}			
	}
	void CalculatePath(){
		Vector2 vel = GetForce (Input.mousePosition)*Time.fixedDeltaTime/mybody.mass;
	
		for (int i = 0; i < projectlesPath.Count; i++) {
			projectlesPath [i].GetComponent<Renderer> ().enabled = true;
			float t = i / 30f;
			Vector3 point = PathPoint (transform.position, vel, t);
			point.z = 1.0f;

			projectlesPath [i].transform.position = point;
		}

	}
	Vector2 PathPoint(Vector2 startP,Vector2 startVel,float t){
		return startP + startVel * t + 0.5f * Physics2D.gravity * t * t;
	}
	void HidePath(){
		for (int i = 0; i < projectlesPath.Count; i++) {
			projectlesPath[i].GetComponent<Renderer>().enabled = false;
		}

	}

	void ShowPath(){
		for (int i = 0; i < projectlesPath.Count; i++) {
			projectlesPath[i].GetComponent<Renderer>().enabled = true;
		}

	}
	void OnCollisionEnter2D(Collision2D target){
		if (target.gameObject.tag == "Ground") {
			hit_ground = true;
			Debug.Log ("djqsh");
		}
			
	}

}
