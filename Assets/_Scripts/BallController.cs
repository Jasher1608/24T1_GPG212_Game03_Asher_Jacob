using UnityEngine;

public class BallController : MonoBehaviour
{
    public float speed;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        InitializeBall();
    }

    void Update()
    {
        
    }

    void InitializeBall()
    {
        Vector2 randomDirection = new Vector2(Random.Range(-1f, 1f), 1).normalized;
        rb.velocity = randomDirection * speed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Paddle"))
        {
            float hitPoint = collision.contacts[0].point.x;

            float paddleCenter = collision.transform.position.x;

            float relativePosition = (hitPoint - paddleCenter) / (collision.collider.bounds.size.x / 2);

            float reflectionAngle = relativePosition * -60f; // Maximum reflection angle 45 degrees

            Vector2 reflectionDirection = Quaternion.Euler(0, 0, reflectionAngle) * Vector2.up;

            rb.velocity = reflectionDirection.normalized * speed;
        }
    }
}
