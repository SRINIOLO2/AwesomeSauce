#pragma strict
// Created by Daehwan_Kim 26.04.14


 public var smooth = 2.0;
 public var DoorOpenAngle = 90.0;
 public var DoorCloseAngle = 0.0;
 public var open 			 : boolean;
 public var enter 			 : boolean;
 public var DoorGui		     : GUIText         = null;
 public var lockDoorGui	     : GUIText         = null;

 
function Start () {

enter = false;
DoorGui.enabled     = false;
lockDoorGui.enabled     = false;
open = false;

}



function Update () {

if(open == true)
{
var target = Quaternion.Euler(0,DoorOpenAngle,0);
transform.localRotation = Quaternion.Slerp(transform.localRotation,target, Time.deltaTime*smooth);
}

if(open == false)
{
var target1 = Quaternion.Euler(0,DoorCloseAngle,0);
transform.localRotation = Quaternion.Slerp(transform.localRotation,target1,Time.deltaTime*smooth);
}


if(enter == true)
{
if(Input.GetKeyDown("r"))
{
open = true;
}
}

if(enter == false)
{
open = false;
}



}
function OnTriggerEnter (other : Collider){ 
//Key system
 if (other.gameObject.tag == "Player")
 {
  if(enter == false)
  {
  	lockDoorGui.enabled = true;
  	{ 
    yield WaitForSeconds (5);
    lockDoorGui.enabled = false;
 	}
  }
  else if(enter == true)
  {
 	DoorGui.enabled      = true;
   	{ 
    yield WaitForSeconds (5);
    DoorGui.enabled     = false;
 	}
  }
 } 
}







