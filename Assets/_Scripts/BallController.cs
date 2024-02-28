using UnityEngine;

public class BallController : MonoBehaviour
{
    public float speed;

    private Rigidbody2D rb;

    private GameObject paddle;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        paddle = GameObject.FindWithTag("Paddle");
        InitializeBall();
    }

    void Update()
    {
        rb.velocity = rb.velocity.normalized * speed;
    }

    void InitializeBall()
    {
        transform.position = paddle.transform.position + new Vector3(0, 0.5f, 0);
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
