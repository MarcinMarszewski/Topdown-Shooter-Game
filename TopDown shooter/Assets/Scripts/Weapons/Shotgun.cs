using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Gun
{
    [SerializeField]
    float spread;
    [SerializeField]
    float velocityNormal;

    // Start is called before the first frame update
    internal override void Shoot()
    {
        System.Random rand = new System.Random(System.DateTime.Now.Second);
        int shotAmount = rand.Next(4, 7);
        for(int i=0; i<shotAmount; i++)
        {
            Quaternion rot = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z+ (float)(((rand.NextDouble() * 2) - 1) * spread) + 90);
            GameObject temp = Instantiate(bullets.bulletList[1], barrelExit.position, rot);
            temp.GetComponent<Rigidbody2D>().velocity = temp.transform.up * bulletSpeed * (float)(1+(((rand.NextDouble() * 2) - 1) * velocityNormal));
            Destroy(temp, bulletLifetime);
        }
    }
}
