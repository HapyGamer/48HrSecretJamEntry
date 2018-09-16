using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpTrees : MonoBehaviour {

	public float timeDecrease = 0.2f;

	private TreeManager treesMan;

	// Use this for initialization
	void Start () {
		treesMan = FindObjectOfType<TreeManager>().GetComponent<TreeManager>();
	}
	
	public void PowerUp()
	{
		foreach(GameObject g in treesMan.trees)
		{
			g.GetComponent<TreeDroppingFruits>().timeTillNextDrop -= timeDecrease;
		}
	}
}
