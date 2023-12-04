using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {
	
	public GameObject projectile;
	public Transform shotPoint;
	public float timeBetweenShots;

	private float shotTime;


	void Update () {
		Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
		
		//Кут weapon (на скільки градусів повернути, щоб було направленне на курсор)
		float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

		// Vector3.forward -> (Z.Axis)
		Quaternion rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward); 
		transform.rotation = rotation;

		//0 - for left, 1 - for right
		if(Input.GetMouseButton(0)){
			if(Time.time >= shotTime)
			{
				Instantiate(projectile, shotPoint.position, transform.rotation);
				shotTime = Time.time + timeBetweenShots;
			}
		}
	}
}
