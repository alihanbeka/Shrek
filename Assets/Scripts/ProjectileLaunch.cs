using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLaunch : MonoBehaviour
{
   public GameObject projectilePrefab;
    public Transform launchPoint;
    public float shootTime;
    public float shootCounter;
   
    public void Shoot()
    {
        if (Input.GetButtonDown("Fire1") && shootCounter <= 0)
        {
            if (gameObject.transform.rotation.y > 0)
            {
                Instantiate(projectilePrefab, launchPoint.position, launchPoint.rotation);
                shootCounter = shootTime;
            }
            else
            {
                Instantiate(projectilePrefab, launchPoint.position, launchPoint.rotation);
                shootCounter = shootTime;
            }
        }
        shootCounter -= Time.deltaTime;


    }


    // Start is called before the first frame update
    void Start()
    {
        shootCounter = shootTime;
        
    }

    // Update is called once per frame
    void Update()
    {
        Shoot();
    }
}
