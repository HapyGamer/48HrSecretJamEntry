using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {

	public float smoothing = 3;

	private Transform player;
	private Vector3 offset;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
		offset = transform.position - player.position;
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		transform.position = Vector3.Lerp(transform.position, player.position + offset, Time.deltaTime * smoothing);
	}
}
