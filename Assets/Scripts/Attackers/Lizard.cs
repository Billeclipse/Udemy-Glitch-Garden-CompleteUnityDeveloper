﻿using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Attacker))]
public class Lizard : MonoBehaviour {
	
	private Animator animator;
	private Attacker attacker;
	
	void Start () {
		animator = GetComponent<Animator>();
		attacker = GetComponent<Attacker>();
	}
	
	void  Update () {
	}
	
	void OnTriggerEnter2D(Collider2D collider){
		GameObject obj = collider.gameObject;
		if(obj.GetComponent<Defender>()){
			attacker.Attack(obj);
			animator.SetBool("isAttacking",true);
		}
	}
	
}