using UnityEngine;
using System.Collections;

public class Attacker : MonoBehaviour {

	[Tooltip ("Average number of seconds between appearances")]
	public float seenEverySeconds;
	private float currentSpeed;
	private GameObject currentTarget;
	private Animator currentAnimator;
	
	void Start () {
		Rigidbody2D myRigidbody = gameObject.AddComponent<Rigidbody2D>();
		myRigidbody.isKinematic = true;
		currentAnimator = GetComponent<Animator>();
	}
	
	void Update () {
		transform.Translate(Vector3.left * currentSpeed * Time.deltaTime);
		if(!currentTarget){
			currentAnimator.SetBool("isAttacking",false);
		}		
	}
		
	public void SetSpeed(float speed){
		currentSpeed = speed;
	}
	
	public void StrikeCurrentTarget(float damage){
		if(currentTarget){
			Health currentTargetHealth = currentTarget.GetComponent<Health>();
			if(currentTargetHealth){
				currentTargetHealth.DealDamage(damage);
			}
		}
	}
	
	public void Attack (GameObject obj){
		currentTarget = obj;
	}
}