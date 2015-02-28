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

	public float speedBoost = 5f;

	public GameObject  playerCamera = null;

	private Vector3    velocity     = Vector3.zero;

	private float      rotationY    = 0;

	public float       minimumY     = -60F;
	public float       maximumY     = 60F;

	public float       sensitivityX = 15F;
	public float       sensitivityY = 15F;

	public int Keys = 0;

	public int maxKeys = 6;

	public GameObject guiUpdater;

	private GameObject LaserTrap1;



	private GUIUpdater updater;
	

	// Use this for initialization
	private void Start () 
	{

		// references the character controller
		controller = GetComponent <CharacterController> ();
		//finds the game object with the GUIUpdater script
		guiUpdater = GameObject.Find("KeyText");
		// makes it so that you can update the GUIUpdater
		updater = guiUpdater.GetComponentInParent<GUIUpdater> ();

		LaserTrap1 = GameObject.Find ("LaserTrap1");


	}

	// Update is called once per frame
	private void Update () 
	{


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
		//if(controller.isGrounded)
		//{
            // press space to jump
	    //	if(Input.GetButtonDown("Jump"))               
		 // 	{
		//	    print ("Jumping");

          //      velocity.y = jumpSpeed;
			
		  // 	}
		 // else
		//	{
				//velocity.y = 0;
			//}
	   // }
		 
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
			speed = 25;
		}
		if(Input.GetKeyUp(KeyCode.LeftShift))
		{
			speed = 10;
		}

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
			// if you get max points you will win if you have less you will lose



		}
		if (other.tag == "LaserTrapTrigger1") 
		{
			if(Keys == 1)
			{
				print("OFF");
				LaserTrap1.SetActive(false);


			}

				
		}

    }




}

