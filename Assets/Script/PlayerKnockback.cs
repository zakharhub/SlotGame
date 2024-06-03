using UnityEngine;

public class PlayerKnockback : MonoBehaviour
{
    public float knockbackForce = 10f;
    public float knockbackDuration = 0.5f;
    private Rigidbody2D rb;
    private bool isKnockedBack = false;
    private float knockbackEndTime;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (isKnockedBack && Time.time > knockbackEndTime)
        {
            isKnockedBack = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("KnockbackObject"))
        {
            Vector2 knockbackDirection = (transform.position - collision.transform.position).normalized;
            rb.AddForce(knockbackDirection * knockbackForce, ForceMode2D.Impulse);
            isKnockedBack = true;
            knockbackEndTime = Time.time + knockbackDuration;
        }
    }
}
