using UnityEngine;

public class ShrekMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float moveSpeed = 5f;
    private Animator _animator;
    

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
       
        // Input al ve hareket y�n�n� belirle
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        Vector2 moveDirection = new Vector2(moveX, moveY).normalized * moveSpeed;

        // Rigidbody h�z�n� ayarla
        rb.velocity = moveDirection;

        // Animator parametrelerini ayarla
        _animator.SetBool("isWalk", moveDirection.magnitude > 0);

        // Karakter y�n�n� belirle
        if (moveX > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (moveX < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }
}
