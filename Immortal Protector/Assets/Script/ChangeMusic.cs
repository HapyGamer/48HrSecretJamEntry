using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMusic : MonoBehaviour {

	public AudioClip mainTheme;
	public AudioSource source;

	public void ChangeTheMusic()
	{
		source.clip = mainTheme;
		source.Play();
		Time.timeScale = 1;
	}
}
