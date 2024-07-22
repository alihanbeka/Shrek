using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyArrow : MonoBehaviour
{
    public GameObject arrow;
    public Transform arrowPos;
    private GameObject player;
    public GameObject archer;

    private float timer;

    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    
    void Update()
    {
       

       
        float distance = Vector2.Distance(archer.transform.position, player.transform.position);
        Debug.Log("Distance: " + distance);

       
        if (distance < 10)
        {
            
            timer += Time.deltaTime;

            
            if (timer > 2)
            {
                timer = 0;
                shoot();
            }
        }
    }

    void shoot()
    {
        Instantiate(arrow, arrowPos.position, Quaternion.identity);
    }
}
