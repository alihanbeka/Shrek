using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrekMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float moveSpeed = 5f;
    private Animator _animator;
    public GameObject projectilePrefab;
    public Transform launchPoint; // Fýrlatma noktasý
    public float shootTime;
    private float shootCounter;
    public float punchRange = 0.5f; // Yumruðun ulaþacaðý mesafe
    public int damage = 10; // Verilecek hasar
    public LayerMask enemyLayer; // Düþmanlarýn bulunduðu layer
    public bool isFacingLeft;
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
            isFacingLeft = false;
        }
        else if (moveX < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            isFacingLeft = true;

        }
    }

    void Shoot()
    {
        if (Input.GetButtonDown("Fire1") && shootCounter <= 0)
        {
            // Fýrlatma animasyonunu baþlat
            _animator.SetBool("isShooting", true);

            shootCounter = shootTime;

            // Fare konumunu al
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 shootDirection = (mousePosition - (Vector2)launchPoint.position).normalized;
            if (shootDirection.x < 0)
                transform.rotation = transform.rotation = Quaternion.Euler(0, 180, 0);
            else
                transform.rotation = transform.rotation = Quaternion.Euler(0, 0, 0);
            Vector3 adjustedLaunchPoint = launchPoint.position;

            // Projectile'ý spawn et

            StartCoroutine(SpawnProjectile(shootDirection, adjustedLaunchPoint));

            // Fýrlatma animasyonunu kýsa bir süre sonra durdur
            StartCoroutine(StopShootingAnimation());
        }

        if (Input.GetButtonDown("Fire2") && shootCounter <= 0)
        {
            // Yumruk atma animasyonunu baþlat
            _animator.SetBool("isPunching", true);
            Debug.Log("Punch set to true");

            shootCounter = shootTime;
            Punch();

            // Yumruk atma animasyonunu kýsa bir süre sonra durdur
            StartCoroutine(StopPunchingAnimation());
        }

        shootCounter -= Time.deltaTime;
    }

    IEnumerator SpawnProjectile(Vector2 direction, Vector3 launchPoint)
    {
        yield return new WaitForSeconds(0.1f);
        GameObject projectile = Instantiate(projectilePrefab, launchPoint, Quaternion.identity);
        projectile.GetComponent<Rigidbody2D>().velocity = direction * 12f; 


    }

    private IEnumerator StopShootingAnimation()
    {
        // Fýrlatma animasyonunun süresi kadar bekle
        yield return new WaitForSeconds(0f);
        _animator.SetBool("isShooting", false);
    }

    private IEnumerator StopPunchingAnimation()
    {
        // Yumruk atma animasyonunun süresi kadar bekle
        yield return new WaitForSeconds(0.1f);
        _animator.SetBool("isPunching", false);
    }

    void Punch()
    {

        if (transform.rotation.y >= 0)
        {
            transform.position += Vector3.right * punchRange * Time.deltaTime;
        }
        else
        {
            transform.position += Vector3.left * punchRange * Time.deltaTime;
        }

        // Bu noktada bulunan tüm collider'larý al
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(launchPoint.position, punchRange, enemyLayer);

        // Her collider'ý kontrol et ve hasar ver
        foreach (Collider2D enemy in hitEnemies)
        {
            EnemyMovement enemyMovement = enemy.GetComponent<EnemyMovement>();
            if (enemyMovement != null)
            {
                enemyMovement.TakeDamage(damage);
            }
        }
    }
}
