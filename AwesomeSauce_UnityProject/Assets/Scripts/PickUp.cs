/*
 * PickUp.cs
 * By Ben Stewart
 * 
 * Destorys the pick up object when the player runs into it*/

using UnityEngine;
using System.Collections;

public class PickUp : MonoBehaviour 
{

	//When the player runs into the pick up the object will be Destoryed 
	public void OnTriggerEnter (Collider other)
	{
		if (other.tag == "Player")
		{
			Destroy (this.gameObject);
		}
	}




}
