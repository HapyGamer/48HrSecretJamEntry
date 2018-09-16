using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUpPrice : MonoBehaviour {

	public int defaultPrice;
	public int increaseAfterPurchase;

	private int currentPrice;
	private Text text;
	private PlayerInventory souls;

	// Use this for initialization
	void Start ()
	{
		text = transform.GetChild(2).GetComponent<Text>();
		souls = FindObjectOfType<PlayerInventory>().GetComponent<PlayerInventory>();
		currentPrice = defaultPrice;
		SetText();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void SetText()
	{
		text.text = "Souls: " + currentPrice;
	}

	public void BuyThis()
	{
		if (currentPrice <= souls.item[1].howMuchIHave)
		{
			souls.item[1].howMuchIHave -= currentPrice;
			currentPrice += increaseAfterPurchase;
			SetText();
		}
	}
}
