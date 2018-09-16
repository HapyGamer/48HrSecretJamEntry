using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HumanCurrentStats : MonoBehaviour {

	public HumanStats stats;
	public float c_Age = 0;
	public float c_Speed = 0;
	public float c_Hunger = 50;
	public float c_maxBabies = 2;
	public float c_maxAgeIncrease = 0;

	private NavMeshAgent agent;
	private ShopManager shop;

	private void Start()
	{
		shop = FindObjectOfType<ShopManager>().GetComponent<ShopManager>();
		c_Age = 0;
		c_Speed = 0;
		c_Hunger = 50;
		c_maxBabies = 2 + shop.s_babiesIncrease;
		c_maxAgeIncrease = 0 + shop.s_maxAgeIncrease;
		agent = GetComponent<NavMeshAgent>();
	}

	private void Update()
	{
		agent.speed = c_Speed;
	}

}
