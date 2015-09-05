using UnityEngine;
using System.Collections;

public class Segment : MonoBehaviour {

	int index;

	void OnEnable () {
		GameObject head = GameObject.Find ("Head");

		if (index == 0) {
			transform.position = head.transform.position + head.transform.forward.normalized * -2;
		} else {
			transform.position = head.GetComponent<Head> ().segments[index-1].transform.position + head.GetComponent<Head> ().segments[index-1].transform.forward.normalized * -2;
		}
	}

	void Update () {
		GameObject head = GameObject.Find ("Head");

		if (index == 0) {
			transform.LookAt (head.transform.position);
			if (Vector3.Distance (transform.position, head.transform.position) > 2) {
				transform.position += transform.forward * 0.1f;
			}
			transform.rotation = Quaternion.Lerp (transform.rotation, head.transform.rotation, 0.05f);
		} else {
			transform.LookAt (head.GetComponent<Head> ().segments[index-1].transform.position);
			if (Vector3.Distance (transform.position, head.GetComponent<Head> ().segments[index-1].transform.position) > 2) {
				transform.position += transform.forward * 0.1f;
			}
			transform.rotation = Quaternion.Lerp (transform.rotation, head.GetComponent<Head> ().segments[index-1].transform.rotation, 0.05f);
		}
	}

	void SetIndex (int ind) {
		index = ind;
	}
	public int getIndex () {
		return index;
	}
}