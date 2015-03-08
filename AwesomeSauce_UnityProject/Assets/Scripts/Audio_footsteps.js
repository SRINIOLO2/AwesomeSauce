#pragma strict

static var makeSound : boolean = true;

function Start () {
makeSound = true;
audio.volume = 0;

}




function Update () {

if(makeSound == true)
{
	audio.mute = false;
	if(Input.GetKey("a") || Input.GetKey("w") || Input.GetKey("d")
	|| Input.GetKey("s") ) 
	{


		audio.volume = 1;

	}


	else 
	{
	
		audio.volume = 0;


	}
}
else
{
	audio.mute = true;
}





}