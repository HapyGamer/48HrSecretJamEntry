using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpHuman : MonoBehaviour {

	public int babiesIncrease = 1;
	public float h_sightRangeIncrease;
	public float r_sightRangeIncrease;
	public int maxAgeIncrease;
	public int hungerIncrease;

	private PopulationManager population;

	// Use this for initialization
	void Start () {
		population = FindObjectOfType<PopulationManager>().GetComponent<PopulationManager>();
	}
	
	public void PowerUp()
	{
		foreach(HumanCurrentStats h in population.humans)
		{
			h.c_maxAgeIncrease += maxAgeIncrease;
			h.c_maxBabies += babiesIncrease;
			h.GetComponent<HumanEat>().seesFoodRange += h_sightRangeIncrease;
			h.GetComponent<HumanEat>().h_Recovery += hungerIncrease;
			h.GetComponent<HumanRepopulate>().r_SightDistance += r_sightRangeIncrease;
		}
	}
}
