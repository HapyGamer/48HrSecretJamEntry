using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


/// <summary>
/// start with checking if any food is within eating range and start heading towards it or eat it
/// </summary>
public class HumanEat : MonoBehaviour {

	public float eatingRange;
	public float seesFoodRange;
	public float h_Recovery;
	public float h_Cooldown;

	public AudioClip adult;
	public AudioClip teen;
	public AudioClip childCreature;

	public bool canEat = false;

	public float eatTimer;
	private bool destinationSet = false;

	public Transform nearestFood;
	private HumanRepopulate repopulate;
	private HumanGrowth growth;
	private HumanCurrentStats c_Stats;
	private NavMeshAgent agent;
	private FoodManager foods;
	private AudioManager audioManager;

	// Use this for initialization
	void Start () {
		foods = FindObjectOfType<FoodManager>().GetComponent<FoodManager>();
		repopulate = GetComponent<HumanRepopulate>();
		c_Stats = GetComponent<HumanCurrentStats>();
		growth = GetComponent<HumanGrowth>();
		audioManager = FindObjectOfType<AudioManager>().GetComponent<AudioManager>();
		agent = GetComponent<NavMeshAgent>();
		eatTimer = h_Cooldown;
		canEat = false;
		destinationSet = false;
		FoodNearBy();
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		//check if not reproducing
		//check if hungry
		if (!repopulate.isReproducing && c_Stats.c_Hunger < c_Stats.stats.maxHunger && canEat)
		{
			//if isnt then go to it
			if (Vector3.Distance(transform.position, nearestFood.position) > eatingRange)
			{
				agent.isStopped = false;
				if (!destinationSet)
				{
					agent.destination = nearestFood.position;
					destinationSet = true;
				}
			}
			//if is close enough eat it
			else
			{
				agent.isStopped = true;
				destinationSet = false;
				AddHunger(h_Recovery);
			}
		}
	}

	private void Update()
	{
		if (!canEat && nearestFood !=null)
		{
			//check if any food is in sight range
			//check if havent already eaten
			canEat = eatTimer >= h_Cooldown && Vector3.Distance(transform.position, nearestFood.position) <= seesFoodRange;
		}
		eatTimer += Time.deltaTime;
	}

	public void FoodNearBy()
	{
		//call this when a food is placed or finished eating food
		if (nearestFood != null)
		{
			foods.AddFood(nearestFood.gameObject);
		}
		//CHECK ALL FOODS
		float dist = 999999;
		for(int i = 0; i < foods.food.Count; i++)
		{
			if (foods.food[i] != null)
			{
				float newDist = Vector3.Distance(transform.position, foods.food[i].transform.position);
				if (newDist < dist)
				{
					dist = newDist;
					nearestFood = foods.food[i].transform;
				}
			}
		}
		if (nearestFood != null)
		{
			foods.RemoveFood(nearestFood.gameObject);
		}
	}

	void AddHunger(float amount)
	{
		c_Stats.c_Hunger += amount;
		if(c_Stats.c_Hunger > c_Stats.stats.maxHunger)
		{
			c_Stats.c_Hunger = c_Stats.stats.maxHunger;
		}
		if (growth.isAdult)
		{
			audioManager.Play("AdultEat");
		}
		else if (growth.isTeen)
		{
			audioManager.Play("TeenEat");
		}
		else
		{
			audioManager.Play("ChildEat");
		}
		eatTimer = 0;
		canEat = false;
		Destroy(nearestFood.gameObject);
		nearestFood = null;
		FoodNearBy();

	}	
}
