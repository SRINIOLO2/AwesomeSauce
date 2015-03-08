#pragma strict

	var flashlight : Transform ;
	
function Start () {


}




function Update () {

if(Input.GetKeyDown(KeyCode.Q))
	{
		flashlight.audio.Play ();
		}
}