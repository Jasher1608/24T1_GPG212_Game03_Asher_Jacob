using UnityEngine;

public class BallController : MonoBehaviour
{
    public float speed;
    private int collisionCounter = 0;
    [SerializeField] private AudioClip hitSound;

    private Rigidbody2D rb;
    private AudioSource audioSource;

    private GameObject paddle;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        paddle = GameObject.FindWithTag("Paddle");
        InitializeBall();
        speed = 5f;
        collisionCounter = 0;
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
        audioSource.pitch = Random.Range(0.85f, 1.15f);
        audioSource.PlayOneShot(hitSound);

        collisionCounter++;
        if (collisionCounter > 10)
        {
            speed = 7f;
        }
        if (collisionCounter > 20)
        {
            speed = 8.5f;
        }
        if (collisionCounter > 30)
        {
            speed = 9.5f;
        }

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
