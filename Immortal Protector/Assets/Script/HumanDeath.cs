using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanDeath : MonoBehaviour {


	private PopulationManager population;

	private void Start()
	{
		population = FindObjectOfType<PopulationManager>().GetComponent<PopulationManager>();
	}

	public void Death()
	{
		population.RemoveHuman(gameObject);
		Destroy(gameObject);
		//maybe also spawn like a gravestone or something
	}
}
