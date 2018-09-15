using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanGrowth : MonoBehaviour {

	public float agingPerSecond;
	public float maxSpeedAge;
	public float hungerDepletedPerSecond;

	private HumanCurrentStats c_Stats;
	private HumanDeath death;
	private Renderer mat;

	private Color black = Color.black;
	private Color materialColor;

	private float speedIncreaseRate;
	private float speedDecreaseRate;

	// Use this for initialization
	void Start () {
		c_Stats = GetComponent<HumanCurrentStats>();
		death = GetComponent<HumanDeath>();
		mat = GetComponent<Renderer>();

		materialColor = mat.material.color;

		speedIncreaseRate = c_Stats.stats.maxSpeed / maxSpeedAge;
		speedDecreaseRate = (c_Stats.stats.maxSpeed - c_Stats.stats.minSpeed) / (c_Stats.stats.maxAge - maxSpeedAge);
	}
	
	// Update is called once per frame
	void Update ()
	{
		CheckIfHumanIsDead();

		c_Stats.c_Age += agingPerSecond * Time.deltaTime;
		c_Stats.c_Hunger -= hungerDepletedPerSecond * Time.deltaTime;

		mat.material.color = Color.Lerp(materialColor, black, c_Stats.c_Age/c_Stats.stats.maxAge);

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
		if (c_Stats.c_Age >= c_Stats.stats.maxAge || c_Stats.c_Hunger <= 0)
		{
			death.Death();
		}
	}
}
