/*
 * EnemyAI.cs
 * 
 * By Ben Stewart
 * 
 * This Scipt is for the Enemies of the game*/



using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour 
{

	[SerializeField]private float patrolSpeed = 2f;
	[SerializeField]private float patrolWaitTime = 1f;
	[SerializeField]private Transform [] patrolWayPoints;

	[SerializeField]private NavMeshAgent nav;
	[SerializeField]private float patrolTimer;
	[SerializeField]private int wayPointIndex;


	private void Awake()
	{
		nav = GetComponent<NavMeshAgent> ();
	}

	private void Update()
	{
		Patrolling ();
	}

	private void Patrolling()
	{
		nav.speed = patrolSpeed;

		if ( nav.remainingDistance < nav.stoppingDistance) 
		{
						patrolTimer += Time.deltaTime;


			if (patrolTimer >= patrolWaitTime) 
			{
				if (wayPointIndex == patrolWayPoints.Length - 1)
					wayPointIndex = 0;
				else
				wayPointIndex ++;


				patrolTimer = 0;

			}

		} 
		else
						
			patrolTimer = 0;


		nav.destination = patrolWayPoints[wayPointIndex].position;
	}

}
