using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {
	
	public GameObject projectile, gun;
	
	private GameObject projectileParent;
	private Animator animator;
	private AttackerSpawner myLaneSpawner;
	
	void Start(){
		animator = GetComponent<Animator>();
		SetMyLaneSpawner();
		//Creates a Parent if necessary.
		projectileParent = GameObject.Find("Projectiles");
		
		if(!projectileParent){
			projectileParent = new GameObject("Projectiles");
		}

		animator.SetBool("isAttacking", true); // TODO: Remove it in the future also fix the cactus cost
	}
	
	void Update(){
		//if(IsAttackerAheadInLane()){
		//	animator.SetBool("isAttacking", true);
		//}else{
		//	animator.SetBool("isAttacking", false);
		//}
	}
	//Look throught all spawners, and set myLaneSpanwer if found
	void SetMyLaneSpawner(){
		AttackerSpawner[] allSpawners = GameObject.FindObjectsOfType<AttackerSpawner>();
		bool foundSpawner = false;
		foreach(AttackerSpawner spawner in allSpawners){
			if(spawner.transform.position.y == transform.position.y){
				myLaneSpawner = spawner;
				foundSpawner = true;
			}
		}
		if(!foundSpawner){
			Debug.LogError("Spawner Not Found!");
		} 
	}
	
	bool IsAttackerAheadInLane(){
		//Exit if no attackers in lane
		if( myLaneSpawner.transform.childCount <= 0){
			return false;
		}
		
		//If there are attackers are they ahead?
		foreach( Transform attacker in myLaneSpawner.transform){
			if(attacker.transform.position.x > transform.position.x){
				return true;
			}
		}
		// Attackers in lane, but behind us.
		return false;
	}
	
	private void Fire(){
		Instantiate(projectile, gun.transform.position, transform.rotation);

		//GameObject newProjectile = Instantiate(projectile) as GameObject;
		//newProjectile.transform.parent = projectileParent.transform;
		//newProjectile.transform.position = gun.transform.position;
	}
}