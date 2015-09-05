using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DisplayScore : MonoBehaviour {

	void Update () {
		GetComponent<Text> ().text = "Score: " + (GameObject.Find ("Head").GetComponent<Head> ().currentSegments - 10).ToString ();
	}
}
