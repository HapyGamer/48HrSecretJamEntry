using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerInventory : MonoBehaviour {

	public Items[] item;

	public void AddItems(int howManyToAdd, string nameOfItem)
	{
		Items i = Array.Find(item, items => items.name == nameOfItem);
		i.howMuchIHave += howManyToAdd;
	}

	public void RemoveItems(int howManyToRemove, string nameOfItem)
	{
		Items i = Array.Find(item, items => items.name == nameOfItem);
		i.howMuchIHave -= howManyToRemove;
	}
}
