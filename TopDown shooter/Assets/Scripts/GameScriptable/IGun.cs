using UnityEngine;

public interface IGun
{
    void Shoot();
    void Reload();
}

public abstract class Gun : MonoBehaviour, IGun
{
    [SerializeField]
    internal int ammoMax, ammoTotal, ammo;
    [SerializeField]
    internal float shootSpeed, reloadTime, bulletSpeed;
    [SerializeField]
    internal Transform barrelExit;

    public abstract void Reload();

    public abstract void Shoot();
}
