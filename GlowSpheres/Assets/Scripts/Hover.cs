using UnityEngine;

public class Hover : MonoBehaviour {
	
	Vector3 startPosition;

	// Use this for initialization
	void Start () {
		startPosition = transform.localPosition;	
	}
	
	// Update is called once per frame
	void Update () {
		float height = Mathf.Sin (Time.realtimeSinceStartup);
		Vector3 offset = new Vector3 (0, height, 0);
		transform.localPosition = startPosition + offset;
	}
}
