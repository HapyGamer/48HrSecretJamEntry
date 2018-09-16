using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public float speed; //get speed
	public float groundDistance; //get distance from player to ground
	public LayerMask ground; //what layer is ground
	public float jumpHeight; //what is jump height

	private CharacterController controller;
	private float Gravity = Physics.gravity.y;
	private Vector3 velocity;
	private bool isGrounded = true;


	// Use this for initialization
	void Start ()
	{
		controller = GetComponent<CharacterController>(); //get character controller
	}
	
	// Update is called once per frame
	void Update ()
	{
		Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));//x z movement
		controller.Move(transform.forward *move.z * Time.deltaTime * speed + transform.right * move.x * Time.deltaTime * speed);//move in x or z direction
		if (move != Vector3.zero)
		{
			transform.eulerAngles = new Vector3(transform.eulerAngles.x, Camera.main.transform.eulerAngles.y, transform.eulerAngles.z); //turn if not facing right way
		}
		

		velocity.y += Gravity * Time.deltaTime;//add gravity to velocity (could just be a single variable) (no gravity in character controller)

		controller.Move(velocity * Time.deltaTime); // make character fall due to gravity

		isGrounded = Physics.CheckSphere(transform.position, groundDistance, ground, QueryTriggerInteraction.Ignore); // check if on ground
		

		if (isGrounded && velocity.y < 0)
		{
			velocity.y = 0f;//if on ground then no gravity
		}

		if (Input.GetButtonDown("Jump") && isGrounded)
		{
			velocity.y += Mathf.Sqrt(jumpHeight * -2f * Gravity);//better jumping
		}
	}
}
