using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanGrowth : MonoBehaviour {

	public float agingPerSecond;
	public float maxSpeedAge;
	public float hungerDepletedPerSecond;

	public int teenAge = 13;
	public int adultAge = 25;

	public bool isTeen = false;
	public bool isAdult = false;

	private HumanCurrentStats c_Stats;
	private HumanDeath death;

	private float speedIncreaseRate;
	private float speedDecreaseRate;

	// Use this for initialization
	void Start () {
		c_Stats = GetComponent<HumanCurrentStats>();
		death = GetComponent<HumanDeath>();

		speedIncreaseRate = c_Stats.stats.maxSpeed / maxSpeedAge;
		speedDecreaseRate = (c_Stats.stats.maxSpeed - c_Stats.stats.minSpeed) / (c_Stats.stats.maxAge - maxSpeedAge);
	}
	
	// Update is called once per frame
	void Update ()
	{
		CheckIfHumanIsDead();

		c_Stats.c_Age += agingPerSecond * Time.deltaTime;
		c_Stats.c_Hunger -= hungerDepletedPerSecond * Time.deltaTime;		
		
		if (c_Stats.c_Age < adultAge && c_Stats.c_Age >= teenAge && !isTeen)
		{
			isTeen = true;
			transform.GetChild(0).gameObject.SetActive(false);
			transform.GetChild(1).gameObject.SetActive(true);
		}
		else if (c_Stats.c_Age >= adultAge && c_Stats.c_Age > teenAge && !isAdult)
		{
			isAdult = true;
			transform.GetChild(1).gameObject.SetActive(false);
			transform.GetChild(2).gameObject.SetActive(true);
		}

		if (c_Stats.c_Age >= maxSpeedAge)
		{
			c_Stats.c_Speed -= speedDecreaseRate * c_Stats.c_Age;
		}

		else
		{
			c_Stats.c_Speed = speedIncreaseRate * c_Stats.c_Age;
		}
		
	}

	void CheckIfHumanIsDead()
	{
		if (c_Stats.c_Age >= c_Stats.stats.maxAge + c_Stats.c_maxAgeIncrease || c_Stats.c_Hunger <= 0)
		{
			death.Death();
		}
	}
}
