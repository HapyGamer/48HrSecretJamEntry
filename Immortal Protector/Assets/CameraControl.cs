using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {
            
    public float Cam = 4.0f;
        public Transform player;

    private Vector3 offset;
    private float turnSpeed;

    void Start()
    {
        offset = new Vector3(0, player.position.y + 8.0f,0);        
    }
    private void LateUpdate()
    {
        offset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * turnSpeed, Vector3.up) * offset;
        transform.position = player.position + offset;
        transform.LookAt(player.position);
    }
}

    
	
	

