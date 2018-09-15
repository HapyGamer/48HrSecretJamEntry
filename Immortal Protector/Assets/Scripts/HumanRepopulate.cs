using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


/// <summary>
/// This will take priority over eating
/// end with checking if any food nearby
/// </summary>
public class HumanRepopulate : MonoBehaviour {

	public float reproduceDistance;
	public float reproduceDuration;
	public float reproduceSightDistance;

	public Vector2 reproductionAgeRange;

	private bool canReproduce = false;
	private Transform mate;
	private HumanCurrentStats c_Stats;

	// Use this for initialization
	void Start ()
	{
		c_Stats = GetComponent<HumanCurrentStats>();			
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		if (c_Stats.c_Age >= reproductionAgeRange.x && c_Stats.c_Age < reproductionAgeRange.y && canReproduce)
		{
			Reproduce(mate.position);
		}
	}

	void Reproduce(Vector3 target)
	{

	}
}
