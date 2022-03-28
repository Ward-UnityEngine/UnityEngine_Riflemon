using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    private float bulletDamage;

    public void setUp(float timeToLive,float bulletDamage)
    {
        this.bulletDamage = bulletDamage;
        Invoke("liveDestroy", timeToLive);
    }


    public void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject otherCol = collision.otherCollider.gameObject;
        if (otherCol.CompareTag("Player_tag") || otherCol.CompareTag("Enemy_tag"))
        {
            otherCol.GetComponent<HealthBehaviour>().bulletHit(bulletDamage);
        }
        GameObject.Destroy(this.gameObject);
    }

    private void liveDestroy()
    {
        GameObject.Destroy(this.gameObject);
    }
}
