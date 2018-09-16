using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeDroppingFruits : MonoBehaviour {

	public GameObject[] fruits;
	public Transform fruitParent;

	public float timeTillNextDrop = 2;

	private float timer = 10;
	private FoodManager foods;
	private PopulationManager population;

	// Use this for initialization
	void Start ()
	{
		foods = FindObjectOfType<FoodManager>().GetComponent<FoodManager>();
		population = FindObjectOfType<PopulationManager>().GetComponent<PopulationManager>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (timer >= timeTillNextDrop)
		{
			Vector3 randomPosition = new Vector3(Random.Range(1, 3), 0, Random.Range(1, 3));
			int randomNum = Random.Range(0, 2);
			if (randomNum == 1)
			{
				randomPosition *= -1;
			}
			var newFood = Instantiate(fruits[Random.Range(0,fruits.Length)], transform.position + randomPosition, Quaternion.identity,fruitParent);
			foods.AddFood(newFood);
			foreach(HumanCurrentStats h in population.humans)
			{
				h.GetComponent<HumanEat>().FoodNearBy();
			}
			timer = 0;
		}
		timer += Time.deltaTime;
	}
}
