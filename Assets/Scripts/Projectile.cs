using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	[SerializeField] float speed;
	[SerializeField] float damage;
	
	void Start () {
		Rigidbody2D myRigidbody = gameObject.AddComponent<Rigidbody2D>();
		myRigidbody.isKinematic = true;
	}
	
	void Update () {
		transform.Translate(Vector3.right * speed * Time.deltaTime);
	}
	
	void OnTriggerEnter2D(Collider2D otherCollider){
		var health = otherCollider.GetComponent<Health>();
		var attacker = otherCollider.GetComponent<Attacker>();

		if (attacker && health){
			health.DealDamage(damage);
			Destroy(gameObject);
		}	
	}
}