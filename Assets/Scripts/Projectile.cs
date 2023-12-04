using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

	public float speed;
	public float lifeTime;
	public int damage;

    public GameObject explosion;

    private void Start()
	{
		Invoke("DestroyProjectile", lifeTime);
	}

	private void Update()
	{
		//not for playing just moving forward, so the difference
		transform.Translate(Vector2.up * speed * Time.deltaTime);
	}
	
	private void DestroyProjectile()
	{
		//Quaternion.identity -> at what rotation to spawn particle ffect
		Instantiate(explosion, transform.position, Quaternion.identity);
		Destroy(gameObject);
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.tag == "Enemy")
		{
			collision.GetComponent<Enemy>().TakeDamage(damage);
			DestroyProjectile();
		}
	}
}
