using UnityEngine;
using System.Collections;

public static class RendererExtensions
{
	public static bool IsVisibleFrom(this Renderer renderer, Camera camera)
	{
		bool isInView;
		bool isBlocked;
		RaycastHit hitInfo;

		Plane[] planes = GeometryUtility.CalculateFrustumPlanes(camera);

		isInView = GeometryUtility.TestPlanesAABB(planes, renderer.bounds);
		isBlocked = Physics.Linecast (camera.transform.position, renderer.transform.position, out hitInfo);

		if (isBlocked) {
			// Ignore a hit to object's own collider.
			isBlocked = !(renderer.GetComponent<Collider> () == hitInfo.collider);
		}

		return (isInView && !isBlocked);
	}


}
