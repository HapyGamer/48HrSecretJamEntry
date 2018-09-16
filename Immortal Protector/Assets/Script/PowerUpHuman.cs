using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpHuman : MonoBehaviour {

	public int babiesIncrease = 1;
	public float h_sightRangeIncrease;
	public float r_sightRangeIncrease;
	public int maxAgeIncrease;
	public int hungerIncrease;

	private ShopManager shop;

	// Use this for initialization
	void Start () {
		shop = FindObjectOfType<ShopManager>().GetComponent<ShopManager>();
	}
	
	public void PowerUp()
	{
		shop.s_babiesIncrease += babiesIncrease;
		shop.s_hungerIncrease += hungerIncrease;
		shop.s_h_sightRangeIncrease += h_sightRangeIncrease;
		shop.s_maxAgeIncrease += maxAgeIncrease;
		shop.s_r_sightRangeIncrease += r_sightRangeIncrease;
	}
}
