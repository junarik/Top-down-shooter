using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public int health;

	[HideInInspector]
	public Transform player;

	public float speed;
	public int damage = 1;

	public float timeBetweenAttacks;

	public void Start()
	{
		player = GameObject.FindGameObjectWithTag("Player").transform;
	}

	public void TakeDamage(int damageAmount){
		health -= damageAmount;

		if(health <= 0)
		{
			Destroy(this.gameObject);
		}
	}
}
