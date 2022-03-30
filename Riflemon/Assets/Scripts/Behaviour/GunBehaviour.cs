using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class GunBehaviour : MonoBehaviour
{
    public float fireRate;
    public float timeToLive;
    public float damagePerBullet;
    public float bulletSpeed;
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
        GameObject newBullet = Instantiate(bullet, getGunSpawnPoint(direction), Quaternion.Euler( getRotation(direction)));
        newBullet.GetComponent<BulletBehaviour>().setUp(timeToLive, damagePerBullet);
        newBullet.GetComponent<Rigidbody2D>().velocity = direction.normalized * bulletSpeed;
    }

    private Vector3 getRotation(Vector2 direction)
    {
        float zAngle = (float)Math.Atan2((float)direction.x ,(float)direction.y);
        zAngle = 180f*zAngle /(float)Math.PI;
        return new Vector3(0, 0, -zAngle);
    }

    private Vector3 getGunSpawnPoint(Vector2 direction)
    {
        return new Vector3(this.transform.position.x + direction.x, this.transform.position.y + direction.y, 0);
    }


  
}
