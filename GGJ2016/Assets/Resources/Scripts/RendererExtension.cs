using UnityEngine;
using System.Collections;

public static class RendererExtensions
{
	public static bool IsVisibleFrom(this Renderer renderer, Camera camera)
	{
		bool isInView;
		bool isBlocked;

		Plane[] planes = GeometryUtility.CalculateFrustumPlanes(camera);

		isInView = GeometryUtility.TestPlanesAABB(planes, renderer.bounds);
		isBlocked = Physics.Linecast (camera.transform.position, renderer.transform.position);

		return (isInView && !isBlocked);
	}
}
