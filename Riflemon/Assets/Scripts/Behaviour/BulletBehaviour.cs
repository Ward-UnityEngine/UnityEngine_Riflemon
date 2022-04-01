using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    private float bulletDamage;
    private Rigidbody2D rb;

    private void OnEnable()
    {
        rb = GetComponent<Rigidbody2D>();
    }



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
        Invoke("liveDestroy", 1);
        rb.drag = 3; //makes the bullet slow down after it has hit the wall
        this.transform.Rotate(0, 0, 180);
    }

    

    private void liveDestroy()
    {
        GameObject.Destroy(this.gameObject);
    }
}
