using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour {

	public CharacterController controller;
	public float runSpeed = 40f;

	float horizontalMove = 0f;
	bool jump = false;


	void Update()
	{
		horizontalMove = Input.GetAxisRaw("Horizontal");

		if(Input.GetButtonDown("Jump"))
		{
			jump = true;
		}
	}

	void FixedUpdate()
	{
		controller.Move(horizontalMove, false, jump);
		jump = false;
	}
}