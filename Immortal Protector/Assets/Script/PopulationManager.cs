using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopulationManager : MonoBehaviour {

	public List<HumanCurrentStats> humans;

	private void Start()
	{
		GameObject[] GO = GameObject.FindGameObjectsWithTag("HumanMale");
		foreach(GameObject g in GO)
		{
			humans.Add(g.GetComponent<HumanCurrentStats>());
		}
		GameObject[] GO1 = GameObject.FindGameObjectsWithTag("HumanFemale");
		foreach (GameObject g in GO1)
		{
			humans.Add(g.GetComponent<HumanCurrentStats>());
		}
	}

	public void AddHuman(GameObject gameObject)
	{
		humans.Add(gameObject.GetComponent<HumanCurrentStats>());
	}

	public void RemoveHuman(GameObject gameObject)
	{
		humans.Remove(gameObject.GetComponent<HumanCurrentStats>());
	}

}
