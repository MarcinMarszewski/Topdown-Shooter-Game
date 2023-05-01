using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Pistol : Gun
{
	[SerializeField]
	BulletStore bullets;

	float nextShotTime;
	float nextReload;

	private void Start()
	{
		bullets = GameObject.FindGameObjectWithTag("GameController").GetComponent<BulletStore>();
		nextShotTime = 0;
		nextReload = 0;
		ammoTotal = ammoMax;
		ammoReady = magCapacity;
	}

	override internal void Reload()
	{
		int reloadValue = Mathf.Min(magCapacity - ammoReady, ammoTotal);
		ammoReady += reloadValue;
		ammoTotal -= reloadValue;
	}
	
	override internal void Shoot()
	{
		GameObject temp = Instantiate(bullets.bulletList[0], barrelExit.position, transform.rotation);
		temp.GetComponent<Rigidbody2D>().velocity = transform.up * bulletSpeed;
		Destroy(temp, 10);
	}

	public override void ShootTrigger()
	{
		if (nextShotTime <= Time.realtimeSinceStartup && nextReload<= Time.realtimeSinceStartup && ammoReady>0)
		{
			Shoot();
			nextShotTime = Time.realtimeSinceStartup + shootDelay;
			ammoReady--;
		}
		if (ammoReady == 0) ReloadTrigger();
	} 

	public override void ReloadTrigger()
    {
		if(nextReload<=Time.realtimeSinceStartup)
        {
			Reload();
			nextReload = Time.realtimeSinceStartup + reloadTime;
        }
    }
}
