using UnityEngine;
using System.Collections;

public class Pointer : MonoBehaviour {
	void Update () {
		GameObject head = GameObject.Find ("Head");
		//transform.position = head.transform.position + head.transform.forward * 2 + head.transform.up * 0.6f;
		transform.LookAt (GameObject.Find ("Food").transform.position);
		//transform.Rotate (new Vector3 (0, 0, head.transform.rotation.eulerAngles.z));
	}
}
