using UnityEngine;
using System.Collections;

public class ObtainableObject : MonoBehaviour {

	private Renderer renderer;

	private Camera camera;

	private float minimumDistance = 10.0F;

	public float durationBeforeActivate = 2.0f;

	private float durationTimer;

	private bool canBeObtained = false;

	void OnEnable() {
		Observer.OnItemActivate += ActivateItem;
	}

	void OnDisable() {
		Observer.OnItemActivate -= ActivateItem;
	}

	public void Start() {
		this.renderer = GetComponent<Renderer>();
		this.camera = GameObject.Find("Main Camera").GetComponent<Camera>();
	}

	public void Update() {
		if(isObtainable()) {
			StartCoroutine("startTimer");
		} else {
			if(durationTimer > 0.0f) {
				durationTimer = 0.0f;
			}
		}
	}

	private IEnumerator startTimer() {
		while(durationTimer <= durationBeforeActivate) {
			durationTimer += Time.deltaTime;
			yield return null;
		}
		ActivateItem();
	}

	public bool isObtainable() {
		return this.renderer.IsVisibleFrom(camera) && isWithinRange();
	}

	private bool isWithinRange() {
		return (Vector3.Distance(camera.gameObject.transform.position, this.transform.position) <= minimumDistance);
	}

	private void ActivateItem() {

	}

}
