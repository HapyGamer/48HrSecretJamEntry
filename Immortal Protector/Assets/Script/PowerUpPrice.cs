using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUpPrice : MonoBehaviour {

	public int defaultPrice;
	public int increaseAfterPurchase;
	public PowerUpHuman powerUpH;
	public PowerUpTrees powerUpT;

	private int currentPrice;
	private Text text;
	private PlayerInventory souls;
	private AudioManager audioManager;

	// Use this for initialization
	void Start ()
	{
		text = transform.GetChild(2).GetComponent<Text>();
		souls = FindObjectOfType<PlayerInventory>().GetComponent<PlayerInventory>();
		audioManager = FindObjectOfType<AudioManager>().GetComponent<AudioManager>();
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
			audioManager.Play("PerkUnlocked");
			if (powerUpH != null)
			{
				powerUpH.PowerUp();
			}
			else
			{
				powerUpT.PowerUp();
			}
			currentPrice += increaseAfterPurchase;
			SetText();
		}
	}
}
