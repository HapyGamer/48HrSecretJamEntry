using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickMeUp : MonoBehaviour {

	public int howMuchToAdd = 1;
	public string nameOfItem = "Fruit";

	PlayerInventory player;

	private void Start()
	{
		player = FindObjectOfType<PlayerInventory>().GetComponent<PlayerInventory>();
	}

	private void OnTriggerStay(Collider other)
	{
		if(other.tag == "Player" && Input.GetKeyDown(KeyCode.E))
		{
			player.AddItems(howMuchToAdd, nameOfItem);
			Destroy(gameObject);
		}
	}
}
