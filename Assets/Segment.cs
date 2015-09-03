using UnityEngine;
using System.Collections;

public class Segment : MonoBehaviour {

	int index;

	void Update () {
		GameObject head = GameObject.Find ("Head");

		if (index == 0) {
			transform.rotation = Quaternion.Lerp (transform.rotation, head.transform.rotation, 0.05f);
			transform.position = head.transform.position + head.transform.forward.normalized * -2;
		} else {
			transform.rotation = Quaternion.Lerp (transform.rotation, head.GetComponent<Head> ().segments[index-1].transform.rotation, 0.05f);
			transform.position = head.GetComponent<Head> ().segments[index-1].transform.position + head.GetComponent<Head> ().segments[index-1].transform.forward.normalized * 2*-0.9f*(head.GetComponent<Head> ().maxSegments-index-1)/head.GetComponent<Head> ().maxSegments;
		}
	}

	void SetIndex (int ind) {
		index = ind;
	}
}