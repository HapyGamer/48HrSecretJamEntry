using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenShop : MonoBehaviour {

	public GameObject shop;	
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			shop.SetActive(!shop.activeSelf);
			if (shop.activeSelf == true)
			{
				Cursor.lockState = CursorLockMode.None;
				Cursor.visible = true;
				Time.timeScale = 0;
				Camera.main.gameObject.GetComponent<CameraControl>().enabled = false;
			}
			else
			{
				Cursor.lockState = CursorLockMode.Locked;
				Cursor.visible = false;
				Time.timeScale = 1;
				Camera.main.gameObject.GetComponent<CameraControl>().enabled = true;
			}
		}
	}
}
