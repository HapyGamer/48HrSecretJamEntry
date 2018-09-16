using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpBetweenMaterials : MonoBehaviour {

	public Material beginning;
	public Material end;

	public bool isChild;
	public bool isTeen;
	public bool isAdult;

	private HumanCurrentStats c_Stats;
	private HumanGrowth growth;
	private Renderer rend;

	// Use this for initialization
	void Start () {
		rend = GetComponent<Renderer>();
		c_Stats = GetComponentInParent<HumanCurrentStats>();
		growth = GetComponentInParent<HumanGrowth>();
	}
	
	// Update is called once per frame
	void Update () {
		if (isChild)
		{
			rend.material.color = Color.Lerp(beginning.color, end.color, c_Stats.c_Age / growth.teenAge);
		}
		else if (isTeen)
		{
			rend.material.color = Color.Lerp(beginning.color, end.color, (c_Stats.c_Age - growth.teenAge) / (growth.adultAge - growth.teenAge));
		}
		else if (isAdult)
		{
			rend.material.color = Color.Lerp(beginning.color, end.color, (c_Stats.c_Age - growth.adultAge) / (c_Stats.stats.maxAge + c_Stats.c_maxAgeIncrease - growth.adultAge));
		}
	}
}
