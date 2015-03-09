/*
 * Player.cs
 * by Ben Stewart
 * 
 * This makes the player move and able to hit triggers.*/

using UnityEngine;
using System.Collections;


public class Player : MonoBehaviour 
{

	private CharacterController controller = null;

    public float speed = 10f;

    public float jumpSpeed = 3f;

	public float speedBoost = 10f;

	public GameObject  playerCamera = null;

	private Vector3    velocity     = Vector3.zero;

	private float      rotationY    = 0;

	public float       minimumY     = -60F;
	public float       maximumY     = 60F;

	public float       sensitivityX = 15F;
	public float       sensitivityY = 15F;

	public int Keys = 0;

	public int maxKeys = 8;

	public float Timer = 0f;

	public GameObject guiUpdater;
	public GameObject guiUpdater2;

	private GUIUpdater updater;

	private GameObject LaserTrap0;
	private GameObject LaserTrap1;
	private GameObject LaserTrap2;
	private GameObject LaserTrap3;
	private GameObject LaserTrap4;
	private GameObject LaserTrap5;
	private GameObject LaserTrap6;
	private GameObject LaserTrap7;
	private GameObject LaserTrap8;
	private GameObject LaserTrap9;
	private GameObject LaserTrap10;
	private GameObject LaserTrap11;
	private GameObject LaserTrap12;
	private GameObject LaserTrap13;
	private GameObject LaserTrap14;
	// Use this for initialization
	private void Start () 

	{   LaserTrap0 = GameObject.Find ("LaserTrap0");
		LaserTrap0.SetActive(false);
		// references the character controller
		controller = GetComponent <CharacterController> ();
		//finds the game object with the GUIUpdater script
		guiUpdater = GameObject.Find("KeyText");

		guiUpdater2 = GameObject.Find ("TimerText");
		// makes it so that you can update the GUIUpdater
		updater = guiUpdater.GetComponentInParent<GUIUpdater> ();
		updater = guiUpdater2.GetComponentInParent<GUIUpdater> ();



		LaserTrap1 = GameObject.Find ("LaserTrap1");
		LaserTrap2 = GameObject.Find ("LaserTrap2");
		LaserTrap3 = GameObject.Find ("LaserTrap3");
		LaserTrap4 = GameObject.Find ("LaserTrap4");
		LaserTrap5 = GameObject.Find ("LaserTrap5");
		LaserTrap6 = GameObject.Find ("LaserTrap6");
		LaserTrap7 = GameObject.Find ("LaserTrap7");
		LaserTrap8 = GameObject.Find ("LaserTrap8");
		LaserTrap9 = GameObject.Find ("LaserTrap9");
		LaserTrap10 = GameObject.Find ("LaserTrap10");
		LaserTrap11 = GameObject.Find ("LaserTrap11");
		LaserTrap12 = GameObject.Find ("LaserTrap12");
		LaserTrap13 = GameObject.Find ("LaserTrap13");
		LaserTrap14 = GameObject.Find ("LaserTrap14");
	}

	// Update is called once per frame
	private void Update () 
	{

		TimerUpdater ();
		// Assume no input
		velocity.x = 0;
		velocity.z = 0;



		// Get user input
		float horizontalInput = Input.GetAxis ("Horizontal");
		float verticalInput = Input.GetAxis ("Vertical");



		// Apply all user input to the singular velocity var
		velocity += transform.right * horizontalInput;
		velocity += transform.forward * verticalInput;


		// you have to be grounded
		/*if(controller.isGrounded)
		{
            // press space to jump
	    	if(Input.GetButtonDown("Jump"))               
		 	{
		//	    print ("Jumping");

               velocity.y = jumpSpeed;
			
		  	}
		  else
		   {
				velocity.y = 0;
		   }
	   }
		*/ 
		velocity += Physics.gravity * Time.deltaTime;

		// Apply all user variable to motion
		controller.Move ( velocity * speed * Time.deltaTime);

		// Inputs for Mouse
		float mouseXInput = Input.GetAxis ("Mouse X");
		float mouseYInput = Input.GetAxis ("Mouse Y");

		this.transform.Rotate (0, mouseXInput * sensitivityX , 0);
		


		rotationY += mouseYInput * sensitivityY;
		// Gets the value between rotationY, minimumY,and maximumY for rotating the player
		rotationY = Mathf.Clamp (rotationY,  minimumY, maximumY);
		
		playerCamera.transform.localEulerAngles = new Vector3(-rotationY, playerCamera.transform.localEulerAngles.y, 0);

		if (Input.GetKeyDown (KeyCode.LeftShift))
		{
			speed = 15;
		}
		if(Input.GetKeyUp(KeyCode.LeftShift))
		{
			speed = 10;
		}
       
	}

