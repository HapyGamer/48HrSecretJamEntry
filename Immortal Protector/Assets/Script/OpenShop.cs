using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenShop : MonoBehaviour {

	public GameObject shop;
	public AudioClip shopMusic;
	public AudioClip normalTheme;
	public AudioSource source;

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			shop.SetActive(!shop.activeSelf);
			if (shop.activeSelf == true)
			{
				Cursor.lockState = CursorLockMode.None;
				Cursor.visible = true;
				source.clip = shopMusic;
				source.Play();
				Time.timeScale = 0;
				Camera.main.gameObject.GetComponent<CameraControl>().enabled = false;
			}
			else
			{
				Cursor.lockState = CursorLockMode.Locked;
				Cursor.visible = false;
				source.clip = normalTheme;
				source.Play();
				Time.timeScale = 1;
				Camera.main.gameObject.GetComponent<CameraControl>().enabled = true;
			}
		}
	}
}
