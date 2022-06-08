using UnityEngine;

public class CameraController : MonoBehaviour
{

	public float movementTime = 5.0f;

	Camera cam;
	public GameObject orbitObject;

	Vector3 dragStartPosition;
	Vector3 dragCurrentPosition;
	Quaternion newRotation;

	public Vector3 newZoom = new Vector3(0, 0, -8);
	public Vector3 zoomAmount = new Vector3(0, 0, 1);

	private void Start()
	{
		cam = GetComponentInChildren<Camera>();
		newRotation = Quaternion.identity;
	}

	private void Update()
	{
		HandleOrbit();
		HandleZoom();
	}

	private void HandleOrbit()
	{
		if (Input.GetMouseButtonDown(0))
			dragStartPosition = Input.mousePosition;
		if (Input.GetMouseButton(0))
		{
			dragCurrentPosition = Input.mousePosition;
			Vector3 difference = dragStartPosition - dragCurrentPosition;
			dragStartPosition = dragCurrentPosition;
			newRotation *= Quaternion.Euler(new Vector3(difference.y, -difference.x, 0) / 5);
		}

		transform.localRotation = Quaternion.Lerp(transform.localRotation, 
			newRotation, movementTime * Time.deltaTime);
	}

	private void HandleZoom()
	{
		if (Input.mouseScrollDelta.y != 0)
			newZoom += Input.mouseScrollDelta.y * zoomAmount;

		cam.transform.localPosition = Vector3.Lerp(cam.transform.localPosition, 
			newZoom, movementTime * Time.deltaTime);
	}
}