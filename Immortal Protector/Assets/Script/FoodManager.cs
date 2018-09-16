using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FoodManager : MonoBehaviour {

	public List<GameObject> food;

	private void Start()
	{
		FindFoods();
	}

	public void AddFood(GameObject gameObject)
	{
		food.Add(gameObject);
	}

	public void RemoveFood(GameObject gameObject)
	{
		food.Remove(gameObject);
		for (var i = food.Count - 1; i > -1; i--)
		{
			if (food[i] == null)
				food.RemoveAt(i);
		}
	}

	void FindFoods()
	{
		GameObject[] GO = GameObject.FindGameObjectsWithTag("Fruit");
		foreach (GameObject g in GO)
		{
			food.Add(g);
		}
	}
}
