using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemysDamage : MonoBehaviour
{
    public int damage;
    public PlayerHealth playerHealth;
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerHealth.TakeDamage(damage);
        }
    }

}
