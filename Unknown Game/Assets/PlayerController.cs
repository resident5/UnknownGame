using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public float walkSpeed;

	void Start ()
	{
		
	}

	void Update ()
	{
		Move (walkSpeed);
	}

	void Move(float move)
	{
		if (Input.GetKey (KeyCode.W))
		{
			transform.position += Vector3.forward * move;
		}
	}
}
