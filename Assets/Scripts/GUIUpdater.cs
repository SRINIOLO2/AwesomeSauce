/*
 * GUIUpdater.cs
 * by Ben Stewart
 * 
 * Updates the UI text*/


using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GUIUpdater : MonoBehaviour 
{
	public Text KeyText;
	//player script
	private Player PlayerScript;

	public void Start()
	{	// finds the player
		PlayerScript = GameObject.Find ("Player").GetComponent<Player>();
	}

	public void UpdateKeys(int Keys)
	{	
		//what the text says
		KeyText.text = ("Keys:" + Keys.ToString());
	}

}
