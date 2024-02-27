using UnityEngine;

public class EdgeColliderCreator : MonoBehaviour
{
    public GameObject topEdge;
    public GameObject leftEdge;
    public GameObject rightEdge;

    void Start()
    {
        // Get screen dimensions in world units
        float screenWidth = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x * 2;
        float screenHeight = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, 0)).y * 2;

        // Adjust size and position of edge colliders
        topEdge.transform.position = new Vector3(0, screenHeight / 2, 0);
        topEdge.GetComponent<BoxCollider2D>().size = new Vector2(screenWidth, 0.5f);

        leftEdge.transform.position = new Vector3(-screenWidth / 2, 0, 0);
        leftEdge.GetComponent<BoxCollider2D>().size = new Vector2(0.5f, screenHeight);

        rightEdge.transform.position = new Vector3(screenWidth / 2, 0, 0);
        rightEdge.GetComponent<BoxCollider2D>().size = new Vector2(0.5f, screenHeight);
    }
}
