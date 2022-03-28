using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class GunBehaviour : MonoBehaviour
{
    public float fireRate;
    public float timeToLive;
    public float damagePerBullet;
    public GameObject bullet;
    private System.DateTime timeStamp;

    public void wantsToShoot(Vector2 direction)
    {
        System.DateTime newTimeStamp = System.DateTime.Now;
        System.TimeSpan timeSpan = newTimeStamp - timeStamp;
        if ( timeSpan.Milliseconds > fireRate)
        {
            shoot(direction);
        }
    }

    private void shoot(Vector2 direction)
    {
        GameObject newBullet = Instantiate(bullet, this.transform.position, Quaternion.LookRotation(new Vector3(direction.x, direction.y, 0)));
        newBullet.GetComponent<BulletBehaviour>().setUp(timeToLive, damagePerBullet);
    }


  
}
