using UnityEngine;

public abstract class Gun : MonoBehaviour
{
	[SerializeField]
	internal int ammoMax, ammoTotal, magCapacity, ammoReady;
	[SerializeField]
	internal float shootDelay, reloadTime, bulletSpeed;
	[SerializeField]
	internal Transform barrelExit;

	internal abstract void Reload();

	internal abstract void Shoot();

	public abstract void ShootTrigger();

	public abstract void ReloadTrigger();
}
