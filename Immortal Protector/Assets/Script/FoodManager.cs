using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodManager : MonoBehaviour {

	public List<GameObject> food;

	private void Start()
	{
		GameObject[] GO = GameObject.FindGameObjectsWithTag("Fruit");
		foreach (GameObject g in GO)
		{
			food.Add(g);
		}
	}

	public void AddFood(GameObject gameObject)
	{
		food.Add(gameObject);
	}

	public void RemoveFood(GameObject gameObject)
	{
		food.Remove(gameObject);
	}
}
