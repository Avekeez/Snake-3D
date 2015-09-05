using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Head : MonoBehaviour {

	Rigidbody rb;

	public int maxSegments;

	public List<GameObject> segments;
	public GameObject SegmentObj;

	public int currentSegments;

	private bool alive;

	void Awake () {
		alive = true;
		currentSegments = 10;
		rb = GetComponent<Rigidbody> ();
		segments = new List<GameObject> (segments);
		for (int i = 0; i < maxSegments; i++) {
			GameObject obj = (GameObject) Instantiate (SegmentObj);
			obj.SendMessage ("SetIndex", i);
			segments.Add (obj);
			obj.SetActive (false);
		}
		GameObject.FindGameObjectWithTag ("Food").transform.position = new Vector3 (0.8f*(Random.value*15-7.5f), 0.8f*(Random.value*15-7.5f), 0.8f*(Random.value*15-7.5f));
	}

	void Update () {
		if (alive) {
			transform.position += transform.forward * 0.1f;
			transform.Rotate (new Vector3 (Input.GetAxis ("Vertical")*2, 0, -Input.GetAxis ("Horizontal")*2));
		}
		for (int i = 0; i < currentSegments; i++) {
			segments[i].SetActive (true);
		}
		//Debug.DrawRay (transform.position + transform.forward * 0.5f, transform.forward*2, Color.green, 1);
		if (Vector3.Distance (transform.position, GameObject.Find ("Food").transform.position) < 10) {
			print ("ayy");
		}
	}

	void OnCollisionEnter (Collision other) {
		if (other.gameObject.tag != "Food") {
			alive = false;
		}
	}

	void OnTriggerEnter (Collider other) {
		if (other.gameObject.tag == "Food") {
			other.gameObject.SetActive (false);
			/*
			other.gameObject.transform.position = new Vector3 (0.8f*(Random.value*50-25), 0.8f*(Random.value*50-25), 0.8f*(Random.value*50-25));
			for (int i = 0; i < GameObject.Find ("Obstacle").transform.childCount; i++) {
				if (other.gameObject.GetComponent<BoxCollider> ().bounds.Intersects (GameObject.Find ("Obstacle").transform.GetChild (i).gameObject.GetComponent<BoxCollider> ().bounds)) {
					other.gameObject.transform.position = new Vector3 (0.8f*(Random.value*50-25), 0.8f*(Random.value*50-25), 0.8f*(Random.value*50-25));
				}
			}
			*/
			bool isSafe = false;
			while (!isSafe) {
				for (int i = 0; i < GameObject.Find ("Obstacle").transform.childCount; i++) {
					if (!other.gameObject.GetComponent<BoxCollider> ().bounds.Intersects (GameObject.Find ("Obstacle").transform.GetChild (i).gameObject.GetComponent<BoxCollider> ().bounds)) {
						isSafe = true;
						other.gameObject.transform.position = new Vector3 (0.8f*(Random.value*15-7.5f), 0.8f*(Random.value*15-7.5f), 0.8f*(Random.value*15-7.5f));
						break;
					}
				}
			}
			currentSegments ++;
			other.gameObject.SetActive (true);
		}
		if (other.gameObject.tag == "Segment" && other.gameObject.GetComponent<Segment> ().getIndex () != 0) {
			alive = false;
		}
	}
}
