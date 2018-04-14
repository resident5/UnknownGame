using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
	public Camera cam;

	public Transform target, centerpoint;

	public Vector3 offset;

	public float moveLft, moveFwd;

	public float mouseX, mouseY;
	public float mouseSensitivity = 5f;
	public float mouseYposition = 2f;

	public float zoom;
	public float zoomSpeed = 2f;
	public float zoomMin = -2f;
	public float zoomMax = -10f;


	void Start ()
	{
		//cam.transform.position = target.position;

		zoom = -3;
	}

	void Update ()
	{
		ZoomInOut ();
		Orbit ();
	}

	void ZoomInOut()
	{
		zoom += Input.GetAxis ("Mouse ScrollWheel") * zoomSpeed;

		if (zoom > zoomMin)
		{
			zoom = zoomMin;
		}

		if (zoom < zoomMax)
		{
			zoom = zoomMax;
		}


		cam.transform.localPosition = new Vector3 (0, 0, zoom);

	}

	void Orbit ()
	{
		if (Input.GetMouseButton (0))
		{
			mouseX += Input.GetAxis ("Mouse X");
			mouseY += Input.GetAxis ("Mouse Y");

		}

		transform.LookAt (centerpoint);
		centerpoint.localRotation = Quaternion.Euler (mouseY, mouseX, 0);

	} 

	void Movement()
	{
		Vector3 movement = new Vector3 (moveLft, 0, moveFwd);

		target.GetComponent<CharacterController> ().Move (movement * Time.deltaTime);
		centerpoint.position = new Vector3 (target.position.x, target.position.y + mouseYposition, target.position.z);

		if(Input.GetAxis ("Vertical"))

	}



//	void LateUpdate()
//	{
//		cam.transform.position = target.position + offset + new Vector3(0,0,zoom);
//
//		transform.LookAt (target.position);
//
//
//	}
}
