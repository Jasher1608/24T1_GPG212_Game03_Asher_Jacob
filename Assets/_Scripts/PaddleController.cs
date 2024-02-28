using UnityEngine;

public class PaddleController : MonoBehaviour
{
    private float paddleHalfWidth;

    private bool isPlaying = false;

    public GameObject ball;

    void Start()
    {
        paddleHalfWidth = GetComponent<SpriteRenderer>().bounds.size.x / 2f;
        ball = GameObject.FindWithTag("Ball");
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    if (!isPlaying)
                    {
                        isPlaying = true;
                        ball.GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(-1f, 1f), 1).normalized * ball.GetComponent<BallController>().speed;
                    }
                    break;
                case TouchPhase.Moved:
                    float desiredX = Camera.main.ScreenToWorldPoint(touch.position).x;
                    float clampedX = Mathf.Clamp(desiredX, GetScreenLeftBound() + paddleHalfWidth, GetScreenRightBound() - paddleHalfWidth);
                    transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);
                    break;
            }
        }

        if (isPlaying && ball.transform.position.y < -6)
        {
            isPlaying = false;
            GameController.TakeLife();
            Destroy(ball);
            ball = Instantiate(ball);
            ball.GetComponent<CircleCollider2D>().enabled = true;
            ball.GetComponent<BallController>().enabled = true;
        }
    }

    float GetScreenLeftBound()
    {
        return Camera.main.ScreenToWorldPoint(Vector3.zero).x;
    }

    float GetScreenRightBound()
    {
        return Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x;
    }
}
