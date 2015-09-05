using UnityEngine;
using System.Collections;

public class MandibleMove : MonoBehaviour {

	void Awake () {
		InvokeRepeating ("Open", 0, 1);
		InvokeRepeating ("Shut", 0.5f, 1);
	}

	void Open () {
		StartCoroutine (OpenSequence ());
	}

	void Shut () {
		StartCoroutine (CloseSequence ());
	}

	IEnumerator OpenSequence () {
		for (int i = 0; i < 10; i ++) {
			transform.GetChild (0).RotateAround (transform.position + new Vector3 (0.5f, 0, 0.2f), transform.up, 0.5f);
			transform.GetChild (1).RotateAround (transform.position + new Vector3 (-0.5f, 0, 0.2f), transform.up, -0.5f);
			yield return new WaitForSeconds (0.01f);
		}
	}

	IEnumerator CloseSequence () {
		for (int i = 0; i < 10; i ++) {
			transform.GetChild (0).RotateAround (transform.position + new Vector3 (0.5f, 0, 0.2f), transform.up, -0.5f);
			transform.GetChild (1).RotateAround (transform.position + new Vector3 (-0.5f, 0, 0.2f), transform.up, 0.5f);
			yield return new WaitForSeconds (0.01f);
		}
	}
}
