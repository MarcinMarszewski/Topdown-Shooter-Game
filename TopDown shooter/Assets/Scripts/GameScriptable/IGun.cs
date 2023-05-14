using UnityEngine;

public abstract class Gun : MonoBehaviour
{
	[SerializeField]
	internal int ammoMax, ammoTotal, magCapacity, ammoReady;
	[SerializeField]
	internal float shootDelay, reloadTime, bulletSpeed, bulletLifetime;
	[SerializeField]
	internal Transform barrelExit;

	[SerializeField]
	internal BulletStore bullets;

	internal float nextShotTime;
	internal float nextReload;

	private void Start()
	{
		bullets = GameObject.FindGameObjectWithTag("GameController").GetComponent<BulletStore>();
		nextShotTime = 0;
		nextReload = 0;
		ammoTotal = ammoMax;
		ammoReady = magCapacity;
	}

	internal void Reload()
	{
		int reloadValue = Mathf.Min(magCapacity - ammoReady, ammoTotal);
		ammoReady += reloadValue;
		ammoTotal -= reloadValue;
	}

	internal abstract void Shoot();

	public void ShootTrigger()
	{
		if (nextShotTime <= Time.realtimeSinceStartup && nextReload <= Time.realtimeSinceStartup && ammoReady > 0)
		{
			Shoot();
			nextShotTime = Time.realtimeSinceStartup + shootDelay;
			ammoReady--;
		}
		if (ammoReady == 0) ReloadTrigger();
	}

	public void ReloadTrigger()
	{
		if (nextReload <= Time.realtimeSinceStartup)
		{
			Reload();
			nextReload = Time.realtimeSinceStartup + reloadTime;
		}
	}
}
