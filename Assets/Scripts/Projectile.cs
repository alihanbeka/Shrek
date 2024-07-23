using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Rigidbody2D projectileRb;
    public float speed;
    public float projectileLife;
    private float projectileCount;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        projectileCount = projectileLife;
        player = FindObjectOfType<PlayerCollisionController>().gameObject;

        if (player.transform.rotation.y == 0)
        {
            projectileRb.velocity = new Vector2(speed, 0);
        }
        else
        {
            projectileRb.velocity = new Vector2(-speed, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        projectileCount -= Time.deltaTime;
        if (projectileCount <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Weak Point")
        {
            Debug.Log("collided with enemy");
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }

        // Çarpýþan objeyi yok et

        // Mermiyi yok et
    }
}
