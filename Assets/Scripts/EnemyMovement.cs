using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform[] patrolPoints;
    public float moveSpeed;
    public int patrolDestination;
    public Transform playerTransform;
    public float chaseDistance;
    public int maxHealth = 100; // Düþmanýn maksimum caný
    private int currentHealth; // Düþmanýn mevcut caný
    private Animator _animator;
    public bool isChasing;
    public float Force;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        currentHealth = maxHealth; // Baþlangýçta caný maksimum seviyede ayarla
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage; // Hasarý mevcut candan düþ
        Debug.Log("Enemy took damage. Current health: " + currentHealth);
        TakenDamage();
        if (currentHealth <= 0)
        {
            Die(); // Can sýfýr veya daha azsa öl
        }
    }
    public void TakenDamage()
    {
        Debug.Log("Enemy taken damage");
        if (playerTransform.rotation.y >= 0)
        {
            transform.position += Force * Time.deltaTime * Vector3.right;
        }
        else {
            transform.position += Force * Time.deltaTime * Vector3.left;
        }
    }
    private void Die()
    {
        // Ölme animasyonunu baþlat
        _animator.SetTrigger("Die");
        // Düþmaný yok et
        Destroy(gameObject, 0.5f); // Yarým saniye sonra düþmaný yok et
    }

    public void Chasing()
    {
        if (isChasing)
        {
            if (transform.position.y > playerTransform.position.y)
            {
                transform.position += Vector3.down * moveSpeed * Time.deltaTime;
            }
            if (transform.position.x > playerTransform.position.x)
            {
                transform.localScale = new Vector3(1, 1, 1);
                transform.position += Vector3.left * moveSpeed * Time.deltaTime;
            }

            if (transform.position.y < playerTransform.position.y)
            {
                transform.position += Vector3.up * moveSpeed * Time.deltaTime;
            }
            if (transform.position.x < playerTransform.position.x)
            {
                transform.localScale = new Vector3(-1, 1, 1);
                transform.position += Vector3.right * moveSpeed * Time.deltaTime;
            }
        }
        else
        {
            if (Vector2.Distance(transform.position, playerTransform.position) < chaseDistance)
            {
                isChasing = true;
            }

            if (patrolPoints.Length > 0)
            {
                if (patrolDestination == 0 && patrolPoints.Length > 0)
                {
                    transform.position = Vector2.MoveTowards(transform.position, patrolPoints[0].position, moveSpeed * Time.deltaTime);
                    if (Vector2.Distance(transform.position, patrolPoints[0].position) < .2f)
                    {
                        transform.localScale = new Vector3(-1, 1, 1);
                        patrolDestination = 1;
                    }
                }
                else if (patrolDestination == 1 && patrolPoints.Length > 1)
                {
                    transform.position = Vector2.MoveTowards(transform.position, patrolPoints[1].position, moveSpeed * Time.deltaTime);
                    if (Vector2.Distance(transform.position, patrolPoints[1].position) < .2f)
                    {
                        transform.localScale = new Vector3(1, 1, 1);
                        patrolDestination = 0;
                    }
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        Chasing();
    }
}
