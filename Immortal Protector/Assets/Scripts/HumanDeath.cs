using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanDeath : MonoBehaviour {

	public void Death()
	{
		Destroy(gameObject);
		//maybe also spawn like a gravestone or something
	}
}
