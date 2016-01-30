using UnityEngine;
using System.Collections;

public class TestObject : MonoBehaviour {

	public bool lookedAt = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {


	}

	void LateUpdate ()
	{
		if (lookedAt) {
			GetComponent<MeshRenderer> ().material.color = Color.red;
		} else {
			GetComponent<MeshRenderer> ().material.color = Color.black;
		}	
	
		lookedAt = false;
	}
}
