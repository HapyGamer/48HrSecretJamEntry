using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HumanCurrentStats : MonoBehaviour {

	public HumanStats stats;
	public float c_Age = 0;
	public float c_Speed = 0;
	public float c_Hunger = 50;
	public float c_maxBabies = 0;
	public float c_maxAgeIncrease = 0;

	private NavMeshAgent agent;

	private void Start()
	{
		c_Age = 0;
		c_Speed = 0;
		c_Hunger = 50;
		c_maxBabies = 0;
		c_maxAgeIncrease = 0;
		agent = GetComponent<NavMeshAgent>();
	}

	private void Update()
	{
		agent.speed = c_Speed;
	}

}
