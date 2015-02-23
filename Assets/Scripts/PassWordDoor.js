#pragma strict
// Created by Daehwan_Kim
 public var stringToEdit : String = "Type Here";
 public var key : String = "685631";
 public var panelActive : boolean = false;
 public var pass : GameObject = null;
 
 
function Start () {
 	pass = GameObject.FindGameObjectWithTag("password");
   
}
 
 function OnGUI () 
 {
 if (panelActive)
 {
 stringToEdit = GUI.TextField (Rect (850, 500, 200, 50), stringToEdit, 100 );
 }
 }

 function Update()
 {
if (Input.GetMouseButtonDown(0))
 {
 if (stringToEdit == key)
 {
 	var password: PassWordDoorAble;
    
	password = pass.GetComponent(PassWordDoorAble);
	password.enter = true;
	gameObject.renderer.material.color = Color.green;
	gameObject.light.color = Color.green;
   
  }
 
 }
 }

 function OnTriggerEnter(other : Collider)
 {
 if (other.transform.tag == "Player")
 {
 panelActive = true;
 }
 }

 function OnTriggerExit(other : Collider)
 {
 if (other.transform.tag == "Player")
 {
 panelActive = false;
 }

 }
