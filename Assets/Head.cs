using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Head : MonoBehaviour {

	Rigidbody rb;

	public int maxSegments;

	public List<GameObject> segments;
	public GameObject SegmentObj;

	public int currentSegments;

	void Awake () {
		currentSegments = 0;
		rb = GetComponent<Rigidbody> ();
		segments = new List<GameObject> (segments);
		for (int i = 0; i < maxSegments; i++) {
			GameObject obj = (GameObject) Instantiate (SegmentObj);
			obj.SendMessage ("SetIndex", i);
			segments.Add (obj);
			obj.SetActive (false);
		}
		GameObject.FindGameObjectWithTag ("Food").transform.position = new Vector3 (0.8f*(Random.value*50-25), 0.8f*(Random.value*50-25), 0.8f*(Random.value*50-25));
	}

	void Update () {
		transform.position += transform.forward * 0.1f;
		transform.Rotate (new Vector3 (Input.GetAxis ("Vertical")*2, 0, -Input.GetAxis ("Horizontal")*2));
		for (int i = 0; i < currentSegments; i++) {
			segments[i].SetActive (true);
		}
	}

	void OnTriggerEnter (Collider other) {
		if (other.gameObject.tag == "Food") {
			other.gameObject.SetActive (false);
			other.gameObject.transform.position = new Vector3 (0.8f*(Random.value*50-25), 0.8f*(Random.value*50-25), 0.8f*(Random.value*50-25));
			currentSegments ++;
			other.gameObject.SetActive (true);
		}
	}
}
