using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrekMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float moveSpeed = 5f;
    private Animator _animator;
    public GameObject projectilePrefab;
    public Transform launchPoint;
    public float shootTime;
    private float shootCounter;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        shootCounter = shootTime;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Shoot();
    }

    void Move()
    {
        // Input al ve hareket yönünü belirle
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        Vector2 moveDirection = new Vector2(moveX, moveY).normalized * moveSpeed;

        // Rigidbody hýzýný ayarla
        rb.velocity = moveDirection;

        // Animator parametrelerini ayarla
        _animator.SetBool("isWalk", moveDirection.magnitude > 0);

        // Karakter yönünü belirle
        if (moveX > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (moveX < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }

    void Shoot()
    {
        if (Input.GetButtonDown("Fire1") && shootCounter <= 0)
        {
            // Fýrlatma animasyonunu baþlat
            _animator.SetBool("isShooting", true);

            shootCounter = shootTime;

            // Fýrlatma animasyonunu kýsa bir süre sonra durdur
            StartCoroutine(StopShootingAnimation());
        }
        shootCounter -= Time.deltaTime;
    }
    public void SpawnProjectile()
    {
        Instantiate(projectilePrefab, launchPoint.position, launchPoint.rotation);
    }

    private IEnumerator StopShootingAnimation()
    {
        // Fýrlatma animasyonunun süresi kadar bekle
        yield return new WaitForSeconds(0.1f);
        _animator.SetBool("isShooting", false);
    }
}
