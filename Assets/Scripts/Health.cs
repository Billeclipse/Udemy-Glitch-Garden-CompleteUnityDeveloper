using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

	public float health = 10f;
	
	public void DealDamage(float damage){
		health -= damage;
		if(health <= 0){
			DestroyObject();
		}
	}
	
	void DestroyObject(){
		Destroy(gameObject);
	}
}