using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


/// <summary>
/// This will take priority over eating
/// end with checking if any food nearby
/// </summary>
public class HumanRepopulate : MonoBehaviour {

	public GameObject baby;

	public float r_Distance;
	public float r_Duration;
	public float r_SightDistance;

	public Vector2 r_AgeRange;

	private bool canReproduce = false;
	private bool grownUp = false;

	private float r_Timer;
	private float r_CoolDown;
	private int currentBabies;

	private Transform mate;
	private HumanCurrentStats m_Stats;
	private HumanCurrentStats c_Stats;
	private NavMeshAgent agent;
	private PopulationManager population;

	// Use this for initialization
	void Start ()
	{
		c_Stats = GetComponent<HumanCurrentStats>();
		agent = GetComponent<NavMeshAgent>();
		population = FindObjectOfType<PopulationManager>().GetComponent<PopulationManager>();
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{	
		if (c_Stats.c_Age >= r_AgeRange.x && c_Stats.c_Age < r_AgeRange.y && canReproduce)//check if within age range and mate nearby
		{

			if (!grownUp)
			{
				CheckIfPartnerIsNear();
				grownUp = true;
			}

			//if not within reproduciton range go to them
			if (Vector3.Distance(transform.position, mate.position) > r_Distance)
			{
				agent.isStopped = false;
				GoToPartner(mate.position);
			}
			//then reproduce 
			else
			{
				agent.isStopped = true;
				Reproduce();
			}			
		}

		if (!canReproduce && mate!=null)
		{
			canReproduce = Vector3.Distance(transform.position, mate.position) >= r_SightDistance && m_Stats.c_Age>=r_AgeRange.x && m_Stats.c_Age >= r_AgeRange.y;
		}
	}

	void GoToPartner(Vector3 target)
	{
		//walk to
		agent.SetDestination(target);
	}

	void CheckIfPartnerIsNear()
	{
		//get nearest partner then check its position

		//first check the closest opposite sex partner that is the same age



		//have it as your mate and check its position until its in sight range
	}

	void Reproduce()
	{
		r_Timer += Time.deltaTime;
		if(r_Timer >= r_Duration)
		{
			Instantiate(baby, transform.position, Quaternion.identity);

			//once reproduction is done set timer to 0 and reproduce again
			r_Timer = 0;
			currentBabies++;
			r_CoolDown = 0;
		}
	}
}
