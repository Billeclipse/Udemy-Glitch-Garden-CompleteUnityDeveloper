using UnityEngine;
using System.Collections;

public class AttackerSpawner : MonoBehaviour {

	[SerializeField] float minSpawnDelay = 1f;
	[SerializeField] float maxSpawnDelay = 5f;
	[SerializeField] public GameObject[] attackerPrefabArray;

	private bool spawn = true;

	// TODO: Delete Code if not used
	//public GameObject[] attackerPrefabArray;

	IEnumerator Start()
	{
		// TODO: Find a better way to spawn attackers
		while (spawn)
		{
			yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
			SpawnAttacker();
		}
	}

	void Update () {
		// TODO: Delete Code if not used
		//foreach (GameObject thisAttacker in attackerPrefabArray)
		//{
		//	if (isTimeToSpawn(thisAttacker))
		//	{
		//		Spawn(thisAttacker);
		//	}
		//}
	}

	private void SpawnAttacker()
	{
		foreach (GameObject thisAttacker in attackerPrefabArray)
		{
			Instantiate(thisAttacker, transform.position, transform.rotation);
		}			
	}

	// TODO: Delete Code if not used
	//void Spawn(GameObject myGameObject)
	//{
	//	GameObject myAttacker = Instantiate(myGameObject) as GameObject;
	//	myAttacker.transform.parent = transform;
	//	myAttacker.transform.position = transform.position;
	//}

	//bool isTimeToSpawn(GameObject attackerGameObject)
	//{
	//	float meanSpawnDelay = attackerGameObject.GetComponent<Attacker>().seenEverySeconds;
	//	float spawnsPerSecond = 1 / meanSpawnDelay;

	//	if (Time.deltaTime > meanSpawnDelay)
	//	{
	//		Debug.LogWarning("Spawn rate capped by frame rate");
	//	}

	//	float threshold = spawnsPerSecond * Time.deltaTime / 5;

	//	return (Random.value < threshold);
	//}
}