using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanDeath : MonoBehaviour {

	public GameObject soul;

	private PopulationManager population;
	private HumanCurrentStats c_stats;

	private void Start()
	{
		population = FindObjectOfType<PopulationManager>().GetComponent<PopulationManager>();
		c_stats = GetComponent<HumanCurrentStats>();
	}

	public void Death()
	{
		var newSoul = Instantiate(soul, transform.position, Quaternion.identity);
		newSoul.GetComponent<PickMeUp>().howMuchToAdd = Mathf.RoundToInt(c_stats.c_Age);
		population.RemoveHuman(gameObject);
		Destroy(gameObject);
		//maybe also spawn like a gravestone or something
	}
}
