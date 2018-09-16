using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanDeath : MonoBehaviour {

	public GameObject soul;

	private PopulationManager population;
	private HumanCurrentStats c_stats;
	private HumanGrowth growth;
	private AudioManager audioManager;

	private void Start()
	{
		population = FindObjectOfType<PopulationManager>().GetComponent<PopulationManager>();
		c_stats = GetComponent<HumanCurrentStats>();
		growth = GetComponent<HumanGrowth>();
		audioManager = FindObjectOfType<AudioManager>().GetComponent<AudioManager>();
	}

	public void Death()
	{
		if (growth.isAdult)
		{
			audioManager.Play("AdultDeath");
		}
		else if (growth.isTeen)
		{
			audioManager.Play("TeenDeath");
		}
		else
		{
			audioManager.Play("ChildDeath");
		}
		var newSoul = Instantiate(soul, transform.position, Quaternion.identity);
		newSoul.GetComponent<PickMeUp>().howMuchToAdd = Mathf.RoundToInt(c_stats.c_Age) * 2;
		population.RemoveHuman(gameObject);
		Destroy(gameObject);
		//maybe also spawn like a gravestone or something
	}
}