	private void TimerUpdater()
	{
		Timer = ( Timer +1  * Time.deltaTime);
		updater.UpdateTimer (Timer);
	}

	/// <summary>
	/// When you walk into a trigger one of the events will happen
	/// </summary>
	/// <param name="other">Other.</param>
  private void OnTriggerEnter(Collider other)
    {
       // print("hit");
		// if you walk into an object that is tagged with Killzone you will die
        if (other.tag == "Killzone")
        {
            Destroy(this.gameObject);
			Application.LoadLevel("GameOver");
            print("Dead");
        }

		// if you walk into an object that is tagged with points will get a point
		if (other.tag == "Key")
		{
			// adds 1 to key
			Keys++;
			//updates the key text when you get a point
			updater.UpdateKeys(Keys);

		}
		//if you walk into an object that is tagged with Damage you will lose a point

		// if you walk into WinZone trigger you will go to the win scene
		if (other.tag == "WinZone")
		{
			if(Keys == maxKeys)
			{
				Application.LoadLevel("Win");
			}



		}
		if (other.tag == "LaserTrap")
		{
			print ("Die");
			Application.LoadLevel("GameOver");
		}

		if (other.tag == "LaserTrapTrigger1") 
		{


			if(Keys == 1)
			{
				print("OFF");
				LaserTrap1.SetActive(false);

				LaserTrap0.SetActive(true);


			}

				
		}
		
		if (other.tag == "LaserTrapTrigger2") 
		{
			if(Keys >= 2)
			{
				print("OFF");
				LaserTrap1.SetActive(true);
				LaserTrap2.SetActive(false);

			}
			if(Keys == 6)
			{
				LaserTrap2.SetActive(true);
			}
			
			
		}
		if (other.tag == "LaserTrapTrigger3") 
		{
			if(Keys == 3)
			{
				print("OFF");
				LaserTrap2.SetActive(true);
				LaserTrap3.SetActive(false);
				
			}
			
			
		}
		if (other.tag == "LaserTrapTrigger4") 
		{
			if(Keys == 4)
			{
				print("OFF");
				LaserTrap3.SetActive(true);
				LaserTrap13.SetActive(false);
			}
			
			
		}
		if (other.tag == "LaserTrapTrigger5") 
		{
			if(Keys == 5)
			{
				print("OFF");
				LaserTrap13.SetActive(true);
				LaserTrap4.SetActive(false);

			}
			
			
		}
		if (other.tag == "LaserTrapTrigger6")
		{
			if(Keys == 7)
			{
				LaserTrap4.SetActive(true);
				LaserTrap5.SetActive(false);
				LaserTrap6.SetActive(false);
				LaserTrap7.SetActive(false);
				LaserTrap8.SetActive(false);
				LaserTrap9.SetActive(false);
				LaserTrap10.SetActive(false);
				LaserTrap11.SetActive(false);
				LaserTrap12.SetActive(false);
				LaserTrap1.SetActive(false);

			}
				
		}
		if (other.tag == "EnemyLight") 
		{
			print ("Die");
			Application.LoadLevel("GameOver");
				
		}

		if (Keys == maxKeys) 
		{
			LaserTrap14.SetActive(false);
		}


    }




}

