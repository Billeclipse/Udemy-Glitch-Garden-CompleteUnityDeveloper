﻿using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {
	
	public GameObject[] attackerPrefabArray;
	
	void Update () {
		foreach (GameObject thisAttacker in attackerPrefabArray){
			if(isTimeToSpawn(thisAttacker)){
				Spawn(thisAttacker);
			}
		}
	}
	
	void Spawn(GameObject myGameObject){
		GameObject myAttacker = Instantiate(myGameObject) as GameObject;
		myAttacker.transform.parent = transform;
		myAttacker.transform.position = transform.position;
	}
	
	bool isTimeToSpawn(GameObject attackerGameObject){
		float meanSpawnDelay = attackerGameObject.GetComponent<Attacker>().seenEverySeconds;
		float spawnsPerSecond = 1 /meanSpawnDelay;
		
		if(Time.deltaTime > meanSpawnDelay){
			Debug.LogWarning("Spawn rate capped by frame rate");
		}
		
		float threshold = spawnsPerSecond * Time.deltaTime / 5;
		
		return (Random.value < threshold);
	}
}