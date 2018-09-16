using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverManager : MonoBehaviour {

	public GameObject gameover;
	public AudioClip gameoverMusic;
	public AudioSource source;

	private PopulationManager population;

	// Use this for initialization
	void Start () {
		population = FindObjectOfType<PopulationManager>().GetComponent<PopulationManager>();
	}
	
	// Update is called once per frame
	void Update () {
		if (population.humans.Count <= 0)
		{
			source.clip = gameoverMusic;
			source.Play();
			gameover.SetActive(true);
			Time.timeScale = 0;
		}
	}
}
