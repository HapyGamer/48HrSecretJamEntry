using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitToDestroy : MonoBehaviour {

	public float timeTillDestroy = 40;

	private float timer = 0;

	private FoodManager foods;

	private void Start()
	{
		foods = FindObjectOfType<FoodManager>().GetComponent<FoodManager>();
		timer = 0;
	}

	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if(timeTillDestroy <= timer)
		{
			foods.RemoveFood(gameObject);
			Destroy(gameObject);
		}
	}
}
