using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Pistol : Gun
{
	override internal void Shoot()
	{
		GameObject temp = Instantiate(bullets.bulletList[0], barrelExit.position, transform.rotation);
		temp.GetComponent<Rigidbody2D>().velocity = transform.up * bulletSpeed;
		Destroy(temp, bulletLifetime);
	}
}
