using UnityEngine;
using System.Collections;

public class KeySpawn : MonoBehaviour 
{
	[SerializeField]private Transform [] keySpawnPoints1;
	[SerializeField]private Transform [] keySpawnPoints2;
	[SerializeField]private Transform [] keySpawnPoints3;
	[SerializeField]private Transform [] keySpawnPoints4;


	private void Awake()
	{
		GameObject instance1 = Instantiate (Resources.Load ("key1"))as GameObject;
		GameObject instance2 = Instantiate (Resources.Load ("key2"))as GameObject;
		GameObject instance3 = Instantiate (Resources.Load ("key3"))as GameObject;
		GameObject instance4 = Instantiate (Resources.Load ("key4"))as GameObject;
		Transform spawnPoint1 = keySpawnPoints1 [Random.Range (0, 4)];
		Transform spawnPoint2 = keySpawnPoints2 [Random.Range (0, 4)];
		Transform spawnPoint3 = keySpawnPoints3 [Random.Range (0, 4)];
		Transform spawnPoint4 = keySpawnPoints4 [Random.Range (0, 4)];
		instance1.transform.position = spawnPoint1.position;
		instance2.transform.position = spawnPoint2.position;
		instance3.transform.position = spawnPoint3.position;
		instance4.transform.position = spawnPoint4.position;
	}
}
