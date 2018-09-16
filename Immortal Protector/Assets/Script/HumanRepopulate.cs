using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


/// <summary>
/// This will take priority over eating
/// end with checking if any food nearby
/// </summary>
public class HumanRepopulate : MonoBehaviour {

	public GameObject[] baby;

	public float r_Distance;
	public float r_SightDistance;
	public float r_Duration;
	public float r_CoolDownLength;

	public bool isFemale;
	[HideInInspector]
	public bool isReproducing = false;

	public int m_ageRange = 10;

	public Vector2 r_AgeRange;

	public AudioClip reproduceSound;

	private bool canReproduce = false;
	private bool grownUp = false;
	private bool destinationSet = false;

	private float r_Timer;
	private float r_CoolDown;
	private int currentBabies;

	private Transform mate;
	private HumanCurrentStats m_Stats;
	private HumanCurrentStats c_Stats;
	private AudioManager audioManager;
	private NavMeshAgent agent;
	private PopulationManager population;

	// Use this for initialization
	void Start ()
	{
		c_Stats = GetComponent<HumanCurrentStats>();
		agent = GetComponent<NavMeshAgent>();
		audioManager = FindObjectOfType<AudioManager>().GetComponent<AudioManager>();
		population = FindObjectOfType<PopulationManager>().GetComponent<PopulationManager>();
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		if (currentBabies >= c_Stats.c_maxBabies)
		{
			if (c_Stats.c_Age >= r_AgeRange.x && c_Stats.c_Age < r_AgeRange.y)//check if within age range and mate nearby
			{
				if (!grownUp)
				{
					CheckIfPartnerIsNear();
					grownUp = true;
				}
				//if not within reproduciton range go to them
				if (canReproduce)
				{
					isReproducing = true;
					if (Vector3.Distance(transform.position, mate.position) > r_Distance)
					{
						agent.isStopped = false;
						GoToPartner(mate.position);
					}
					//then reproduce 
					else
					{
						agent.isStopped = true;
						isReproducing = false;
						destinationSet = false;
						Reproduce();
					}
				}
			}
		}
	}

	private void Update()
	{
		if (!canReproduce && mate != null)
		{
			if (r_CoolDown >= r_CoolDownLength)
			{
				canReproduce = Vector3.Distance(transform.position, mate.position) <= r_SightDistance && m_Stats.c_Age >= r_AgeRange.x && m_Stats.c_Age <= r_AgeRange.y;
			}
		}
		if (mate == null)
		{
			isReproducing = false;
		}
		r_CoolDown += Time.deltaTime;
	}

	void GoToPartner(Vector3 target)
	{
		//walk to
		if (!destinationSet)
		{
			agent.destination = target;
			destinationSet = true;
		}
	}

	void CheckIfPartnerIsNear()
	{
		//get nearest partner then check its position
		float dist = 9999999999;
		for(int i = 0; i < population.humans.Count; i++)
		{
			if (population.humans[i].c_Age >= r_AgeRange.x - m_ageRange && population.humans[i].c_Age < r_AgeRange.x + m_ageRange 
				&& isFemale != population.humans[i].GetComponent<HumanRepopulate>().isFemale)
			{
				float newDist = Vector3.Distance(population.humans[i].transform.position, transform.position);
				if (newDist < dist && newDist > 1f)
				{
					dist = newDist;
					mate = population.humans[i].GetComponent<Transform>();
					m_Stats = population.humans[i].GetComponent<HumanCurrentStats>();
				}
			}
		}
		
	}

	void Reproduce()
	{
		if (isFemale)
		{
			r_Timer += Time.deltaTime;
			if (r_Timer >= r_Duration)
			{
				audioManager.Play("Reproduction");
				var newHuman = Instantiate(baby[Random.Range(0, baby.Length)], transform.position + Vector3.forward, Quaternion.identity);
				population.AddHuman(newHuman);
				//once reproduction is done set timer to 0 and reproduce again
				r_Timer = 0;
				currentBabies++;
				r_CoolDown = 0;
				GetComponent<HumanEat>().FoodNearBy();
				GetComponent<HumanEat>().eatTimer = 0;
				GetComponent<HumanEat>().canEat = false;
				canReproduce = false;
			}
		}
	}
}
