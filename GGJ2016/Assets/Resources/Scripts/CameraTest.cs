using UnityEngine;
using System;
using System.Collections;

public class CameraTest : MonoBehaviour {
	public GameObject testObject;


	private Camera camera;

	// Use this for initialization
	void Start () {

		// Store reference to camera.
		camera = GetComponent<Camera> ();

	}

	// Update is called once per frame
	void Update () {
		RaycastHit hit;
		GameObject objectHit = null;

		Vector3 cameraCenter = camera.ScreenToWorldPoint 
			(new Vector3(Screen.width / 2f, Screen.height / 2f, camera.nearClipPlane));

		if (Physics.Raycast(cameraCenter, this.transform.forward, out hit, 1000.0f))
		{
			objectHit = hit.transform.gameObject;
		}

		if (objectHit != null) {
//			Debug.DrawLine (transform.position, objectHit.transform.position, Color.red, 5.0f);

			TestObject test = objectHit.GetComponent<TestObject> ();

			if (test != null) {
				test.lookedAt = true;
			}
		}

		if (Input.GetKey (KeyCode.W)) {
			moveForward (1.0f);
		}

		if (Input.GetKey (KeyCode.S)) {
			moveBack (1.0f);
		}

		if (Input.GetKey (KeyCode.D)) {
			moveRight (1.0f);
		}

		if (Input.GetKey (KeyCode.A)) {
			moveLeft (1.0f);
		}

	}

	private void moveForward(float speed) {
		transform.localPosition += transform.forward * speed * Time.deltaTime;
	}
	
	private void moveBack(float speed) {
		transform.localPosition -= transform.forward * speed * Time.deltaTime;
	}
	
	private void moveRight(float speed) {
		transform.localPosition += transform.right * speed * Time.deltaTime;
	}
	
	private void moveLeft(float speed) {
		transform.localPosition -= transform.right * speed * Time.deltaTime;
	}
}
