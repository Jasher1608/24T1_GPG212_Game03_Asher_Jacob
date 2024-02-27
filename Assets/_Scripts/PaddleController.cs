using UnityEngine;

public class PaddleController : MonoBehaviour
{
    private float paddleHalfWidth;

    void Start()
    {
        // Calculate half width of the paddle
        paddleHalfWidth = GetComponent<SpriteRenderer>().bounds.size.x / 2f;
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Moved:
                    // Calculate the desired position of the paddle based on touch position
                    float desiredX = Camera.main.ScreenToWorldPoint(touch.position).x;
                    // Adjust desired position by considering paddle's half width
                    float clampedX = Mathf.Clamp(desiredX, GetScreenLeftBound() + paddleHalfWidth, GetScreenRightBound() - paddleHalfWidth);
                    // Lerp the current position towards the desired position
                    transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);
                    break;
            }
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
