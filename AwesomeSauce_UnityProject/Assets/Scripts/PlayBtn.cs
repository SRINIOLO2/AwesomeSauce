using UnityEngine;
using System.Collections;

public class PlayBtn : MonoBehaviour 
{

	private void OnMouseDown()
	{
		Application.LoadLevel ("test1");
	}


}
