using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

	public float speed;
	public float lifeTime;

	private void Start()
	{
		Destroy(gameObject, lifeTime);
	}

	private void Update()
	{
		//not for playing just moving forward, so the difference
		transform.Translate(Vector2.up * speed * Time.deltaTime);
	}
	
}
