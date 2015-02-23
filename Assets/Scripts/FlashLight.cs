using UnityEngine;
using System.Collections;

public class FlashLight : MonoBehaviour 
{
	private bool FlashLights = false;

	void Update () 
	{
		if (Input.GetKeyDown (KeyCode.Q) && FlashLights == false) 
		{
			FlashLights = true;
			light.intensity = 3;

		} 
		else if (Input.GetKeyDown (KeyCode.Q) && FlashLights == true) 
		{
			FlashLights = false;

			light.intensity = 0;
		}

	
	}
}
