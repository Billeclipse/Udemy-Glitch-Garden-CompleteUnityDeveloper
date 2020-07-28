using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

	[SerializeField] float health = 10f;
	[SerializeField] GameObject deathVFX;

	public void DealDamage(float damage){
		health -= damage;
		if(health <= 0){
			DestroyObject();
		}
	}
	
	void DestroyObject(){
		TriggerDeathVFX();
		Destroy(gameObject);
	}

	private void TriggerDeathVFX()
    {
		if(!deathVFX) { return; }
		GameObject deathVFXObject = Instantiate(deathVFX, transform.position, transform.rotation);
		Destroy(deathVFXObject, 1f);
	}
}