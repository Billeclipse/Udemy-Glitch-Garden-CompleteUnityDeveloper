using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Defender))]
public class GraveStone : MonoBehaviour {
	
	private Animator animator;
	
	void Start(){
		animator = GetComponent<Animator>();
	}
	
	void OnTriggerStay2D(Collider2D collider){
		GameObject obj = collider.gameObject;
		if(obj.GetComponent<Attacker>()){
			animator.SetTrigger("underAttackTrigger");
		}
	}
}