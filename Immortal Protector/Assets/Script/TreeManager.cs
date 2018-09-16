using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeManager : MonoBehaviour {

	public List<GameObject> trees;

	private void Start()
	{
		FindTrees();
	}

	public void AddFood(GameObject gameObject)
	{
		trees.Add(gameObject);
	}

	public void RemoveFood(GameObject gameObject)
	{
		trees.Remove(gameObject);
		for (var i = trees.Count - 1; i > -1; i--)
		{
			if (trees[i] == null)
				trees.RemoveAt(i);
		}
	}

	void FindTrees()
	{
		GameObject[] GO = GameObject.FindGameObjectsWithTag("Tree");
		foreach (GameObject g in GO)
		{
			trees.Add(g);
		}
	}

}
