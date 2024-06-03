using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveDistance = 1f;
    public float jumpForce = 10f;

    private bool isGrounded = true;
    private Rigidbody2D rb;
    private Animator animator;
    private bool facingRight = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            MoveLeft();
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            MoveRight();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        if (rb.velocity == Vector2.zero)
        {
            StopMoving();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.contacts.Length > 0)
        {
            isGrounded = true;
            animator.SetBool("isJumping", false);
        }
    }

    public void MoveLeft()
    {
        rb.velocity = new Vector2(-moveDistance, rb.velocity.y);
        if (facingRight)
        {
            Flip();
        }
        animator.SetBool("isMoving", true);      
    }

    public void MoveRight()
    {
        rb.velocity = new Vector2(moveDistance, rb.velocity.y);
        if (!facingRight)
        {
            Flip();
        }
        animator.SetBool("isMoving", true);  
    }

    public void Jump()
    {
        if (isGrounded)
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            isGrounded = false;
            animator.SetBool("isJumping", true);
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    public void StopMoving()
    {
        print("stop");
        animator.SetBool("isMoving", false);
    }
}
