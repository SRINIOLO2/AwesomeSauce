using UnityEngine;
using System.Collections;

public class MainMenuBtn : MonoBehaviour 
{

	private void OnMouseDown()
	{
		Application.LoadLevel ("MainMenu");
	}

}
