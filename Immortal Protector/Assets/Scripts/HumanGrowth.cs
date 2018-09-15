using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanGrowth : MonoBehaviour {

	public float agingPerSecond;
	public float maxSpeedAge;
	public float hungerDepletedPerSecond;

	private HumanCurrentStats humanCurrentStats;
	private HumanDeath death;
	private Renderer mat;

	private Color black = Color.black;
	private Color materialColor;

	private float speedIncreaseRate;
	private float speedDecreaseRate;

	// Use this for initialization
	void Start () {
		humanCurrentStats = GetComponent<HumanCurrentStats>();
		death = GetComponent<HumanDeath>();
		mat = GetComponent<Renderer>();

		materialColor = mat.material.color;

		speedIncreaseRate = humanCurrentStats.stats.maxSpeed / maxSpeedAge;
		speedDecreaseRate = (humanCurrentStats.stats.maxSpeed - humanCurrentStats.stats.minSpeed) / (humanCurrentStats.stats.maxAge - maxSpeedAge);
	}
	
	// Update is called once per frame
	void Update ()
	{
		CheckIfHumanIsDead();

		humanCurrentStats.c_Age += agingPerSecond * Time.deltaTime;
		humanCurrentStats.c_Hunger -= hungerDepletedPerSecond * Time.deltaTime;

		mat.material.color = Color.Lerp(materialColor, black, humanCurrentStats.c_Age/humanCurrentStats.stats.maxAge);

		if (humanCurrentStats.c_Age >= maxSpeedAge)
		{
			humanCurrentStats.c_Speed -= speedDecreaseRate * humanCurrentStats.c_Age;
		}

		else
		{
			humanCurrentStats.c_Speed = speedIncreaseRate * humanCurrentStats.c_Age;
		}
		
	}

	void CheckIfHumanIsDead()
	{
		if (humanCurrentStats.c_Age >= humanCurrentStats.stats.maxAge || humanCurrentStats.c_Hunger <= 0)
		{
			death.Death();
		}
	}
}
