using UnityEngine;
using System.Collections;

public class KeySpawn : MonoBehaviour 
{
	[SerializeField]private Transform [] keySpawnPoints1;
	[SerializeField]private Transform [] keySpawnPoints2;
	[SerializeField]private Transform [] keySpawnPoints3;
	[SerializeField]private Transform [] keySpawnPoints4;
	[SerializeField]private Transform [] keySpawnPoints5;
	[SerializeField]private Transform [] keySpawnPoints6;


	private void Awake()
	{
		GameObject instance1 = Instantiate (Resources.Load ("key1"))as GameObject;
		GameObject instance2 = Instantiate (Resources.Load ("key2"))as GameObject;
		GameObject instance3 = Instantiate (Resources.Load ("key3"))as GameObject;
		GameObject instance4 = Instantiate (Resources.Load ("key4"))as GameObject;
		GameObject instance5 = Instantiate (Resources.Load ("key5"))as GameObject;
		GameObject instance6 = Instantiate (Resources.Load ("key6"))as GameObject;
		Transform spawnPoint1 = keySpawnPoints1 [Random.Range (0, 4)];
		Transform spawnPoint2 = keySpawnPoints2 [Random.Range (0, 4)];
		Transform spawnPoint3 = keySpawnPoints3 [Random.Range (0, 4)];
		Transform spawnPoint4 = keySpawnPoints4 [Random.Range (0, 4)];
		Transform spawnPoint5 = keySpawnPoints5 [Random.Range (0, 4)];
		Transform spawnPoint6 = keySpawnPoints6 [Random.Range (0, 4)];
		instance1.transform.position = spawnPoint1.position;
		instance2.transform.position = spawnPoint2.position;
		instance3.transform.position = spawnPoint3.position;
		instance4.transform.position = spawnPoint4.position;
		instance5.transform.position = spawnPoint5.position;
		instance6.transform.position = spawnPoint6.position;
	}
}
