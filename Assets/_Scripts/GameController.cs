using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameController : MonoBehaviour
{
    private static int playerLives;
    private int playerPoints;

    [SerializeField] private TextMeshProUGUI pointsText;

    private void Start()
    {
        playerLives = 3;
        playerPoints = 0;
        pointsText.text = playerPoints.ToString();
    }

    private void Update()
    {
        WinLose();
    }

    public void AddPoints(int points)
    {
        playerPoints += points;
        pointsText.text = playerPoints.ToString();
    }

    public static void TakeLife()
    {
        playerLives--;
    }

    private void WinLose()
    {
        if (playerLives <= 0)
        {
            SceneManager.LoadScene("Level01");
        }
    }
}
