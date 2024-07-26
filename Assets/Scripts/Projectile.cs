using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public int damage = 10; // Projectile'ýn vereceði hasar
    public float speed = 5f; // Projectile'ýn hýzý
    public LayerMask enemyLayer; // Düþmanlarýn bulunduðu layer

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if ((other.gameObject.tag == "Weak Point"))
        {
            other.gameObject.GetComponent<EnemyMovement>().TakeDamage(damage);
            Destroy(this.gameObject);
        }
        else
            Destroy(gameObject, 2);

    }
}
