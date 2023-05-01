using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : Gun
{
    [SerializeField]
    GameObject bullet;

    override public void Reload()
    {
        throw new System.NotImplementedException();
    }
    
    override public void Shoot()
    {
        GameObject temp = Instantiate(bullet, barrelExit.position, transform.rotation);
        temp.GetComponent<Rigidbody2D>().velocity = transform.forward * bulletSpeed;
        Destroy(temp, 10);
    }
}
