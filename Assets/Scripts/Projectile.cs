using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {
	
	public float speed,damage;
	
	void Start () {
		Rigidbody2D myRigidbody = gameObject.AddComponent<Rigidbody2D>();
		myRigidbody.isKinematic = true;
	}
	
	void Update () {
		transform.Translate(Vector3.right * speed * Time.deltaTime);
	}
	
	void OnTriggerEnter2D(Collider2D collider){
		GameObject currentTarget = collider.gameObject;
		if(currentTarget.GetComponent<Attacker>()){
			Health currentTargetHealth = currentTarget.GetComponent<Health>();
			if(currentTargetHealth){
				currentTargetHealth.DealDamage(damage);
				Destroy(gameObject);
			}
		}	
	}
}