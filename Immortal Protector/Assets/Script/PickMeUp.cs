using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickMeUp : MonoBehaviour {

	public int howMuchToAdd = 1;
	public string nameOfItem = "Fruit";

	private PlayerInventory player;
	private FoodManager foods;

	private void Start()
	{
		player = FindObjectOfType<PlayerInventory>().GetComponent<PlayerInventory>();
		foods = FindObjectOfType<FoodManager>().GetComponent<FoodManager>();
	}

	private void OnTriggerStay(Collider other)
	{
		if(other.tag == "Player" && Input.GetKeyDown(KeyCode.E))
		{
			player.AddItems(howMuchToAdd, nameOfItem);
			foods.food.Remove(gameObject);
			Destroy(gameObject);
		}
	}
}
