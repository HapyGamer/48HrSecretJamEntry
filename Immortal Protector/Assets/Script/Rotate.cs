using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour {

	public float speed;
	float rotation;
	
	// Update is called once per frame
	void Update () {
		rotation += Time.deltaTime * speed;
		transform.eulerAngles = new Vector3(transform.eulerAngles.x, rotation, transform.eulerAngles.z);
	}
}
