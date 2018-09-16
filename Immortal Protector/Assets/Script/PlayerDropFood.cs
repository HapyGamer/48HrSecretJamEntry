using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Q to drop food then check for all the creatures if its the nearest food for them
/// </summary>
public class PlayerDropFood : MonoBehaviour {

	private int currentlySelectedFruit = 0;

	private PopulationManager population;
	private PlayerInventory inventory;
	private FoodManager foods;

	// Use this for initialization
	void Start ()
	{
		population = FindObjectOfType<PopulationManager>().GetComponent<PopulationManager>();
		inventory = GetComponent<PlayerInventory>();
		foods = FindObjectOfType<FoodManager>().GetComponent<FoodManager>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown(KeyCode.Q))
		{
			DropFood();
		}

		if (Input.GetKeyDown(KeyCode.Alpha1))
		{
			currentlySelectedFruit = 0;
		}
	}

	void DropFood()
	{
		if (inventory.item[currentlySelectedFruit].howMuchIHave > 0)
		{			
			var item = Instantiate(inventory.item[currentlySelectedFruit].item, transform.position, Quaternion.identity);
			inventory.item[currentlySelectedFruit].howMuchIHave--;
			foods.food.Add(item);
			foreach (HumanCurrentStats h in population.humans)
			{
				if (!h.GetComponent<HumanRepopulate>().isReproducing)
				{
					h.GetComponent<HumanEat>().FoodNearBy();
				}
			}
		}
	}
}
