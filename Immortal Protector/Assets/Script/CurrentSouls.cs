using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentSouls : MonoBehaviour {

	private PlayerInventory souls;
	private Text text;

	// Use this for initialization
	void Start ()
	{
		souls = FindObjectOfType<PlayerInventory>().GetComponent<PlayerInventory>();
		text = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		text.text = "Souls: " + souls.item[1].howMuchIHave;
	}
}
